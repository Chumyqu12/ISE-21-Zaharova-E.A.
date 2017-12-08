import java.awt.Color;
import java.awt.Graphics;
import java.io.Serializable;

public interface ITransport extends Serializable {
	void moveLodka(Graphics g);
	void drawLodka(Graphics g);
	void SetPosition(int x, int y);
	void loadPassenger(int count);
	int getPassenger();
	void SetColor(Color color);
	void SetdopColor(Color color);
	

}
