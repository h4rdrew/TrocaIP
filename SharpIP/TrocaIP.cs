using SharpIP.Lib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpIP
{
    public partial class TrocaIP : Form
    {
        Ipconfig ipcfg = new Ipconfig();
        string[] ipSemMascara;
        string ipComMascara;
        public TrocaIP()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PegaNomeDaRede(); //Pega os nomes das redes (network) e seta no ComboBox
            lblNetAdapterName.Text = PegaNomeDoAdaptadorDaRede(cbxNetworks.SelectedItem.ToString());
        }

        private void PegaNomeDaRede()
        {
            //----------Pega o nome da Rede----------------
            List<string> ListNetwork = ipcfg.NetworkName();

            int v = 1, p = (ListNetwork.Count / 2);

            while (ListNetwork.Count != p)
            {
                ListNetwork.RemoveAt(v);
                v = v + 1;
            }

            cbxNetworks.DataSource = ListNetwork;
        }

        private string PegaNomeDoAdaptadorDaRede(string selectedItem)
        {
            List<string> ListNetwork = ipcfg.NetworkName();

            string aux = "";
            if (ListNetwork.Contains(selectedItem))
            {
                aux = ListNetwork[(ListNetwork.IndexOf(selectedItem) + 1)];
            }
            return aux;
        }

        private void getDefaultConfig()
        {
            string selectedNetwork = (cbxNetworks.SelectedItem).ToString();

            //Get and Set IP
            ipComMascara = PegaIPapartirDoNomeDaRede(selectedNetwork);
            ipSemMascara = ipComMascara.Split('.');
            txtIP1.Text = ipSemMascara[0];
            txtIP2.Text = ipSemMascara[1];
            txtIP3.Text = ipSemMascara[2];
            txtIP4.Text = "254";

            // Get and Set SubNetMask
            txtSubNetMask.Text = ipcfg.GetSubnetMask(IPAddress.Parse(ipComMascara)).ToString();

            // Get and Set Gatway
            txtGatway.Text = ipcfg.GetGateway(selectedNetwork);
        }

        private string PegaIPapartirDoNomeDaRede(string selectedItem)
        {
            List<string> ListIP = ipcfg.GetLocalIPAddress();
            string aux = "";
            if (ListIP.Contains(selectedItem))
            {
                aux = ListIP[(ListIP.IndexOf(selectedItem) + 1)];
            }
            return aux;
        }

        public void cbx_Networks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = Convert.ToString(cbxNetworks.SelectedItem);


            // Checa o nome do Rede selecionado na ComboBox e retorna o IP como resultado na Label
            lbIpLocalAtual.Text = PegaIPapartirDoNomeDaRede(selectedItem);

            // Checa o nome do Adaptador da Rede selecionado na ComboBox e retorna para a Label
            lblNetAdapterName.Text = PegaNomeDoAdaptadorDaRede(cbxNetworks.SelectedItem.ToString());

            // Seta IP, SubNetMask e Gatway para as TextBox.
            getDefaultConfig();
        }

        private async void btnSetIP_Click(object sender, EventArgs e)
        {

            ipSemMascara[3] = txtIP4.Text;
            string ipComMascara = "";

            for (int i = 0; i < ipSemMascara.Length; i++)
            {
                ipComMascara += ipSemMascara[i] + ".";
            }

            ipComMascara = ipComMascara.Remove(ipComMascara.Length - 1, 1);

            if (!Ipconfig.PingHost(ipComMascara))
            {
                // Pegando os valores
                string subnetMask = txtSubNetMask.Text;
                string gatway = txtGatway.Text;
                string networkAdapter = PegaNomeDoAdaptadorDaRede(cbxNetworks.SelectedItem.ToString());

                // Aplicando as configurações
                ipcfg.SetIPTest(ipComMascara, subnetMask, gatway, networkAdapter, "EnableStatic");

                var result = DialogBox.Dialog();

                if (result == DialogResult.Yes)
                {
                    cbx_Networks_SelectedIndexChanged(sender, e);
                    MessageBox.Show("As configurações foram mantidas.");
                    return;
                }

                if (result == DialogResult.Cancel)
                {
                    ipcfg.SetIpDHCP(networkAdapter);

                    await PausaComTaskDelay();
                    cbx_Networks_SelectedIndexChanged(sender, e);

                    MessageBox.Show("As configurações serão revertidas pois tempo de espera expirou.");

                    return;
                }

                if (result == DialogResult.No)
                {
                    ipcfg.SetIpDHCP(networkAdapter);

                    await PausaComTaskDelay();
                    cbx_Networks_SelectedIndexChanged(sender, e);

                    MessageBox.Show("As configurações serão revertidas.");

                    return;
                }
            }
            else
            {
                MessageBox.Show("Existe conflito com esse endereço de IP.\r\nNão foi feito alteração.");
            }
        }
        async Task PausaComTaskDelay()
        {
            await Task.Delay(1000);
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            if (BackColor == System.Drawing.Color.FromArgb(13, 75, 126))
            {
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            }
            else BackColor = System.Drawing.Color.FromArgb(13, 75, 126);
        }
    }
}
