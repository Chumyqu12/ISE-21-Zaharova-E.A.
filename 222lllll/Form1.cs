using NLog;
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
    public partial class Form1 : Form
    {

        Parking parking;
        Form2 form;
        private Logger log;

        public Form1()
        {


            InitializeComponent();
            log = LogManager.GetCurrentClassLogger();
            parking = new Parking(5);

            for (int i = 1; i < 6; i++)
            {
                listBox1.Items.Add("Level" + i);
            }
            listBox1.SelectedIndex = parking.getCurrentLevel;
            Draw();

        }

        private void Draw()
        {
            if (listBox1.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking.Draw(gr);
                pictureBox1.Image = bmp;
            }
        }





        private void button1_Click(object sender, EventArgs e)//лодка
        {

            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var car = new Lodka(100, 4, 1000, 130, dialog.Color);
                int place = parking.PutCarInParking(car);
                Draw();
                MessageBox.Show("Вашеместо: " + place);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var car = new Cutter(100, 4, 1000, 130, dialog.Color, true, dialogDop.Color);
                    int place = parking.PutCarInParking(car);
                    Draw();
                    MessageBox.Show("Вашеместо: " + place);
                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                string level = listBox1.Items[listBox1.SelectedIndex].ToString();

                if (maskedTextBox1.Text != "")
                {
                    try
                    {
                        var car = parking.GetCarInParking(Convert.ToInt32(maskedTextBox1.Text));

                        Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        car.SetPosition(5, 5);
                        car.drawLodka(gr);
                        pictureBox2.Image = bmp;
                        Draw();
                        log.Info("Забрали с места: " + Convert.ToInt32(maskedTextBox1.Text));
                    }
                    catch (ParkingIndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message, "Неверный номер",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Общая ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Down
        private void button3_Click(object sender, EventArgs e)
        {
            parking.LevelDown();
            listBox1.SelectedIndex = parking.getCurrentLevel;
            log.Info("Переход на уровень ниже, текущий уровень :" + parking.getCurrentLevel);
            Draw();
        }
        //Up
        private void button4_Click(object sender, EventArgs e)
        {
            parking.LevelUp();
            listBox1.SelectedIndex = parking.getCurrentLevel;
            log.Info("Переход на уровень выше Текущий уровень: " + parking.getCurrentLevel);
            Draw();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form = new Form2();
            form.AddEvent(AddLodka);
            form.ShowDialog();
        }

        private void AddLodka(ITransport lodka)
        {
            if (lodka != null)
            {
                try
                {
                    int place = parking.PutCarInParking(lodka);
                    Draw();
                    log.Info("Добавление на место: " + place);
                    MessageBox.Show("Ваше место: " + place);
                }
                catch (ParkingOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка переполнения",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ParkingAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Already have exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Общая ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (parking.SaveData(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Norm save", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO SAVE", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (parking.LoadData(openFileDialog1.FileName))
                {
                    MessageBox.Show("3@GrY}|{EH0", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO 3@GrY}|{EH0", "",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            parking.Sort();
            Draw();
            log.Info("Сортировка уровня " + parking.getCurrentLevel);
        }
    }
}

