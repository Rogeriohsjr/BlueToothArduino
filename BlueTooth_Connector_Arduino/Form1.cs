using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueTooth_Connector_Arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> objListDevices = new List<string>();

            BluetoothDeviceInfo[] devices;
            using (BluetoothClient sdp = new BluetoothClient())
            {
                devices = sdp.DiscoverDevices();
            }

            
            foreach (BluetoothDeviceInfo deviceInfo in devices)
            {
                //TODO: Remove it
                if (deviceInfo.DeviceName.IndexOf("Rogerio") == -1)
                    continue;

                deviceInfo.Refresh();
                objListDevices.Add(deviceInfo.DeviceName + " - " + deviceInfo.DeviceAddress);

                //foreach (Guid pService in deviceInfo.InstalledServices)
                //{
                //    BluetoothListener objListener = new BluetoothListener(pService);

                //    BluetoothEndPoint ep = new BluetoothEndPoint(deviceInfo.DeviceAddress, pService);
                //    BluetoothClient cli = new BluetoothClient(ep);
                //}

                //this works
                //BluetoothSecurity.RemoveDevice(deviceInfo.DeviceAddress);
                //BluetoothSecurity.SetPin(deviceInfo.DeviceAddress, "0000");
            }

            cbListDevices.Items.Clear();

            foreach (string pDevice in objListDevices)
            {
                cbListDevices.Items.Add(pDevice);
            }

            if (cbListDevices.Items.Count > 0)
            {
                cbListDevices.SelectedIndex = 0;
            }
        }

        private void SendMessage(string pAddress, string pMessage)
        {
            try
            {
                BluetoothAddress objDeviceAddress = BluetoothAddress.Parse(pAddress);

                BluetoothDeviceInfo objDevice = new BluetoothDeviceInfo(objDeviceAddress);

                if (objDevice.Remembered && !objDevice.Connected && objDevice.Authenticated)
                {
                    BluetoothSecurity.PairRequest(objDevice.DeviceAddress, "0000");
                }
                else
                {
                    BluetoothSecurity.SetPin(objDevice.DeviceAddress, "0000");
                }

                Guid serviceClass = BluetoothService.SerialPort;
                BluetoothEndPoint ep = new BluetoothEndPoint(objDeviceAddress, serviceClass);

                BluetoothClient cli = new BluetoothClient();
                cli.Connect(ep);
                Stream peerStream = cli.GetStream();

                byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(pMessage);
                peerStream.Write(bMessage, 0, bMessage.Length);

                peerStream.Close();
                cli.Close();
            }
            catch (SocketException ex)
            {
                string reason;
                switch (ex.ErrorCode)
                {
                    case 10048: // SocketError.AddressAlreadyInUse
                        // RFCOMM only allow _one_ connection to a remote service from each device.
                        reason = "There is an existing connection to the remote Chat2 Service";
                        break;
                    case 10049: // SocketError.AddressNotAvailable
                        reason = "Chat2 Service not running on remote device";
                        break;
                    case 10064: // SocketError.HostDown
                        reason = "Chat2 Service not using RFCOMM (huh!!!)";
                        break;
                    case 10013: // SocketError.AccessDenied:
                        reason = "Authentication required";
                        break;
                    case 10060: // SocketError.TimedOut:
                        reason = "Timed-out";
                        break;
                    default:
                        reason = null;
                        break;

                }

                lblError.Text = reason;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error unexpected! Ex[" + ex.Message + "]";
            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string pItem = cbListDevices.SelectedItem.ToString();
            SendMessage(pItem.Split('-')[1].Trim(), txtMessage.Text);
        }
    }
}
