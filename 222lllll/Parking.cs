using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	class Parking
	{
		List<ClassArray<ITransport>> parkingStages;
		int countPlaces = 20;
		int placeSizeWidth = 210;
		int placeSizeHeight = 80;
		int currentLevel;
		public int getCurrentLevel {get {return currentLevel; } }
		//СПИСОЧЕК!!!
		public Parking(int countStages) {
			parkingStages = new List<ClassArray<ITransport>>();
			for (int i = 0; i < countStages; i++)
				            {
				parkingStages.Add(new ClassArray<ITransport>(countPlaces, null));
				            }
		}
		public void LevelUp() {
			if (currentLevel + 1 < parkingStages.Count) {
				currentLevel++;
			}
		}
		public void LevelDown() {
			if (currentLevel > 0) {
				currentLevel--;
			}
		}
		public int PutCarInParking(ITransport car)
		{
			return parkingStages[currentLevel] + car;
		}
		public ITransport GetCarInParking(int ticket) {
			return parkingStages[currentLevel] - ticket;
		}
		public void Draw(Graphics g) {
			DrawMarking(g);
			for (int i = 0; i < countPlaces; i++)
			{
				var car = parkingStages[currentLevel][i];
				if (car != null)
				{
					car.SetPosition(5 + i / 5 * placeSizeWidth + 5, i % 5 * placeSizeHeight + 15);
					car.drawLodka(g);
				}
			}
			}
	
			private void DrawMarking(Graphics g) {
			Pen pen = new Pen(Color.Blue, 3);
			g.DrawString("L" + (currentLevel + 1), new Font("Arial", 30), new SolidBrush(Color.Blue),
				(countPlaces / 5) * placeSizeWidth - 70, 420);
			g.DrawRectangle(pen, 0, 0, (countPlaces / 5) * placeSizeWidth, 480);
			for (int i = 0; i < countPlaces / 5; i++) {
				for (int j = 0; j < 6; ++j) {
					g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight
						, i * placeSizeWidth + 110, j * placeSizeHeight) ;
					if (j < 5) {
						g.DrawString((i * 5 + j + 1).ToString(), new Font("Arial", 30),
							new SolidBrush(Color.Blue), i * placeSizeWidth + 30, j * placeSizeHeight + 20);
					}
				}
				g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 400);
			}
		}

		}
	}

