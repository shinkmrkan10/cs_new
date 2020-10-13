using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
    public class Dijkstra
    {
  // スレッド間の排他ロックに利用するオブジェクト
//  private object _lockObject = new object();
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
 
        // コンストラクタ
        public Dijkstra() {
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
		// dijkstra	
	     	while(true){
        		min = INF;
		    	foreach (Node dN in DataN){
          			if(!dN.used && (min > dN.cost)){
            			min = dN.cost;
            			dN.used = true;
						numN = dN.num;
          			}
        		}
		        if(min == INF){
        			break;
      			}
				  
			    foreach (Node dN2 in DataN){
    			    if(dN2.cost == min){
        			    foreach(Edge dE in DataE){
							if(dE.from==numN){
								numNew=dE.to;
								foreach(Node dNew in DataN)
								{
									if(dNew.num==numNew && (dNew.cost > dE.cost + min) )
									{
										dNew.cost = dE.cost + min;
									}
								}
							}
    		    	    }
				    }
       			}
	    	}
		}		
			/*
  int x, y;
      while(true){
        min = INF;
        for(x = 0; x < NUMBER; x++){
          if(!used[x] && (min > cost[x])){
            min = cost[x];
            used[x] = true;
          }
        }
        if(min == INF){
          break;
        }
        for(y = 0; y < NUMBER; y++){
          if(cost[y] == min){
            for(x = 0; x < NUMBER; x++){
              if(cost[x] > dist[x,y] + cost[y]){
                cost[x] = dist[x,y] + cost[y];
              }
            }
          }
        }

		}
		*/
	}

