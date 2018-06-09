using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
    public partial class FormPart : Form
    {
     
        public int Id { set { id = value; } }


        private int? id;

        public FormPart()
        {
            InitializeComponent();
            
        }

        private void FormPart_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Part/Get/" + id.Value);
                                        if (response.Result.IsSuccessStatusCode)
                    {
                        var component = APICustomer.GetElement<PartViewModel>(response);
                        textBoxName.Text = component.PartName;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Part/UpdateElement", new PartBindingModel
                    {
                        Id = id.Value,
                        PartName = textBoxName.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Part/AddElement", new PartBindingModel
                    {
                        PartName = textBoxName.Text
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
