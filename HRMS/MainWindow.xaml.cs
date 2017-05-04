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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool btnAdministratorShowStatus = false;
        public bool btnMainNavStatus = false;
        public static MainWindow mainwindow;
        public static Frame mWindowContentFrame;
        public MainWindow()
        {
            InitializeComponent();
            mainwindow = mainWindow;
            mWindowContentFrame = mainWindowContentFrame;
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
        }
        //public void CloseWindow(object sender, RoutedEventArgs args)
        //{
        //    this.Close();
        //}

        private void btnAdministratorShow_Click(object sender, RoutedEventArgs e)
        {
            if (!btnAdministratorShowStatus)
            {
                AdministratorShowDialog.adminShowDialog.Visibility = Visibility.Visible;
                AdministratorShowDialog.adminShowDialog.Width = 280;
                MainNavDialog.mainnavDialog.Visibility = Visibility.Hidden;
            }
            else
            {
                AdministratorShowDialog.adminShowDialog.Width = 140;
                AdministratorShowDialog.adminShowDialog.Visibility = Visibility.Hidden;
            }
            btnAdministratorShowStatus = !btnAdministratorShowStatus;
        }
       
        private void btnMainNav_Click(object sender, RoutedEventArgs e)
        {
            if (!btnMainNavStatus)
            {
                MainNavDialog.mainnavDialog.Visibility = Visibility.Visible;
                MainNavDialog.mainnavDialog.Width = 280;
                AdministratorShowDialog.adminShowDialog.Width = 0;
                AdministratorShowDialog.adminShowDialog.Visibility = Visibility.Hidden;
            }
            else
            {
                MainNavDialog.mainnavDialog.Width = 140;
                AdministratorShowDialog.adminShowDialog.Width = 140;
                MainNavDialog.mainnavDialog.Visibility = Visibility.Hidden;
            }
            btnMainNavStatus = !btnMainNavStatus;
        }      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinsize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
