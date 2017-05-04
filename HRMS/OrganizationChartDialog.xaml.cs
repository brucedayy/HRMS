using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OrganizationChartDialog.xaml
    /// </summary>
    public partial class OrganizationChartDialog : Window
    {
        bool linestatus = false;
        public OrganizationChartDialog()
        {
            InitializeComponent();
        }
        public void DragWindow(object sender, MouseEventArgs args)
        {
            this.DragMove();
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
            linestatus = false;
        }

        private void orgLeafCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgLeaf.Cursor = Cursors.Pen;
            orgCreateClassify = "orgleaf";
            orgStatus = true;
            linestatus = false;
        }

        private void orgNameCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgName.Cursor = Cursors.Pen;
            orgCreateClassify = "orgname";
            orgStatus = true;
            linestatus = false;
        }

        private void orgLineCreate(object sender, MouseEventArgs args)
        {
            this.Cursor = Cursors.Pen;
            orgLine.Cursor = Cursors.Pen;
            orgCreateClassify = "orgline";
            orgStatus = true;
            linestatus = true;
        }

        //private void TxbNameMRDown(object sender,MouseEventArgs args)
        //{
        //    (sender as TextBox).IsEnabled = false;
        //    //MessageBox.Show("Ok");
        //}             
        private void orgCanvasMouseLeftDown(object sender, MouseEventArgs args)
        {
            if (orgCreateClassify == "orgname")
            {                
                TextBox txb = new TextBox();
                txb.Width = 100;
                txb.Height = 40;
                txb.FontSize = 20;
                //txb.LostFocus += TxbNameLostFocus;
                //txb.MouseRightButtonDown += TxbNameMRDown;
                //txb.LostFocus += (object se, RoutedEventArgs e) => { txb.IsEnabled = false; };                                
                (sender as Canvas).Children.Add(txb);
                orgName.Cursor = Cursors.Hand;
                orgCreateClassify = "";
                return;
            }
            Point p = args.GetPosition((IInputElement)motherCanvas);
            (sender as Canvas).Margin = new Thickness(p.X - (sender as Canvas).Width / 2, p.Y - (sender as Canvas).Height / 2, 0, 0);
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

        private void orgCanvasMouseRightDown(object sender, MouseEventArgs args)
        {
            (sender as Canvas).MouseMove -= orgCanvasMove;
        }

        private void orgCanvasMove(object sender, MouseEventArgs args)
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
                        //rootCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        rootCanvas.Background = new SolidColorBrush(Colors.Brown);
                        motherCanvas.Children.Add(rootCanvas);
                        orgRoot.Cursor = Cursors.Hand;
                        #region
                        //rootCanvas.AllowDrop = true;
                        //rootCanvas.Drop += orgCanvasDrop;
                        #endregion
                        if (!linestatus)
                        {
                            rootCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                            rootCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;
                            rootCanvas.MouseRightButtonDown += orgCanvasMouseRightDown;
                        }
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
                        //nodeCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        nodeCanvas.Background = new SolidColorBrush(Colors.Crimson);
                        motherCanvas.Children.Add(nodeCanvas);
                        orgNode.Cursor = Cursors.Hand;
                        if (!linestatus)
                        {
                            nodeCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                            nodeCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;
                            nodeCanvas.MouseRightButtonDown += orgCanvasMouseRightDown;
                        }
                        break;
                    case "orgleaf":
                        Canvas leafCanvas = new Canvas();
                        leafCanvas.Width = 48;
                        leafCanvas.Height = 124;
                        leafCanvas.Margin = new Thickness(p.X - 24, p.Y - 62, 0, 0);
                        //leafCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        leafCanvas.Background = new SolidColorBrush(Colors.Cyan);
                        motherCanvas.Children.Add(leafCanvas);
                        orgLeaf.Cursor = Cursors.Hand;
                        if (!linestatus)
                        {
                            leafCanvas.MouseLeftButtonDown += orgCanvasMouseLeftDown;
                            leafCanvas.MouseLeftButtonUp += orgCanvasMouseLeftUp;
                            leafCanvas.MouseRightButtonDown += orgCanvasMouseRightDown;
                        }
                        break;
                    case "orgline":
                        //if (linestatus)
                        //{
                        //Line line = new Line();
                        //line.X1 = p.X;
                        //line.Y1 = p.Y;
                        //line.Stroke = new SolidColorBrush(Colors.Blue);
                        //line.StrokeThickness = 5;
                        //line.X2 = p.X + 100;
                        //line.Y2 = p.Y + 100;
                        //motherCanvas.Children.Add(line);     
                        //if (linestatus)
                        //{
                        //motherCanvas.MouseLeftButtonDown += GetStartPos;
                        //motherCanvas.MouseMove += PosMove;
                        //motherCanvas.MouseLeftButtonUp += GetEndPos;
                        bool status = false;
                        Line line = new Line();
                        motherCanvas.Children.Add(line);
                        motherCanvas.MouseLeftButtonDown += (sder, ars) =>
                            {
                                this.Cursor = Cursors.Pen;
                                Point pos = ars.GetPosition((IInputElement)motherCanvas);
                                line.X1 = pos.X;
                                line.Y1 = pos.Y;
                                line.Stroke = new SolidColorBrush(Colors.Blue);
                                line.StrokeThickness = 10;                               
                                status = !status;
                            };
                        motherCanvas.MouseMove += (sder, ars) =>
                        {
                            if (!status)
                            {
                                this.Cursor = Cursors.Pen;
                                Point pos = ars.GetPosition((IInputElement)motherCanvas);
                                line.X2 = pos.X;
                                line.Y2 = pos.Y;
                            }
                        };
                        motherCanvas.MouseLeftButtonUp += (sder, ars) =>
                        {
                            status = !status;
                            this.Cursor = Cursors.Arrow;                              
                            };
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
            List<string> dep = new List<string>();
            foreach (dynamic child in motherCanvas.Children)
            {
                dep.Add(child.Children[0].Text);               
            }           
            foreach (string str in dep)
            {
                new HRMSDAL.Department().InsertDepartment(str);
            }
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow.mainwindow.WindowState = WindowState.Normal;
            //MainWindow.mainwindow.ShowInTaskbar = true;
            MainWindow.mainwindow.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, EventArgs args)
        {
            this.WindowState = WindowState.Minimized;
        }

      
        //private void GetStartPos(object sender, MouseEventArgs args)
        //{            
        //    Point p = args.GetPosition((IInputElement)motherCanvas);
        //    line.X1 = p.X+10;
        //    line.Y1 = p.Y+10;
        //    line.Stroke = new SolidColorBrush(Colors.Blue);
        //    line.StrokeThickness = 10;
        //    line.X2 = p.X;
        //    line.Y2 = p.Y;
        //    motherCanvas.Children.Add(line);
        //    status = !status;
        //}
        //private void PosMove(object sender, MouseEventArgs args)
        //{
        //    if (status)
        //    {
        //        Point p = args.GetPosition((IInputElement)motherCanvas);
        //        line.X2 = p.X;
        //        line.Y2 = p.Y;
        //    }
        //}
        //private void GetEndPos(object sender, MouseEventArgs args)
        //{
        //    status = !status;
        //}

        //protected override void OnMouseWheel(MouseWheelEventArgs e)
        //{
        //    var x = Math.Pow(2, e.Delta / 3.0 / Mouse.MouseWheelDeltaForOneLine);
        //    motherCanvas.Scale *= x;
        //}

        //private Point LastMousePosition;

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    var position = e.GetPosition(this);
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        motherCanvas.Offset -= position - LastMousePosition;
        //    }
        //    LastMousePosition = position;
        //}

    }
}
