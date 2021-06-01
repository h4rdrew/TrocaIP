using System;
using System.Windows.Forms;

namespace SharpIP
{
    public partial class DialogBox : Form
    {
        int tempo = 15;
        // 'cod = 0' não representa nada
        // 'cod = 1' operação revertida
        // 'cod = 2' operação salva
        public DialogBox()
        {
            InitializeComponent();
            timer1.Start();

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            tempo--;
            label1.Text = tempo.ToString();

            if (tempo > 0) return;

            timer1.Stop();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public static DialogResult Dialog()
        {
            using (DialogBox frm = new DialogBox())
            {
                return frm.ShowDialog();
            }
        }


    }
}
