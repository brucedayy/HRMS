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
    /// Interaction logic for DataStatistics.xaml
    /// </summary>
    public partial class DataStatistics : Window
    {
        public DataStatistics()
        {
            InitializeComponent();
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
        }
        private void quit_Click(object sender, EventArgs args)
        {
            this.Close();
            MainWindow.mainwindow.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, EventArgs args)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
