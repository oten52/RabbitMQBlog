using RabbitMQCore;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RabbitMQBlog
{
    public partial class frmMain : Form
    {
        CancellationTokenSource ctsDirectSend;
        CancellationTokenSource ctsTopicSend;
        public frmMain()
        {
            InitializeComponent();
        }

        string sendString = "Send";
        string stopString = "Stop";

        /// <summary>
        /// Routing key'i birebir girmesi gerekir consumer'ın
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDirectSend_Click(object sender, EventArgs e)
        {

            if (ctsDirectSend != null && !ctsDirectSend.Token.IsCancellationRequested)
            {
                ctsDirectSend.Cancel();
                btnDirectSend.Text = sendString;
                WriteLog("Direct IsCancellationRequested = True");
            }
            else
            {
                ctsDirectSend = new CancellationTokenSource();
                btnDirectSend.Text = stopString;

                var res = await RabbitMQHelper.Instance.SendToQAsync(new Uri(RabbitMQCore.Constants.ConnectionUrl), txtDirectMessage.Text.Trim(), txtDirectRoutingKey.Text.Trim(), ctsDirectSend.Token);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Direct - RoutingKey: {txtTopicRoutingKey.Text.Trim()}");
                sb.AppendLine($"Res State = {res.State}");

                if (res.State != StateEnum.Success)
                {
                    sb.AppendLine($"Error Message = {res.ErrorMessage}");
                }

                WriteLog(sb.ToString());

                btnDirectSend.Text = sendString;
                ctsDirectSend = null;
            }

        }
        /// <summary>
        /// Topic ile gönderimlerde consumer # ve * ifadeleri ile sorgulama yapabiliyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnTopicSend_Click(object sender, EventArgs e)
        {
            if (ctsTopicSend != null && !ctsTopicSend.Token.IsCancellationRequested)
            {
                ctsTopicSend.Cancel();
                btnTopicSend.Text = sendString;
                WriteLog("Topic IsCancellationRequested = True");
            }
            else
            {
                ctsTopicSend = new CancellationTokenSource();
                btnTopicSend.Text = stopString;

                var res = await RabbitMQHelper.Instance.SendToQTopicAsync(new Uri(RabbitMQCore.Constants.ConnectionUrl), txtTopicMessage.Text.Trim(), txtTopicRoutingKey.Text.Trim(), txtExchangeName.Text.Trim(), ctsTopicSend.Token);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Topic - RoutingKey: {txtTopicRoutingKey.Text.Trim()}");
                sb.AppendLine($"Res State = {res.State}");

                if (res.State != StateEnum.Success)
                {
                    sb.AppendLine($"Error Message = {res.ErrorMessage}");
                }

                WriteLog(sb.ToString());

                btnTopicSend.Text = sendString;
                ctsTopicSend = null;
            }
        }

        /// <summary>
        /// WriteLog - Rtb üzerinden log tutmaya yarar
        /// </summary>
        /// <param name="message"></param>
        public void WriteLog(string message)
        {
            rtbLog.AppendText($"{DateTime.Now}{Environment.NewLine}{message}{Environment.NewLine}");
            rtbLog.Refresh();
        }
    }
}
