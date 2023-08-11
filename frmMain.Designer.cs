using System;

namespace ZXNTCount
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbSource = new System.Windows.Forms.RichTextBox();
            this.lvwTable = new System.Windows.Forms.ListView();
            this.colInstruction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmtsmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmtsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmtsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmtsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTotalTCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotalBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProcessing = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectAll = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectNone = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslTextOptions = new System.Windows.Forms.ToolStripLabel();
            this.tscbTCount = new ZXNTCount.ToolStripCheckBox();
            this.tscbByteCount = new ZXNTCount.ToolStripCheckBox();
            this.tscbFlags = new ZXNTCount.ToolStripCheckBox();
            this.tscbComments = new ZXNTCount.ToolStripCheckBox();
            this.tscbDescription = new ZXNTCount.ToolStripCheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwTable);
            this.splitContainer1.Size = new System.Drawing.Size(800, 458);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // rtbSource
            // 
            this.rtbSource.AllowDrop = true;
            this.rtbSource.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSource.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSource.Location = new System.Drawing.Point(0, 0);
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.Size = new System.Drawing.Size(400, 458);
            this.rtbSource.TabIndex = 1;
            this.rtbSource.Text = "";
            this.rtbSource.WordWrap = false;
            this.rtbSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.rtbSource_DragEnter);
            this.rtbSource.TextChanged += new System.EventHandler(this.rtbSource_TextChanged);
            this.rtbSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbSource_MouseDown);
            // 
            // lvwTable
            // 
            this.lvwTable.AllowColumnReorder = true;
            this.lvwTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInstruction,
            this.colTime,
            this.colSize,
            this.colFlags,
            this.colComments,
            this.colDescription});
            this.lvwTable.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTable.FullRowSelect = true;
            this.lvwTable.GridLines = true;
            this.lvwTable.HideSelection = false;
            this.lvwTable.Location = new System.Drawing.Point(0, 0);
            this.lvwTable.Name = "lvwTable";
            this.lvwTable.Size = new System.Drawing.Size(396, 458);
            this.lvwTable.TabIndex = 2;
            this.lvwTable.UseCompatibleStateImageBehavior = false;
            this.lvwTable.View = System.Windows.Forms.View.Details;
            this.lvwTable.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwTable_ColumnClick);
            this.lvwTable.SelectedIndexChanged += new System.EventHandler(this.lvwTable_SelectedIndexChanged);
            this.lvwTable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwTable_KeyUp);
            this.lvwTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwTable_MouseDown);
            this.lvwTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwTable_MouseMove);
            // 
            // colInstruction
            // 
            this.colInstruction.Text = "Instruction";
            this.colInstruction.Width = 200;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colFlags
            // 
            this.colFlags.Text = "Flags";
            // 
            // colComments
            // 
            this.colComments.Text = "Comments";
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmtsmiReload,
            this.toolStripMenuItem1,
            this.cmtsmiCut,
            this.cmtsmiCopy,
            this.cmtsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 98);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // cmtsmiReload
            // 
            this.cmtsmiReload.Name = "cmtsmiReload";
            this.cmtsmiReload.Size = new System.Drawing.Size(110, 22);
            this.cmtsmiReload.Text = "Reload";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 6);
            // 
            // cmtsmiCut
            // 
            this.cmtsmiCut.Name = "cmtsmiCut";
            this.cmtsmiCut.Size = new System.Drawing.Size(110, 22);
            this.cmtsmiCut.Text = "Cut";
            // 
            // cmtsmiCopy
            // 
            this.cmtsmiCopy.Name = "cmtsmiCopy";
            this.cmtsmiCopy.Size = new System.Drawing.Size(110, 22);
            this.cmtsmiCopy.Text = "Copy";
            // 
            // cmtsmiDelete
            // 
            this.cmtsmiDelete.Name = "cmtsmiDelete";
            this.cmtsmiDelete.Size = new System.Drawing.Size(110, 22);
            this.cmtsmiDelete.Text = "Delete";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTotalTCount,
            this.tsslTotalBytes,
            this.tsslSpring,
            this.tspbProcessing});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslTotalTCount
            // 
            this.tsslTotalTCount.Name = "tsslTotalTCount";
            this.tsslTotalTCount.Size = new System.Drawing.Size(79, 17);
            this.tsslTotalTCount.Text = "rustypixels.uk";
            // 
            // tsslTotalBytes
            // 
            this.tsslTotalBytes.Name = "tsslTotalBytes";
            this.tsslTotalBytes.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslSpring
            // 
            this.tsslSpring.Name = "tsslSpring";
            this.tsslSpring.Size = new System.Drawing.Size(604, 17);
            this.tsslSpring.Spring = true;
            // 
            // tspbProcessing
            // 
            this.tspbProcessing.Name = "tspbProcessing";
            this.tspbProcessing.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReload,
            this.toolStripSeparator1,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.toolStripSeparator3,
            this.tsbSelectAll,
            this.tsbSelectNone,
            this.tsbDelete,
            this.toolStripSeparator2,
            this.tslTextOptions,
            this.tscbTCount,
            this.tscbByteCount,
            this.tscbFlags,
            this.tscbComments,
            this.tscbDescription});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 48);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReload
            // 
            this.tsbReload.AutoSize = false;
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = ((System.Drawing.Image)(resources.GetObject("tsbReload.Image")));
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(32, 32);
            this.tsbReload.Text = "Reload";
            this.tsbReload.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbCut
            // 
            this.tsbCut.AutoSize = false;
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(32, 32);
            this.tsbCut.Text = "Cut";
            this.tsbCut.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.AutoSize = false;
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(32, 32);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.AutoSize = false;
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(32, 32);
            this.tsbPaste.Text = "Paste";
            this.tsbPaste.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbSelectAll
            // 
            this.tsbSelectAll.AutoSize = false;
            this.tsbSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectAll.Image")));
            this.tsbSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectAll.Name = "tsbSelectAll";
            this.tsbSelectAll.Size = new System.Drawing.Size(32, 32);
            this.tsbSelectAll.Text = "Select All";
            this.tsbSelectAll.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // tsbSelectNone
            // 
            this.tsbSelectNone.AutoSize = false;
            this.tsbSelectNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectNone.Image")));
            this.tsbSelectNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectNone.Name = "tsbSelectNone";
            this.tsbSelectNone.Size = new System.Drawing.Size(32, 32);
            this.tsbSelectNone.Text = "Select None";
            this.tsbSelectNone.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(32, 32);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.toolStrip1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tslTextOptions
            // 
            this.tslTextOptions.Name = "tslTextOptions";
            this.tslTextOptions.Size = new System.Drawing.Size(76, 45);
            this.tslTextOptions.Text = "Text Options:";
            // 
            // tscbTCount
            // 
            this.tscbTCount.BackColor = System.Drawing.Color.Transparent;
            this.tscbTCount.Checked = false;
            this.tscbTCount.Name = "tscbTCount";
            this.tscbTCount.Size = new System.Drawing.Size(64, 45);
            this.tscbTCount.Text = "TCount";
            // 
            // tscbByteCount
            // 
            this.tscbByteCount.BackColor = System.Drawing.Color.Transparent;
            this.tscbByteCount.Checked = false;
            this.tscbByteCount.Name = "tscbByteCount";
            this.tscbByteCount.Size = new System.Drawing.Size(85, 45);
            this.tscbByteCount.Text = "Byte Count";
            // 
            // tscbFlags
            // 
            this.tscbFlags.BackColor = System.Drawing.Color.Transparent;
            this.tscbFlags.Checked = false;
            this.tscbFlags.Name = "tscbFlags";
            this.tscbFlags.Size = new System.Drawing.Size(53, 45);
            this.tscbFlags.Text = "Flags";
            // 
            // tscbComments
            // 
            this.tscbComments.BackColor = System.Drawing.Color.Transparent;
            this.tscbComments.Checked = false;
            this.tscbComments.Name = "tscbComments";
            this.tscbComments.Size = new System.Drawing.Size(85, 45);
            this.tscbComments.Text = "Comments";
            // 
            // tscbDescription
            // 
            this.tscbDescription.BackColor = System.Drawing.Color.Transparent;
            this.tscbDescription.Checked = false;
            this.tscbDescription.Name = "tscbDescription";
            this.tscbDescription.Size = new System.Drawing.Size(86, 45);
            this.tscbDescription.Text = "Description";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsmiEdit,
            this.tsmiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiSave,
            this.toolStripMenuItem4,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(103, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(103, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReload,
            this.toolStripMenuItem2,
            this.tsmiCut,
            this.tsmiCopy,
            this.tsmiDelete,
            this.toolStripMenuItem3,
            this.optionsToolStripMenuItem});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmiEdit.Text = "Edit";
            // 
            // tsmiReload
            // 
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.Size = new System.Drawing.Size(180, 22);
            this.tsmiReload.Text = "Reload";
            this.tsmiReload.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(180, 22);
            this.tsmiCut.Text = "Cut";
            this.tsmiCut.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(180, 22);
            this.tsmiCopy.Text = "Copy";
            this.tsmiCopy.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(180, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(107, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZXN TCount [VERSION]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotalBytes;
        private System.Windows.Forms.ToolStripProgressBar tspbProcessing;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotalTCount;
        private System.Windows.Forms.ListView lvwTable;
        private System.Windows.Forms.ColumnHeader colInstruction;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colFlags;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmtsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem cmtsmiCut;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton tsbReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiReload;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem cmtsmiReload;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmtsmiDelete;
        private ToolStripCheckBox tscbTCount;
        private ToolStripCheckBox tscbByteCount;
        private ToolStripCheckBox tscbFlags;
        private ToolStripCheckBox tscbDescription;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tslTextOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.RichTextBox rtbSource;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ColumnHeader colComments;
        private ToolStripCheckBox tscbComments;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripButton tsbSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSelectNone;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

