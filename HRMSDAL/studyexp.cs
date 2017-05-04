using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class studyexp
    {
        private static readonly string conStr = @"Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        private int _uid;
        private string _id;
        private string _studyexpone;
        private string _studyexptwo;
        private string _studyexpthree;
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
        public string StudyExpOne
        {
            set { _studyexpone = value; }
            get { return _studyexpone; }
        }
        public string StudyExpTwo
        {
            set { _studyexptwo = value; }
            get { return _studyexptwo; }
        }
        public string StudyExpThree
        {
            set { _studyexpthree = value; }
            get { return _studyexpthree; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="id"></param>
        /// <param name="studyexpone"></param>
        /// <param name="studyexptwo"></param>
        /// <param name="studyexpthree"></param>
        public studyexp(int uid, string id, string studyexpone, string studyexptwo, string studyexpthree)
        {
            _uid = uid;
            _id = id;
            _studyexpone = studyexpone;
            _studyexptwo = studyexptwo;
            _studyexpthree = studyexpthree;
        }
        public studyexp() { }
        public List<studyexp> GetAllStudyExp()
        {
            List<studyexp> stuexp = new List<studyexp>();
            string cmdSelect = "SELECT * FROM studyexp";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand(cmdSelect, con);
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stuexp.Add(new studyexp(
                        reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetString(3),
                        reader.GetString(4)
                        ));
                }
                con.Close();
                return stuexp;
            }
        }
        public bool InsertStudyExp(string id, string studyexpone, string studyexptwo, string studyexpthree)
        {
            SqlConnection con = new SqlConnection(conStr);
            string cmdInsert = "INSERT INTO studyexp(id,studyexpone,studyexptwo,studyexpthree) VALUES('" + id +
                "','" + studyexpone + "','" + studyexptwo + "','" + studyexpthree + "')";
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
