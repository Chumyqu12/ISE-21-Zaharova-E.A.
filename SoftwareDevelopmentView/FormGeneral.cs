using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
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
                var response = APICustomer.GetRequest("api/General/GetList");
                                if (response.Result.IsSuccessStatusCode)
                {
                    List<OfferViewModel> list = APICustomer.GetElement<List<OfferViewModel>>(response);
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
                                else
               {
                    throw new Exception(APICustomer.GetError(response));
                }
            }
            catch (Exception ex)
            {
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
            LoadData();
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
                LoadData();
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    var response = APICustomer.PostRequest("api/General/FinalOffer", new OfferBindingModel
                     {
                        Id = id
                                            });
                                        if (response.Result.IsSuccessStatusCode)
                                            {
                        LoadData();
                                           }
                                        else
                                            {
                       throw new Exception(APICustomer.GetError(response));
                                            }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    var response = APICustomer.PostRequest("api/General/.CostOffer", new OfferBindingModel
                      {
                        Id = id
                                           });
                                       if (response.Result.IsSuccessStatusCode)
                                           {
                        LoadData();
                                           }
                                        else
                    {
                        throw new Exception(APICustomer.GetError(response));
                                           }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
				try
				{
                    var response = APICustomer.PostRequest("api/Report/SaveSoftwareCost", new ReportBindingModel
					{
						FileName = sfd.FileName
					});
                    if (response.Result.IsSuccessStatusCode)
                                            {
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        else
                                            {
                        throw new Exception(APICustomer.GetError(response));
                                            }
                }
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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

		
	}
}
