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
    /// Interaction logic for DistributingTask.xaml
    /// </summary>
    public partial class DistributingTask : Window
    {
        public DistributingTask()
        {
            InitializeComponent();
            List<string> lstName = new List<string>();           
            HRMSDAL.Employee emp = new HRMSDAL.Employee();
            List<HRMSDAL.Employee> lstemp = emp.GetAllEmployee();
            foreach (var na in lstemp)
            {
                lstName.Add(na.Id+"/"+na.Name+"/"+na.Serverddep);
            }
            lstWorker.ItemsSource = lstName;
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.mainwindow.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, EventArgs args)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void pubTask_Click(object sender, RoutedEventArgs e)
        {
            HRMSDAL.WorkPlan emp = new HRMSDAL.WorkPlan();
            string empid = lstWorker.SelectedValue.ToString();
            string empworkplan = txbWorkPlan.Text;
            string empworktime = txbWorkTime.Text;
            string empaddtion = txbAddition.Text;
            emp.InsertWorkPlan(empid, empworkplan, empworktime, empaddtion);
        }
    }
}
