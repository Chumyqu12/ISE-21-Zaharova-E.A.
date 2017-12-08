import java.awt.Color;
import java.awt.Graphics;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;

public class Parking {

	ArrayList<ClassArray<ITransport>> parking;

	int countPlaces = 20;

	int placesSizeWidth = 210;
	int placesSizeHeight = 80;
	int currentLevel;

	public Parking(int countStages) {
		parking = new ArrayList<>();
		for (int i = 0; i < countStages; ++i) {
			parking.add(new ClassArray<ITransport>(countPlaces, null));
		}
	}

	public int getCurrentLevel() {
		return currentLevel;
	}

	public void setCurrentLevel(int currentLevel) {
		this.currentLevel = currentLevel;
	}

	public int PutkutiInparking(ITransport kut) {
		return parking.get(currentLevel).Add(kut);
	}

	public ITransport GetkutInparking(int ticket) {
		return parking.get(currentLevel).Get(ticket);

	}

	public void Draw(Graphics g) {
		DrawMarking(g);
		for (int i = 0; i < countPlaces; i++) {

			ITransport kut = parking.get(currentLevel).GetKut(i);
			if (kut != null) {
				kut.SetPosition(5 + i / 5 * placesSizeWidth + 5, i % 5 * placesSizeHeight + 15);
				kut.drawLodka(g);
			}
		}

	}

	public void DrawMarking(Graphics g) {

		g.setColor(Color.BLUE);

		g.fillRect(0, 0, (countPlaces / 5) * placesSizeWidth, 480);
		g.setColor(Color.black);
		for (int i = 0; i < countPlaces / 5; i++) {
			for (int j = 0; j < 6; ++j) {
				g.drawLine(i * placesSizeWidth, j * placesSizeHeight, i * placesSizeWidth + 110, j * placesSizeHeight);
			}
			g.drawLine(i * placesSizeWidth, 0, i * placesSizeWidth, 400);
		}
	}
	public void saveData(String fileName){
		 try {  
		        FileOutputStream fileStream = new FileOutputStream(fileName);  
		        ObjectOutputStream os = new ObjectOutputStream(fileStream);  
		        os.writeObject(parking);  
		    }  
		    catch (Exception e) {
		    	System.out.println("что-то пошло не так");
		    }
	}
	
	public void loadData(String fileName){
		try {
			FileInputStream inStream = new FileInputStream(fileName);
			ObjectInputStream inObject = new ObjectInputStream(inStream);
			parking = (	ArrayList<ClassArray<ITransport>> )inObject.readObject();
		} catch (Exception ex) {
			System.out.println("что-то пошло не так");
		}
	}

}
