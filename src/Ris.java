import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.image.BufferedImage;

import javax.swing.JPanel;

public class Ris extends JPanel {
	ITransport transport;
	Parking parking;
	
	public Ris(Parking parking) {
		this.parking=parking;
	}

	public void paint(Graphics g) {
		super.paint(g);
		BufferedImage image=new BufferedImage(this.getWidth(),this.getHeight(),BufferedImage.TYPE_INT_RGB);
		Graphics2D gr=image.createGraphics();
		gr.setColor(Color.WHITE);
		gr.fillRect(0, 0, image.getWidth(), image.getHeight());
		
		parking.Draw(gr);
		
		g.drawImage(image, 0, 0, null);
	}
	
}
