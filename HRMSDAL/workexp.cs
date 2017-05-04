using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class workexp
    {
        static string conStr = "Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        private int _uid;
        private string _id;
        private string _workexpone;
        private string _workexptwo;
        private string _workexpthree;
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
        public string WorkExpOne
        {
            set { _workexpone = value; }
            get { return _workexpone; }
        }
        public string WorkExpTwo
        {
            set { _workexptwo = value; }
            get { return _workexptwo; }
        }
        public string WorkExpThree
        {
            set { _workexpthree = value; }
            get { return _workexpthree; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="id"></param>
        /// <param name="workexpone"></param>
        /// <param name="workexptwo"></param>
        /// <param name="workexpthree"></param>
        public workexp(int uid, string id, string workexpone, string workexptwo, string workexpthree)
        {
            _uid = uid;
            _id = id;
            _workexpone = workexpone;
            _workexptwo = workexptwo;
            _workexpthree = workexpthree;
        }
        public workexp() { }
        public List<workexp> GetAllWorkExp()
        {
            List<workexp> wexp = new List<workexp>();
            SqlConnection con = new SqlConnection(conStr);
            string cmdSelect = "SELECT * FROM workexp";
            SqlCommand cmd = new SqlCommand(cmdSelect, con);
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wexp.Add(new workexp(
                        reader.GetInt32(0),reader.GetString(1),reader.GetString(2),
                        reader.GetString(3),reader.GetString(4)
                        ));
                }
                con.Close();
                return wexp;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workexpone"></param>
        /// <param name="workexptwo"></param>
        /// <param name="workexpthree"></param>
        /// <returns></returns>
        public bool InsertWorkExp(string id, string workexpone, string workexptwo, string workexpthree)
        {
            SqlConnection con = new SqlConnection(conStr);
            string cmdInsert = "INSERT INTO workexp(id,workexpone,workexptwo,workexpthree) VALUES('" + id +
                "','" + workexpone + "','" + workexptwo + "','" + workexpthree + "')";
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
