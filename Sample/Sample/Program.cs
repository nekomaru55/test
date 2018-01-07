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
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            m_ctrlLogger.Info("Start Application.");
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } catch (Exception ex) {
                m_ctrlLogger.Fatal(ex);
            } finally {
                m_ctrlLogger.Info("End Application.");
            }
        }
    }
}
