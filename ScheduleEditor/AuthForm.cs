using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ScheduleEditor
{
    public partial class AuthForm : Form
    {
        private const string UserFilePath = "user.txt";

        public AuthForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPass.Text;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста введите логин и пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        private void LoadUsers()
        {
            if (!File.Exists(UserFilePath))
            {
                UserManager.AddUser("admin", "admin123");
            }

        }

    }
}
