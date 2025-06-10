using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ScheduleEditor
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPass.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                List<string[]> user_datas = File.ReadAllLines("./database/users.txt")
                                        .Select(user_data => user_data.Split('|'))
                                        .ToList();

                var result_data = user_datas.FirstOrDefault(user_data => user_data[0] == login && user_data[1] == password);

                if (result_data != null)
                {
                    EnterToSchedule(result_data[2]);

                }
                else
                {
                    MessageBox.Show("Неверный логи или пароль", "Ошибка аавторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EnterToSchedule(string faculty)
        {
            this.Hide();
            ScheduleForm scheduleForm = new ScheduleForm(faculty);
            scheduleForm.ShowDialog();
            this.Close();
        }

    }
}
