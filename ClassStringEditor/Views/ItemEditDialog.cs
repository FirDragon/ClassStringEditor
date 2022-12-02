using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassStringEditor.Views
{
    public partial class ItemEditDialog : Form
    {
        public const int WM_KEYUP = 0x0101;
        public Action<string>? onChanged = null;
        public ItemEditDialog()
        {
            InitializeComponent();
        }
        public void SetText(string source, string? oldChangeText = null)
        {
            sourceText.Text = source;
            if (oldChangeText != null)
                changedText.Text = oldChangeText;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (onChanged != null)
                onChanged(changedText.Text);
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void changedText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancel_Click(this, e);
                return;
            }
            else if (e.KeyChar == (char)(Keys.ControlKey | Keys.Enter))
            {
                ok_Click(this, e);
                return;
            }
        }

        private void ItemEdit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
                cancel_Click(this, e);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    cancel.PerformClick();
                    return true;
                case Keys.Enter| Keys.Control:
                    ok.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
