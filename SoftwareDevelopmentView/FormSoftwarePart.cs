﻿using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace SoftwareDevelopmentView
{
    public partial class FormProductPart : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public SoftwarePartViewModel Model { set { model = value; }  get { return model; } }

        private readonly IPartService service;

        private SoftwarePartViewModel model;

        public FormProductPart(IPartService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormProductPart_Load(object sender, EventArgs e)
        {
            try
            {
                List<PartViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxPart.DisplayMember = "PartName";
                    comboBoxPart.ValueMember = "Id";
                    comboBoxPart.DataSource = list;
                    comboBoxPart.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxPart.Enabled = false;
                comboBoxPart.SelectedValue = model.PartId;
                textBoxCount.Text = model.Number.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPart.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new SoftwarePartViewModel
                    {
                        PartId = Convert.ToInt32(comboBoxPart.SelectedValue),
                        PartName = comboBoxPart.Text,
                       Number = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Number = Convert.ToInt32(textBoxCount.Text);
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
