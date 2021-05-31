
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbIpLocalAtual
            // 
            this.lbIpLocalAtual.AutoSize = true;
            this.lbIpLocalAtual.Location = new System.Drawing.Point(67, 9);
            this.lbIpLocalAtual.Name = "lbIpLocalAtual";
            this.lbIpLocalAtual.Size = new System.Drawing.Size(66, 13);
            this.lbIpLocalAtual.TabIndex = 0;
            this.lbIpLocalAtual.Text = "IpLocalAutal";
            // 
            // lbIpLocalAtual_
            // 
            this.lbIpLocalAtual_.AutoSize = true;
            this.lbIpLocalAtual_.Location = new System.Drawing.Point(12, 9);
            this.lbIpLocalAtual_.Name = "lbIpLocalAtual_";
            this.lbIpLocalAtual_.Size = new System.Drawing.Size(49, 13);
            this.lbIpLocalAtual_.TabIndex = 1;
            this.lbIpLocalAtual_.Text = "IP Local:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbIpLocalAtual_);
            this.Controls.Add(this.lbIpLocalAtual);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIpLocalAtual;
        private System.Windows.Forms.Label lbIpLocalAtual_;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

