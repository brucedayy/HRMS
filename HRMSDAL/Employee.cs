using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class Employee
    {
        static string conStr = "Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        SqlConnection con = new SqlConnection(conStr);
        #region
        private int _uid;
        private string _id = "";     //工号id
        private string _name = "";   //姓名
        private string _sex = "";     //性别
        private string _nation = "";    //民族
        private string _polstatus = "";   //政治面貌
        private string _borndate = "";   //出生日期
        private string _bodyweight = "";   //体重
        private string _height = "";   //身高
        private string _nativeplace = "";  //籍贯
        private string _health = "";  //健康状况
        private string _maritalstatus = "";  //婚姻状况
        private string _bloodgroup = "";  //血型
        private string _idcard = "";  //身份证号
        private string _serveddep = "";  //所属部门   
        #endregion
        #region
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }   
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        public string Polstatus
        {
            set { _polstatus = value; }
            get { return _polstatus; }
        }
        public string Borndate
        {
            set { _borndate = value; }
            get { return _borndate; }
        }
        public string Bodyweight
        {
            set { _bodyweight = value; }
            get { return _bodyweight; }
        }
        public string Height
        {
            set { _height = value; }
            get { return _height; }
        }
        public string Nativeplace
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }
        public string Heath
        {
            set { _health = value; }
            get { return _health; }
        }
        public string Maritalstatus
        {
            set { _maritalstatus = value; }
            get { return _maritalstatus; }
        }
        public string Bloodgroup
        {
            set { _bloodgroup = value; }
            get { return _bloodgroup; }
        }
        public string Idcard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        public string Serverddep
        {
            set { _serveddep = value; }
            get { return _serveddep; }
        }
        #endregion
        public Employee(int uid,string id, string name, string sex, string nation, string polstatus, string borndate, string bodyweight, string height,
            string nativeplace, string health, string maritalstatus, string bloodgroup, string idcard, string serveddep)
        {
            _uid = uid;
            _id = id;
            _name = name;
            _sex = sex;
            _nation = nation;
            _polstatus = polstatus;
            _borndate = borndate;
            _bodyweight = bodyweight;
            _height = height;
            _nativeplace = nativeplace;
            _health = health;
            _maritalstatus = maritalstatus;
            _bloodgroup = bloodgroup;
            _idcard = idcard;
            _serveddep = serveddep;
        }
        public Employee() { }
        public bool InsertEmployee(string id, string name, string sex, string nation, string polstatus, string borndate, string bodyweight, string height,
            string nativeplace, string health, string maritalstatus, string bloodgroup, string idcard, string serveddep)
        {          
            con.Open();
            string cmdInsert = "INSERT INTO Employee(id,name,sex,nation,polstatus,borndate,bodyweight,height,nativeplace,"+
                "health,maritalstatus,bloodgroup,idcard,serveddep) VALUES('"
                +id+"','"+ name+"','" + sex+ "','" + nation + "','" + polstatus + "','" + 
                borndate + "','" + bodyweight + "','" + height + "','" + nativeplace + "','" + health +
                "','" + maritalstatus + "','" + bloodgroup + "','" + idcard + "','" +serveddep+"')";
            SqlCommand cmd = new SqlCommand(cmdInsert,con);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public List<Employee> GetAllEmployee()
        {
            string cmdSelect = "SELECT * FROM Employee";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdSelect, con);
            List<Employee> employees = new List<Employee>();
            using(con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader.GetInt32(0),reader.GetString(1),reader.GetString(2),
                        reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),
                        reader.GetString(7),reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), 
                        reader.GetString(12), reader.GetString(13),reader.GetString(14)
                        ));
                }
                con.Close();
                return employees;
            }
        }
              
    }
}
