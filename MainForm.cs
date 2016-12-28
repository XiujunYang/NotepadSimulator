using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExerciseNotePad
{
    /** Main WinForm for Notepad.
     * @Author: XiuJun Yang
     * @Date: 29th Dec 2016
     */
    public partial class MainForm : Form
    {
        const int NEW_ACTION = 0;
        const int SAVE_ACTION = 1;
        const int SAVE_AS_ACTION = 2;
        const int LOAD_ACTION = 3;
        const int EXIT_ACTION = 4;
        #region Declare variable
        private MainMenu mainMenu1;
        private MenuItem fileMenuItem, newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem,
            pageSetupMenuItem, printMenuItem, exitMenuItem;
        private MenuItem editMenuItem, undoMenuItem, cutMenuItem, copyMenuItem, pasteMenuItem,
            deleteMenuItem, findMenuItem, findNextMenuItem, replaceMenuItem, goToMenuItem,
            selectAllMenuItem, timeDateMenuItem;
        private MenuItem formatMenuItem, wordWrapMenuItem, fontMenuItem, colorMenuItem;
        private MenuItem viewMenuItem, statusBarMenuItem;
        private MenuItem helpMenuItem, aboutMenuItem;
        private ContextMenu contextMenu;
        private MenuItem rightToLeftMenuItem, undoMenuItem2, cutMenuItem2, copyMenuItem2,
            pasteMenuItem2, deleteMenuItem2, selectAllMenuItem2;

        private DateTimePicker dateTimePicker1;
        private RichTextBox txtbox;
        private FontDialog fontDialog1;
        private StatusBar statusBar1;
        private StatusBarPanel statusBarPanel1;
        private StatusBarPanel statusBarPanel2;
        private IContainer components;
        private ColorDialog colorDialog1;
        string savefile = null; //Save file path and name Currently.
        string data = ""; //Save content in @savefile.
        string FindTxt = ""; //Search text currently.
        #endregion

        public MainForm()
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

        //Windows Form inital
        protected void InitializeComponent()
        {
            #region Create variable
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            mainMenu1 = new MainMenu(components);
            fileMenuItem = new MenuItem();
            newMenuItem = new MenuItem();
            openMenuItem = new MenuItem();
            saveMenuItem = new MenuItem();
            saveAsMenuItem = new MenuItem();
            pageSetupMenuItem = new MenuItem();
            printMenuItem = new MenuItem();
            exitMenuItem = new MenuItem();
            editMenuItem = new MenuItem();
            undoMenuItem = new MenuItem();
            cutMenuItem = new MenuItem();
            copyMenuItem = new MenuItem();
            pasteMenuItem = new MenuItem();
            deleteMenuItem = new MenuItem();
            findMenuItem = new MenuItem();
            findNextMenuItem = new MenuItem();
            replaceMenuItem = new MenuItem();
            goToMenuItem = new MenuItem();
            selectAllMenuItem = new MenuItem();
            timeDateMenuItem = new MenuItem();
            formatMenuItem = new MenuItem();
            wordWrapMenuItem = new MenuItem();
            fontMenuItem = new MenuItem();
            colorMenuItem = new MenuItem();
            viewMenuItem = new MenuItem();
            statusBarMenuItem = new MenuItem();
            helpMenuItem = new MenuItem();
            aboutMenuItem = new MenuItem();
            dateTimePicker1 = new DateTimePicker();
            txtbox = new RichTextBox();
            contextMenu = new ContextMenu();
            rightToLeftMenuItem = new MenuItem();
            // how to use same mentItem object to both of contextMenu and EditMenuItem?
            undoMenuItem2 = new MenuItem();
            cutMenuItem2 = new MenuItem();
            copyMenuItem2 = new MenuItem();
            pasteMenuItem2 = new MenuItem();
            deleteMenuItem2 = new MenuItem();
            selectAllMenuItem2 = new MenuItem();
            fontDialog1 = new FontDialog();
            statusBar1 = new StatusBar();
            statusBarPanel1 = new StatusBarPanel();
            statusBarPanel2 = new StatusBarPanel();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(statusBarPanel2)).BeginInit();
            SuspendLayout();
            #endregion

            #region MainMenu
            // mainMenu1
            mainMenu1.MenuItems.Add(fileMenuItem);
            mainMenu1.MenuItems.Add(editMenuItem);
            mainMenu1.MenuItems.Add(formatMenuItem);
            mainMenu1.MenuItems.Add(viewMenuItem);
            mainMenu1.MenuItems.Add(helpMenuItem);
            #endregion

            #region FileMenuItem Setup
            // fileMenuItem
            fileMenuItem.Text = "File";
            fileMenuItem.MenuItems.Add(newMenuItem);
            fileMenuItem.MenuItems.Add(openMenuItem);
            fileMenuItem.MenuItems.Add(saveMenuItem);
            fileMenuItem.MenuItems.Add(saveAsMenuItem);
            fileMenuItem.MenuItems.Add("-");
            fileMenuItem.MenuItems.Add(pageSetupMenuItem);
            fileMenuItem.MenuItems.Add(printMenuItem);
            fileMenuItem.MenuItems.Add("-");
            fileMenuItem.MenuItems.Add(exitMenuItem);

            // newMenuItem
            newMenuItem.Shortcut = Shortcut.CtrlN;
            newMenuItem.Text = "New";
            newMenuItem.Click += new EventHandler(newMenuItem_Click);

            // openMenuItem
            openMenuItem.Shortcut = Shortcut.CtrlO;
            openMenuItem.Text = "Open...";
            openMenuItem.Click += new EventHandler(openMenuItem_Click);

            // saveMenuItem
            saveMenuItem.Shortcut = Shortcut.CtrlS;
            saveMenuItem.Text = "Save";
            saveMenuItem.Click += new EventHandler(saveMenuItem_Click);

            // saveAsMenuItem
            saveAsMenuItem.Text = "Save As...";
            saveAsMenuItem.Click += new EventHandler(saveAsMenuItem_Click);

            // pageSetupMenuItem
            pageSetupMenuItem.Enabled = false;
            pageSetupMenuItem.Text = "Page Setup...";

            // printMenuItem
            printMenuItem.Enabled = false;
            printMenuItem.Shortcut = Shortcut.CtrlP;
            printMenuItem.Text = "Print";

            // exitMenuItem
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += new EventHandler(exitMenuItem_Click);
            #endregion

            #region EditMenuItem Setup
            // editMenuItem
            editMenuItem.Text = "Edit";
            editMenuItem.MenuItems.AddRange(new MenuItem[] {
                undoMenuItem,
                new MenuItem("-"),
                cutMenuItem,
                copyMenuItem,
                pasteMenuItem,
                deleteMenuItem,
                new MenuItem("-"),
                findMenuItem,
                findNextMenuItem,
                new MenuItem("-"),
                replaceMenuItem,
                goToMenuItem,
                new MenuItem("-"),
                selectAllMenuItem,
                timeDateMenuItem
            });

            // undoMenuItem
            undoMenuItem.Enabled = false;
            undoMenuItem.Shortcut = Shortcut.CtrlZ;
            undoMenuItem.Text = "Undo";
            undoMenuItem.Click += new EventHandler(undoMenuItem_Click);

            // cutMenuItem
            cutMenuItem.Enabled = false;
            cutMenuItem.Visible = true;
            cutMenuItem.Shortcut = Shortcut.CtrlX;
            cutMenuItem.Text = "Cut";
            cutMenuItem.Click += new EventHandler(cutMenuItem_Click);

            // copyMenuItem
            copyMenuItem.Enabled = false;
            copyMenuItem.Shortcut = Shortcut.CtrlC;
            copyMenuItem.Text = "Copy";
            copyMenuItem.Click += new EventHandler(copyMenuItem_Click);

            // pasteMenuItem
            pasteMenuItem.Shortcut = Shortcut.CtrlV;
            pasteMenuItem.Text = "Paste";
            pasteMenuItem.Click += new EventHandler(pasteMenuItem_Click);

            // deleteMenuItem
            deleteMenuItem.Enabled = false;
            deleteMenuItem.Shortcut = Shortcut.Del;
            deleteMenuItem.Text = "Delete";
            deleteMenuItem.Click += new EventHandler(deleteMenuItem_Click);

            // findMenuItem
            findMenuItem.Enabled = false;
            findMenuItem.Shortcut = Shortcut.CtrlF;
            findMenuItem.Text = "Find";
            findMenuItem.Click += new EventHandler(findMenuItem_Click);

            // findNextMenuItem
            findNextMenuItem.Enabled = false;
            findNextMenuItem.Shortcut = Shortcut.F3;
            findNextMenuItem.Text = "Find Next";
            findNextMenuItem.Click += new EventHandler(findNextMenuItem_Click);

            // replaceMenuItem
            replaceMenuItem.Enabled = false;
            replaceMenuItem.Shortcut = Shortcut.CtrlH;
            replaceMenuItem.Text = "Replace";

            // goToMenuItem
            goToMenuItem.Enabled = false;
            goToMenuItem.Shortcut = Shortcut.CtrlG;
            goToMenuItem.Text = "Go to";

            // selectAllMenuItem
            selectAllMenuItem.Shortcut = Shortcut.CtrlA;
            selectAllMenuItem.Text = "Select All";
            selectAllMenuItem.Click += new EventHandler(selectAllMenuItem_Click);

            // timeDateMenuItem
            timeDateMenuItem.Shortcut = Shortcut.F5;
            timeDateMenuItem.Text = "Time/Date";
            timeDateMenuItem.Click += new EventHandler(timeDateMenuItem_Click);
            #endregion

            #region FormatMenuItem Setup
            // formatMenuItem
            formatMenuItem.MenuItems.Add(wordWrapMenuItem);
            formatMenuItem.MenuItems.Add(fontMenuItem);
            formatMenuItem.MenuItems.Add(colorMenuItem);
            formatMenuItem.Text = "Format";

            // wordWrapMenuItem
            wordWrapMenuItem.Text = "Word Wrap";
            wordWrapMenuItem.Click += new EventHandler(wordWrapMenuItem_Click);

            // fontMenuItem
            fontMenuItem.Text = "Font";
            fontMenuItem.Click += new EventHandler(fontMenuItem_Click);

            // colorMenuItem
            colorMenuItem.Text = "Color";
            colorMenuItem.Click += new EventHandler(colorMenuItem_Click);
            #endregion

            #region ViewMenuItem Setup
            // viewMenuItem
            viewMenuItem.MenuItems.Add(statusBarMenuItem);
            viewMenuItem.Text = "View";

            // statusBarMenuItem
            statusBarMenuItem.Text = "Status Bar";
            statusBarMenuItem.Click += new EventHandler(statusBarMenuItem_Click);
            #endregion

            #region HelpMenuItem Setup
            // helpMenuItem
            helpMenuItem.MenuItems.Add(aboutMenuItem);
            helpMenuItem.Text = "Help";

            // aboutMenuItem
            aboutMenuItem.Text = "About Notepad";
            aboutMenuItem.Click += new EventHandler(aboutMenuItem_Click);
            #endregion

            // rightToLeftMenuItem
            rightToLeftMenuItem.Text = "Right to left Reading order";
            rightToLeftMenuItem.Click += new EventHandler(rightToLeftMenuItem_Click);

            // dateTimePicker1 
            dateTimePicker1.Location = new System.Drawing.Point(218, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(320, 26);
            dateTimePicker1.TabIndex = 1;

            #region ContextMenu Setup
            // contextMenu
            contextMenu.MenuItems.Add(undoMenuItem2);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(cutMenuItem2);
            contextMenu.MenuItems.Add(copyMenuItem2);
            contextMenu.MenuItems.Add(pasteMenuItem2);
            contextMenu.MenuItems.Add(deleteMenuItem2);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(selectAllMenuItem2);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(rightToLeftMenuItem);

            // undoMenuItem2
            undoMenuItem2.Enabled = false;
            undoMenuItem2.Shortcut = Shortcut.CtrlZ;
            undoMenuItem2.Text = "Undo";
            undoMenuItem2.Click += new EventHandler(undoMenuItem_Click);

            // cutMenuItem2
            cutMenuItem2.Enabled = false;
            cutMenuItem2.Visible = true;
            cutMenuItem2.Shortcut = Shortcut.CtrlX;
            cutMenuItem2.Text = "Cut";
            cutMenuItem2.Click += new EventHandler(cutMenuItem_Click);

            // copyMenuItem2
            copyMenuItem2.Enabled = false;
            copyMenuItem2.Shortcut = Shortcut.CtrlC;
            copyMenuItem2.Text = "Copy";
            copyMenuItem2.Click += new EventHandler(copyMenuItem_Click);

            // pasteMenuItem2
            pasteMenuItem2.Shortcut = Shortcut.CtrlV;
            pasteMenuItem2.Text = "Paste";
            pasteMenuItem2.Click += new EventHandler(pasteMenuItem_Click);

            // deleteMenuItem2
            deleteMenuItem2.Enabled = false;
            deleteMenuItem2.Shortcut = Shortcut.Del;
            deleteMenuItem2.Text = "Delete";
            deleteMenuItem2.Click += new EventHandler(deleteMenuItem_Click);

            // selectAllMenuItem2
            selectAllMenuItem2.Shortcut = Shortcut.CtrlA;
            selectAllMenuItem2.Text = "Select All";
            selectAllMenuItem2.Click += new EventHandler(selectAllMenuItem_Click);
            #endregion

            // txtbox
            txtbox.AutoWordSelection = true;
            txtbox.ContextMenu = contextMenu;
            txtbox.Dock = DockStyle.Fill;
            txtbox.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            txtbox.Location = new System.Drawing.Point(0, 0);
            txtbox.Name = "txtbox";
            txtbox.RightToLeft = RightToLeft.No;
            txtbox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            txtbox.Size = new System.Drawing.Size(592, 297);
            txtbox.TabIndex = 2;
            txtbox.TabStop = false;
            txtbox.Text = "";
            txtbox.WordWrap = false;
            txtbox.TextChanged += new EventHandler(txtbox_TextChanged);
            txtbox.KeyUp += new KeyEventHandler(txtbox_KeyUp);
            txtbox.MouseUp += new MouseEventHandler(txtbox_MouseUp);

            // fontDialog1 
            fontDialog1.ShowColor = true;

            // statusBar1
            statusBar1.Location = new System.Drawing.Point(0, 297);
            statusBar1.Name = "statusBar1";
            statusBar1.Panels.AddRange(new StatusBarPanel[] {
            statusBarPanel1,
            statusBarPanel2});
            statusBar1.ShowPanels = true;
            statusBar1.Size = new System.Drawing.Size(592, 30);
            statusBar1.TabIndex = 3;
            statusBar1.Visible = false;
 
            // statusBarPanel1
            statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Spring;
            statusBarPanel1.Name = "statusBarPanel1";
            statusBarPanel1.Width = 367;

            // statusBarPanel2
            statusBarPanel2.MinWidth = 200;
            statusBarPanel2.Name = "statusBarPanel2";
            statusBarPanel2.Width = 200;

            // MainForm
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(592, 327);
            this.Controls.Add(txtbox);
            this.Controls.Add(statusBar1);
            this.Controls.Add(dateTimePicker1);
            //Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            this.Menu = mainMenu1;
            this.Name = "MainForm";
            this.Text = "Untitled - Notepad";
            this.Closed += new EventHandler(Form_Closed);
            ((System.ComponentModel.ISupportInitialize)(statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(statusBarPanel2)).EndInit();
            ResumeLayout(false);

        }


        private void wordWrapMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapMenuItem.Checked == false)
            {
                txtbox.WordWrap = true;
                wordWrapMenuItem.Checked = true;
            }
            else
            {
                txtbox.WordWrap = false;
                wordWrapMenuItem.Checked = false;
            }
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.Copy();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.SelectedText = "";
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.Cut();
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.Paste(); 
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.SelectionStart = 0;
            txtbox.SelectionLength = txtbox.Text.Length;
        }

        private void timeDateMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.Text = txtbox.Text + dateTimePicker1.Value;
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            txtbox.Undo();
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            txtbox.SelectionFont = fontDialog1.Font;
            txtbox.SelectionColor = fontDialog1.Color;
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            checkIfSaveFile(NEW_ACTION);
            txtbox.Clear();
            txtbox.Focus();
            Text = "Untitled - Notepad";
            statusBar1.Invalidate();
            savefile = null;
            data = "";
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            checkIfSaveFile(LOAD_ACTION);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files|*.txt|rtf files|*.rtf";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);
                txtbox.Text = reader.ReadToEnd();
                reader.Close();
            }
            Text = dlg.FileName + "-Notepad";
            savefile = dlg.FileName;
            data = txtbox.Text;
            try
            {
                statusBarPanel1.Text = "Loading " + dlg.FileName;
            }
            catch (Exception ex)
            {
                // Handle exception
                statusBarPanel1.Text = "Unable to load " + dlg.FileName;
                MessageBox.Show("Unable to load file: " + ex.Message);
            }
            
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            checkIfSaveFile(SAVE_ACTION);
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            checkIfSaveFile(SAVE_AS_ACTION);
        }

        private void statusBarMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarMenuItem.Checked == false)
            {
                statusBarMenuItem.Checked = true;
                statusBar1.Visible = true;
            }
            else
            {
                statusBarMenuItem.Checked = false;
                statusBar1.Visible = false;
            }
        }

        private void findMenuItem_Click(object sender, EventArgs e)
        {
            using (FindForm F2 = new FindForm())
            {
                if (F2.ShowDialog() == DialogResult.OK)
                {
                    FindTxt = F2.cData;

                    int str = txtbox.Find(FindTxt);
                    if (str >= 0)
                    {
                        // 將欲找尋字串長度指定給RichTextBox1控制項的SelectionLength屬性
                        txtbox.SelectionLength = FindTxt.Length;
                        // 將strstart索引值指定給SelectionStart屬性
                        txtbox.SelectionStart = str;
                        // 將插入點游標移到目前SelectionStart和SelectionLength屬性所指的字串並反白
                        txtbox.Focus();
                    }
                    else
                    {
                        DialogResult Result = MessageBox.Show("Can not find '" + FindTxt + "'", "Notepad",
                            MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        private void findNextMenuItem_Click(object sender, EventArgs e)
        {
            // To Do: get cursor's position, and find next FindTxt
                
        }

        private void rightToLeftMenuItem_Click(object sender, EventArgs e)
        {
            if (rightToLeftMenuItem.Checked == false)
            {
                txtbox.RightToLeft = RightToLeft.Yes;
                rightToLeftMenuItem.Checked = true;
            }
            else
            {
                txtbox.RightToLeft = RightToLeft.No;
                rightToLeftMenuItem.Checked = false;
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            // Link to microsoft's website.
            System.Diagnostics.Process.Start(
                "https://support.microsoft.com/zh-tw/products/windows?os=windows-10");
        }

        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtbox.SelectionColor = colorDialog1.Color;
        }

        private void txtbox_MouseUp(object sender, MouseEventArgs e)
        {
            selectedTextCheck();
        }

        private void txtbox_KeyUp(object sender, KeyEventArgs e)
        {
            selectedTextCheck();
            if (statusBarMenuItem.Checked == true)
            {
                int line = txtbox.GetLineFromCharIndex(txtbox.SelectionStart)+1;
                statusBarPanel2.Text = "Row no." + line.ToString();
            }
        }

        private void selectedTextCheck()
        {
            int len = txtbox.SelectionLength;
            if (statusBarMenuItem.Checked == true)
            {
                statusBarPanel1.Text = "Selected Text Lenght is" + len.ToString() + ".";
            }

            if (len > 0)
            {
                deleteMenuItem.Enabled = true;
                copyMenuItem.Enabled = true;
                cutMenuItem.Enabled = true;
                deleteMenuItem2.Enabled = true;
                copyMenuItem2.Enabled = true;
                cutMenuItem2.Enabled = true;
            }
            else
            {
                deleteMenuItem.Enabled = false;
                copyMenuItem.Enabled = false;
                cutMenuItem.Enabled = false;
                deleteMenuItem2.Enabled = false;
                copyMenuItem2.Enabled = false;
                cutMenuItem2.Enabled = false;
            }
        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            undoMenuItem.Enabled = true;
            undoMenuItem2.Enabled = true;
            if (txtbox.TextLength > 0)
            {
                findMenuItem.Enabled = true;
            }
            else
            {
                findMenuItem.Enabled = false;
            }
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            checkIfSaveFile(EXIT_ACTION);
            Application.Exit();
        }

        private void checkIfSaveFile(int Action)
        {
            if (txtbox.Text == data && Action != SAVE_AS_ACTION) return;
            if (savefile == null)
            {
                // not saved and loaded file
                switch (Action)
                {
                    case NEW_ACTION:
                    case LOAD_ACTION:
                    case EXIT_ACTION:
                        Boolean saveInqyery = showUpSaveQueryDialog(null);
                        if (saveInqyery) saveFileByUntitled();
                        break;
                    case SAVE_ACTION:
                    case SAVE_AS_ACTION:
                        saveFileByUntitled();
                        break;
                }
            }
            else
            {// Existed file
                switch (Action)
                {
                    case SAVE_ACTION:
                        saveFileBySpecificFile(savefile);
                        break;
                    case NEW_ACTION:
                    case EXIT_ACTION:
                    case LOAD_ACTION:
                        Boolean saveInqyery = showUpSaveQueryDialog(savefile);
                        if (saveInqyery) saveFileBySpecificFile(savefile);
                        break;
                    case SAVE_AS_ACTION:
                        saveFileByUntitled();
                        break;
                }

            }
        }

        private Boolean showUpSaveQueryDialog(string fileName)
        {
            DialogResult result;
            if (fileName == null)
            {
                result = MessageBox.Show("Do you want to save change?", "Notepad",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            else
            {
                result = MessageBox.Show("Do you want to save change to\n" +
                fileName + "?", "Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            return result == DialogResult.Yes;
        }

        private void saveFileByUntitled()
        {
            SaveFileDialog sfDlg = new SaveFileDialog();
            sfDlg.Filter = "txt files|*.txt|rtf files|*.rtf";
            sfDlg.FileName = "Untitled";
            sfDlg.AddExtension = true;
            sfDlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (DialogResult.OK == sfDlg.ShowDialog())
            {
                writeToFile(false, sfDlg);
            }
        }

        private void saveFileBySpecificFile(string fileName)
        {
            if (fileName == null)
            {
                SaveFileDialog sfDlg = new SaveFileDialog();
                sfDlg.Filter = "txt files|*.txt|rtf files|*.rtf";
                sfDlg.FileName = "Untitled";
                sfDlg.ShowDialog();


                if (sfDlg.FileName != "")
                {
                    writeToFile(false, sfDlg);
                }
            }
            else
            {
                writeToFile(true, null);
            }

        }

        private void writeToFile(Boolean useDefaultFileName, SaveFileDialog saveFileDialog)
        {
            StreamWriter sw;
            if (useDefaultFileName)
                sw = new StreamWriter(savefile, false, System.Text.Encoding.Default);    
            else 
                sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.Default);
            sw.Write(txtbox.Text);
            sw.Flush();
            sw.Close();
            if (!useDefaultFileName)
            {
                Text = saveFileDialog.FileName + "-Notepad";
                savefile = saveFileDialog.FileName;
            } 
            data = txtbox.Text;
        }
    }
}
