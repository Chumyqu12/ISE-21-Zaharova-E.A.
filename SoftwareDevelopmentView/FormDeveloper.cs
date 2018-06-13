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

        private void FormDeveloper_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    var implementer = Task.Run(() => APICustomer.GetRequestData<DeveloperViewModel>("api/Developer/Get/" + id.Value)).Result;
                    textBoxFIO.Text = implementer.DeveloperName;
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
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fio = textBoxFIO.Text;
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Developer/UpdateElement", new DeveloperBindingModel
                {
                    Id = id.Value,
                    DeveloperName = fio
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Developer/AddElement", new DeveloperBindingModel
                {
                    DeveloperName = fio
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
