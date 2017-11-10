using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	public class Lodka : WaterTransport
	{

		public override int MaxSpeed
		{
			get
			{
				return base.MaxSpeed;
			}

			protected set
			{
				if (value > 0 && value < 300)
				{
					base.MaxSpeed = value;
				}
				else {
					base.MaxSpeed = 100;
				}
			}
		}

		public override int MaxCountPassengers
		{
			get
			{
				return base.MaxCountPassengers;
			}

			protected set
			{
				if (value > 0 && value < 10)
				{
					base.MaxCountPassengers = value;
				}
				else
				{
					base.MaxCountPassengers = 9;
				}
				
			}
		}

		public override double Weigth
		{
			get
			{
				return base.Weigth;
			}

			protected set
			{
				if (value > 1000 && value < 2000)
				{
					base.Weigth = value;
				}
				else
				{
					base.Weigth = 1500;
				}
			}
		}

		

		public override int vodoizmeshenie
		{
			get
			{
				return base.vodoizmeshenie;
			}

			protected set
			{
				if (value > 100 && value < 500)
				{
					base.vodoizmeshenie = value;
				}
				else
				{
					base.vodoizmeshenie = 1500;
				}
			}
		}


		


		public Lodka(int maxSpeed, int maxCountPassenger, double weigth, int vodoizmeshenie, Color color) {
			this.MaxSpeed = maxSpeed;
            this.vodoizmeshenie = vodoizmeshenie;
            this.MaxCountPassengers = maxCountPassenger;
           
			this.ColorBody = color;
			this.Weigth = weigth;
			this.countPassengers = 0;
			Random rand = new Random();
			startPosX = rand.Next(10, 60);
			startPosY = rand.Next(10, 60);
		}
		public override void moveLodka(Graphics g) {
			startPosX += (MaxSpeed * 50) / (float)Weigth / (countPassengers == 0 ? 1 : countPassengers);
			drawLodka(g);

		}
		public override void drawLodka(Graphics g) {
			draw(g);
		}
		protected virtual void draw(Graphics g) {
            
            Brush brush1 = new SolidBrush(ColorBody);
            g.FillEllipse(brush1, startPosX, startPosY, 90,  60);
            Brush brush2 = new SolidBrush(Color.Brown);
            g.FillEllipse(brush2, startPosX+10, startPosY+10,  70,  40);
            Brush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, startPosX + 47, startPosY+10 , 13, 40);
        }
	}
}
