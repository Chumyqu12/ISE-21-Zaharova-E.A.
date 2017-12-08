import java.awt.Graphics;

import javax.swing.JPanel;

public class Ris extends JPanel {
	ITransport transport;
	public Ris(ITransport transport){
		this.transport=transport;
	}
	
	public void paint(Graphics g) {
		super.paint(g);
		lodka(g,transport);

	}
	public void lodka(Graphics g,ITransport transport){
		if (transport!=null){
			transport.drawLodka(g);
		}
	}
	
	
}
