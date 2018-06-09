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

        private List<SoftwarePartViewModel> productParts;

        public FormSoftware()
        {
            InitializeComponent();
        
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Software/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var product = APICustomer.GetElement<SoftwareViewModel>(response);
                        textBoxName.Text = product.SoftwareName;
                        textBoxPrice.Text = product.Cost.ToString();
                        productParts = product.SoftwareParts;
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
            else
            {
                productParts = new List<SoftwarePartViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (productParts != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = productParts;
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
                if(form.Model != null)
                {
                    if(id.HasValue)
                    {
                        form.Model.SoftwareId = id.Value;
                    }
                    productParts.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormSoftwarePart();
                form.Model = productParts[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productParts[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
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
                        productParts.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
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
            if (productParts == null || productParts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<SoftwarePartBindingModel> productPartBM = new List<SoftwarePartBindingModel>();
                for (int i = 0; i < productParts.Count; ++i)
                {
                    productPartBM.Add(new SoftwarePartBindingModel
                    {
                        Id = productParts[i].Id,
                        SoftwareId = productParts[i].SoftwareId,
                        PartId = productParts[i].PartId,
                        Number = productParts[i].Number
                    });
                }
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Software/UpdateElement", new SoftwareBindingModel
                    {
                        Id = id.Value,
                        SoftwareName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxPrice.Text),
                        SoftwareParts = productPartBM
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Software/AddElement", new SoftwareBindingModel
                    {
                        SoftwareName = textBoxName.Text,
                        Cost = Convert.ToInt32(textBoxPrice.Text),
                        SoftwareParts = productPartBM
                    });
                }
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
