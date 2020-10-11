using System.Collections.ObjectModel;
 
public class NodeList {
		const int INF = 1000000;
        // バインディングの指定先プロパティ
        public ObservableCollection<Node> Data { get; set; }
 
        // コンストラクタ(データ入力)
        public NodeList() {
            Data = new ObservableCollection<Node>{
//				for(int x=0;x<2;x++){
//					for(int y=0;y<2;y++){
//						int n = x * 2 + y;
					new Node{Node_num=0,Node_x=0,Node_y=0,Node_from=INF,Node_cost=INF}
					,new Node{Node_num=1,Node_x=0,Node_y=1,Node_from=INF,Node_cost=INF}
					,new Node{Node_num=2,Node_x=1,Node_y=0,Node_from=INF,Node_cost=INF}
					,new Node{}
//					}
//				}
			};
		
		}
    }   

