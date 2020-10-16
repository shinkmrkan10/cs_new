using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
    public class Dijkstra
    {
		const int INF = 1000000;
		const int WIDTH = 9;
		const int HEIGHT =9;
 		const int NUMBER = WIDTH * HEIGHT ;
		const int UNDER = -3;
		const int OVER = 100;
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
					DataN.Add(new Node{num=n,x=i,y=j,cost=INF,used=false,from=n});
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
					int r;
					if(j>HEIGHT/3 && j<HEIGHT*2/3){
						r = r1.Next(-OVER,-UNDER);
					}
					else{
						r = r1.Next(UNDER,OVER);
					}
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
					int r;
					if(i>WIDTH/3 && i>WIDTH*2/3){
						r = r1.Next(-OVER,-UNDER);
					}
					else{
						r = r1.Next(UNDER,OVER);
					}
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
										dNew.from = dE.from;
									}
								}
							}
    		    	    }
				    }
       			}
	    	}
		}		
	}