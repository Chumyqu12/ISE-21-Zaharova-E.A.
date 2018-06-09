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
    public partial class FormTakeOfferInWork : Form
    {

        public int Id { set { id = value; } }


        private int? id;

        public FormTakeOfferInWork()
        {
            InitializeComponent();
        }

        private void FormTakeOrderInWork_Load(object sender, EventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указан заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                var response = APICustomer.GetRequest("api/Developer/GetList");
                               if (response.Result.IsSuccessStatusCode)
                                    {
                    List <DeveloperViewModel> list = APICustomer.GetElement<List<DeveloperViewModel>>(response);
                                        if (list != null)
                                           {
                        comboBoxImplementer.DisplayMember = "DeveloperName";
                        comboBoxImplementer.ValueMember = "Id";
                        comboBoxImplementer.DataSource = list;
                        comboBoxImplementer.SelectedItem = null;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxImplementer.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/General/TakeOfferInWork", new OfferBindingModel
                {
                    Id = id.Value,
                    DeveloperId = Convert.ToInt32(comboBoxImplementer.SelectedValue)
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
