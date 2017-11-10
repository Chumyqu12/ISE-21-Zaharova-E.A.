using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace _222lllll
{
	public abstract class WaterTransport : ITransport
	{
		public virtual int vodoizmeshenie { protected set; get; }
		protected float startPosX;
		protected float startPosY;
		protected int countPassengers;
		public virtual int MaxCountPassengers { protected set; get; }
		public virtual int MaxSpeed { protected set; get; }
		public Color ColorBody { protected set; get; }
        public Color DopColor { protected set; get; }
        public virtual double Weigth { protected set; get; }
		public abstract void moveLodka(Graphics g);
		public abstract void drawLodka(Graphics g);
		public void SetPosition (int x, int y) {
			startPosX = x;
			startPosY = y;
		}
		public void loadPassenger(int count) {
			if (countPassengers + count < MaxCountPassengers) {
				countPassengers += count;
			}
		}
		public int getPassenger() {
			int count = countPassengers;
			countPassengers = 0;
			return count;
		}
	}
}
