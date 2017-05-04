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
    /// Interaction logic for SearchResultListItem.xaml
    /// </summary>
    public partial class SearchResultListItem : UserControl
    {
        public SearchResultListItem()
        {
            InitializeComponent();
        }
        private void searchResultCanvas_MouseEnter(object sender, MouseEventArgs args)
        {
            searchResultCanvas.Background = new SolidColorBrush(Colors.Beige);
        }
        private void searchResultCanvas_MouseLeave(object sender, MouseEventArgs args)
        {
            searchResultCanvas.Background = new SolidColorBrush(Colors.AliceBlue);
        }

        private void useredit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userphone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void useremail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
