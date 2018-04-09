using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace AbstractShopView
{
    public partial class FormCreateOffer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly ISoftwareService serviceP;

        private readonly IGeneralService serviceM;

        public FormCreateOffer(ICustomerService serviceC, ISoftwareService serviceP, IGeneralService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceP = serviceP;
            this.serviceM = serviceM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "CustomerName";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
                List<SoftwareViewModel> listP = serviceP.GetList();
                if (listP != null)
                {
                    comboBoxProduct.DisplayMember = "SoftwareName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listP;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    SoftwareViewModel product = serviceP.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Cost).ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateOffer(new OfferBindingModel
                {
                    CustomerId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    SoftwareId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Number = Convert.ToInt32(textBoxCount.Text),
                    Summa = Convert.ToInt32(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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

        private void labelProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
