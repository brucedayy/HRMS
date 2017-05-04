using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ComponentMake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region
        //private delegate void canvasMouseLeftDown(object sender, MouseEventArgs args);
        //public Canvas passcanvas;
        #endregion
        private string orgCreateClassify;
        private bool orgStatus = false;
        private void orgRootCreate(object sender, MouseEventArgs args)
        {
            #region
            //Thumb orgRoot = new Thumb(); 
            //passcanvas = orgRoot;
            //passcanvas.Width = orgRoot.Width;
            //passcanvas.Height = orgRoot.Height;
            //passcanvas.Background = orgRoot.Background;   
            #endregion
            this.Cursor = Cursors.Pen;
            orgRoot.Cursor = Cursors.Pen;
            orgCreateClassify = "orgroot";
            orgStatus = true;
        }
        private void orgNodeCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgNode.Cursor = Cursors.Pen;
            orgCreateClassify = "orgnode";
            orgStatus = true;
        }

        private void orgLeafCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgLeaf.Cursor = Cursors.Pen;
            orgCreateClassify = "orgleaf";
            orgStatus = true;
        }

        private void orgNameCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgName.Cursor = Cursors.Pen;
            orgCreateClassify = "orgname";
            orgStatus = true;
        }

        private void orgLineCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgLine.Cursor = Cursors.Pen;
            orgCreateClassify = "orgline";
            orgStatus = true;
        }

        //private void TxbNameMRDown(object sender,MouseEventArgs args)
        //{
        //    (sender as TextBox).IsEnabled = false;
        //    //MessageBox.Show("Ok");
        //}

        private void orgCanvasMouseLeftDown(object sender,MouseEventArgs args)
        {
            if (orgCreateClassify == "orgname")
            {
                TextBox txb = new TextBox();
                txb.Width = 100;
                txb.Height = 40;              
                txb.FontSize = 20;
                (sender as Canvas).Name = txb.Text;
                //txb.LostFocus += TxbNameLostFocus;
                //txb.MouseRightButtonDown += TxbNameMRDown;
                //txb.LostFocus += (object se, RoutedEventArgs e) => { txb.IsEnabled = false; };
                (sender as Canvas).Children.Add(txb);
                orgName.Cursor = Cursors.Hand;
                orgCreateClassify = "";
                return;
            }
            Point p = args.GetPosition((IInputElement)motherCanvas);
            (sender as Canvas).Margin = new Thickness(p.X- (sender as Canvas).Width/2, p.Y- (sender as Canvas).Height/2, 0, 0);
            (sender as Canvas).MouseMove += orgCanvasMove;
            orgCreateClassify = "";
        }               

        private void orgCanvasMouseLeftUp(object sender, MouseEventArgs args)
        {
            #region
            //Point p = args.GetPosition((IInputElement)motherCanvas);
            //(sender as Canvas).Margin = new Thickness(p.X - 112, p.Y - 25, 0, 0);
            #endregion
            (sender as Canvas).MouseMove -= orgCanvasMove;
        }

        private void orgCanvasMove(object sender,MouseEventArgs args)
        {
            Point p = args.GetPosition((IInputElement)motherCanvas);
            (sender as Canvas).Margin = new Thickness(p.X - (sender as Canvas).Width / 2, p.Y - (sender as Canvas).Height / 2, 0, 0);
        }

        private void orgCanvasDrop(object sender, DragEventArgs args)
        {
            Point p = args.GetPosition((IInputElement)sender);
            (sender as Canvas).Margin = new Thickness(p.X - (sender as Canvas).Width / 2, p.Y - (sender as Canvas).Height / 2, 0, 0);
        }

        private void canvasAdd(object sender, MouseEventArgs args)
        {
            Point p = args.GetPosition((IInputElement)sender);
            if (orgStatus)
            {
                switch (orgCreateClassify)
                {
                    case "orgroot":
                        Canvas rootCanvas = new Canvas();
                        rootCanvas.Width = 224;
                        rootCanvas.Height = 50;
                        rootCanvas.Margin = new Thickness(p.X - 112, p.Y - 25, 0, 0);
                        rootCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        motherCanvas.Children.Add(rootCanvas);
                        orgRoot.Cursor = Cursors.Hand;
                        #region
                        //rootCanvas.AllowDrop = true;
                        //rootCanvas.Drop += orgCanvasDrop;
                        #endregion
                        rootCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                        rootCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;                       
                        #region
                        //rootCanvas.MouseMove += orgCanvasMove;
                        //rootCanvas.MouseMove += orgCanvasMove;
                        #endregion
                        break;
                    case "orgnode":
                        Canvas nodeCanvas = new Canvas();
                        nodeCanvas.Width = 156;
                        nodeCanvas.Height = 94;
                        nodeCanvas.Margin = new Thickness(p.X - 78, p.Y - 47, 0, 0);
                        nodeCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        motherCanvas.Children.Add(nodeCanvas);
                        orgNode.Cursor = Cursors.Hand;
                        nodeCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                        nodeCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;
                        break;
                    case "orgleaf":
                        Canvas leafCanvas = new Canvas();
                        leafCanvas.Width = 48;
                        leafCanvas.Height = 124;
                        leafCanvas.Margin = new Thickness(p.X - 24, p.Y - 62, 0, 0);
                        leafCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        motherCanvas.Children.Add(leafCanvas);
                        orgLeaf.Cursor = Cursors.Hand;
                        leafCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                        leafCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;
                        break;
                    case "orgline":
                        Line line = new Line();
                        line.X1 = p.X;
                        line.Y1 = p.Y;
                        line.Stroke = new SolidColorBrush(Colors.Blue);
                        line.StrokeThickness = 5;
                        line.X2 = p.X + 100;
                        line.Y2 = p.Y + 100;
                        motherCanvas.Children.Add(line);
                        break;
                    default:
                        break;
                        #region
                        //Canvas rootCanvas = new Canvas();
                        //rootCanvas.Width = 224;
                        //rootCanvas.Height = 50;
                        //rootCanvas.Margin = new Thickness(p.X-112, p.Y-25, 0, 0);
                        //rootCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        //motherCanvas.Children.Add(rootCanvas);
                        //status++;
                        //orgRoot.Cursor = Cursors.Hand;
                        #endregion
                }
                orgStatus = !orgStatus;
                this.Cursor = Cursors.Arrow;
            }
            #region
            //passcanvas.Margin = new Thickness(100,100,0,0);
            //motherCanvas.Children.Add(passcanvas);
            //Canvas canvas = new Canvas();
            //canvas.Width = 100;
            //canvas.Height = 100;
            //canvas.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            //motherCanvas.Children.Add(canvas);
            //TextBlock txbX = new TextBlock();
            //txbX.Width = 100;
            //txbX.Height = 30;
            //txbX.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            //canvas.Children.Add(txbX);
            //Point p = args.GetPosition((IInputElement)sender);
            //txbX.Text = p.X + "--" + p.Y;
            #endregion            
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            List<string> test = new List<string>();
            foreach (dynamic child in motherCanvas.Children)
            {
                test.Add(child.Name);
            }
            MessageBox.Show(test.Count().ToString());
        }
    }
}
