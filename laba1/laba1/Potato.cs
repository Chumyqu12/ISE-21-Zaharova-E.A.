using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Potato
    {
        private int has_ready = 0;

        public bool Have_scin{ set; get; }
        public int Has_ready { get { return has_ready; } }
		private int dirty = 10;
		public int Dirty { set { if (value > -1 && value < 11) dirty = value; } get { return dirty; } }


		public void GetHeat() {
            if (has_ready < 10) {
                has_ready++;
            }
        }
        
    }
}
