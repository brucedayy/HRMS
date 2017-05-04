using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class Department
    {
        static string conStr = "Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conStr);
        public bool InsertDepartment(string depname)
        {
            con.Open();
            string cmdInsert = "INSERT INTO Department VALUES('" + depname + "')";
            SqlCommand cmd = new SqlCommand(cmdInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public List<string> GetDepartmentList()
        {
            con.Open();
            string cmdSelect = "SELECT depname FROM Department";
            SqlCommand cmd = new SqlCommand(cmdSelect,con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                result.Add(reader[0].ToString());
            }
            return result;
        }

    }
}
