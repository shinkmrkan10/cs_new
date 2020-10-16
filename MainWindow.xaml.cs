﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace cs_new
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //! "No"カラム名
        private static readonly string ColumnNo = "No";

        //! "Name"カラム名
        private static readonly string ColumnName = "Name";
		const int INF = 1000000;
		const int WIDTH = 9;
		const int HEIGHT =9;
 		const int NUMBER = WIDTH * HEIGHT ;
		const int UNDER = -3;
		const int OVER = 34;
		int numN, numNew, min;
		Random r1 = new System.Random();
        public ObservableCollection<Edge> DataE { get; set; }
        public ObservableCollection<Node> DataN { get; set; }
 

        public MainWindow()
        {
            InitializeComponent();
            Init();
/* 
    // 動的にバインディング
    Binding bi;
    bi = new Binding("LastName"); 
    bi.Mode = BindingMode.TwoWay;
    this.TextName.SetBinding(TextBox.TextProperty, bi);
    bi = new Binding("OutName"); 
    bi.Mode = BindingMode.TwoWay;
    this.ItemsSource.SetBinding(TextBox.TextProperty, bi);
*/     
    // コマンドも動的に設定
 //   this.BtnSave.Click += BtnSave_Click;
 
    // データコンテキストに設定
 //   this.DataContext = MyModel;
        }

private void Init()
        {
            // データグリッドの初期化処理を行います。
            InitDataGrid();
            InitListView();

            // データテーブルの生成処理を行います。
            var dataTable = CreateDataTable();

            // データグリッドにデータテーブルを設定します。
            dataGrid1.DataContext = dataTable;

 
            //NodeList nodeList = new NodeList();

            //EdgeList edgeList = new EdgeList();

            //Dijkstra dijkstra = new Dijkstra();
            //InitListView initListView = new InitListView();

            mylistViewNode.DataContext = DataN;
            listViewEdge.DataContext = DataE;
            listViewDijk.DataContext = DataN;


        }

        /**
         * @brief データグリッドの初期化を行います。
         */
        private void InitDataGrid()
        {
            // カラムを追加します。
            dataGrid1.Columns.Add(CreateDataGridTextColumn("番号", ColumnNo));
            dataGrid1.Columns.Add(CreateDataGridTextColumn("名前", ColumnName));
        }

        public void InitListView()
        {
            DataE = new ObservableCollection<Edge>();
            DataN = new ObservableCollection<Node>();
        // (データ入力:ノード)
			for(int j=0;j<HEIGHT;j++){
				for(int i=0;i<WIDTH;i++){
					int n = j * WIDTH + i;
					DataN.Add(new Node{num=n,x=i,y=j,cost=INF,used=false});
				}
			}
		// スタートノード(num==0)設定
		    foreach (Node d in DataN)
		    {
		      	if (d.num == 0){
		        d.cost = 0;
				}
		    }
        // (データ入力:エッジ)
			for(int j=0;j<HEIGHT;j++){
				for(int i=0;i<WIDTH-1;i++){
					int n = j * HEIGHT + i;
					int r = r1.Next(UNDER,OVER);
					if(r>0){
						DataE.Add(new Edge{from=n,to=n + 1,cost=1});
					}
					else if(r<0){
						DataE.Add(new Edge{to=n,from=n + 1,cost=1});
					}
				}
			}
			for(int i=0;i<WIDTH;i++){
				for(int j=0;j<HEIGHT-1;j++){
					int n = j * WIDTH + i;
					int r = r1.Next(UNDER,OVER);
					if(r>0){
						DataE.Add(new Edge{from= n,to=n + WIDTH,cost=1});
					}
					else if(r<0){
						DataE.Add(new Edge{to= n,from=n + WIDTH,cost=1});
					}
				}
			}
            //NodeList nodeList = new NodeList();
            ListView mylistViewNode = new ListView();
            GridView myGridView = new GridView();
            //myGridView.AllowsColumnReorder = true; 
            //myGridView.ColumnHeaderToolTip = "Employee Information";

            StackPanel myStackPanel = new StackPanel();
            mylistViewNode.DataContext = DataN;
            mylistViewNode.ItemsSource = DataN;
            mylistViewNode.View = myGridView;
           // mylistViewNode.ItemsSource = "{Binding <nodeList.DataN>}";
            //myStackPanel.Children.Add(mylistViewNode);
            //
            
            //var mylistViewNode = new ListView();
            //listViewNode.SetValue(Grid.RowProperty, 0);
            //listViewNode.SetValue(Grid.ColumnProperty, 0);
/* 
    // 動的にバインディング
    Binding bi;
    bi = new Binding("LastName"); 
    bi.Mode = BindingMode.TwoWay;
    this.TextName.SetBinding(TextBox.TextProperty, bi);
    bi = new Binding("OutName"); 
    bi.Mode = BindingMode.TwoWay;
    this.ItemsSource.SetBinding(TextBox.TextProperty, bi);
*/     
            myStackPanel.Children.Add(mylistViewNode);
            //var binding = new Binding("num") { Source = "{Binding}", Path = new PropertyPath(ListView.ViewProperty) };
            var binding = new Binding() { Source = DataN, Path = new PropertyPath(ListView.ViewProperty) };
            binding.Mode = BindingMode.TwoWay;
            //var nodeList = new NodeList();
            mylistViewNode.SetBinding(ListView.ViewProperty, binding);

            GridViewColumn gvc1 = new GridViewColumn(); 
            gvc1.DisplayMemberBinding = new Binding("num");
            gvc1.Header = "Number";
            gvc1.Width = 30;
            myGridView.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("x");
            gvc2.Header = "x";
            gvc2.Width = 30;
            myGridView.Columns.Add(gvc2);
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("y");
            gvc3.Header = "y";
            gvc3.Width = 30;
            myGridView.Columns.Add(gvc3);
            GridViewColumn gvc4 = new GridViewColumn();
            gvc4.DisplayMemberBinding = new Binding("cost");
            gvc4.Header = "cost";
            gvc4.Width = 60;
            myGridView.Columns.Add(gvc4);
            GridViewColumn gvc5 = new GridViewColumn();
            gvc5.DisplayMemberBinding = new Binding("used");
            gvc5.Header = "used";
            gvc5.Width = 40;
            myGridView.Columns.Add(gvc5);
          
            //mylistViewNode.DataContext = DataN;
        }
    

