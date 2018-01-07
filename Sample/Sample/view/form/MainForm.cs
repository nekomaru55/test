using log4net;
using System.Reflection;
using System.Windows.Forms;

namespace Sample.view.form {
    public partial class MainForm : Form {
        #region --- [ Logger ] ---
        static ILog m_ctrlLogger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region --- [ Fields ] ---
        #endregion
        #region --- [ Constructor ] ---
        public MainForm() {
            InitializeComponent();
        }
        #endregion
        #region --- [ Events ] ---
        private void btnMessage_Click(object sender, System.EventArgs e) {
            m_ctrlLogger.Debug("[EVENT]btnMessage_Click");
            MessageBox.Show(Properties.Resources.FORM_MSG_SAMPLE,
                Properties.Resources.COM_MSG_TITLE_INFO,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion
        #region --- [ Public method ] ---
        #endregion
        #region --- [ Private method ] ---
        #endregion
    }
}
