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

namespace ComponentMake
{
    /// <summary>
    /// Interaction logic for zoomablecanvas.xaml
    /// </summary>
    public partial class zoomablecanvas : Window
    {
        public zoomablecanvas()
        {
            InitializeComponent();
        }

        private void btnMinsize_Click(object sender, EventArgs args)
        {
            mainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMaximun_Click(object sender, EventArgs args)
        {
            mainWindow.WindowState = WindowState.Maximized;
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
        }
    }
}
