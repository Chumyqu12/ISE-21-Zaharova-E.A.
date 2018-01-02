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
		public void setDopColor(Color color)
		{
			dopColor = color;
		}
		public Cutter(int maxSpeed, int maxCountPassenger, double weigth, int vodoizmeshenie, Color color,
            bool motor, Color dopColor) :
			base(maxSpeed, maxCountPassenger, weigth, vodoizmeshenie, color)
		{
			this.motor = motor;
			this.dopColor = dopColor;
          
        }
        public Cutter(string info) : base(info) {
            string[] strs = info.Split(';');
            if (strs.Length == 7) {
                MaxSpeed = Convert.ToInt32(strs[0]);
                MaxCountPassengers = Convert.ToInt32(strs[1]);
                Weigth = Convert.ToInt32(strs[2]);
                vodoizmeshenie = Convert.ToInt32(strs[3]);
                ColorBody = Color.FromName(strs[4]);
                motor = Convert.ToBoolean(strs[5]);
               dopColor = Color.FromName(strs[6]);
            }
        }
        public override string getInfo()
        {
            return MaxSpeed+ ";"+ MaxCountPassengers+";"+ Weigth+";"+ vodoizmeshenie+";"+ ColorBody.Name+";"+
            motor+";"+ dopColor.Name;
            
        }

        public int CompareTo(Cutter other)
        {
            var res = (this is Lodka).CompareTo(other is Lodka);
            if (res != 0)
            {
                return res;
            }
            if (motor != other.motor)
            {
                return motor.CompareTo(other.motor);
            }
            if (dopColor != other.dopColor)
            {
                return dopColor.Name.CompareTo(other.dopColor.Name);
            }
            return 0;
        }

        public bool Equals(Cutter other)
        {
            var res = (this as Lodka).Equals(other as Lodka);
            if (!res)
            {
                return res;
            }
            if (motor != other.motor)
            {
                return false;
            }
           
            if (dopColor != other.dopColor)
            {
                return false;
            }
            
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
          Cutter locObj = obj as Cutter;
            if (locObj == null)
            {
                return false;
            }
            else
            {
                return Equals(locObj);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }




        protected override void draw(Graphics g)
        {
            base.draw(g);
            if (motor)
            {
                Brush brush = new SolidBrush(dopColor);
                g.FillRectangle(brush, startPosX + 22, startPosY + 20, 20, 20);
            }


        }
		
    }
}
