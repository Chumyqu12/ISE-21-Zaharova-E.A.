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
    public partial class FormSoftware : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ISoftwareService service;

        private int? id;

        private List<SoftwarePartUserViewModel> SoftwareParts;


        public FormSoftware(ISoftwareService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormSoftware_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SoftwareUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.SoftwareName;
                        textBoxPrice.Text = view.Price.ToString();
                        SoftwareParts = view.SoftwarePart;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SoftwareParts = new List<SoftwarePartUserViewModel>();
            }
        }

        private void FormSoftware_Load_1(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SoftwareUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.SoftwareName;
                        textBoxPrice.Text = view.Price.ToString();
                        SoftwareParts = view.SoftwarePart;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SoftwareParts = new List<SoftwarePartUserViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (SoftwareParts != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = SoftwareParts;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSoftwarePart>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.SoftwareId = id.Value;
                    }
                    SoftwareParts.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSoftwarePart>();
                form.Model = SoftwareParts[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SoftwareParts[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SoftwareParts.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SoftwareParts == null || SoftwareParts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<SoftwarePartConnectingModel> SoftwarePartBM = new List<SoftwarePartConnectingModel>();
                for (int i = 0; i < SoftwareParts.Count; ++i)
                {
                    SoftwarePartBM.Add(new SoftwarePartConnectingModel
                    {
                        Id = SoftwareParts[i].Id,
                        SoftwareId = SoftwareParts[i].SoftwareId,
                        PartId = SoftwareParts[i].PartId,
                        Count = SoftwareParts[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdPart(new SoftwareConnectingModel
                    {
                        Id = id.Value,
                        SoftwareName = textBoxName.Text,
                        Value = Convert.ToInt32(textBoxPrice.Text),
                        SoftwarePart = SoftwarePartBM
                    });
                }
                else
                {
                    service.AddPart(new SoftwareConnectingModel
                    {
                        SoftwareName = textBoxName.Text,
                        Value = Convert.ToInt32(textBoxPrice.Text),
                        SoftwarePart = SoftwarePartBM
                    });
                }
                MessageBox.Show("Сохранение успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void groupBoxComponents_Enter(object sender, EventArgs e)
        {

        }
    }
}
