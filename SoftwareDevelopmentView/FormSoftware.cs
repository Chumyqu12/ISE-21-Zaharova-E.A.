using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormSoftware : Form
    {
        

        public int Id { set { id = value; } }

     

        private int? id;

        private List<SoftwarePartViewModel> SoftwareParts;

        public FormSoftware()
        {
            InitializeComponent();
        
        }

        private void FormSoftware_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var Software = Task.Run(() => APICustomer.GetRequestData<SoftwareViewModel>("api/Software/Get/" + id.Value)).Result;
                    textBoxName.Text = Software.SoftwareName;
                    textBoxPrice.Text = Software.Cost.ToString();
                    SoftwareParts = Software.SoftwareParts;
                    LoadData();
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
            else
            {
                SoftwareParts = new List<SoftwarePartViewModel>();
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
            var form = new FormSoftwarePart();
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
                var form = new FormSoftwarePart();
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
            List<SoftwarePartBindingModel> SoftwareComponentBM = new List<SoftwarePartBindingModel>();
            for (int i = 0; i < SoftwareParts.Count; ++i)
            {
                SoftwareComponentBM.Add(new SoftwarePartBindingModel
                {
                    Id = SoftwareParts[i].Id,
                    SoftwareId = SoftwareParts[i].SoftwareId,
                    PartId = SoftwareParts[i].PartId,
                    Number = SoftwareParts[i].Number
                });
            }
            string name = textBoxName.Text;
            int price = Convert.ToInt32(textBoxPrice.Text);
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Software/UpdateElement", new SoftwareBindingModel
                {
                    Id = id.Value,
                    SoftwareName = name,
                    Cost = price,
                    SoftwareParts = SoftwareComponentBM
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Software/AddElement", new SoftwareBindingModel
                {
                    SoftwareName = name,
                    Cost = price,
                    SoftwareParts = SoftwareComponentBM
                }));
            }

            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
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

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
