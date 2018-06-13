using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormSoftwarePart : Form
    {
       

        public SoftwarePartViewModel Model { set { model = value; }  get { return model; } }

       

        private SoftwarePartViewModel model;

        public FormSoftwarePart()
        {
            InitializeComponent();
          
        }

        private void FormProductPart_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxPart.DisplayMember = "PartName";
                comboBoxPart.ValueMember = "Id";
                comboBoxPart.DataSource = Task.Run(() => APICustomer.GetRequestData<List<PartViewModel>>("api/Part/GetList")).Result;
                comboBoxPart.SelectedItem = null;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                                    {
                    ex = ex.InnerException;
                                    }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxPart.Enabled = false;
                comboBoxPart.SelectedValue = model.PartId;
                textBoxCount.Text = model.Number.ToString();
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
            try
            {
                if (model == null)
                {
                    model = new SoftwarePartViewModel
                    {
                        PartId = Convert.ToInt32(comboBoxPart.SelectedValue),
                        PartName = comboBoxPart.Text,
                       Number = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Number = Convert.ToInt32(textBoxCount.Text);
                }
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
    }
}
