using SharpIP.Lib;
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

namespace SharpIP
{
    public partial class Form1 : Form
    {
        Ipconfig ipcfg = new Ipconfig();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PegaNomeDaRede(); //Pega os nomes das redes (network) e seta no ComboBox
            lb_netAdapterName.Text = PegaNomeDoAdaptadorDaRede(cbx_Networks.SelectedItem.ToString());

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

            cbx_Networks.DataSource = ListNetwork;
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
            // Seta IP, SubNetMask e Gatway para as TextBox.

            string selectedNetwork = (cbx_Networks.SelectedItem).ToString();

            txtBox_IP.Text = PegaIPapartirDoNomeDaRede(selectedNetwork); // Get IP
            txtBox_SubNetMask.Text = ipcfg.GetSubnetMask(IPAddress.Parse(txtBox_IP.Text)).ToString(); // Get SubNetMask
            txtBox_Gatway.Text = ipcfg.GetGateway(selectedNetwork); // Get Gatway
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

        private void cbx_Networks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = Convert.ToString(cbx_Networks.SelectedItem);
            // Checa o nome do Rede selecionado na ComboBox e retorna o IP como resultado na Label
            lbIpLocalAtual.Text = PegaIPapartirDoNomeDaRede(selectedItem);

            // Checa o nome do Adaptador da Rede selecionado na ComboBox e retorna para a Label
            lb_netAdapterName.Text = PegaNomeDoAdaptadorDaRede(cbx_Networks.SelectedItem.ToString());

            // Seta IP, SubNetMask e Gatway para as TextBox.
            getDefaultConfig();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            // Pegando os valores
            string ipv4 = txtBox_IP.Text;
            string subnetMask = txtBox_SubNetMask.Text;
            string gatway = txtBox_Gatway.Text;
            string networkAdapter = PegaNomeDoAdaptadorDaRede(cbx_Networks.SelectedItem.ToString());

            //string ipv4 = lbIpLocalAtual.Text;
            //string subnetMask = (ipcfg.GetSubnetMask(IPAddress.Parse(ipv4))).ToString();
            //string gatway = ipcfg.GetGateway(Convert.ToString(cbx_Networks.SelectedItem));
            //string networkAdapter = PegaNomeDoAdaptadorDaRede(cbx_Networks.SelectedItem.ToString());

            // Aplicando as configurações
            ipcfg.SetIPTest(ipv4, subnetMask, gatway, networkAdapter);
            //ipcfg.setIP(txtBox_IP.Text, txtBox_SubNetMask.Text);
            //ipcfg.setGateway(txtBox_Gatway.Text);

            var result = DialogBox.Dialog();

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("As configurações foram mantidas.");
                cbx_Networks_SelectedIndexChanged(sender, e);
                return;
            }

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("As configurações serão revertidas pois tempo de espera expirou.");

                //ipcfg.setIP(ipv4, subnetMask);
                //ipcfg.setGateway(gatway);

                cbx_Networks_SelectedIndexChanged(sender, e);
            }

            if (result == DialogResult.No)
            {
                MessageBox.Show("As configurações serão revertidas.");

                //ipcfg.setIP(ipv4, subnetMask);
                ipcfg.setGateway(gatway);

                cbx_Networks_SelectedIndexChanged(sender, e);
            }

        }
    }
}
