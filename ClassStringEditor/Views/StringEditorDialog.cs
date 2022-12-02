
using ClassStringEditor.Views;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using static ClassStringEditor.ClassFileParser;

namespace ClassStringEditor
{
    public partial class StringEditorDialog : Form
    {
        private class StringMeta {
            public ClassStringEditor editor;
            public ClsStringItem stringItem;
            public StringMeta(ClassStringEditor editor, ClsStringItem stringItem)
            {
                this.editor = editor;
                this.stringItem = stringItem;
            }
        }

        private const int WM_KEYUP = 0x0101;
        private const string ClassPath = ".tmp";
        private bool needSave = false;
        public StringEditorDialog()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            CloseFile_Click(sender, e);
            if (needSave)
                return;
            DialogResult result = openJar.ShowDialog();
            if (result != DialogResult.OK)
                return;
            if (Directory.Exists(ClassPath))
                Directory.Delete(ClassPath, true);
            Directory.CreateDirectory(ClassPath);
            ZipFile.ExtractToDirectory(openJar.FileName, ClassPath, true);
            ViewFileTree(ClassPath, classTree.Nodes);
        }
        private void ViewFileTree(string path, TreeNodeCollection collection, bool reload=true)
        {
            if (reload)
                classTree.Nodes.Clear();
            foreach (string directory in Directory.EnumerateDirectories(path))
            {
                TreeNode node = new TreeNode(directory);
                node.Name = directory;
                ViewFileTree(directory, node.Nodes, false);
                collection.Add(node);
            }
            foreach (string file in Directory.EnumerateFiles(path))
            {
                collection.Add(file);
            }
        }
        private void classTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = classTree.SelectedNode;
            if (treeNode.Tag == null)
            {
                string filePath = classTree.SelectedNode.Text;
                if (!Path.GetExtension(filePath).ToLower().Equals(".class"))
                    return;

                treeNode.Tag = new ClassStringEditor(filePath);
            }
            ViewClassString(treeNode);
        }
        private void fileStringList_DoubleClick(object sender, EventArgs e)
        {
            if (fileStringList.SelectedItems.Count == 0)
                return;
            var selectedItem = fileStringList.SelectedItems[0];
            StringMeta stringMeta = (StringMeta)selectedItem.Tag;
            ItemEditDialog itemEdit = new ItemEditDialog();
            itemEdit.SetText(selectedItem.Text, selectedItem.SubItems[1].Text);
            itemEdit.onChanged = delegate (string changedText)
            {
                needSave = true;
                selectedItem.SubItems[1].Text = changedText;
                if (changedText.Length != 0)
                    stringMeta.editor.Edit(stringMeta.stringItem.index, changedText);
                else
                    stringMeta.editor.Recover(stringMeta.stringItem.index);
            };
            itemEdit.ShowDialog();
        }

        private void fileStringList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Enter)
                fileStringList_DoubleClick(sender, e);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in classTree.Nodes)
                SaveTree(node);
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            string jarFilePath = ConfigOperator.GetValue(ConfigOperator.KEY_JDK_PATH);
            saveJar.FileName = Path.GetFileName(jarFilePath);
            DialogResult result = saveJar.ShowDialog();
            if (result != DialogResult.OK)
                return;

            foreach (TreeNode node in classTree.Nodes)
                SaveTree(node);
            if (!BuildJar(ClassPath, saveJar.FileName))
                MessageBox.Show("无法构建Jar，请检查配置中的JDK路径后重新尝试。");
        }
        private void CloseFile_Click(object sender, EventArgs e)
        {
            if (needSave)
            {
                DialogResult result = MessageBox.Show("确认不保存退出？", "保存", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                else
                    needSave = false;
            }

            foreach (TreeNode node in classTree.Nodes)
                CloseTree(node);
            if (Directory.Exists(ClassPath))
                Directory.Delete(ClassPath, true);
        }
        private void ViewClassString(TreeNode treeNode, bool reload = true)
        {
            if (reload)
                fileStringList.Items.Clear();

            string fileExtension = Path.GetExtension(treeNode.Text).ToLower();
            if (!fileExtension.Equals(".class"))
            {
                if (string.IsNullOrEmpty(fileExtension))
                {
                    foreach (TreeNode node in treeNode.Nodes)
                        ViewClassString(node, false);
                }
                else
                {
                    return;
                }
            }

            if (treeNode.Tag == null)
            {
                string filePath = treeNode.Text;
                if (!Path.GetExtension(filePath).ToLower().Equals(".class"))
                    return;
                treeNode.Tag = new ClassStringEditor(filePath);
            }
            ClassStringEditor stringEditor = (ClassStringEditor)treeNode.Tag;
            foreach (ClsStringItem constString in stringEditor.GetStrings())
            {
                ListViewItem item = new ListViewItem();
                item.Tag = new StringMeta(stringEditor, constString);
                item.Text = constString.data;
                item.SubItems.Add(stringEditor.LookupEdit(constString.index));
                fileStringList.Items.Add(item);
            }
        }
        private void CloseTree(TreeNode treeNode)
        {
            if (!Path.GetExtension(treeNode.Text).ToLower().Equals(".class"))
            {
                foreach (TreeNode node in treeNode.Nodes)
                    CloseTree(node);
                return;
            }

            ClassStringEditor stringEditor = (ClassStringEditor)treeNode.Tag;
            if (stringEditor != null)
                stringEditor.Close();
        }
        private void SaveTree(TreeNode node)
        {
            foreach (TreeNode subNode in node.Nodes)
                SaveTree(subNode);
            if (node.Tag != null)
            {
                ClassStringEditor stringEditor = (ClassStringEditor)node.Tag;
                stringEditor.Save();
            }
        }
        private bool BuildJar(string classPath, string jarPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "jar.exe";
            startInfo.UseShellExecute = true;
            startInfo.Arguments = $"--create --file \"{jarPath}\" -m META-INF\\MANIFEST.MF .";
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = Path.GetFullPath(classPath);
            Process? jarProcess = Process.Start(startInfo);
            if (jarProcess == null)
                return false;
            jarProcess.WaitForExit();
            return true;
        }

        private void StringEditor_Load(object sender, EventArgs e)
        {

        }

        private void Configure_Click(object sender, EventArgs e)
        {
            ConfigureDialog configureDialog = new ConfigureDialog();
            DialogResult result = configureDialog.ShowDialog();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            FindStringDialog findDialog = new FindStringDialog();
            DialogResult result = findDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;


        }

        private void CtxMenuLoadTreeString_Click(object sender, EventArgs e)
        {
            ViewClassString(classTree.SelectedNode);
        }

        private void classTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point screenPoint = classTree.PointToScreen(new Point(e.X, e.Y));
                RightClickTreeItem.Show(screenPoint);
            }
        }

        private void StringEditorDialog_DragDrop(object sender, DragEventArgs e)
        {
        }
    }
}