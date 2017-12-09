import java.awt.Graphics;
import java.awt.Panel;

public class ReturnP extends Panel {
	ITransport lodka;
	public ReturnP(ITransport lodka){
		this.lodka=lodka;
	}
	
	public void paint(Graphics g) {
		super.paint(g);
		kut(g,lodka);
	

	}
	public void kut(Graphics g,ITransport lodka){
		if (lodka!=null){
		lodka.drawLodka(g);
		}
	}
}
