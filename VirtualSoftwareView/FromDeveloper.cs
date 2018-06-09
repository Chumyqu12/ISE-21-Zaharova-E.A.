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
    public partial class FromDeveloper : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDeveloperService service;

        private int? id;

        public FromDeveloper(IDeveloperService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FromDeveloper_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DeveloperUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        textBoxFIO.Text = view.DeveloperFIO;
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
                if (id.HasValue)
                {
                    service.UpdPart(new DeveloperConnectingModel
                    {
                        Id = id.Value,
                        DeveloperFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    service.AddPart(new DeveloperConnectingModel
                    {
                        DeveloperFIO = textBoxFIO.Text
                    });
                }
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
    }
}
