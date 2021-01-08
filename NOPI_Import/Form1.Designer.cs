namespace NOPI_Import
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bt_ChooseFile = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSqlConnection = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_tableName = new System.Windows.Forms.TextBox();
            this.bt_Insert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bt_ChooseFile
            // 
            this.bt_ChooseFile.AutoSize = true;
            this.bt_ChooseFile.Location = new System.Drawing.Point(161, 153);
            this.bt_ChooseFile.Name = "bt_ChooseFile";
            this.bt_ChooseFile.Size = new System.Drawing.Size(177, 71);
            this.bt_ChooseFile.TabIndex = 0;
            this.bt_ChooseFile.Text = "选择Excel文件";
            this.bt_ChooseFile.UseVisualStyleBackColor = true;
            this.bt_ChooseFile.Click += new System.EventHandler(this.bt_ChooseFile_Click);
            // 
            // txt_log
            // 
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_log.Enabled = false;
            this.txt_log.ForeColor = System.Drawing.Color.Red;
            this.txt_log.Location = new System.Drawing.Point(0, 263);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(946, 319);
            this.txt_log.TabIndex = 11;
            this.txt_log.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSqlConnection);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.groupBox1.Size = new System.Drawing.Size(946, 65);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sql Connection";
            // 
            // txtSqlConnection
            // 
            this.txtSqlConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlConnection.Location = new System.Drawing.Point(13, 21);
            this.txtSqlConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSqlConnection.Multiline = true;
            this.txtSqlConnection.Name = "txtSqlConnection";
            this.txtSqlConnection.Size = new System.Drawing.Size(920, 41);
            this.txtSqlConnection.TabIndex = 1;
            this.txtSqlConnection.Text = "Database=ttt;Data Source=.;User Id=sa;Password=123; Max Pool Size=512";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_tableName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.groupBox2.Size = new System.Drawing.Size(946, 50);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table Name";
            // 
            // txt_tableName
            // 
            this.txt_tableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_tableName.Location = new System.Drawing.Point(13, 21);
            this.txt_tableName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_tableName.Multiline = true;
            this.txt_tableName.Name = "txt_tableName";
            this.txt_tableName.Size = new System.Drawing.Size(920, 26);
            this.txt_tableName.TabIndex = 1;
            this.txt_tableName.Text = "customerConOld";
            // 
            // bt_Insert
            // 
            this.bt_Insert.AutoSize = true;
            this.bt_Insert.Location = new System.Drawing.Point(531, 153);
            this.bt_Insert.Name = "bt_Insert";
            this.bt_Insert.Size = new System.Drawing.Size(177, 71);
            this.bt_Insert.TabIndex = 17;
            this.bt_Insert.Text = "导入";
            this.bt_Insert.UseVisualStyleBackColor = true;
            this.bt_Insert.Click += new System.EventHandler(this.bt_Insert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 582);
            this.Controls.Add(this.bt_Insert);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.bt_ChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel导入数据库";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bt_ChooseFile;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSqlConnection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_tableName;
        private System.Windows.Forms.Button bt_Insert;
    }
}

