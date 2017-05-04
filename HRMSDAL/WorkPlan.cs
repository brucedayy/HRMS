using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDAL
{
    public class WorkPlan
    {
        private static readonly string conStr = @"Data Source=daju;Initial Catalog=HRMS;Integrated Security=True";
        private int _uid;
        private string _id;
        private string _workplan;
        private string _worktime;
        private string _addtionnote;
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
        public string Workplan
        {
            set { _workplan = value; }
            get { return _workplan; }
        }
        public string Worktime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        public string AddtionNote
        {
            set { _addtionnote = value; }
            get { return _addtionnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="id"></param>
        /// <param name="workplan"></param>
        /// <param name="worktime"></param>
        public WorkPlan(int uid, string id, string workplan, string worktime,string addtionnote)
        {
            _uid = uid;
            _id = id;
            _workplan = workplan;
            _worktime = worktime;
            _addtionnote = addtionnote;
        }
        public WorkPlan() { }
        public bool InsertWorkPlan(string id,string workplan,string worktime,string addtionnote)
        {
            SqlConnection con = new SqlConnection(conStr);
            string cmdInsert = "INSERT INTO WorkPlan(id,workplan,worktime,addtionnote) VALUES('" + id + "','" + workplan + "','" + worktime + "','" + addtionnote + "')";
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
