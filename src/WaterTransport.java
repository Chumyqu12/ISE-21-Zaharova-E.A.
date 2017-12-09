import java.awt.Color;
import java.awt.Graphics;
import java.io.Serializable;

public abstract class WaterTransport implements ITransport, Serializable {
	  /**
	 * 
	 */
	private static final long serialVersionUID = 6840182876369128826L;
	protected int startPosX;
      protected int startPosY;
      protected int countPassengers;
      public  double Weigth;
      public  int vodoizmeshenie;
      public  int MaxSpeed;
      public int MaxCountPassengers;
      public int speed;
      public int getMaxSpeed() {
		return MaxSpeed;
	}
	protected void setMaxSpeed(int MaxSpeed) {
		this.MaxSpeed = MaxSpeed;
	}
	public abstract void SetColor(Color color);
	

      public Color ColorBody;
      public Color getColorBody() {
		return ColorBody;
	}
      protected void setColorBody(Color colorBody) {
		this.ColorBody = colorBody;
	}
  	protected void setvodoizmeshenie(int vodoizmeshenie) {
		this.vodoizmeshenie = vodoizmeshenie;
	}
  	protected void setWeight(int Weigth) {
		this.Weigth = Weigth;
	}

      protected void setMaxCountPassengers (int MaxCountPassengers ){
    	  this.MaxCountPassengers = MaxCountPassengers;  
      }
	  public abstract void moveLodka(Graphics g);
      public abstract void drawLodka(Graphics g);

      public void SetPosition(int x,int y) {
          startPosX = x;
          startPosY = y;
      }
      
      public void loadPassenger(int count) {
			if (countPassengers + count < MaxCountPassengers) {
				countPassengers += count;
			}
		}
		public int getPassenger() {
			int count = countPassengers;
			countPassengers = 0;
			return count;
		}

}
