using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.RealiseInterface;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwareView
{
    public partial class FormTakeFromSoftwareWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDeveloperService serviceI;

        private readonly IGeneralSelection serviceM;

        private int? id;


        public FormTakeFromSoftwareWarehouse(IDeveloperService serviceI, IGeneralSelection serviceM)
        {
            InitializeComponent();
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }

        private void FormTakeFromSoftwareWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указан заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                List<DeveloperUserViewModel> listI = serviceI.GetList();
                if (listI != null)
                {
                    comboBoxImplementer.DisplayMember = "DeveloperFIO";
                    comboBoxImplementer.ValueMember = "Id";
                    comboBoxImplementer.DataSource = listI;
                    comboBoxImplementer.SelectedItem = null;
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
                serviceM.TakeOrderInWork(new CustomerSelectionModel
                {
                    Id = id.Value,
                    DeveloperId = Convert.ToInt32(comboBoxImplementer.SelectedValue)
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

        private void comboBoxImplementer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
