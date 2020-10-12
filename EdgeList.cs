using System.Collections.ObjectModel;
 
public class EdgeList {
		const int INF = 1000000;
		const int WIDTH = 6;
		const int HEIGHT =6;
        // バインディングの指定先プロパティ
        public ObservableCollection<Edge> Data { get; set; }
 
        // コンストラクタ(データ入力)
        public EdgeList() {
            Data = new ObservableCollection<Edge>();
			for(int j=0;j<HEIGHT;j++){
				for(int i=0;i<WIDTH;i++){
					Data.Add(new Edge{from=j,to=i,cost=INF});
				}
			}
			
		// 自身へのコスト(cost=0)設定
		    foreach (Edge d in Data)
		    {
		      	if (d.from == d.to){
		        d.cost = 0;
				}
		    }		
		
		}
    }   

