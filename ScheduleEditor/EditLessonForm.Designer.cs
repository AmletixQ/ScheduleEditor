namespace ScheduleEditor
{
    partial class EditLessonForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.LessonTypeDropBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputLessonName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.InputTeacher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WeekTypeDropBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InputClassroom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(122, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Изменить занятие";
            // 
            // LessonTypeDropBox
            // 
            this.LessonTypeDropBox.FormattingEnabled = true;
            this.LessonTypeDropBox.Items.AddRange(new object[] {
            "Лекция",
            "Семинар",
            "Лаборатория"});
            this.LessonTypeDropBox.Location = new System.Drawing.Point(12, 63);
            this.LessonTypeDropBox.Name = "LessonTypeDropBox";
            this.LessonTypeDropBox.Size = new System.Drawing.Size(121, 21);
            this.LessonTypeDropBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип занятия";
            // 
            // InputLessonName
            // 
            this.InputLessonName.Location = new System.Drawing.Point(178, 64);
            this.InputLessonName.Name = "InputLessonName";
            this.InputLessonName.Size = new System.Drawing.Size(236, 20);
            this.InputLessonName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Название занятия";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(15, 236);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(129, 236);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(175, 99);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(86, 13);
            this.label.TabIndex = 8;
            this.label.Text = "Преподаватель";
            // 
            // InputTeacher
            // 
            this.InputTeacher.Location = new System.Drawing.Point(178, 116);
            this.InputTeacher.Name = "InputTeacher";
            this.InputTeacher.Size = new System.Drawing.Size(236, 20);
            this.InputTeacher.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип недели";
            // 
            // WeekTypeDropBox
            // 
            this.WeekTypeDropBox.FormattingEnabled = true;
            this.WeekTypeDropBox.Items.AddRange(new object[] {
            "Четная",
            "Нечетная",
            "Оба"});
            this.WeekTypeDropBox.Location = new System.Drawing.Point(15, 115);
            this.WeekTypeDropBox.Name = "WeekTypeDropBox";
            this.WeekTypeDropBox.Size = new System.Drawing.Size(121, 21);
            this.WeekTypeDropBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Аудитория";
            // 
            // InputClassroom
            // 
            this.InputClassroom.Location = new System.Drawing.Point(15, 166);
            this.InputClassroom.Name = "InputClassroom";
            this.InputClassroom.Size = new System.Drawing.Size(121, 20);
            this.InputClassroom.TabIndex = 11;
            // 
            // EditLessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 271);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InputClassroom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WeekTypeDropBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.InputTeacher);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InputLessonName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LessonTypeDropBox);
            this.Controls.Add(this.label1);
            this.Name = "EditLessonForm";
            this.Text = "EditLessonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LessonTypeDropBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputLessonName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox InputTeacher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox WeekTypeDropBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox InputClassroom;
    }
}