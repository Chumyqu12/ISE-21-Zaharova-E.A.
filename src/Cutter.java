import java.awt.Color;
import java.awt.Graphics;

public class Cutter extends Lodka {
	private boolean motor;
    private  Color dopColor;
  
	public Cutter(int maxSpeed, int maxCountPassenger, double weigth, int vodoizmeshenie, Color color,
            boolean motor, Color dopColor) {
		super(maxSpeed, maxCountPassenger, weigth, vodoizmeshenie, color);
		this.motor = motor;
        this.dopColor = dopColor;
	}
	
	protected  void draw (Graphics g) {
		 super.draw(g);
		 if (motor) {
		 		g.setColor(dopColor);
		 		g.fillRect(startPosX + 22, startPosY + 20, 20, 20);

		      }
    
    
	}

}
