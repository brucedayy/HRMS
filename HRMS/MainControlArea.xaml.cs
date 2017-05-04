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
    /// Interaction logic for MainControlArea.xaml
    /// </summary>
    public partial class MainControlArea : Page
    {
        public static MainControlArea maincontrolarea;
        public MainControlArea()
        {
            InitializeComponent();
            maincontrolarea = mainControlArea;                                    
        }
        private void showOrganizationChartDialog(object sender, MouseEventArgs args)
        {
            OrganizationChartDialog ocDialog = new OrganizationChartDialog();
            ocDialog.Show();
            //MainWindow.mainwindow.WindowState = WindowState.Minimized;
            //MainWindow.mainwindow.ShowInTaskbar = false;
            MainWindow.mainwindow.Visibility = Visibility.Hidden;
        }

        private void showEmployeeDetails(object sender, MouseEventArgs args)
        {
            EmployeeDetails empDetailsDialog = new EmployeeDetails();
            empDetailsDialog.Show();
            MainWindow.mainwindow.Visibility = Visibility.Hidden;
        }        

        private void showNewEmployeeDialog(object sender, MouseEventArgs args)
        {
            NewEmployeeDialog neDialog = new NewEmployeeDialog();
            neDialog.Show();
            //MainWindow.mainwindow.WindowState = WindowState.Minimized;
            //MainWindow.mainwindow.ShowInTaskbar = false;
            MainWindow.mainwindow.Visibility = Visibility.Hidden;
        }

        private void showDataStatisticsDialog(object sender, MouseEventArgs args)
        {
            DataStatistics dataStaWin = new DataStatistics();
            dataStaWin.Show();
            //MainWindow.mainwindow.WindowState = WindowState.Minimized;
            //MainWindow.mainwindow.ShowInTaskbar = false;
            MainWindow.mainwindow.Visibility = Visibility.Hidden;
        }

        private void PreSearch(object sender,EventArgs args)
        {                                                                       
        }

        private void btnEmployeeSearch_Click(object sender, RoutedEventArgs e)
        {
            //Canvas resultCanvas = new Canvas();
            //resultCanvas.Width = 300;
            //resultCanvas.Height = 300;
            //resultCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));             
            //SearchResultListItem searchItem1 = new SearchResultListItem();
            //SearchResultListItem searchItem2 = new SearchResultListItem();
            //SearchPage.searchResultSatckPanel.Children.Add(searchItem1);
            //SearchPage.searchResultSatckPanel.Children.Add(searchItem2);
            ////foreach (var tt in GetChildObjects<TextBlock>(searchItem1, typeof(TextBlock)))
            ////    MessageBox.Show(tt.Text);
            //List<TextBlock> test = GetChildObjects<TextBlock>(searchItem1, typeof(TextBlock));
            //MessageBox.Show(test[0].ToString());  
            //dynamic test1=searchItem1.FindName("usershortcut");
            //test1.Text = "11111111111";
            //dynamic test2 = searchItem2.FindName("usershortcut");
            //test2.Text = "22222222222";   
            MainWindow.mWindowContentFrame.Content = new SearchPage();
            string keystr = String.Empty;
            keystr = txbSearchInput.Text;
            List<HRMSDAL.View_EmployeeSearch> results = GetResult(keystr);
            int searchitemShowCount = 0;
            if (results.Count > 6)
                searchitemShowCount = 6;
            else
                searchitemShowCount = results.Count;
            SearchResultListItem[] searchItem = new SearchResultListItem[searchitemShowCount];
            for (int i = 0; i < searchitemShowCount; i++)
            {
                searchItem[i] = new SearchResultListItem();
                SearchPage.searchResultSatckPanel.Children.Add(searchItem[i]);
                dynamic txbUserShortcut = searchItem[i].FindName("usershortcut");
                txbUserShortcut.Text = results[i].id + "/" + results[i].name + "/" + results[i].serveddep + "/" + results[i].phonenumber;
            }
        }

        //得到搜索结果
        private List<HRMSDAL.View_EmployeeSearch> GetResult(string keystr)
        {
            List<HRMSDAL.View_EmployeeSearch> results = new List<HRMSDAL.View_EmployeeSearch>();
            HRMSDAL.View_EmployeeSearch viewemployee = new HRMSDAL.View_EmployeeSearch();
            results=viewemployee.GetEmployeeWhereLike(keystr, keystr, keystr);
            return results;
        }       

        /// <summary>
        /// 获取指定名称的子元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public List<T> GetChildObjects<T>(DependencyObject obj, Type typename)
            where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if(child is T&&(((T)child).GetType()==typename))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, typename));
            }
            return childList;
        }

        private void showDistributingTaskDialog(object sender, MouseEventArgs args)
        {
            DistributingTask dsTask = new DistributingTask();
            dsTask.Show();
            MainWindow.mainwindow.Visibility = Visibility.Hidden;
        }

        private void PreSearch(object sender, TextChangedEventArgs e)
        {
            //if (txbSearchInput.Text.Length == 1)
            //{
            //    string keystr = String.Empty;
            //    keystr = txbSearchInput.Text;
            //    List<HRMSDAL.View_EmployeeSearch> results = GetResult(keystr);
            //    SearchResultListItem[] searchItem = new SearchResultListItem[results.Count];
            //    for (int i = 0; i < results.Count; i++)
            //    {
            //        searchItem[i] = new SearchResultListItem();
            //        SearchPage.searchResultSatckPanel.Children.Add(searchItem[i]);
            //        dynamic txbUserShortcut = searchItem[i].FindName("usershortcut");
            //        txbUserShortcut.Text = results[i].id + "/" + results[i].name + "/" + results[i].serveddep + "/" + results[i].phonenumber;
            //    }
            //}
        }
    }
}
