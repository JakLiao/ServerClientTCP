namespace ServerClientTCP
{
    partial class ClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Information = new System.Windows.Forms.Label();
            this.R_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.T_Port = new System.Windows.Forms.TextBox();
            this.T_IPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.R_SendMessage = new System.Windows.Forms.RichTextBox();
            this.B_SendMessage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // L_Information
            // 
            this.L_Information.AutoSize = true;
            this.L_Information.Location = new System.Drawing.Point(44, 345);
            this.L_Information.Name = "L_Information";
            this.L_Information.Size = new System.Drawing.Size(0, 12);
            this.L_Information.TabIndex = 21;
            // 
            // R_ReceiveMessage
            // 
            this.R_ReceiveMessage.Location = new System.Drawing.Point(320, 49);
            this.R_ReceiveMessage.Name = "R_ReceiveMessage";
            this.R_ReceiveMessage.Size = new System.Drawing.Size(240, 309);
            this.R_ReceiveMessage.TabIndex = 20;
            this.R_ReceiveMessage.Text = "";
            // 
            // T_Port
            // 
            this.T_Port.Location = new System.Drawing.Point(125, 57);
            this.T_Port.Name = "T_Port";
            this.T_Port.Size = new System.Drawing.Size(170, 21);
            this.T_Port.TabIndex = 19;
            this.T_Port.Text = "10001";
            // 
            // T_IPAddress
            // 
            this.T_IPAddress.Location = new System.Drawing.Point(125, 17);
            this.T_IPAddress.Name = "T_IPAddress";
            this.T_IPAddress.Size = new System.Drawing.Size(170, 21);
            this.T_IPAddress.TabIndex = 18;
            this.T_IPAddress.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "IPAddress:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Send Message:";
            // 
            // R_SendMessage
            // 
            this.R_SendMessage.Location = new System.Drawing.Point(44, 136);
            this.R_SendMessage.Name = "R_SendMessage";
            this.R_SendMessage.Size = new System.Drawing.Size(251, 193);
            this.R_SendMessage.TabIndex = 13;
            this.R_SendMessage.Text = "";
            this.R_SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.R_SendMessage_KeyPress);
            // 
            // B_SendMessage
            // 
            this.B_SendMessage.Location = new System.Drawing.Point(193, 335);
            this.B_SendMessage.Name = "B_SendMessage";
            this.B_SendMessage.Size = new System.Drawing.Size(102, 23);
            this.B_SendMessage.TabIndex = 11;
            this.B_SendMessage.Text = "SendMessage";
            this.B_SendMessage.UseVisualStyleBackColor = true;
            this.B_SendMessage.Click += new System.EventHandler(this.B_SendMessage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "Received Message:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 374);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L_Information);
            this.Controls.Add(this.R_ReceiveMessage);
            this.Controls.Add(this.T_Port);
            this.Controls.Add(this.T_IPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R_SendMessage);
            this.Controls.Add(this.B_SendMessage);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Information;
        private System.Windows.Forms.RichTextBox R_ReceiveMessage;
        private System.Windows.Forms.TextBox T_Port;
        private System.Windows.Forms.TextBox T_IPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox R_SendMessage;
        private System.Windows.Forms.Button B_SendMessage;
        private System.Windows.Forms.Label label2;
    }
}

