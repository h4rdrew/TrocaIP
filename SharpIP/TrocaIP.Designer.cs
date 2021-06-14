
namespace SharpIP
{
    partial class TrocaIP
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
            this.cbxNetworks = new System.Windows.Forms.ComboBox();
            this.lblSubNetMask = new System.Windows.Forms.Label();
            this.txtSubNetMask = new System.Windows.Forms.TextBox();
            this.btnSetIP = new System.Windows.Forms.Button();
            this.gbxSetIP = new System.Windows.Forms.GroupBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP4 = new System.Windows.Forms.TextBox();
            this.txtIP3 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.lblGateway = new System.Windows.Forms.Label();
            this.txtGatway = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.gbxSearchIP = new System.Windows.Forms.GroupBox();
            this.lblNetAdapterName = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSharpSistemas = new System.Windows.Forms.Label();
            this.gbxSetIP.SuspendLayout();
            this.gbxSearchIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIpLocalAtual
            // 
            this.lbIpLocalAtual.AutoSize = true;
            this.lbIpLocalAtual.Location = new System.Drawing.Point(32, 31);
            this.lbIpLocalAtual.Name = "lbIpLocalAtual";
            this.lbIpLocalAtual.Size = new System.Drawing.Size(56, 13);
            this.lbIpLocalAtual.TabIndex = 0;
            this.lbIpLocalAtual.Text = "IPCombox";
            // 
            // lbIpLocalAtual_
            // 
            this.lbIpLocalAtual_.AutoSize = true;
            this.lbIpLocalAtual_.Location = new System.Drawing.Point(6, 31);
            this.lbIpLocalAtual_.Name = "lbIpLocalAtual_";
            this.lbIpLocalAtual_.Size = new System.Drawing.Size(21, 13);
            this.lbIpLocalAtual_.TabIndex = 1;
            this.lbIpLocalAtual_.Text = "IP:";
            // 
            // cbxNetworks
            // 
            this.cbxNetworks.BackColor = System.Drawing.SystemColors.Control;
            this.cbxNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNetworks.FormattingEnabled = true;
            this.cbxNetworks.Location = new System.Drawing.Point(148, 31);
            this.cbxNetworks.Name = "cbxNetworks";
            this.cbxNetworks.Size = new System.Drawing.Size(203, 21);
            this.cbxNetworks.TabIndex = 4;
            this.cbxNetworks.SelectedIndexChanged += new System.EventHandler(this.cbx_Networks_SelectedIndexChanged);
            // 
            // lblSubNetMask
            // 
            this.lblSubNetMask.AutoSize = true;
            this.lblSubNetMask.Location = new System.Drawing.Point(177, 61);
            this.lblSubNetMask.Name = "lblSubNetMask";
            this.lblSubNetMask.Size = new System.Drawing.Size(72, 13);
            this.lblSubNetMask.TabIndex = 6;
            this.lblSubNetMask.Text = "Subnet Mask:";
            // 
            // txtSubNetMask
            // 
            this.txtSubNetMask.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtSubNetMask.Location = new System.Drawing.Point(256, 58);
            this.txtSubNetMask.Name = "txtSubNetMask";
            this.txtSubNetMask.ReadOnly = true;
            this.txtSubNetMask.Size = new System.Drawing.Size(95, 21);
            this.txtSubNetMask.TabIndex = 5;
            // 
            // btnSetIP
            // 
            this.btnSetIP.BackColor = System.Drawing.Color.White;
            this.btnSetIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetIP.ForeColor = System.Drawing.Color.Black;
            this.btnSetIP.Location = new System.Drawing.Point(309, 108);
            this.btnSetIP.Name = "btnSetIP";
            this.btnSetIP.Size = new System.Drawing.Size(48, 29);
            this.btnSetIP.TabIndex = 7;
            this.btnSetIP.Text = "Set IP";
            this.btnSetIP.UseVisualStyleBackColor = false;
            this.btnSetIP.Click += new System.EventHandler(this.btnSetIP_Click);
            // 
            // gbxSetIP
            // 
            this.gbxSetIP.Controls.Add(this.lblSharpSistemas);
            this.gbxSetIP.Controls.Add(this.picLogo);
            this.gbxSetIP.Controls.Add(this.lblIP);
            this.gbxSetIP.Controls.Add(this.txtIP4);
            this.gbxSetIP.Controls.Add(this.txtIP3);
            this.gbxSetIP.Controls.Add(this.txtIP2);
            this.gbxSetIP.Controls.Add(this.txtIP1);
            this.gbxSetIP.Controls.Add(this.lblGateway);
            this.gbxSetIP.Controls.Add(this.txtGatway);
            this.gbxSetIP.Controls.Add(this.btnSetIP);
            this.gbxSetIP.Controls.Add(this.lblSubNetMask);
            this.gbxSetIP.Controls.Add(this.txtSubNetMask);
            this.gbxSetIP.ForeColor = System.Drawing.Color.White;
            this.gbxSetIP.Location = new System.Drawing.Point(12, 80);
            this.gbxSetIP.Name = "gbxSetIP";
            this.gbxSetIP.Size = new System.Drawing.Size(363, 143);
            this.gbxSetIP.TabIndex = 8;
            this.gbxSetIP.TabStop = false;
            this.gbxSetIP.Text = "Set IP";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(6, 32);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(21, 13);
            this.lblIP.TabIndex = 14;
            this.lblIP.Text = "IP:";
            // 
            // txtIP4
            // 
            this.txtIP4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtIP4.Location = new System.Drawing.Point(128, 29);
            this.txtIP4.MaxLength = 3;
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.Size = new System.Drawing.Size(26, 21);
            this.txtIP4.TabIndex = 13;
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP3
            // 
            this.txtIP3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtIP3.Location = new System.Drawing.Point(96, 29);
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.ReadOnly = true;
            this.txtIP3.Size = new System.Drawing.Size(26, 21);
            this.txtIP3.TabIndex = 12;
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP2
            // 
            this.txtIP2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtIP2.Location = new System.Drawing.Point(64, 29);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.ReadOnly = true;
            this.txtIP2.Size = new System.Drawing.Size(26, 21);
            this.txtIP2.TabIndex = 11;
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP1
            // 
            this.txtIP1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtIP1.Location = new System.Drawing.Point(32, 29);
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.ReadOnly = true;
            this.txtIP1.Size = new System.Drawing.Size(26, 21);
            this.txtIP1.TabIndex = 10;
            this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.Location = new System.Drawing.Point(204, 32);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(48, 13);
            this.lblGateway.TabIndex = 9;
            this.lblGateway.Text = "Gatway:";
            // 
            // txtGatway
            // 
            this.txtGatway.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtGatway.Location = new System.Drawing.Point(256, 29);
            this.txtGatway.Name = "txtGatway";
            this.txtGatway.ReadOnly = true;
            this.txtGatway.Size = new System.Drawing.Size(95, 21);
            this.txtGatway.TabIndex = 8;
            // 
            // lblObservacao
            // 
            this.lblObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(9, 228);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(253, 13);
            this.lblObservacao.TabIndex = 10;
            this.lblObservacao.Text = "Em caso de falha será revertido para IP automático";
            // 
            // gbxSearchIP
            // 
            this.gbxSearchIP.Controls.Add(this.lblNetAdapterName);
            this.gbxSearchIP.Controls.Add(this.lbIpLocalAtual_);
            this.gbxSearchIP.Controls.Add(this.lbIpLocalAtual);
            this.gbxSearchIP.Controls.Add(this.cbxNetworks);
            this.gbxSearchIP.ForeColor = System.Drawing.Color.White;
            this.gbxSearchIP.Location = new System.Drawing.Point(12, 12);
            this.gbxSearchIP.Name = "gbxSearchIP";
            this.gbxSearchIP.Size = new System.Drawing.Size(363, 62);
            this.gbxSearchIP.TabIndex = 9;
            this.gbxSearchIP.TabStop = false;
            this.gbxSearchIP.Text = "Search IP";
            // 
            // lblNetAdapterName
            // 
            this.lblNetAdapterName.AutoSize = true;
            this.lblNetAdapterName.Location = new System.Drawing.Point(145, 16);
            this.lblNetAdapterName.Name = "lblNetAdapterName";
            this.lblNetAdapterName.Size = new System.Drawing.Size(119, 13);
            this.lblNetAdapterName.TabIndex = 5;
            this.lblNetAdapterName.Text = "Network Adapter Name";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::SharpIP.Properties.Resources.Logo_V3_512_Branco;
            this.picLogo.Location = new System.Drawing.Point(6, 61);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(116, 64);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            // 
            // lblSharpSistemas
            // 
            this.lblSharpSistemas.AutoSize = true;
            this.lblSharpSistemas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSharpSistemas.Location = new System.Drawing.Point(12, 127);
            this.lblSharpSistemas.Name = "lblSharpSistemas";
            this.lblSharpSistemas.Size = new System.Drawing.Size(105, 13);
            this.lblSharpSistemas.TabIndex = 16;
            this.lblSharpSistemas.Text = "SHARP SISTEMAS";
            // 
            // TrocaIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(75)))), ((int)(((byte)(126)))));
            this.ClientSize = new System.Drawing.Size(384, 243);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.gbxSearchIP);
            this.Controls.Add(this.gbxSetIP);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TrocaIP";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharp Sistemas - Trocar IP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxSetIP.ResumeLayout(false);
            this.gbxSetIP.PerformLayout();
            this.gbxSearchIP.ResumeLayout(false);
            this.gbxSearchIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIpLocalAtual;
        private System.Windows.Forms.Label lbIpLocalAtual_;
        private System.Windows.Forms.ComboBox cbxNetworks;
        private System.Windows.Forms.Label lblSubNetMask;
        private System.Windows.Forms.TextBox txtSubNetMask;
        private System.Windows.Forms.Button btnSetIP;
        private System.Windows.Forms.GroupBox gbxSetIP;
        private System.Windows.Forms.GroupBox gbxSearchIP;
        private System.Windows.Forms.Label lblGateway;
        private System.Windows.Forms.TextBox txtGatway;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblNetAdapterName;
        private System.Windows.Forms.TextBox txtIP1;
        private System.Windows.Forms.TextBox txtIP4;
        private System.Windows.Forms.TextBox txtIP3;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSharpSistemas;
    }
}

