using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	public class Cutter : Lodka
	{
		private bool motor;
		private Color dopColor;
		public Cutter(int maxSpeed, int maxCountPassenger, double weigth, int vodoizmeshenie, Color color,
            bool motor, Color dopColor) :
			base(maxSpeed, maxCountPassenger, weigth, vodoizmeshenie, color)
		{
			this.motor = motor;
			this.dopColor = dopColor;
          
        }

        protected override void draw(Graphics g)
        {
            base.draw(g);
            if (motor)
            {
                Brush brush = new SolidBrush(Color.Beige);
                g.FillRectangle(brush, startPosX + 22, startPosY + 20, 20, 20);
            }


        }
    }
}
