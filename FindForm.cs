using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseNotePad
{
    /** WinForm for search text in Notepad.
     * @Author: XiuJun Yang
     * @Date: 29th Dec 2016
     */
    public partial class FindForm : Form
    {
        private Label label1;
        private TextBox findText;
        private Button findNextBtn, cancelBtn;
        private ToolTip toolTip1;
        private IContainer components;

        public FindForm()
        {
            InitializeComponent();
        }

		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form inital
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.findText = new System.Windows.Forms.TextBox();
            this.findNextBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();

            // label1
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find What:";

            // findText
            this.findText.Location = new System.Drawing.Point(151, 41);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(250, 26);
            this.findText.TabIndex = 1;
            this.toolTip1.SetToolTip(this.findText, "Key in what do you want to find");
            this.findText.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);

            // findNextBtn
            this.findNextBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.findNextBtn.Enabled = false;
            this.findNextBtn.Location = new System.Drawing.Point(60, 102);
            this.findNextBtn.Name = "findNextBtn";
            this.findNextBtn.Size = new System.Drawing.Size(120, 30);
            this.findNextBtn.TabIndex = 2;
            this.findNextBtn.Text = "Find Next";
            this.toolTip1.SetToolTip(this.findNextBtn, "Begin to find");
            this.findNextBtn.Click += new System.EventHandler(this.findNextBtn_Click);

            // cancelBtn
            this.cancelBtn.Location = new System.Drawing.Point(281, 102);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 30);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cancelBtn, "Cancel");
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
 
            // FindForm
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(480, 166);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.findNextBtn);
            this.Controls.Add(this.findText);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.Text = "FindForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public String cData
        { get{ return findText.Text; } }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtsearch_TextChanged(object sender, System.EventArgs e)
        {
            if (findText.TextLength != 0)
            {
                findNextBtn.Enabled = true;
            }
            else
            {
                findNextBtn.Enabled = false;
            }
        }

        private void findNextBtn_Click(object sender, System.EventArgs e)
        {
            //BEGIN SEARCH
        }
    }
}
