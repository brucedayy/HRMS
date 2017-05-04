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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public static StackPanel searchResultSatckPanel;
        public SearchPage()
        {
            InitializeComponent();
            searchResultSatckPanel = SearchResultSatckPanel;
        }
        //private void searchResultCanvas_MouseEnter(object sender, MouseEventArgs args)
        //{
        //    //searchResultCanvas.Background = new SolidColorBrush(Colors.Blue);
        //}
        //private void searchResultCanvas_MouseLeave(object sender, MouseEventArgs args)
        //{
        //    //searchResultCanvas.Background = new SolidColorBrush(Colors.AliceBlue);
        //}
    }
}
