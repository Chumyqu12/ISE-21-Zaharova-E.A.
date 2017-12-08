import java.awt.Color;
import java.awt.Graphics;

public class Parking {
	
	ClassArray<ITransport> parking;

    int countPlaces = 20;

    int placesSizeWidth = 210;
    int placesSizeHeight = 80;

    public Parking() {
    	parking = new ClassArray<ITransport>(countPlaces,null,ITransport.class);
    }

    public int PutkutiInparking(ITransport kut) {
        return parking.Add(kut);
    }
    public ITransport GetkutInparking(int ticket) {
        return parking.Get(ticket);
    }

    public void Draw(Graphics g) {
        DrawMarking(g);
        for (int i=0;i<countPlaces;i++) {
            ITransport kut = parking.Getkut(i);
            if (kut!=null) {
                kut.SetPosition(5 + i / 5 * placesSizeWidth + 5, i % 5 * placesSizeHeight + 15);
                kut.drawLodka(g);
            }
        }
       
    }

    public void DrawMarking(Graphics g) {
       
        g.setColor(Color.BLUE);

        g.fillRect(0, 0, (countPlaces / 5) * placesSizeWidth, 480);
        g.setColor(Color.black);
        for (int i=0;i<countPlaces/5;i++) {
            for (int j=0;j<6;++j) {
                g.drawLine(i * placesSizeWidth, j * placesSizeHeight, i * placesSizeWidth + 110, j * placesSizeHeight);
            }
            g.drawLine(i*placesSizeWidth,0,i*placesSizeWidth,400);
        }
    }
	

}