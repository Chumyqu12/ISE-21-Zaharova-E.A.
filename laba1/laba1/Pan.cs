using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Pan
    {
        private Water water;
        private Potato[] potato;
        private Salt salt;
        private Onion[] onion;
        private Lapsha lapsha;
        private Chicken chicken;
        private Carrot[] carrot;

        public bool ReadyToGo { get { return Check(); } }

		public void Init() {
			water = new Water();
			potato = new Potato[10];
			carrot = new Carrot[10];
			onion = new Onion[10];

		}
        public void AddWater(Water w) {
            
                if (water == null)
                {
                    water  = w;
                    return;
                }
            
            
        }

        public void AddSalt(Salt s) {
            salt = s;
        }

        public void AddPotato(Potato[] p) {
           
                if (potato == null) {
                    potato = p;
                    return;
                }
            
        }

        public void AddCarrot(Carrot[] c) {
            
                if (carrot == null) {
                    carrot = c;
                    return;
                }
            
        }
        public void AddChicken(Chicken c) {
            chicken = c;
        }
        public void AddOnion(Onion[] o) {
            
                if (onion == null)
                {
                    onion = o;
                    return;
                }
            
        }
        public void AddLapsha(Lapsha t) {
           lapsha = t;
        }

        private bool Check() {
            if (water==null) {
                return false;
            }
            if (potato.Length == 0) {
                return false;
            }
            if (carrot.Length == 0) {
                return false;
            }
            if (chicken == null) {
                return false;
            }
            if (onion.Length == 0) {
                return false;
            }
            if (lapsha == null) {
                return false;
            }
            for (int i = 0; i < carrot.Length; ++i)
            {
                if (carrot[i] == null)
                {
                    return false;
                }
            }
            for (int i = 0; i < potato.Length; ++i)
            {
                if (potato[i] == null)
                {
                    return false;
                }
            }
            for (int i = 0; i < onion.Length; ++i)
            {
                if (onion[i] == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void Getheat() {
            if (!Check()) {
                return;
            }
            if (water!= null) {
                if (water.Temp < 100)
                {
                   
                        water.Getheat();
                    
                    bool flag = false;

                    switch (water.Temp)
                    {
                        case 20: flag = true; break;
                        case 40: flag = true; break;
                        case 60: flag = true; break;
                        case 80: flag = true; break;
                        case 100: flag = true; break;
                    }
                    if (flag)
                    {
                        for (int i = 0; i < potato.Length; ++i)
                        {
                            potato[i].GetHeat();
                        }
                        for (int i = 0; i < onion.Length; ++i)
                        {
                            onion[i].GetHeat();
                        }
                        for (int i = 0; i < carrot.Length; ++i)
                        {
                            carrot[i].GetHeat();
                        }
                      lapsha.GetHeat();
                        chicken.GetHeat();
                    }
                }
                else {
                    for (int i = 0; i < potato.Length; ++i)
                    {
                        potato[i].GetHeat();
                    }
                    for (int i = 0; i < onion.Length; ++i)
                    {
                        onion[i].GetHeat();
                    }
                    for (int i = 0; i < carrot.Length; ++i)
                    {
                        carrot[i].GetHeat();
                    }
                    lapsha.GetHeat();
                    chicken.GetHeat();

                }
            }
        }

        public bool Isready() {
            
                if (water.Temp<100)
                {
                    return false;
                }
            
            for (int i = 0; i < potato.Length; ++i)
            {
                if (potato[i].Has_ready < 10) {
                    return false;
                }
            }
            for (int i = 0; i < onion.Length; ++i)
            {
                if (onion[i].Has_ready < 10)
                {
                    return false;
                }
            }
            for (int i = 0; i < carrot.Length; ++i)
            {
                if (carrot[i].Has_ready < 10)
                {
                    return false;
                }
            }
            if (chicken.Has_ready < 10)
            {
                return false;
            }
            if (lapsha.Has_ready < 10)
            {
                return false;
            }
            return true;
            

        }

    }
}
