using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormPutOnWarehouse : Form
    {

        public FormPutOnWarehouse()
        {
            InitializeComponent();
            
        }

        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                var responseC = APICustomer.GetRequest("api/Part/GetList");
                                if (responseC.Result.IsSuccessStatusCode)
                                    {
                    List < PartViewModel > list = APICustomer.GetElement<List<PartViewModel>>(responseC);
                                        if (list != null)
                                            {
                        comboBoxPart.DisplayMember = "PartName";
                        comboBoxPart.ValueMember = "Id";
                        comboBoxPart.DataSource = list;
                        comboBoxPart.SelectedItem = null;
                                            }
                                    }
                                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
                var responseS = APICustomer.GetRequest("api/Warehouse/GetList");
                                if (responseS.Result.IsSuccessStatusCode)
                {
                    List<WarehouseViewModel> list = APICustomer.GetElement<List<WarehouseViewModel>>(responseS);
                                        if (list != null)
                                            {
                        comboBoxStock.DisplayMember = "WarehouseName";
                        comboBoxStock.ValueMember = "Id";
                        comboBoxStock.DataSource = list;
                        comboBoxStock.SelectedItem = null;
                                            }
                                   }
                                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPart.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStock.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/General/PutPartOnWarehouse", new WarehousePartBindingModel
                {
                    PartId = Convert.ToInt32(comboBoxPart.SelectedValue),
                    WarehouseId = Convert.ToInt32(comboBoxStock.SelectedValue),
                    Number = Convert.ToInt32(textBoxCount.Text)
                });
                if (response.Result.IsSuccessStatusCode)
                                    {
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
