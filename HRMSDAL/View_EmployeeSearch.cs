using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class View_EmployeeSearch
    {
        private static readonly string conStr = @"Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        private string _id;
        private string _name;
        private string _phonenumber;
        private string _serveddep;
        private string _email;
        public View_EmployeeSearch(string id,string name,string phonenumber,string serveddep,string email)
        {
            _id = id;
            _name = name;
            _phonenumber = phonenumber;
            _serveddep = serveddep;
            _email = email;
        }
        public View_EmployeeSearch() { }
        #region
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string phonenumber
        {
            set { _phonenumber = value; }
            get { return _phonenumber; }
        }
        public string serveddep
        {
            set { _serveddep = value; }
            get { return _serveddep; }
        }
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        #endregion Addition
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<View_EmployeeSearch> GetEmployeeWhereLike(string id, string name,string serveddep)
        {
            List<View_EmployeeSearch> empSearch = new List<View_EmployeeSearch>();
            SqlConnection con = new SqlConnection(conStr);
            string cmdSelect = "SELECT id,name,phonenumber,serveddep,email FROM View_EmployeeSearch WHERE id LIKE '%"
                + id + "%' OR name LIKE '%" + name + "%' OR serveddep LIKE '%" + serveddep + "%'";
            SqlCommand cmd = new SqlCommand(cmdSelect, con);
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    empSearch.Add(new View_EmployeeSearch(
                            (string)reader["id"],
                            (string)reader["name"],
                            (string)reader["phonenumber"],
                            (string)reader["serveddep"],
                            (string)reader["email"]
                            ));
                }
            }
            return empSearch;
        }
    }
}