/*ListView myListView = new ListView();

GridView myGridView = new GridView();
myGridView.AllowsColumnReorder = true; 
myGridView.ColumnHeaderToolTip = "Employee Information";

GridViewColumn gvc1 = new GridViewColumn();
gvc1.DisplayMemberBinding = new Binding("FirstName");
gvc1.Header = "FirstName";
gvc1.Width = 100;
myGridView.Columns.Add(gvc1);*/
            //
    
//        <GridViewColumn Header="Number" DisplayMemberBinding="{Binding Path=num}" Width="30"/>
    

        /**
         * @brief データグリッドテキストカラムを生成します。
         * 
         * @param [in] header ヘッダーに表示する見出し
         * @param [in] path バインドするパス名
         * @return データグリッドテキストカラム
         */
        private DataGridTextColumn CreateDataGridTextColumn(string header, string path)
        {
            var dataGridTextColumn = new DataGridTextColumn()
                {
                    Header = header,
                    IsReadOnly = false,
                    FontSize = 12,
                    Binding = new Binding(path)
                };
            return dataGridTextColumn;
        }

        /**
         * @brief データテーブルを生成します。
         */
        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable("dataTable1");
            dataTable.Columns.Add(CreateDataColumn<int>(ColumnNo));
            dataTable.Columns.Add(CreateDataColumn<string>(ColumnName));

            // サンプルデータを追加します。
            for (int i = 0; i < 10; ++i)
            {
                var row = dataTable.NewRow();
                var no = i + 1;
                row[ColumnNo] = no;
                row[ColumnName] = "名前" + no.ToString();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /**
         * @brief データカラムを生成します。
         * 
         * @param [in] name カラム名
         * @return データカラム
         */
        private DataColumn CreateDataColumn<T>(string name)
        {
            var dataColumn = new DataColumn(name, typeof(T));
            return dataColumn;
        }
    }

/*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
*/
/*
            var label1 = new Label() { Content = "Slider:" };
            label1.SetValue(Grid.RowProperty, 0);
            label1.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(label1);
            var slider1 = new Slider();
            slider1.SetValue(Grid.RowProperty, 0);
            slider1.SetValue(Grid.ColumnProperty, 1);
            grid1.Children.Add(slider1);
*/

/*
            var listViewNode = new ListView();
            listViewNode.SetValue(Grid.RowProperty, 0);
            listViewNode.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(listViewNode);
            var binding = new Binding() { Source = "{Binding}", Path = new PropertyPath(ListView.ViewProperty) };
            var nodeList = new NodeList();
//            listViewNode.SetBinding(ListView.ViewProperty, binding);

            listViewNode.DataContext = nodeList.DataN;

*/
/*
        <ListView ItemsSource="{Binding}" x:Name="listViewNode" Margin="30,30,0,0">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Number" DisplayMemberBinding="{Binding Path=num}" Width="30"/>
                    <GridViewColumn Header="x" DisplayMemberBinding="{Binding Path=x}" Width="30"/>
                    <GridViewColumn Header="y" DisplayMemberBinding="{Binding Path=y}" Width="30"/>
                    <GridViewColumn Header="cost" DisplayMemberBinding="{Binding Path=cost}" Width="60"/>
                    <GridViewColumn Header="used" DisplayMemberBinding="{Binding Path=used}" Width="40"/>
                </GridView>
            </ListView.View>
</ListView>
*/
//            nodeList.SetValue(Grid.RowProperty, 0);
//            nodeList.SetValue(Grid.ColumnProperty, 1);
//            grid1.Children.Add(nodeList);


/*
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
*/
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

