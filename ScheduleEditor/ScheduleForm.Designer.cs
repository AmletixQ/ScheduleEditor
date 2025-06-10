namespace ScheduleEditor
{
    partial class ScheduleForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.FlowNavigation = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Панель навигации";
            // 
            // FlowNavigation
            // 
            this.FlowNavigation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowNavigation.Location = new System.Drawing.Point(5, 33);
            this.FlowNavigation.Margin = new System.Windows.Forms.Padding(4);
            this.FlowNavigation.Name = "FlowNavigation";
            this.FlowNavigation.Size = new System.Drawing.Size(165, 471);
            this.FlowNavigation.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(5, 523);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(100, 28);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Добавить";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(113, 523);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(100, 28);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ScheduleDataGrid
            // 
            this.ScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeColumn,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday});
            this.ScheduleDataGrid.Location = new System.Drawing.Point(220, 32);
            this.ScheduleDataGrid.Name = "ScheduleDataGrid";
            this.ScheduleDataGrid.ReadOnly = true;
            this.ScheduleDataGrid.RowHeadersWidth = 49;
            this.ScheduleDataGrid.RowTemplate.Height = 24;
            this.ScheduleDataGrid.Size = new System.Drawing.Size(838, 471);
            this.ScheduleDataGrid.TabIndex = 4;
            this.ScheduleDataGrid.Visible = false;
            // 
            // TimeColumn
            // 
            this.TimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.MinimumWidth = 6;
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            this.TimeColumn.Width = 67;
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Понедельник";
            this.Monday.MinimumWidth = 6;
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            this.Monday.Width = 120;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Вторник";
            this.Tuesday.MinimumWidth = 6;
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            this.Tuesday.Width = 120;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Среда";
            this.Wednesday.MinimumWidth = 6;
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            this.Wednesday.Width = 120;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Четверг";
            this.Thursday.MinimumWidth = 6;
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            this.Thursday.Width = 120;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Пятница";
            this.Friday.MinimumWidth = 6;
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            this.Friday.Width = 120;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Суббота";
            this.Saturday.MinimumWidth = 6;
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            this.Saturday.Width = 120;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 569);
            this.Controls.Add(this.ScheduleDataGrid);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.FlowNavigation);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScheduleForm";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlowNavigation;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView ScheduleDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
    }
}

