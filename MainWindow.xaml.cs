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
