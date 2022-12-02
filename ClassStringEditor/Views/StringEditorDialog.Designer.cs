namespace ClassStringEditor
{
    partial class StringEditorDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileStringList = new System.Windows.Forms.ListView();
            this.source = new System.Windows.Forms.ColumnHeader();
            this.target = new System.Windows.Forms.ColumnHeader();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Configure = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Revoke = new System.Windows.Forms.ToolStripMenuItem();
            this.Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.Find = new System.Windows.Forms.ToolStripMenuItem();
            this.openJar = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.classTree = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.javaCode = new System.Windows.Forms.RichTextBox();
            this.saveJar = new System.Windows.Forms.SaveFileDialog();
            this.RightClickTreeItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxMenuLoadTreeString = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.RightClickTreeItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileStringList
            // 
            this.fileStringList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.source,
            this.target});
            this.fileStringList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileStringList.FullRowSelect = true;
            this.fileStringList.Location = new System.Drawing.Point(0, 0);
            this.fileStringList.MultiSelect = false;
            this.fileStringList.Name = "fileStringList";
            this.fileStringList.Size = new System.Drawing.Size(624, 211);
            this.fileStringList.TabIndex = 0;
            this.fileStringList.UseCompatibleStateImageBehavior = false;
            this.fileStringList.View = System.Windows.Forms.View.Details;
            this.fileStringList.DoubleClick += new System.EventHandler(this.fileStringList_DoubleClick);
            this.fileStringList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileStringList_KeyPress);
            // 
            // source
            // 
            this.source.Text = "源文字";
            this.source.Width = 300;
            // 
            // target
            // 
            this.target.Text = "替换文字";
            this.target.Width = 300;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.编辑EToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 28);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile,
            this.SaveAs,
            this.CloseFile,
            this.Configure});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(71, 24);
            this.menuFile.Text = "文件[&F]";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFile.Size = new System.Drawing.Size(257, 26);
            this.OpenFile.Text = "打开[&O]";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(257, 26);
            this.SaveFile.Text = "保存[&S]";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(257, 26);
            this.SaveAs.Text = "另存为[&A]";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // CloseFile
            // 
            this.CloseFile.Name = "CloseFile";
            this.CloseFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.CloseFile.Size = new System.Drawing.Size(257, 26);
            this.CloseFile.Text = "关闭[&C]";
            this.CloseFile.Click += new System.EventHandler(this.CloseFile_Click);
            // 
            // Configure
            // 
            this.Configure.Name = "Configure";
            this.Configure.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Configure.Size = new System.Drawing.Size(257, 26);
            this.Configure.Text = "配置[&P]";
            this.Configure.Click += new System.EventHandler(this.Configure_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Revoke,
            this.Redo,
            this.Find});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.编辑EToolStripMenuItem.Text = "编辑[&E]";
            // 
            // Revoke
            // 
            this.Revoke.Name = "Revoke";
            this.Revoke.Size = new System.Drawing.Size(142, 26);
            this.Revoke.Text = "撤销[&Z]";
            // 
            // Redo
            // 
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(142, 26);
            this.Redo.Text = "重做[&R]";
            // 
            // Find
            // 
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(142, 26);
            this.Find.Text = "搜索[&F]";
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // openJar
            // 
            this.openJar.DefaultExt = "jar";
            this.openJar.Filter = "Jar文件|*.jar|所有文件|*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.classTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 422);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // classTree
            // 
            this.classTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTree.Location = new System.Drawing.Point(0, 0);
            this.classTree.Name = "classTree";
            this.classTree.Size = new System.Drawing.Size(172, 422);
            this.classTree.TabIndex = 0;
            this.classTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.classTree_AfterSelect);
            this.classTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.classTree_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fileStringList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.javaCode);
            this.splitContainer2.Size = new System.Drawing.Size(624, 422);
            this.splitContainer2.SplitterDistance = 211;
            this.splitContainer2.TabIndex = 1;
            // 
            // javaCode
            // 
            this.javaCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.javaCode.Location = new System.Drawing.Point(0, 0);
            this.javaCode.Name = "javaCode";
            this.javaCode.Size = new System.Drawing.Size(624, 207);
            this.javaCode.TabIndex = 0;
            this.javaCode.Text = "";
            // 
            // saveJar
            // 
            this.saveJar.DefaultExt = "jar";
            this.saveJar.Filter = "JAR文件|*.jar|所有文件|*";
            // 
            // RightClickTreeItem
            // 
            this.RightClickTreeItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickTreeItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxMenuLoadTreeString});
            this.RightClickTreeItem.Name = "contextMenuStrip1";
            this.RightClickTreeItem.Size = new System.Drawing.Size(229, 28);
            // 
            // CtxMenuLoadTreeString
            // 
            this.CtxMenuLoadTreeString.Name = "CtxMenuLoadTreeString";
            this.CtxMenuLoadTreeString.Size = new System.Drawing.Size(228, 24);
            this.CtxMenuLoadTreeString.Text = "加载整个目录的字符串";
            this.CtxMenuLoadTreeString.Click += new System.EventHandler(this.CtxMenuLoadTreeString_Click);
            // 
            // StringEditorDialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "StringEditorDialog";
            this.Text = "文本编辑";
            this.Load += new System.EventHandler(this.StringEditor_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.StringEditorDialog_DragDrop);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.RightClickTreeItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView fileStringList;
        private ColumnHeader source;
        private ColumnHeader target;
        private MenuStrip menu;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem OpenFile;
        private ToolStripMenuItem SaveFile;
        private ToolStripMenuItem SaveAs;
        private ToolStripMenuItem CloseFile;
        private OpenFileDialog openJar;
        private SplitContainer splitContainer1;
        private TreeView classTree;
        private SplitContainer splitContainer2;
        private RichTextBox javaCode;
        private SaveFileDialog saveJar;
        private ToolStripMenuItem Configure;
        private ToolStripMenuItem 编辑EToolStripMenuItem;
        private ToolStripMenuItem Revoke;
        private ToolStripMenuItem Redo;
        private ToolStripMenuItem Find;
        private ContextMenuStrip RightClickTreeItem;
        private ToolStripMenuItem CtxMenuLoadTreeString;
    }
}