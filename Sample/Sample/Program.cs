using log4net;
using Sample.view.form;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Sample {
    static class Program {
        #region --- [ Logger ] ---
        static ILog m_ctrlLogger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        [STAThread]
        static void Main() {
            m_ctrlLogger.Info("Start Application.");
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } catch (Exception ex) {
                m_ctrlLogger.Fatal(ex);
                MessageBox.Show(string.Format(Properties.Resources.APP_MSG_SYSTEM_ERROR, ex.Message),
                    Properties.Resources.COM_MSG_DLG_CAPTION_EXCEPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {
                m_ctrlLogger.Info("End Application.");
            }
        }
    }
}
