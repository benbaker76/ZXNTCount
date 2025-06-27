namespace ZXNTCount
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.grpIndentation = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboIndentType = new System.Windows.Forms.ComboBox();
            this.nudIndentSpaceCount = new System.Windows.Forms.NumericUpDown();
            this.grpInstructionSeperator = new System.Windows.Forms.GroupBox();
            this.cboInstructionSeperator = new System.Windows.Forms.ComboBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpIndentation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndentSpaceCount)).BeginInit();
            this.grpInstructionSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpIndentation
            // 
            this.grpIndentation.Controls.Add(this.label1);
            this.grpIndentation.Controls.Add(this.cboIndentType);
            this.grpIndentation.Controls.Add(this.nudIndentSpaceCount);
            this.grpIndentation.Location = new System.Drawing.Point(12, 12);
            this.grpIndentation.Name = "grpIndentation";
            this.grpIndentation.Size = new System.Drawing.Size(365, 78);
            this.grpIndentation.TabIndex = 0;
            this.grpIndentation.TabStop = false;
            this.grpIndentation.Text = "Indentation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Indent Space Count:";
            // 
            // cboIndentType
            // 
            this.cboIndentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndentType.FormattingEnabled = true;
            this.cboIndentType.Location = new System.Drawing.Point(15, 33);
            this.cboIndentType.Name = "cboIndentType";
            this.cboIndentType.Size = new System.Drawing.Size(121, 21);
            this.cboIndentType.TabIndex = 0;
            // 
            // nudIndentSpaceCount
            // 
            this.nudIndentSpaceCount.Location = new System.Drawing.Point(270, 33);
            this.nudIndentSpaceCount.Name = "nudIndentSpaceCount";
            this.nudIndentSpaceCount.Size = new System.Drawing.Size(73, 20);
            this.nudIndentSpaceCount.TabIndex = 2;
            // 
            // grpInstructionSeperator
            // 
            this.grpInstructionSeperator.Controls.Add(this.cboInstructionSeperator);
            this.grpInstructionSeperator.Location = new System.Drawing.Point(12, 96);
            this.grpInstructionSeperator.Name = "grpInstructionSeperator";
            this.grpInstructionSeperator.Size = new System.Drawing.Size(365, 78);
            this.grpInstructionSeperator.TabIndex = 1;
            this.grpInstructionSeperator.TabStop = false;
            this.grpInstructionSeperator.Text = "Instruction Seperator";
            // 
            // cboInstructionSeperator
            // 
            this.cboInstructionSeperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstructionSeperator.FormattingEnabled = true;
            this.cboInstructionSeperator.Location = new System.Drawing.Point(15, 31);
            this.cboInstructionSeperator.Name = "cboInstructionSeperator";
            this.cboInstructionSeperator.Size = new System.Drawing.Size(121, 21);
            this.cboInstructionSeperator.TabIndex = 0;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(12, 189);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(97, 28);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(278, 189);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(97, 28);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 237);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.grpInstructionSeperator);
            this.Controls.Add(this.grpIndentation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.grpIndentation.ResumeLayout(false);
            this.grpIndentation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndentSpaceCount)).EndInit();
            this.grpInstructionSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpIndentation;
        private System.Windows.Forms.NumericUpDown nudIndentSpaceCount;
        private System.Windows.Forms.GroupBox grpInstructionSeperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboIndentType;
        private System.Windows.Forms.ComboBox cboInstructionSeperator;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
    }
}