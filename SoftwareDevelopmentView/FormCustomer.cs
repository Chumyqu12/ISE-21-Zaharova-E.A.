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
                    var client = Task.Run(() => APICustomer.GetRequestData<CustomerViewModel>("api/Customer/Get/" + id.Value)).Result;
                    textBoxFIO.Text = client.CustomerName;
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
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fio = textBoxFIO.Text;
            Task task;
              if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Customer/UpdateElement", new CustomerBindingModel
                                    {
                    Id = id.Value,
                    CustomerName = fio
               }));
                            }
                        else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Customer/AddElement", new CustomerBindingModel
                {
                    CustomerName = fio
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
            }, 
TaskContinuationOptions.OnlyOnFaulted);
            
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}
