using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareDevelopmentView
{
    public partial class FormDeveloper : Form
    {
      

        public int Id { set { id = value; } }


        private int? id;

        public FormDeveloper()
        {
            InitializeComponent();
           
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Developer/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var developer = APICustomer.GetElement<DeveloperViewModel>(response);
                        textBoxFIO.Text = developer.DeveloperName;
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
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Developer/UpdateElement", new DeveloperBindingModel
                    {
                        Id = id.Value,
                        DeveloperName = textBoxFIO.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Developer/AddElement", new DeveloperBindingModel
                    {
                        DeveloperName = textBoxFIO.Text
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
