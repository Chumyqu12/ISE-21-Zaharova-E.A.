using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	class Parking
	{
		List<ClassArray<ITransport>> parkingStages;
		int countPlaces = 20;
		int placeSizeWidth = 210;
		int placeSizeHeight = 80;
		int currentLevel;
		public int getCurrentLevel {get {return currentLevel; } }
		//СПИСОЧЕК!!!
		public Parking(int countStages) {
			parkingStages = new List<ClassArray<ITransport>>();
			for (int i = 0; i < countStages; i++)
				            {
				parkingStages.Add(new ClassArray<ITransport>(countPlaces, null));
				            }
		}
		public void LevelUp() {
			if (currentLevel + 1 < parkingStages.Count) {
				currentLevel++;
			}
		}
		public void LevelDown() {
			if (currentLevel > 0) {
				currentLevel--;
			}
		}
		public int PutCarInParking(ITransport car)
		{
			return parkingStages[currentLevel] + car;
		}
		public ITransport GetCarInParking(int ticket) {
			return parkingStages[currentLevel] - ticket;
		}
		public void Draw(Graphics g) {
			DrawMarking(g);
			for (int i = 0; i < countPlaces; i++)
			{
				var car = parkingStages[currentLevel][i];
				if (car != null)
				{
					car.SetPosition(5 + i / 5 * placeSizeWidth + 5, i % 5 * placeSizeHeight + 15);
					car.drawLodka(g);
				}
			}
			}
	
			private void DrawMarking(Graphics g) {
			Pen pen = new Pen(Color.Blue, 3);
			g.DrawString("L" + (currentLevel + 1), new Font("Arial", 30), new SolidBrush(Color.Blue),
				(countPlaces / 5) * placeSizeWidth - 70, 420);
			g.DrawRectangle(pen, 0, 0, (countPlaces / 5) * placeSizeWidth, 480);
			for (int i = 0; i < countPlaces / 5; i++) {
				for (int j = 0; j < 6; ++j) {
					g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight
						, i * placeSizeWidth + 110, j * placeSizeHeight) ;
					if (j < 5) {
						g.DrawString((i * 5 + j + 1).ToString(), new Font("Arial", 30),
							new SolidBrush(Color.Blue), i * placeSizeWidth + 30, j * placeSizeHeight + 20);
					}
				}
				g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 400);
			}
		}
        public bool SaveData(string filename) {
            if (File.Exists(filename)) {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                using (BufferedStream bs = new BufferedStream(fs)) {
                    byte[] info = new UTF8Encoding(true).GetBytes("CountLeveles:" +
                        parkingStages.Count + Environment.NewLine);
                    fs.Write(info, 0, info.Length);
                    foreach (var level in parkingStages) {
                        info = new UTF8Encoding(true).GetBytes("Level" + Environment.NewLine);
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < countPlaces; i++) {
                            var car = level[i];
                            if (car != null) {
                                if (car.GetType().Name == "Lodka") {
                                    info = new UTF8Encoding(true).GetBytes("Lodka:");
                                    fs.Write(info, 0, info.Length);
                                }
                                if (car.GetType().Name == "Cutter")
                                {
                                    info = new UTF8Encoding(true).GetBytes("Cutter:");
                                    fs.Write(info, 0, info.Length);
                                }
                                info = new UTF8Encoding(true).GetBytes(car.getInfo() + Environment.NewLine);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool LoadData(string filename) {
            if (!File.Exists(filename)) {
                return false;
            }
            using (FileStream fs = new FileStream(filename, FileMode.Open)) {
                string s = "";
                using (BufferedStream bs = new BufferedStream(fs)) {
                    byte [] b = new byte[fs.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (bs.Read(b, 0, b.Length) > 0) {
                        s += temp.GetString(b);
                    }
                }
                s = s.Replace("\r", "");
                var strs = s.Split('\n');
                if (strs[0].Contains("CountLeveles"))
                {
                    int count = Convert.ToInt32(strs[0].Split(':')[1]);
                    if (parkingStages != null)
                    {
                        parkingStages.Clear();
                    }
                    parkingStages = new List<ClassArray<ITransport>>(count);
                }
                else {
                    return false;
                }
                int counter = -1;
                for (int i = 1; i < strs.Length; ++i) {
                    if (strs[i] == "Level")
                    {
                        counter++;
                        parkingStages.Add(new ClassArray<ITransport>(countPlaces, null));
                    }
                    else if (strs[i].Split(':')[0] == "Lodka")
                    {
                        ITransport lodka = new Lodka(strs[i].Split(':')[1]);
                        int number = parkingStages[counter] + lodka;
                        if (number == -1)
                        {
                            return false;
                        }
                    }
                    else if (strs[i].Split(':')[0] == "Cutter") {
                        ITransport lodka = new Cutter(strs[i].Split(':')[1]);
                        int number = parkingStages[counter] + lodka;
                        if (number == -1) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }




		}
	}

