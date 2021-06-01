
namespace SharpIP
{
    partial class Form1
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
            this.lbIpLocalAtual = new System.Windows.Forms.Label();
            this.lbIpLocalAtual_ = new System.Windows.Forms.Label();
            this.txtBox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Networks = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_SubNetMask = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_SetIP = new System.Windows.Forms.GroupBox();
            this.groupBox_SearchIP = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox_Gatway = new System.Windows.Forms.TextBox();
            this.groupBox_SetIP.SuspendLayout();
            this.groupBox_SearchIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbIpLocalAtual
            // 
            this.lbIpLocalAtual.AutoSize = true;
            this.lbIpLocalAtual.Location = new System.Drawing.Point(32, 31);
            this.lbIpLocalAtual.Name = "lbIpLocalAtual";
            this.lbIpLocalAtual.Size = new System.Drawing.Size(55, 13);
            this.lbIpLocalAtual.TabIndex = 0;
            this.lbIpLocalAtual.Text = "IPCombox";
            // 
            // lbIpLocalAtual_
            // 
            this.lbIpLocalAtual_.AutoSize = true;
            this.lbIpLocalAtual_.Location = new System.Drawing.Point(6, 31);
            this.lbIpLocalAtual_.Name = "lbIpLocalAtual_";
            this.lbIpLocalAtual_.Size = new System.Drawing.Size(20, 13);
            this.lbIpLocalAtual_.TabIndex = 1;
            this.lbIpLocalAtual_.Text = "IP:";
            // 
            // txtBox_IP
            // 
            this.txtBox_IP.Location = new System.Drawing.Point(32, 33);
            this.txtBox_IP.Name = "txtBox_IP";
            this.txtBox_IP.Size = new System.Drawing.Size(95, 20);
            this.txtBox_IP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // cbx_Networks
            // 
            this.cbx_Networks.FormattingEnabled = true;
            this.cbx_Networks.Location = new System.Drawing.Point(135, 28);
            this.cbx_Networks.Name = "cbx_Networks";
            this.cbx_Networks.Size = new System.Drawing.Size(186, 21);
            this.cbx_Networks.TabIndex = 4;
            this.cbx_Networks.SelectedIndexChanged += new System.EventHandler(this.cbx_Networks_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Subnet Mask:";
            // 
            // txtBox_SubNetMask
            // 
            this.txtBox_SubNetMask.Location = new System.Drawing.Point(226, 33);
            this.txtBox_SubNetMask.Name = "txtBox_SubNetMask";
            this.txtBox_SubNetMask.Size = new System.Drawing.Size(95, 20);
            this.txtBox_SubNetMask.TabIndex = 5;
            this.txtBox_SubNetMask.Text = "255.255.255.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Set IP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_SetIP
            // 
            this.groupBox_SetIP.Controls.Add(this.label3);
            this.groupBox_SetIP.Controls.Add(this.txtBox_Gatway);
            this.groupBox_SetIP.Controls.Add(this.label1);
            this.groupBox_SetIP.Controls.Add(this.button1);
            this.groupBox_SetIP.Controls.Add(this.txtBox_IP);
            this.groupBox_SetIP.Controls.Add(this.label2);
            this.groupBox_SetIP.Controls.Add(this.txtBox_SubNetMask);
            this.groupBox_SetIP.Location = new System.Drawing.Point(12, 80);
            this.groupBox_SetIP.Name = "groupBox_SetIP";
            this.groupBox_SetIP.Size = new System.Drawing.Size(425, 114);
            this.groupBox_SetIP.TabIndex = 8;
            this.groupBox_SetIP.TabStop = false;
            this.groupBox_SetIP.Text = "Set IP";
            // 
            // groupBox_SearchIP
            // 
            this.groupBox_SearchIP.Controls.Add(this.lbIpLocalAtual_);
            this.groupBox_SearchIP.Controls.Add(this.lbIpLocalAtual);
            this.groupBox_SearchIP.Controls.Add(this.cbx_Networks);
            this.groupBox_SearchIP.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SearchIP.Name = "groupBox_SearchIP";
            this.groupBox_SearchIP.Size = new System.Drawing.Size(425, 62);
            this.groupBox_SearchIP.TabIndex = 9;
            this.groupBox_SearchIP.TabStop = false;
            this.groupBox_SearchIP.Text = "Search IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gatway:";
            // 
            // txtBox_Gatway
            // 
            this.txtBox_Gatway.Location = new System.Drawing.Point(226, 59);
            this.txtBox_Gatway.Name = "txtBox_Gatway";
            this.txtBox_Gatway.Size = new System.Drawing.Size(95, 20);
            this.txtBox_Gatway.TabIndex = 8;
            this.txtBox_Gatway.Text = "192.168.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 220);
            this.Controls.Add(this.groupBox_SearchIP);
            this.Controls.Add(this.groupBox_SetIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_SetIP.ResumeLayout(false);
            this.groupBox_SetIP.PerformLayout();
            this.groupBox_SearchIP.ResumeLayout(false);
            this.groupBox_SearchIP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbIpLocalAtual;
        private System.Windows.Forms.Label lbIpLocalAtual_;
        private System.Windows.Forms.TextBox txtBox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Networks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_SubNetMask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox_SetIP;
        private System.Windows.Forms.GroupBox groupBox_SearchIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBox_Gatway;
    }
}

