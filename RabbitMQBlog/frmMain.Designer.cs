namespace RabbitMQBlog
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
            this.btnDirectSend = new System.Windows.Forms.Button();
            this.txtDirectMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectRoutingKey = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTopicSend = new System.Windows.Forms.Button();
            this.txtTopicRoutingKey = new System.Windows.Forms.TextBox();
            this.txtTopicMessage = new System.Windows.Forms.TextBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.txtExchangeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDirectSend
            // 
            this.btnDirectSend.Location = new System.Drawing.Point(233, 80);
            this.btnDirectSend.Name = "btnDirectSend";
            this.btnDirectSend.Size = new System.Drawing.Size(86, 20);
            this.btnDirectSend.TabIndex = 0;
            this.btnDirectSend.Text = "Send";
            this.btnDirectSend.UseVisualStyleBackColor = true;
            this.btnDirectSend.Click += new System.EventHandler(this.btnDirectSend_Click);
            // 
            // txtDirectMessage
            // 
            this.txtDirectMessage.Location = new System.Drawing.Point(100, 54);
            this.txtDirectMessage.Name = "txtDirectMessage";
            this.txtDirectMessage.Size = new System.Drawing.Size(219, 20);
            this.txtDirectMessage.TabIndex = 1;
            this.txtDirectMessage.Text = "Test Mesajı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDirectSend);
            this.groupBox1.Controls.Add(this.txtDirectRoutingKey);
            this.groupBox1.Controls.Add(this.txtDirectMessage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 121);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direct Send";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Routing Key :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Message :";
            // 
            // txtDirectRoutingKey
            // 
            this.txtDirectRoutingKey.Location = new System.Drawing.Point(100, 28);
            this.txtDirectRoutingKey.Name = "txtDirectRoutingKey";
            this.txtDirectRoutingKey.Size = new System.Drawing.Size(219, 20);
            this.txtDirectRoutingKey.TabIndex = 1;
            this.txtDirectRoutingKey.Text = "printer.public";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnTopicSend);
            this.groupBox2.Controls.Add(this.txtExchangeName);
            this.groupBox2.Controls.Add(this.txtTopicRoutingKey);
            this.groupBox2.Controls.Add(this.txtTopicMessage);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Topic Send";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Routing Key :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Message :";
            // 
            // btnTopicSend
            // 
            this.btnTopicSend.Location = new System.Drawing.Point(233, 95);
            this.btnTopicSend.Name = "btnTopicSend";
            this.btnTopicSend.Size = new System.Drawing.Size(86, 20);
            this.btnTopicSend.TabIndex = 0;
            this.btnTopicSend.Text = "Send";
            this.btnTopicSend.UseVisualStyleBackColor = true;
            this.btnTopicSend.Click += new System.EventHandler(this.btnTopicSend_Click);
            // 
            // txtTopicRoutingKey
            // 
            this.txtTopicRoutingKey.Location = new System.Drawing.Point(100, 43);
            this.txtTopicRoutingKey.Name = "txtTopicRoutingKey";
            this.txtTopicRoutingKey.Size = new System.Drawing.Size(219, 20);
            this.txtTopicRoutingKey.TabIndex = 1;
            this.txtTopicRoutingKey.Text = "printer.private.l1";
            // 
            // txtTopicMessage
            // 
            this.txtTopicMessage.Location = new System.Drawing.Point(100, 69);
            this.txtTopicMessage.Name = "txtTopicMessage";
            this.txtTopicMessage.Size = new System.Drawing.Size(219, 20);
            this.txtTopicMessage.TabIndex = 1;
            this.txtTopicMessage.Text = "Test Mesajı";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(12, 282);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(325, 100);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // txtExchangeName
            // 
            this.txtExchangeName.Location = new System.Drawing.Point(100, 19);
            this.txtExchangeName.Name = "txtExchangeName";
            this.txtExchangeName.Size = new System.Drawing.Size(219, 20);
            this.txtExchangeName.TabIndex = 1;
            this.txtExchangeName.Text = "printer-exchange";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Exchange Name:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 394);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orçun TEN :: RabbitMq Publisher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDirectSend;
        private System.Windows.Forms.TextBox txtDirectMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectRoutingKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTopicSend;
        private System.Windows.Forms.TextBox txtTopicRoutingKey;
        private System.Windows.Forms.TextBox txtTopicMessage;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExchangeName;
    }
}

