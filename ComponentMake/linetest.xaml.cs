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
    /// Interaction logic for linetest.xaml
    /// </summary>
    public partial class linetest : Window
    {
        public linetest()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Line line = new Line();
            //line.X1 = 10;
            //line.Y1 = 10;
            //line.X2 = 100;
            //line.Y2 = 100;
            //line.Stroke = new SolidColorBrush(Colors.Blue);
            //line.StrokeThickness = 10;
            //canvas.Children.Add(line);
        }
        Line line = new Line();
        bool status = false;
        private void GetStartPos(object sender, MouseEventArgs args)
        {
            Point p = args.GetPosition((IInputElement)canvas);
            line.X1 = p.X;
            line.Y1 = p.Y;
            line.Stroke = new SolidColorBrush(Colors.Blue);
            line.StrokeThickness = 10;
            line.X2 = p.X;
            line.Y2 = p.Y;
            canvas.Children.Add(line);
            status = !status;      
        }
        private void PosMove(object sender, MouseEventArgs args)
        {
            if (status)
            {
                Point p = args.GetPosition((IInputElement)canvas);
                line.X2 = p.X;
                line.Y2 = p.Y;
            }
        }
        private void GetEndPos(object sender, MouseEventArgs args)
        {
            status = !status;
        }
    }
}
