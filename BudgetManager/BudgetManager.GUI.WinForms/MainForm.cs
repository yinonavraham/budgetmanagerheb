using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.GUI.WinForms.Controls;
using BudgetManager.BusinessLayar;
using BudgetManager.Data;
using BudgetManager.GUI.WinForms.Dialogs;

namespace BudgetManager.GUI.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        #region Menu events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void help2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm form = new CategoriesForm();
            form.ShowDialog();
        }

        #endregion


        public void SetStatusMessage(String message)
        {
            this.statusMessage.Text = message == null ? "" : message;
        }


        private void importTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportTransactionsDialog dialog = new ImportTransactionsDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                foreach (CategorizedTransaction t in dialog.ImportedTransactions)
                {
                    TransactionsManager.Instance.AddTransaction(t);
                }
            }
            else
            {
            }
        }

        
        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            SetStatusMessage(""); 
            foreach (Control ctrl in e.TabPage.Controls)
            {
                if (ctrl is ITabPageSelectionChangeHandler)
                {
                    ((ITabPageSelectionChangeHandler)ctrl).TabPageDeselected();
                }
            }
        }


        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            foreach (Control ctrl in e.TabPage.Controls)
            {
                if (ctrl is ITabPageSelectionChangeHandler)
                {
                    ((ITabPageSelectionChangeHandler)ctrl).TabPageSelected();
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                CategoriesManager.Instance.Load(Properties.Settings.Default.CategoriesFilepath);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(
                    String.Format("טעינת קובץ הקטגוריות נכשלה:\r\n{0}\r\n{1}", ex.Message, "האם ברצונך לאפס את הקטגוריות?"), 
                    "שגיאה!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign|MessageBoxOptions.RtlReading);
                if (result.Equals(DialogResult.Yes))
                {
                    CategoriesManager.Instance.Reset();
                }
                return;
            }
            try
            {
                if (Properties.Settings.Default.IsLoadLastTransactionsFile)
                    TransactionsManager.Instance.Load(Properties.Settings.Default.LastTransactionsFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    String.Format("טעינת קובץ התנועות נכשלה:\r\n{0}",ex.Message), 
                    "שגיאה!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading|MessageBoxOptions.RightAlign);
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                TransactionsManager.Instance.Load(openFileDialog.FileName);
                Properties.Settings.Default.LastTransactionsFile = openFileDialog.FileName;
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                TransactionsManager.Instance.Save(saveFileDialog.FileName);
                Properties.Settings.Default.LastTransactionsFile = saveFileDialog.FileName;
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CategoriesManager.Instance.Save(Properties.Settings.Default.CategoriesFilepath);
        }


        private void analyseCategorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CategorySuggestionManager.Instance.CalculateSuggestions(TransactionsManager.Instance.Transactions);
            AnalyseCategoriesPopup popup = new AnalyseCategoriesPopup();
            popup.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.MainFormLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.MainFormSize;
            this.Location = Properties.Settings.Default.MainFormLocation;
        }
    }
}
