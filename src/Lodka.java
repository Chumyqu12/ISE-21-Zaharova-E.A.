import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Lodka extends WaterTransport {
	
	public  int getMaxSpeed()
    {
            return super.MaxSpeed;
            
    }
        
        protected void setMaxSpeed(int value) {
    		
    		 if (value > 100 && value < 300)
             {
    			 super.MaxSpeed = value;
             }
             else {
            	 super.MaxSpeed = 150;
             }
    	}

    
    	public  int getMaxCountPassengers()
        {
                return super.MaxCountPassengers;
                
        }
            
            protected void setMaxCountPassengers(int value) {
        		
        		 if (value > 0 && value < 10)
                 {
        			 super.MaxCountPassengers = value;
                 }
                 else {
                	 super.MaxCountPassengers = 9;
                 }
        	}

            public  int getvodoizmeshenie()
            {
                    return super.vodoizmeshenie;
                    
            }
                
                protected void setvodoizmeshenie(int value) {
            		
            		 if (value > 100 && value < 500)
                     {
            			 super.vodoizmeshenie = value;
                     }
                     else {
                    	 super.vodoizmeshenie = 1500;
                     }
            	}

                public  double getWeigth()
                {
                        return super.Weigth;
                        
                }
                    
                    protected void setWeigth(int value) {
                		
                		 if (value > 1000 && value < 2000)
                         {
                			 super.Weigth = value;
                         }
                         else {
                        	 super.Weigth = 1500;
                         }
                	}

    public Lodka(int maxSpeed, int maxCountPassenger, double weigth, int vodoizmeshenie, Color color) {
    	this.MaxSpeed = maxSpeed;
        this.vodoizmeshenie = vodoizmeshenie;
        this.MaxCountPassengers = maxCountPassenger;
		this.ColorBody = color;
		this.Weigth = weigth;
		this.countPassengers = 0;
        Random rand = new Random();
        startPosX = rand.nextInt(200);
        startPosX = rand.nextInt(200);
        

    }



    public  void moveLodka(Graphics g)
    {
        startPosX += MaxSpeed;
        drawLodka(g);
    }
    public  void drawLodka(Graphics g)
    {
        draw(g);
    }
    protected void draw(Graphics g)
    
    {
    	 g.setColor(ColorBody);
    	 g.fillOval(startPosX, startPosY, 90,  60);
         g.setColor(Color.ORANGE);
         g.fillOval(startPosX+10, startPosY+10,  70,  40);
         g.setColor(Color.BLACK);
         g.fillRect(startPosX + 47, startPosY+10 , 13, 40);
       
    }

	
	public void SetPosition(int x, int y) {
		// TODO Auto-generated method stub
		
	}

	

}
