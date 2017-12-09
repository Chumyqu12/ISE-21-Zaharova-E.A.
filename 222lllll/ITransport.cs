using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace _222lllll
{
	public interface ITransport
	{
		void moveLodka(Graphics g);
		void drawLodka(Graphics g);
		void SetPosition(int x, int y);
		void loadPassenger(int count);
		int getPassenger();
		void setMainColor(Color color);
        string getInfo();
	}
}
