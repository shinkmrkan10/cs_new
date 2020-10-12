using System.Collections.ObjectModel;
 
public class NodeList {
		const int INF = 1000000;
		const int WIDTH = 6;
		const int HEIGHT =6;
        // バインディングの指定先プロパティ
        public ObservableCollection<Node> Data { get; set; }
 
        // コンストラクタ(データ入力)
        public NodeList() {
            Data = new ObservableCollection<Node>();
			for(int j=0;j<HEIGHT;j++){
				for(int i=0;i<WIDTH;i++){
					int n = j * WIDTH + i;
					Data.Add(new Node{num=n,x=i,y=j,cost=INF,used=false});
				}
			}
		// スタートノード(num==0)設定
		    foreach (Node d in Data)
		    {
		      	if (d.num == 0){
		        d.cost = 0;
//				d.used = true;
				}
		    }		
		}
    }   

