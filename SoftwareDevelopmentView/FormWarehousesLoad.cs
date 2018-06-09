using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormWarehousesLoad : Form
    {
     
        public FormWarehousesLoad()
        {
            InitializeComponent();
        }

        private void FormStocksLoad_Load(object sender, EventArgs e)
        {
            try
            {
                var response = APICustomer.GetRequest("api/Report/GetWarehousesLoad");
                               if (response.Result.IsSuccessStatusCode)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in APICustomer.GetElement<List<WarehousesLoadViewModel>>(response))
                    {
                        dataGridView.Rows.Add(new object[] { elem.WarehouseName, "", "" });
                        foreach (var listElem in elem.Parts)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.PartName, listElem.Number });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(new object[] { });
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

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var response = APICustomer.PostRequest("api/Report/SaveWarehousesLoad", new ReportBindingModel
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
    }
}
