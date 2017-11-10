using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Stove
    {
        private Pan pan;
        public bool State { set; get; }
        public Pan Pan { set { pan = value; }get { return pan; } }

        public bool pan1() {
            if (!pan.ReadyToGo)
            {
                return false;
            }
            else {
                return true;
            }
        }

        public void Cook()
        {
            
            if (State)
            {
                while (pan.Isready())
                {
                    pan.Getheat();
                }
            }

        }
    }
}
