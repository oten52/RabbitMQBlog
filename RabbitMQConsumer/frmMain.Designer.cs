namespace RabbitMQConsumer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnStartDirectListen = new System.Windows.Forms.Button();
            this.txtRoutingKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExchangeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartTopicListen = new System.Windows.Forms.Button();
            this.frmNewInstance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLog.Location = new System.Drawing.Point(0, 124);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(434, 195);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnStartDirectListen
            // 
            this.btnStartDirectListen.Location = new System.Drawing.Point(210, 91);
            this.btnStartDirectListen.Name = "btnStartDirectListen";
            this.btnStartDirectListen.Size = new System.Drawing.Size(103, 23);
            this.btnStartDirectListen.TabIndex = 1;
            this.btnStartDirectListen.Text = "Listen Direct";
            this.btnStartDirectListen.UseVisualStyleBackColor = true;
            this.btnStartDirectListen.Click += new System.EventHandler(this.btnStartDirectListen_Click);
            // 
            // txtRoutingKey
            // 
            this.txtRoutingKey.Location = new System.Drawing.Point(102, 65);
            this.txtRoutingKey.Name = "txtRoutingKey";
            this.txtRoutingKey.Size = new System.Drawing.Size(320, 20);
            this.txtRoutingKey.TabIndex = 2;
            this.txtRoutingKey.Text = "printer.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Routing Key :";
            // 
            // txtExchangeName
            // 
            this.txtExchangeName.Location = new System.Drawing.Point(102, 39);
            this.txtExchangeName.Name = "txtExchangeName";
            this.txtExchangeName.Size = new System.Drawing.Size(320, 20);
            this.txtExchangeName.TabIndex = 2;
            this.txtExchangeName.Text = "printer-exchange";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exchange Name :";
            // 
            // btnStartTopicListen
            // 
            this.btnStartTopicListen.Location = new System.Drawing.Point(319, 91);
            this.btnStartTopicListen.Name = "btnStartTopicListen";
            this.btnStartTopicListen.Size = new System.Drawing.Size(103, 23);
            this.btnStartTopicListen.TabIndex = 1;
            this.btnStartTopicListen.Text = "Listen Topic";
            this.btnStartTopicListen.UseVisualStyleBackColor = true;
            this.btnStartTopicListen.Click += new System.EventHandler(this.btnStartTopicListen_Click);
            // 
            // frmNewInstance
            // 
            this.frmNewInstance.Location = new System.Drawing.Point(332, 10);
            this.frmNewInstance.Name = "frmNewInstance";
            this.frmNewInstance.Size = new System.Drawing.Size(90, 23);
            this.frmNewInstance.TabIndex = 1;
            this.frmNewInstance.Text = "New Consumer";
            this.frmNewInstance.UseVisualStyleBackColor = true;
            this.frmNewInstance.Click += new System.EventHandler(this.frmNewInstance_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExchangeName);
            this.Controls.Add(this.txtRoutingKey);
            this.Controls.Add(this.frmNewInstance);
            this.Controls.Add(this.btnStartTopicListen);
            this.Controls.Add(this.btnStartDirectListen);
            this.Controls.Add(this.rtbLog);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orçun TEN :: RabbitMq Consumer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnStartDirectListen;
        private System.Windows.Forms.TextBox txtRoutingKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExchangeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartTopicListen;
        private System.Windows.Forms.Button frmNewInstance;
    }
}

