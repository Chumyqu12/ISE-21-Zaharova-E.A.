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
    public partial class FormPutOnSoftwareWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ISoftwareWarehouseService serviceS;

        private readonly IPartService serviceC;

        private readonly IGeneralSelection serviceM;

        public FormPutOnSoftwareWarehouse(ISoftwareWarehouseService serviceS, IPartService serviceC, IGeneralSelection serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }

        private void FormPutOnSoftwareWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                List<PartUserViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxComponent.DisplayMember = "PartName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = listC;
                    comboBoxComponent.SelectedItem = null;
                }
                List<SoftwareWarehouseUserViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStock.DisplayMember = "SoftwareWarehouseName";
                    comboBoxStock.ValueMember = "Id";
                    comboBoxStock.DataSource = listS;
                    comboBoxStock.SelectedItem = null;
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
            if (comboBoxComponent.SelectedValue == null)
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
                serviceM.PutComponentOnStock(new SoftwareWarehousePartConnectingModel
                {
                    PartId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                    SoftwareWarehouseId = Convert.ToInt32(comboBoxStock.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
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

        private void comboBoxStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
