using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace SharpIP.Lib
{
    public class Ipconfig
    {
        /// <summary>
        /// Pega o nome das Redes e Adaptadores respectivos e retorna em uma lista.
        /// </summary>
        public List<string> NetworkName()
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();

            List<string> currentNetName = new List<string>();

            for (int i = 0; i < networkInfo.Length; i++)
            {
                string nStatus = networkInfo[i].OperationalStatus.ToString();

                if (nStatus == "Up" && networkInfo[i].Name != "Loopback Pseudo-Interface 1")
                {
                    currentNetName.Add(networkInfo[i].Name.ToString());
                    currentNetName.Add(networkInfo[i].Description.ToString());
                }
            }
            return currentNetName;
        }

        /// <summary>
        /// Pega os IP(s) local e retorna em uma Lista.
        /// </summary>
        public List<string> GetLocalIPAddress()
        {

            List<string> ListIP = new List<string>();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    ListIP.Add(ni.Name);
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ListIP.Add(ip.Address.ToString());
                            Console.WriteLine(ip.Address.ToString());
                        }
                    }
                }
            }
            return ListIP;
        }

        /// <summary>
        /// Localiza a Máscara de Subrede a partir do endereço de IP
        /// </summary>
        /// <param name="address">Endereço do IP</param>
        public IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

        /// <summary>
        /// Localiza o Gatway a patir do nome da Rede (network)
        /// </summary>
        /// <param name="network">Nome da Rede(network)</param>
        public string GetGateway(string network)
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();
            string gatewayAdress = "";

            foreach (var item in networkInfo)
            {
                if (item.Name == network)
                {
                    var itensDeGateway = item.GetIPProperties();

                    foreach (var adress in itensDeGateway.GatewayAddresses)
                    {

                        gatewayAdress = adress.Address.ToString();

                        if (gatewayAdress.Length < 15)
                        {
                            return gatewayAdress;
                        }
                    }
                }
            }
            return gatewayAdress;
        }

        public void SetIpDHCP(string networkAdapter)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(managementObject => (bool)managementObject["IPEnabled"]))
                    {
                        var cfg = WMIHelper.Build<Win32_NetworkAdapterConfiguration>(managementObject);

                        if (cfg.Description != networkAdapter) continue;

                        using (var newIP = managementObject.GetMethodParameters("EnableDHCP"))
                        {
                            managementObject.InvokeMethod("EnableDHCP", newIP, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMask">The Submask IP Address</param>
        /// <param name="gateway">The gateway.</param>
        /// <param name="IPstatus">EnableDHCP or EnableStatic.</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetIPTest(string ipAddress, string subnetMask, string gateway, string networkAdapter, string IPstatus)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(managementObject => (bool)managementObject["IPEnabled"]))
                    {
                        var cfg = WMIHelper.Build<Win32_NetworkAdapterConfiguration>(managementObject);

                        if (cfg.Description != networkAdapter) continue;

                        //if (IPstatus == "EnableDHCP")
                        //{

                        //    using (var newIP = managementObject.GetMethodParameters($"{IPstatus}"))
                        //    {
                        //        managementObject.InvokeMethod($"{IPstatus}", newIP, null);
                        //    }

                        //}
                        if (IPstatus == "EnableStatic")
                        {
                            using (var newIP = managementObject.GetMethodParameters($"{IPstatus}"))
                            {
                                // Set new IP address and subnet if needed
                                if ((!String.IsNullOrEmpty(ipAddress)) || (!String.IsNullOrEmpty(subnetMask)))
                                {
                                    if (!String.IsNullOrEmpty(ipAddress))
                                    {
                                        newIP["IPAddress"] = new[] { ipAddress };
                                    }

                                    if (!String.IsNullOrEmpty(subnetMask))
                                    {
                                        newIP["SubnetMask"] = new[] { subnetMask };
                                    }

                                    managementObject.InvokeMethod($"{IPstatus}", newIP, null);
                                }

                                // Set mew gateway if needed
                                if (!String.IsNullOrEmpty(gateway))
                                {
                                    using (var newGateway = managementObject.GetMethodParameters("SetGateways"))
                                    {
                                        newGateway["DefaultIPGateway"] = new[] { gateway };
                                        newGateway["GatewayCostMetric"] = new[] { 1 };
                                        managementObject.InvokeMethod("SetGateways", newGateway, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
