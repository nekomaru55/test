using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Sample.view.form {
    public partial class MainForm : Form {
        #region --- [ Logger ] ---
        static ILog m_ctrlLogger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region --- [ Defines ] ---
        private readonly string XML_SELECT_TITLE = "title";
        private readonly string XML_SELECT_NODES = "channel/item";
        private readonly string XML_SELECT_DESCRIPTION = "link";
        // @see
        // http://kizasi.jp/tool/kizapi.html
        private readonly string KIZASI_API_REQUEST_URL = "http://kizasi.jp/kizapi.py?type=rank";
        #endregion
        #region --- [ Delegate ] ---
        delegate void updateDataGridViewDelegate(string strXml);
        #endregion
        #region --- [ Events ] ---
        private void btnSearch_Click(object sender, EventArgs e) {
            m_ctrlLogger.Debug("[EVENT](START)Click");
            try {
                if (bkwTask.IsBusy) {
                    m_ctrlLogger.Warn("In progress...");
                    return;
                }
                btnSearch.Enabled = false;
                bkwTask.RunWorkerAsync();
            } finally {
                m_ctrlLogger.Debug("[EVENT](END)Click");
            }
        }
        private void dgvRankResult_CellClick(object sender, DataGridViewCellEventArgs e) {
            //TODO DataGridViewの使い方...分からない。。。2って…知識なし( ﾟДﾟ)
            m_ctrlLogger.Debug("[EVENT](START)CellClick");
            if (e.RowIndex == -1 || e.ColumnIndex != 2) {
                return;
            }
            try {
                Process.Start((string)dgvRankResult.CurrentRow.Cells[2].Value);
            } catch (Exception ex) {
                m_ctrlLogger.Error(ex);
            }
            m_ctrlLogger.Debug("[EVENT](END)CellClick");
        }
        private void bkwTask_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            m_ctrlLogger.Debug("[EVENT](START)DoWork");
            getRankingSearch();
            m_ctrlLogger.Debug("[EVENT](END)DoWork");
        }

        private void bkwTask_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            m_ctrlLogger.Debug("[EVENT](START)RunWorkerCompleted");
            btnSearch.Enabled = true;
            m_ctrlLogger.Debug("[EVENT](END)RunWorkerCompleted");
        }
        #endregion
        #region --- [ Constructor ] ---
        public MainForm() {
            InitializeComponent();
        }
        #endregion
        #region --- [ Private method ] ---
        private async void getRankingSearch() {
            string result = string.Empty;
            try {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(KIZASI_API_REQUEST_URL))
                using (HttpContent content = response.Content) {
                    result = await content.ReadAsStringAsync();
                    m_ctrlLogger.InfoFormat("Response status code: {0}", response.StatusCode);
                    // Update data grid view
                    Invoke(new updateDataGridViewDelegate(updateDataGridViewResult), result);
                }
            } catch (WebException ex) {
                // Protocol error
                if (ex.Status == WebExceptionStatus.ProtocolError) {
                    HttpWebResponse errres = (HttpWebResponse)ex.Response;
                    m_ctrlLogger.ErrorFormat("Response url: {0}", errres.ResponseUri);
                    m_ctrlLogger.ErrorFormat("Response status code: {0}:{1}",
                        errres.StatusCode, errres.StatusDescription);
                }
            } catch (Exception ex) {
                m_ctrlLogger.Fatal(ex);
                MessageBox.Show(string.Format(Properties.Resources.MAIN_FORM_MSG_CONNECT_ERROR, ex.Message),
                Properties.Resources.COM_MSG_DLG_CAPTION_ERROR,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void updateDataGridViewResult(string strXml) {
            dgvRankResult.Rows.Clear();
            if (string.IsNullOrEmpty(strXml)) {
                m_ctrlLogger.Error("XML data is null or empty.");
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(strXml));
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes(XML_SELECT_NODES);
            if (nodeList == null) {
                m_ctrlLogger.Error("XML node data is null or empty.");
                return;
            } else if (nodeList.Count == 0) {
                m_ctrlLogger.Error("XML node data is empty.");
                return;
            }
            for (int i = 0; i < nodeList.Count; i++) {
                XmlNode tmp = nodeList[i];
                dgvRankResult.Rows.Add(new string[] { string.Format("{0}",i+1),
                    tmp.SelectSingleNode(XML_SELECT_TITLE).InnerText,
                    tmp.SelectSingleNode(XML_SELECT_DESCRIPTION).InnerText });
            }
        }
        #endregion
    }
}
