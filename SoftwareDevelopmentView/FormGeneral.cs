﻿using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormGeneral : Form
    {
     
		public FormGeneral()
        {
            InitializeComponent();
           
		}

        private void LoadData()
        {
            try
            {
                List<OfferViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<OfferViewModel>>("api/General/GetList")).Result;
                                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                                    {
                    ex = ex.InnerException;
                                    }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomers();
            form.ShowDialog();
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormParts();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormSoftwares();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormWarehouses();
            form.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDevelopers();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPutOnWarehouse();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOffer ();
            form.ShowDialog();
           
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormTakeOfferInWork
                {
                    Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value)
                                    };
                form.ShowDialog();
                
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                Task task = Task.Run(() => APICustomer.PostRequestData("api/General/FinalOffer", new OfferBindingModel
                {
                    Id = id
                }));
                
                task.ContinueWith((prevTask) => MessageBox.Show("Статус заказа изменен. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
                
                task.ContinueWith((prevTask) =>
                                {
                    var ex = (Exception)prevTask.Exception;
                                        while (ex.InnerException != null)
                    {
                                        ex = ex.InnerException;
                                    }
            
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }, TaskContinuationOptions.OnlyOnFaulted);
            }
            
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            Task task = Task.Run(() => APICustomer.PostRequestData("api/General/CostOffer", new OfferBindingModel
                {
                Id = id
                }));
            
            task.ContinueWith((prevTask) => MessageBox.Show("Статус заказа изменен. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
            TaskContinuationOptions.OnlyOnRanToCompletion);
            
            task.ContinueWith((prevTask) =>
                {
                var ex = (Exception)prevTask.Exception;
                                    while (ex.InnerException != null)
                {
                        ex = ex.InnerException;
                    }
                
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }, TaskContinuationOptions.OnlyOnFaulted);
        }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
		

		private void прайсИзделийToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = "doc|*.doc|docx|*.docx"
			};
			if (sfd.ShowDialog() == DialogResult.OK)
			{
            string fileName = sfd.FileName;
            Task task = Task.Run(() => APICustomer.PostRequestData("api/Report/SaveSoftwareCost", new ReportBindingModel
                {
                FileName = fileName
                }));
            
            task.ContinueWith((prevTask) => MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
            TaskContinuationOptions.OnlyOnRanToCompletion);
            
            task.ContinueWith((prevTask) =>
                {
                var ex = (Exception)prevTask.Exception;
                                    while (ex.InnerException != null)
                {
                        ex = ex.InnerException;
                    }
                
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}, TaskContinuationOptions.OnlyOnFaulted);
			}
		}

		private void загруженностьСкладовToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
            var form = new FormWarehousesLoad();
            form.ShowDialog();
		}

		private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
		{
            var form = new FormCustomerOffers();
            form.ShowDialog();
		}

        private void письмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMails();
            form.ShowDialog();
        }
    }
}
