using System;
using System.Collections.ObjectModel;
    public class Dijkstra
    {
		const int NUMBER = 6 * 6 ;
		const int INF = 1000000;
        public ObservableCollection<Edge> DataE { get; set; }
        public ObservableCollection<Node> DataN { get; set; }
 
        // コンストラクタ(データ入力)
        public Dijkstra() {
            DataE = new ObservableCollection<Edge>();
            DataN = new ObservableCollection<Node>();
    		// コスト 1 のエッジ
			while(true){
				int min = INF;
				int numN;
			    foreach (Node dN in DataN)
			    {
					if(!dN.used && (min > dN.cost)){
						min = dN.cost;
						dN.used = true;
						numN = dN.num;
					}
			        if(min == INF){
        			  break;
      				}
					  

			        for(int y = 0; y < NUMBER; y++){
    			      	if(dN.cost == min){
        			    	foreach(Edge dE in DataE){
								if(dE.from==y){
            				  		if(dN.cost > dE.cost + min){
            	    					dN.cost = dE.cost + min;
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
	}

