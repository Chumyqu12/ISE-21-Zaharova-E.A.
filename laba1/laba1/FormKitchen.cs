using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class FormKitchen : Form
    {
        private Salt salt;

        private WaterTap waterTap;

        private Knife knife;

        private Pan pan;

        private Stove stove;
        private Water water;
        private Potato[] potato;
        private Onion[] onion;
        private Lapsha lapsha;
        private Chicken chicken;
        private Carrot[] carrot;
        

        public FormKitchen()
        {
            InitializeComponent();
            waterTap = new WaterTap();
            knife = new Knife();
            pan = new Pan();
            stove = new Stove();
            waterTap = new WaterTap();


           

            
        }
        private void FormKitchen_Load(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ker_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (carrot == null)
            {
                MessageBox.Show("Моркови нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carrot.Length == 0)
            {
                MessageBox.Show("Моркови нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < carrot.Length; ++i)
            {
                knife.Clean_carrots(carrot[i]);
            }
            button12.Enabled = true;
            MessageBox.Show("Морковь  можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            knife.Cutting_c(chicken);
            MessageBox.Show("курицу можно добавлять в касттрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button10.Enabled = true;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            if (onion == null)
            {
                MessageBox.Show("лука нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (onion.Length == 0)
            {
                MessageBox.Show("лука нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < onion.Length; ++i)
            {
                knife.Clean_onion(onion[i]);
            }
            button11.Enabled = true;
            MessageBox.Show("лук  можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (potato == null)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (potato.Length == 0)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < potato.Length; i++)
            {
                knife.Clean_potato(potato[i]);
            }
            button9.Enabled = true;
            MessageBox.Show("Картошку  можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                waterTap.State = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                waterTap.State = true;
            }

        }

        private void numericUpDownPOP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (potato == null)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (potato.Length == 0)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < potato.Length; ++i)
            {
               
                if (potato[i].Have_scin)
                {
                    MessageBox.Show("Нужно почистить", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
                pan.AddPotato(potato);
            
        
            MessageBox.Show("Картошку положили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (carrot == null)
            {
                MessageBox.Show("Моркови нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carrot.Length == 0)
            {
                MessageBox.Show("Моркови нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < carrot.Length; ++i)
            {

                if (carrot[i].Have_scin)
                {
                    MessageBox.Show("Нужно почистить", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
                pan.AddCarrot(carrot);
      
            MessageBox.Show("Морковь положили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (onion == null)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (onion.Length == 0)
            {
                MessageBox.Show("Картошки нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < onion.Length; ++i)
            {

                if (onion[i].Have_scin)
                {
                    MessageBox.Show("Нужно почистить", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
                pan.AddOnion(onion);
            
           
            MessageBox.Show("Лук положили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (lapsha == null)
            {
                MessageBox.Show("лапши нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MessageBox.Show("лапша в кастрюле", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pan.AddLapsha(lapsha);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (chicken == null)
            {
                MessageBox.Show("курицы нет", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chicken.cutting)
            {
                MessageBox.Show("курицу нужно нарезать", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("курица в кастрюле", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pan.AddChicken(chicken);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!waterTap.State)
            {
                MessageBox.Show("Кран закрыт, как заливать?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           
                pan.AddWater(waterTap.GetWater());
            
            button13.Enabled = true;
            radioButton2.Checked = true;
            MessageBox.Show("Воду залили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            salt = new Salt();
            salt.Count = Convert.ToInt32(numericUpDown3.Value);
            if (salt.Count > 0)
            {
                pan.AddSalt(salt);
                MessageBox.Show("Соль добавили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Соли нет, что добавлять?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            stove.Pan = pan;
            button7.Enabled = true;
            MessageBox.Show("Кастрюля на плите", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!stove.pan1())
            {
                MessageBox.Show("У нас не все готово к варке!", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!stove.State)
            {
                MessageBox.Show("Варить собрались с божьей помощью или все же включим плиту?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stove.Cook();
            if (!stove.Pan.Isready())
            {
                radioButton3.Checked = false;
                MessageBox.Show("Сварилась!", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            stove.State = radioButton3.Checked;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            potato = new Potato[3];
            for (int i = 0; i < potato.Length; i++) {
                potato[i] = new Potato();
                
            }
            carrot = new Carrot[2];
            for (int i = 0; i < carrot.Length; i++) {
                carrot[i] = new Carrot();
            }
            onion = new Onion[2];
            for (int i = 0; i < onion.Length; i++)
            {
                onion[i] = new Onion();
            }
            chicken = new Chicken();
           lapsha = new Lapsha();
            

        }

		private void FormKitchen_Load_1(object sender, EventArgs e)
		{

		}

        private void button4_Click(object sender, EventArgs e)
        {
            if (!waterTap.State)
            {
                MessageBox.Show("Кран закрыт, как мыть?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            else {
				for (int i = 0; i < potato.Length; ++i)
				{
					potato[i] = new Potato();
				}
				for (int i = 0; i < potato.Length; ++i)
				{
					potato[i].Dirty = 0;
				}

			}


			MessageBox.Show("Картоху помыли", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button16_Click(object sender, EventArgs e)
		{
			if (!waterTap.State)
			{
				MessageBox.Show("Кран закрыт, как мыть?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			else
			{
				for (int i = 0; i < carrot.Length; ++i)
				{
					carrot[i] = new Carrot();
				}
				for (int i = 0; i < carrot.Length; ++i)
				{
					carrot[i].Dirty = 0;
				}
			}
			MessageBox.Show("Морковку помыли", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button17_Click(object sender, EventArgs e)
		{
			if (!waterTap.State)
			{
				MessageBox.Show("Кран закрыт, как мыть?", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			else
			{
				for (int i = 0; i < onion.Length; ++i)
				{
					onion[i] = new Onion();
				}
				for (int i = 0; i < onion.Length; ++i)
				{
					onion[i].Dirty = 0;
				}
			}
			MessageBox.Show("Лучок помыли", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
