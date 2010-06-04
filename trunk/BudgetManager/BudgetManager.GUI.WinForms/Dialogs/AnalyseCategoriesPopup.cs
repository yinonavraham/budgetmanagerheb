using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.BusinessLayar;
using System.Threading;
using BudgetManager.Data;

namespace BudgetManager.GUI.WinForms.Dialogs
{
    public partial class AnalyseCategoriesPopup : Form
    {
        private delegate void SetMessageCallback(String message);
        private delegate void SetProgressCallback(int percentage);


        public AnalyseCategoriesPopup()
        {
            InitializeComponent();
            this.btnOK.Enabled = false;
            this.progressBar.Value = 0;

            CategorySuggestionManager.Instance.CalculationStarted +=
                new BudgetManager.Data.ProgressReportEventHandler(SuggestionManager_CalculationStarted);
            CategorySuggestionManager.Instance.CalculationFinished +=
                new BudgetManager.Data.ProgressReportEventHandler(SuggestionManager_CalculationFinished);
            CategorySuggestionManager.Instance.TransactionCounted +=
                new BudgetManager.Data.ProgressReportEventHandler(SuggestionManager_TransactionCounted);
            CategorySuggestionManager.Instance.SuggestionValidated +=
                new BudgetManager.Data.ProgressReportEventHandler(SuggestionManager_SuggestionValidated);
        }


        private void SuggestionManager_CalculationStarted(object sender, ProgressReportEventArgs args)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new ProgressReportEventHandler(SuggestionManager_CalculationStarted), sender, args);
            }
            else
            {
                this.progressBar.Maximum = args.TotalIterations;
                this.progressBar.Value = 0;
                SetMessage("מונה תנועות...");
            }
        }


        private void SuggestionManager_CalculationFinished(object sender, ProgressReportEventArgs args)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new ProgressReportEventHandler(SuggestionManager_CalculationFinished), sender, args);
            }
            else
            {
                SetMessage(String.Format("הושלם. נמצאו {0} הצעות.", args.TotalIterations));
                SetProgress(100);
            }
        }


        private void SuggestionManager_TransactionCounted(object sender, ProgressReportEventArgs args)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new ProgressReportEventHandler(SuggestionManager_TransactionCounted), sender, args);
            }
            else
            {
                this.progressBar.PerformStep();
            }
        }


        private void SuggestionManager_SuggestionValidated(object sender, ProgressReportEventArgs args)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new ProgressReportEventHandler(SuggestionManager_SuggestionValidated), sender, args);
            }
            else
            {
                if (args.CurrentIteration == 1)
                {
                    this.progressBar.Maximum = args.TotalIterations;
                    SetProgress(0);
                    SetMessage("מחשב הצעות...");
                }
                this.progressBar.PerformStep();
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.bgwAnalyseCategories.IsBusy)
            {
                this.bgwAnalyseCategories.CancelAsync();
            }
        }


        private void bgwAnalyseCategories_DoWork(object sender, DoWorkEventArgs e)
        {
            CategorySuggestionManager.Instance.CalculateSuggestions(TransactionsManager.Instance.Transactions);
        }


        private void bgwAnalyseCategories_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        private void bgwAnalyseCategories_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                this.btnOK.Enabled = true;
                this.btnCancel.Enabled = false;
            }
            else if (e.Error != null)
            {
                SetMessage("אירעה שגיאה!");
                this.toolTip.SetToolTip(this.lblMessage, e.Error.Message);
            }
        }


        private void AnalyseCategoriesPopup_Load(object sender, EventArgs e)
        {
            this.bgwAnalyseCategories.RunWorkerAsync();
        }


        private void SetMessage(String message)
        {
            if (this.lblMessage.InvokeRequired)
            {
                this.lblMessage.Invoke(new SetMessageCallback(SetMessage), message);
            }
            else
            {
                this.lblMessage.Text = message;
            }
        }


        private void SetProgress(int percentage)
        {
            if (this.lblMessage.InvokeRequired)
            {
                this.lblMessage.Invoke(new SetProgressCallback(SetProgress), percentage);
            }
            else
            {
                this.progressBar.Value = (int)((double)percentage / 100.0 * (double)this.progressBar.Maximum);
            }
        }
    }
}
