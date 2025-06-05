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

            List<string[]> user_datas = File.ReadAllLines("./database/users.txt")
                                        .Select(user_data => user_data.Split('|'))
                                        .ToList();

            string[] result_data = user_datas.Where(user_data => user_data[0] == login && user_data[1] == password).First();
            EnterToSchedule(result_data[2]);
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
