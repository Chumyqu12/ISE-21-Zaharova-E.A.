using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	class ParkingOverflowException:Exception
	{
		public ParkingOverflowException() :
			base("Нет свободных мест")
		{ }
	}
}
