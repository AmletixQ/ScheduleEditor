namespace ScheduleEditor
{
    partial class CreateNewFolderOrFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DirectoryRadioButton = new System.Windows.Forms.RadioButton();
            this.FileRadioButton = new System.Windows.Forms.RadioButton();
            this.InputOfNewName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DirectoryRadioButton
            // 
            this.DirectoryRadioButton.AutoSize = true;
            this.DirectoryRadioButton.Location = new System.Drawing.Point(57, 51);
            this.DirectoryRadioButton.Name = "DirectoryRadioButton";
            this.DirectoryRadioButton.Size = new System.Drawing.Size(119, 17);
            this.DirectoryRadioButton.TabIndex = 0;
            this.DirectoryRadioButton.TabStop = true;
            this.DirectoryRadioButton.Text = "Новая директория";
            this.DirectoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // FileRadioButton
            // 
            this.FileRadioButton.AutoSize = true;
            this.FileRadioButton.Location = new System.Drawing.Point(57, 74);
            this.FileRadioButton.Name = "FileRadioButton";
            this.FileRadioButton.Size = new System.Drawing.Size(166, 17);
            this.FileRadioButton.TabIndex = 1;
            this.FileRadioButton.TabStop = true;
            this.FileRadioButton.Text = "Новый файл для расписаия";
            this.FileRadioButton.UseVisualStyleBackColor = true;
            // 
            // InputOfNewName
            // 
            this.InputOfNewName.Location = new System.Drawing.Point(57, 147);
            this.InputOfNewName.Name = "InputOfNewName";
            this.InputOfNewName.Size = new System.Drawing.Size(170, 20);
            this.InputOfNewName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите название";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(57, 193);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 4;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(152, 193);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Отменить";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(54, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Что хотите создать?";
            // 
            // CreateNewFolderOrFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 247);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputOfNewName);
            this.Controls.Add(this.FileRadioButton);
            this.Controls.Add(this.DirectoryRadioButton);
            this.Name = "CreateNewFolderOrFile";
            this.Text = "Добавить новый раздел";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton DirectoryRadioButton;
        private System.Windows.Forms.RadioButton FileRadioButton;
        private System.Windows.Forms.TextBox InputOfNewName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label2;
    }
}