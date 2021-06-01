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

        public List<string> NetworkIdentifier()
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();

            List<string> currentNetName = new List<string>();

            for (int i = 0; i < networkInfo.Length; i++)
            {
                string nStatus = networkInfo[i].OperationalStatus.ToString();

                if (nStatus == "Up" && networkInfo[i].Name != "Loopback Pseudo-Interface 1")
                {
                    currentNetName.Add(networkInfo[i].Name.ToString());
                }
            }
            return currentNetName;
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
    }
}
