namespace ClassStringEditor.Views
{
    partial class ConfigureDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.JdkPathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UndefinedTextEdit = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.JdkPath = new System.Windows.Forms.TextBox();
            this.BrowerFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.OpenJdk = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.JdkPathLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.UndefinedTextEdit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 488);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // JdkPathLabel
            // 
            this.JdkPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.JdkPathLabel.AutoSize = true;
            this.JdkPathLabel.Location = new System.Drawing.Point(105, 217);
            this.JdkPathLabel.Name = "JdkPathLabel";
            this.JdkPathLabel.Size = new System.Drawing.Size(81, 20);
            this.JdkPathLabel.TabIndex = 0;
            this.JdkPathLabel.Text = "JDK路径：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "一个没用的编辑框：";
            // 
            // UndefinedTextEdit
            // 
            this.UndefinedTextEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UndefinedTextEdit.Location = new System.Drawing.Point(192, 251);
            this.UndefinedTextEdit.Name = "UndefinedTextEdit";
            this.UndefinedTextEdit.Size = new System.Drawing.Size(408, 27);
            this.UndefinedTextEdit.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.JdkPath);
            this.flowLayoutPanel1.Controls.Add(this.BrowerFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(192, 209);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(408, 36);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // JdkPath
            // 
            this.JdkPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JdkPath.Location = new System.Drawing.Point(3, 4);
            this.JdkPath.Name = "JdkPath";
            this.JdkPath.Size = new System.Drawing.Size(366, 27);
            this.JdkPath.TabIndex = 0;
            // 
            // BrowerFile
            // 
            this.BrowerFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowerFile.Location = new System.Drawing.Point(375, 3);
            this.BrowerFile.MaximumSize = new System.Drawing.Size(30, 30);
            this.BrowerFile.MinimumSize = new System.Drawing.Size(30, 30);
            this.BrowerFile.Name = "BrowerFile";
            this.BrowerFile.Size = new System.Drawing.Size(30, 30);
            this.BrowerFile.TabIndex = 1;
            this.BrowerFile.Text = "...";
            this.BrowerFile.UseVisualStyleBackColor = true;
            this.BrowerFile.Click += new System.EventHandler(this.BrowerFile_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.OK);
            this.panel1.Location = new System.Drawing.Point(155, 399);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 49);
            this.panel1.TabIndex = 5;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(183, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(145, 43);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(3, 3);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(145, 43);
            this.OK.TabIndex = 0;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // OpenJdk
            // 
            this.OpenJdk.Description = "选择JDK所在目录";
            this.OpenJdk.RootFolder = System.Environment.SpecialFolder.ProgramFilesX86;
            this.OpenJdk.ShowNewFolderButton = false;
            // 
            // ConfigureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigureDialog";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.ConfigureDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label JdkPathLabel;
        private Label label2;
        private TextBox UndefinedTextEdit;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox JdkPath;
        private Button BrowerFile;
        private FolderBrowserDialog OpenJdk;
        private Panel panel1;
        private Button OK;
        private Button Cancel;
    }
}