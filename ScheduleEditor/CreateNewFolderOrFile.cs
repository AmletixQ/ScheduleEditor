using System;
using System.IO;
using System.Windows.Forms;

namespace ScheduleEditor
{
    public partial class CreateNewFolderOrFile : Form
    {
        string newName = string.Empty;
        bool isFolder = false;
        readonly string path = string.Empty;

        public CreateNewFolderOrFile(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            newName = InputOfNewName.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Введите название файла", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isFolder = DirectoryRadioButton.Checked;
            Create();
        }

        private void Create()
        {
            string newPath = Path.Combine(path, newName);

            if (isFolder)
                Directory.CreateDirectory(newPath);
            else
            {
                string newFilePath = newPath + ".json";

                File.Create(newFilePath).Close();
                File.WriteAllText(newFilePath, "{}");
            }

            DialogResult = DialogResult.OK;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
