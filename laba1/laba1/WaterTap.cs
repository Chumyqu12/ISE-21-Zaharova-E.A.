using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class WaterTap
    {

		public bool State { set; get; }
		public void WashPotato(Potato p)
		{
			if (State)
			{
				p.Dirty = 0;

			}
		}

		public void WashCarrot(Carrot c)
		{
			if (State)
			{
				c.Dirty = 0;

			}
		}


		public void WashOnion(Onion o)
		{
			if (State)
			{
				o.Dirty = 0;

			}
		}
		public Water GetWater() {
            if (State)
            {
                return new Water();

            }
            else {
                return null;
            }
        }
    }
}
