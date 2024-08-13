using RabbitMQCore;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RabbitMQConsumer
{
    public partial class frmMain : Form
    {
        CancellationTokenSource ctsStartTopicListen = null;
        CancellationTokenSource ctsStartDirectListen = null;
        public frmMain()
        {
            InitializeComponent();
        }
        string listenString = "Listen";
        string stopString = "Stop";
        private async void btnStartTopicListen_Click(object s, EventArgs e)
        {

            if (ctsStartTopicListen != null && !ctsStartTopicListen.IsCancellationRequested)
            {
                ctsStartTopicListen.Cancel();
                btnStartTopicListen.Text = listenString;
            }
            else
            {
                ctsStartTopicListen = new CancellationTokenSource();
                btnStartTopicListen.Text = stopString;

                var res = await RabbitMQHelper.Instance.ListenTopicAsync(new Uri(RabbitMQCore.Constants.ConnectionUrl), txtRoutingKey.Text.Trim(), txtExchangeName.Text.Trim(), rtbLog, ctsStartTopicListen.Token);
            }
        }

        private async void btnStartDirectListen_Click(object sender, EventArgs e)
        {

            if (ctsStartDirectListen != null && !ctsStartDirectListen.IsCancellationRequested)
            {
                ctsStartDirectListen.Cancel();
                btnStartDirectListen.Text = listenString;
            }
            else
            {
                ctsStartDirectListen = new CancellationTokenSource();
                btnStartDirectListen.Text = stopString;

                var res = await RabbitMQHelper.Instance.ListenDirectAsync(new Uri(RabbitMQCore.Constants.ConnectionUrl), txtRoutingKey.Text.Trim(), rtbLog, ctsStartDirectListen.Token);
            }
        }
        private void frmNewInstance_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
        }


    }
}
