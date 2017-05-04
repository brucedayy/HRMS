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
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Window
    {
        public EmployeeDetails()
        {
            InitializeComponent();
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

    }
}
