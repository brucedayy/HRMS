using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class Contact
    {
        private static readonly string conStr = @"Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        private int _uid;
        private string _id;
        private string _phoneNumber;
        private string _email;
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string PhoneNumber
        {
            set { _phoneNumber = value; }
            get { return _phoneNumber; }
        }
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="id"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public Contact(int uid, string id, string phoneNumber, string email)
        {
            _uid = uid;
            _id = id;
            _phoneNumber = phoneNumber;
            _email = email;
        }
        public Contact() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetAllContact()
        {
            List<Contact> contact = new List<Contact>();
            SqlConnection con = new SqlConnection(conStr);
            string cmdSelect = "SELECT uid,id,phonenumber,email FROM Contact";
            SqlCommand cmd = new SqlCommand(cmdSelect, con);
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    contact.Add(new Contact(
                        reader.GetInt32(0),reader.GetString(1),
                        reader.GetString(2),reader.GetString(3)
                        ));
                }
            }
            return contact;
        }
        public bool InsertContact(string id,string phoneNumber,string email)
        {
            SqlConnection con = new SqlConnection(conStr);
            string cmdInsert = "INSERT INTO Contact(id,phonenumber,email) VALUES('" + id + "','" + phoneNumber + "','" + email + "')";
            SqlCommand cmd = new SqlCommand(cmdInsert, con);
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
    }
}
