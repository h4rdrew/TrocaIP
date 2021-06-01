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
        public void setIP(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                            objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public void setGateway(string gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    ManagementBaseObject setGateway;
                    ManagementBaseObject newGateway =
                      objMO.GetMethodParameters("SetGateways");

                    newGateway["DefaultIPGateway"] = new string[] { gateway };
                    newGateway["GatewayCostMetric"] = new int[] { 1 };

                    setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                }
            }
        }

        public List<string> NetworkName()
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();

            List<string> currentNetName = new List<string>();
            //List<string> currentAdapter = new List<string>();

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

        public List<string> NetworkAdapaterName()
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();

            List<string> currentAdapter = new List<string>();

            for (int i = 0; i < networkInfo.Length; i++)
            {
                string nStatus = networkInfo[i].OperationalStatus.ToString();

                if (nStatus == "Up" && networkInfo[i].Name != "Loopback Pseudo-Interface 1")
                {
                    currentAdapter.Add(networkInfo[i].Description.ToString());
                }
            }
            return currentAdapter;
        }

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
            string test = "";

            foreach (var item in networkInfo)
            {
                if (item.Name == network)
                {
                    var hein = item.GetIPProperties();

                    foreach (var oxe in hein.GatewayAddresses)
                    {

                        test = oxe.Address.ToString();

                        if (test.Length < 15)
                        {
                            return test;
                        }
                    }
                }
            }
            return test;
        }

        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMask">The Submask IP Address</param>
        /// <param name="gateway">The gateway.</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetIPTest(string ipAddress, string subnetMask, string gateway, string networkAdapter)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(managementObject => (bool)managementObject["IPEnabled"]))
                    {
                        //var cfg = Win32_NetworkAdapterConfiguration.Build(managementObject);
                        var cfg = WMIHelper.Build<Win32_NetworkAdapterConfiguration>(managementObject);

                        if (cfg.Description != networkAdapter) continue;

                        //string fkingDesc = (string)managementObject["Description"];
                        //string fkingCaption = (string)managementObject["Caption"];
                        using (var newIP = managementObject.GetMethodParameters("EnableStatic"))
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

                                managementObject.InvokeMethod("EnableStatic", newIP, null);
                            }

                            // Set mew gateway if needed
                            //if (!String.IsNullOrEmpty(gateway))
                            //{
                            //    using (var newGateway = managementObject.GetMethodParameters("SetGateways"))
                            //    {
                            //        newGateway["DefaultIPGateway"] = new[] { gateway };
                            //        newGateway["GatewayCostMetric"] = new[] { 1 };
                            //        managementObject.InvokeMethod("SetGateways", newGateway, null);
                            //    }
                            //}

                            if(gateway == "") gateway = "0.0.0.0";

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
