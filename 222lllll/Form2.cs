using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _222lllll
{
	public partial class Form2 : Form
	{
		ITransport lodka = null;
		public ITransport getlodka { get { return lodka; } }

		private event myDel eventAddLodka;

		public void AddEvent(myDel ev) {
			if (eventAddLodka == null)
			{
				eventAddLodka = new myDel(ev);
			}
			else {
				eventAddLodka += ev;
			}
		}

		public Form2()
		{
			InitializeComponent();
			panel2.MouseDown +=panelColor_MouseDown;
			panel3.MouseDown += panelColor_MouseDown;
			panel4.MouseDown += panelColor_MouseDown;
			panel5.MouseDown += panelColor_MouseDown;
			panel6.MouseDown += panelColor_MouseDown;
			panel7.MouseDown += panelColor_MouseDown;
			panel8.MouseDown += panelColor_MouseDown;
			panel9.MouseDown += panelColor_MouseDown;

			button2.Click += (object sender, EventArgs e) => { Close(); };
		}

		private void panelColor_MouseDown(object sender, MouseEventArgs e) {
			(sender as Control).DoDragDrop((sender as Control).BackColor,
				DragDropEffects.Move | DragDropEffects.Copy);
		}



		private void DrawLodka()
		{
			if (lodka != null)
			{
				Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
				Graphics gr = Graphics.FromImage(bmp);
				lodka.SetPosition(5, 5);
				lodka.drawLodka(gr);
				pictureBox1.Image = bmp;
			}
		}
		


		private void labelLodka_down(object sender, MouseEventArgs e)
		{
			label1.DoDragDrop(label1.Text, DragDropEffects.Move | DragDropEffects.Copy);
		}
		private void labelCutterdown(object sender, MouseEventArgs e)
		{
			label2.DoDragDrop(label2.Text, DragDropEffects.Move | DragDropEffects.Copy);
		}
		private void panelDrop(object sender, DragEventArgs e)
		{
			switch (e.Data.GetData(DataFormats.Text).ToString())
			{
				case "лодочка":
					lodka = new Lodka(100, 4, 500, 1000, Color.White);
					break;
				case "катер":
					lodka = new Cutter(100, 4, 500, 1000, Color.White,true, Color.Black);
					break;
			}
			DrawLodka();
		}
	
		private void panelEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void MainDrop(object sender, DragEventArgs e)
		{
			if (lodka != null) {
				lodka.setMainColor((Color)e.Data.GetData(typeof(Color)));
				DrawLodka();
			}
		}

		private void MainEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Color)))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}









		private void DopDrop(object sender, DragEventArgs e)
		{
			if (lodka != null)
			{
				if (lodka is Cutter)
                {
					(lodka as Cutter).setDopColor((Color)e.Data.GetData(typeof(Color)));
					DrawLodka();
				}
			}
		}
		

		private void button1_Click(object sender, EventArgs e)
		{
			if (eventAddLodka != null) {
				eventAddLodka(lodka);
			}
			Close();
		}

		
	}
}
