using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZXNTCount
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            cboIndentType.Items.AddRange(new string[] { "Spaces", "Tabs" });
            cboInstructionSeperator.Items.AddRange(new string[] { "Space", "Tab" });

            cboIndentType.SelectedIndex = (int)Settings.IndentType;
            nudIndentSpaceCount.Value = Settings.IndentSpaceCount;

            cboInstructionSeperator.SelectedIndex = (int)Settings.InstructionSeparator;
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Settings.IndentType = (SpaceType)cboIndentType.SelectedIndex;
            Settings.IndentSpaceCount = (int)nudIndentSpaceCount.Value;

            Settings.InstructionSeparator = (SpaceType)cboInstructionSeperator.SelectedIndex;

            this.DialogResult = DialogResult.OK;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
