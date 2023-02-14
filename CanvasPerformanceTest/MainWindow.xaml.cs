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

namespace CanvasPerformanceTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 備え付けコントロールで描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            Rectangle rect = new Rectangle();
            rect.Width = 350;
            rect.Height = 150;
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.StrokeThickness = 3;

            System.Windows.Controls.Canvas.SetLeft(rect,25);
            System.Windows.Controls.Canvas.SetTop(rect, 25);
            canvas.Children.Add(rect);

            Random random = new Random();
            List<Ellipse> ellipseList = new List<Ellipse>();
            for (int i = 0; i < 10000; i++)
            {
                Ellipse elipse = new Ellipse();
                elipse.Width = 2;
                elipse.Height = 2;
                elipse.Stroke = new SolidColorBrush(Colors.Black);
                elipse.StrokeThickness = 2;
                
                int x = random.Next(0, 350);
                int y = random.Next(0, 150);
                System.Windows.Controls.Canvas.SetLeft(elipse, 25 + x);
                System.Windows.Controls.Canvas.SetTop(elipse, 25 + y);
                ellipseList.Add(elipse);
            }

            DateTime startTime = DateTime.Now;

            foreach (var elipse in ellipseList)
            {
                canvas.Children.Add(elipse);
            }

            DateTime endTime = DateTime.Now;

            normalTime.Text = (endTime - startTime).TotalSeconds.ToString();
        }

        private void improveDraw_Click(object sender, RoutedEventArgs e)
        {
            inproveCanvas.Children.Clear();

            Rectangle rect = new Rectangle();
            rect.Width = 350;
            rect.Height = 150;
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.StrokeThickness = 3;

            CanvasPerformanceTest.Canvas.SetLocation(rect, new Point(0, 0));
            inproveCanvas.Children.Add(rect);

            Random random = new Random();
            List<Ellipse> ellipseList = new List<Ellipse>();
            for (int i = 0; i < 10000; i++)
            {
                Ellipse elipse = new Ellipse();
                elipse.Width = 2;
                elipse.Height = 2;
                elipse.Stroke = new SolidColorBrush(Colors.Black);
                elipse.StrokeThickness = 2;

                int x = random.Next(0, 350);
                int y = random.Next(0, 150);
                CanvasPerformanceTest.Canvas.SetLocation(elipse, new Point(x, y));
                ellipseList.Add(elipse);
            }

            DateTime startTime = DateTime.Now;

            foreach (var elipse in ellipseList)
            {
                inproveCanvas.Children.Add(elipse);
            }

            DateTime endTime = DateTime.Now;

            inprovelTime.Text = (endTime - startTime).TotalSeconds.ToString();
            inproveCanvas.BringIntoView();
        }
    }
}
