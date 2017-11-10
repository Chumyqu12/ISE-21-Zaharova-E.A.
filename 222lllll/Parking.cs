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
		ClassArray<ITransport> parking;
		int countPlaces = 20;
		int placeSizeWidth = 210;
		int placeSizeHeight = 80;
		public Parking() {
			parking = new ClassArray<ITransport>(countPlaces, null);
		}
		public int PutCarInParking(ITransport car)
		{
			return parking + car;
		}
		public ITransport GetCarInParking(int ticket) {
			return parking - ticket;
		}
		public void Draw(Graphics g, int width, int height) {
			DrawMarking(g);
			for (int i = 0; i < countPlaces; i++)
			{
				var car = parking.getObject(i);
				if (car != null)
				{
					car.SetPosition(5 + i / 5 * placeSizeWidth + 5, i % 5 * placeSizeHeight + 15);
					car.drawLodka(g);
				}
			}
			}
			private void DrawMarking(Graphics g) {
			Pen pen = new Pen(Color.Blue, 3);
			g.DrawRectangle(pen, 0, 0, (countPlaces / 5) * placeSizeWidth, 480);
			for (int i = 0; i < countPlaces / 5; i++) {
				for (int j = 0; j < 6; ++j) {
					g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight
						, i * placeSizeWidth + 110, j * placeSizeHeight); ;
				}
				g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 400);
			}
		}

		}
	}

