using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace cs_new
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            var label1 = new Label() { Content = "Slider:" };
            label1.SetValue(Grid.RowProperty, 0);
            label1.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(label1);
            var slider1 = new Slider();
            slider1.SetValue(Grid.RowProperty, 0);
            slider1.SetValue(Grid.ColumnProperty, 1);
            grid1.Children.Add(slider1);

            var label2 = new Label() { Content = "Input:" };
            label2.SetValue(Grid.RowProperty, 1);
            label2.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(label2);
            var tbox1 = new TextBox();
            tbox1.SetValue(Grid.RowProperty, 1);
            tbox1.SetValue(Grid.ColumnProperty, 1);
            var binding = new Binding() { Source = slider1, Path = new PropertyPath(Slider.ValueProperty) };
            tbox1.SetBinding(TextBox.TextProperty, binding);
            grid1.Children.Add(tbox1);

            var label3 = new Label() { Content = "Rectangle:" };
            label3.SetValue(Grid.RowProperty, 2);
            label3.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(label3);
            var rect1 = new Rectangle() { Height = 100.0 };
            rect1.SetValue(Grid.RowProperty, 2);
            rect1.SetValue(Grid.ColumnProperty, 1);
            var brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0.0, 0.0),
                EndPoint = new Point(1.0, 1.0)
            };
            brush.GradientStops.Add(new GradientStop() { Color = Colors.Yellow, Offset = 0.0 });
            brush.GradientStops.Add(new GradientStop() { Color = Colors.Red, Offset = 1.0 });
            rect1.Fill = brush;
            grid1.Children.Add(rect1);

            rect1.MouseLeftButtonDown += rect1_MouseLeftButtonDown;
        }

        void rect1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Title = e.GetPosition(grid1).ToString();
        }
    }
}


/*
namespace cs_new
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
 
            InitializeComponent();

            NodeList nodeList = new NodeList();
            listViewNode.DataContext = nodeList.DataN;

            EdgeList edgeList = new EdgeList();

            Dijkstra dijkstra = new Dijkstra();

            listViewEdge.DataContext = dijkstra.DataE;
            listViewDijk.DataContext = dijkstra.DataN;

 
        }
    }
}
*/

