import java.awt.Graphics;

public interface ITransport {
	void moveLodka(Graphics g);
	void drawLodka(Graphics g);
	void SetPosition(int x, int y);
	void loadPassenger(int count);
	int getPassenger();
	

}
