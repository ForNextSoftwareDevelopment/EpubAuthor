using System;
using System.Windows.Forms;

namespace EpubAuthor
{
    public partial class FormProgress : Form
    {
        #region Members

        public bool cancelled;

        #endregion

        #region Constructor

        public FormProgress()
        {
            InitializeComponent();

            cancelled = false;
        }

        #endregion

        #region Methods

        public void SetValue(int value, int total)
        {
            lblFromTo.Text = value.ToString() + " From " + total.ToString();
            if (total > 0)
            {
                progressBar.Value = 100 * value / total;
            }   else
            {
                progressBar.Value = 0;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Cancel receiving mails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            Close();
        }

        #endregion
    }
}
