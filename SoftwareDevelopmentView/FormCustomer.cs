using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SoftwareDevelopmentView
{
    public partial class FormCustomer : Form
    {
       

        public int Id { set { id = value; } }


        private int? id;

        public FormCustomer()
        {
            InitializeComponent();
           
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Customer/Get/" + id.Value);
                                        if (response.Result.IsSuccessStatusCode)
                                            {
                        var client = APICustomer.GetElement<CustomerViewModel>(response);
                        textBoxFIO.Text = client.CustomerName;
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
            if(string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Customer/UpdateElement", new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerName = textBoxFIO.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerName = textBoxFIO.Text
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
