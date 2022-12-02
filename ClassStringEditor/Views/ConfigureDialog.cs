using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassStringEditor.Views
{
    public partial class ConfigureDialog : Form
    {
        public string jdkPath = "";
        public ConfigureDialog()
        {
            InitializeComponent();
        }

        private bool CheckJdkPath(string path)
        {
            return File.Exists(Path.Combine(path, "bin", "jar.exe"));
        }
        private void BrowerFile_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenJdk.ShowDialog();
            if (result == DialogResult.OK)
                if (CheckJdkPath(OpenJdk.SelectedPath))
                    JdkPath.Text = OpenJdk.SelectedPath;
                else
                    MessageBox.Show("不是一个有效的JDK目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (!CheckJdkPath(JdkPath.Text))
                MessageBox.Show("不是一个有效的JDK目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SaveChange();
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void SaveChange()
        {
            ConfigOperator.SetValue(ConfigOperator.KEY_JDK_PATH, JdkPath.Text);
            ConfigOperator.SetValue(ConfigOperator.KEY_NONE, UndefinedTextEdit.Text);
            ConfigOperator.Save();
        }

        private void ConfigureDialog_Load(object sender, EventArgs e)
        {
            JdkPath.Text = ConfigOperator.GetValue(ConfigOperator.KEY_JDK_PATH);
            UndefinedTextEdit.Text = ConfigOperator.GetValue(ConfigOperator.KEY_NONE);
        }
    }
}
