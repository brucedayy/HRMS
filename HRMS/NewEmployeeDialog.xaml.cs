using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HRMS
{
    /// <summary>
    /// Interaction logic for NewEmployeeDialog.xaml
    /// </summary>
    public partial class NewEmployeeDialog : Window
    {
        public NewEmployeeDialog()
        {
            InitializeComponent();
            lsbServeddep.ItemsSource = new HRMSDAL.Department().GetDepartmentList();
            if (lsbServeddep.Items.Count >0)
            {
                lsbServeddep.SelectedValue = lsbServeddep.Items[0];
            }
            lsbMaritalstatus.Items.Add("已婚");
            lsbMaritalstatus.Items.Add("未婚");
            lsbMaritalstatus.SelectedValue = "已婚";
            lsbBloodgroup.Items.Add("A");
            lsbBloodgroup.Items.Add("B");
            lsbBloodgroup.Items.Add("AB");
            lsbBloodgroup.Items.Add("O");
            lsbBloodgroup.SelectedValue = "A";
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow.mainwindow.WindowState = WindowState.Normal;
            //MainWindow.mainwindow.ShowInTaskbar = true;
            MainWindow.mainwindow.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, EventArgs args)
        {
            this.WindowState = WindowState.Minimized;
        }

        private static string sex;
        private void submitEmployee_Click(object sender, EventArgs args)
        {         
            //MessageBox.Show("OK");         
            string id = txbId.Text;     //工号i
            string name = txbName.Text;   //姓名
            //string sex = "";   //性别          
            string nation =txbNation.Text;    //民族
            string polstatus = txbPolstatus.Text;   //政治面貌
            string borndate = txbBorndate.Text;   //出生日期
            string bodyweight = txbBodyweight.Text;   //体重
            string height = txbHeight.Text;   //身高
            string nativeplace = txbNativeplace.Text;  //籍贯
            string health =txbHealth.Text;  //健康状况
            string maritalstatus = lsbMaritalstatus.SelectedValue.ToString();  //婚姻状况
            string bloodgroup = lsbBloodgroup.SelectedValue.ToString();  //血型
            string idcard = txbIdcard.Text;  //身份证号
            string serveddep = lsbServeddep.SelectedValue.ToString();  //所属部门  

            //MessageBox.Show(maritalstatus+"--"+bloodgroup);
            //maritalstatus = "男";
            //bloodgroup = "A";

            string phonenumber = txbPhoneNumber.Text;
            string email = txbEmail.Text;

            string studyexpone = txbstudyone.Text,
                studyexptwo = txbstudytwo.Text,
                studyexpthree = txbstudythree.Text;

            string workexpone = txbworkone.Text,
                workexptwo = txbworktwo.Text,
                workexpthree = txbworkthree.Text;

            HRMSDAL.Employee emp = new HRMSDAL.Employee();
            HRMSDAL.Contact contact = new HRMSDAL.Contact();
            HRMSDAL.studyexp sexp = new HRMSDAL.studyexp();
            HRMSDAL.workexp wexp = new HRMSDAL.workexp();

            if (emp.InsertEmployee(id, name, sex, nation, polstatus, borndate,
                bodyweight, height, nativeplace, health, maritalstatus, bloodgroup, idcard, serveddep) &&
                contact.InsertContact(id, phonenumber, email) && sexp.InsertStudyExp(id, studyexpone, studyexptwo, studyexpthree)
                && wexp.InsertWorkExp(id, workexpone, workexptwo, workexpthree))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Failure");
            }            
        }

        private void radioMale_Checked(object sender, RoutedEventArgs e)
        {
            sex = "男";
        }

        private void radioFemale_Checked(object sender, RoutedEventArgs e)
        {
            sex = "女";
        }
    }

}

