using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
    class ParkingAlreadyHaveException:Exception
    {
        public ParkingAlreadyHaveException() : base("Уже есть такой объект") { }
    }
}
