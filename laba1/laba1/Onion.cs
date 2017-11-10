using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    // лук
    class Onion
    {
		private int dirty = 10;
		public int Dirty { set { if (value > -1 && value < 11) dirty = value; } get { return dirty; } }
		public bool Have_scin { set; get; }
        private int has_ready = 0;
        public int Has_ready { get { return has_ready; } }
        public void GetHeat()
        {
            if (has_ready < 10)
            {
                has_ready++;
            }
        }
    }
}
