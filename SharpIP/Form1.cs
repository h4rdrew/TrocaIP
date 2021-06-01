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
            cbx_Networks.DataSource = ipcfg.NetworkIdentifier();
            string selectedItem = Convert.ToString(cbx_Networks.SelectedItem);
            lbIpLocalAtual.Text = Teste(selectedItem);
        }

        private string Teste(string selectedItem)
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
            lbIpLocalAtual.Text = Teste(selectedItem);
            ipcfg.GetGateway(selectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string ipv4 = lbIpLocalAtual.Text;
            
            string subnetMask = (ipcfg.GetSubnetMask(IPAddress.Parse(ipv4))).ToString();

            string gatway = ipcfg.GetGateway(Convert.ToString(cbx_Networks.SelectedItem));

            ipcfg.setIP(txtBox_IP.Text, txtBox_SubNetMask.Text);
            ipcfg.setGateway(txtBox_Gatway.Text);

            DialogBox dialogBox = new DialogBox();
            dialogBox.Show();


            // 'cod = 0' não representa nada
            // 'cod = 1' operação revertida
            // 'cod = 2' operação salva


            if (dialogBox.codigoDaOperacao() == 1)
            {
                ipcfg.setIP(ipv4, subnetMask);
                ipcfg.setGateway(gatway);
            }
            if (dialogBox.codigoDaOperacao() == 2) return;

            cbx_Networks_SelectedIndexChanged(sender, e);
        }
    }
}
