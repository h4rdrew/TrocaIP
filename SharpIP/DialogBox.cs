using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpIP.Lib;

namespace SharpIP
{
    public partial class DialogBox : Form
    {
        int tempo = 15;

        // 'cod = 0' não representa nada
        // 'cod = 1' operação revertida
        // 'cod = 2' operação salva
        int codigoOperacao = 1;
        public DialogBox()
        {
            InitializeComponent();
            timer1.Start();

        }

        public int codigoDaOperacao()
        {
            int cod = codigoOperacao;
            return cod;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            tempo--;
            label1.Text = tempo.ToString();

            if (tempo == 0)
            {
                timer1.Stop();

                MessageBox.Show("As configurações foram revertidas.");
                codigoOperacao = 1;
                this.Close();
            }
        }

        public void btnYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As configurações foram salvas.");
            codigoOperacao = 2;
            this.Close();
        }

        public void btnNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As configurações foram revertidas.");
            codigoOperacao = 1;
            this.Close();

        }
    }
}
