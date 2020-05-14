using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BluetoothApplication
{
    class BluetoothHandler
    {
        const string DEVICE_NAME = "rzl";
        const string UUID_STRING = "00001101-0000-1000-8000-00805f9b34fb";
        const string CLASS_TAG = "BLUETOOTH";
        static BluetoothConnection myConnection = new BluetoothConnection();



        public static async System.Threading.Tasks.Task sendAsync(int n)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            byte[] buffer = uniencoding.GetBytes(n.ToString());
            await myConnection.thisSocket.OutputStream.WriteAsync(buffer, 0, buffer.Length);

        }
        public static void connect()
        {
            Log.Debug(CLASS_TAG, "connecting..");
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
                throw new Exception("No Bluetooth adapter found.");

            if (!adapter.IsEnabled)
                throw new Exception("Bluetooth adapter is not enabled.");
            BluetoothDevice device = (from bd in adapter.BondedDevices
                                      where bd.Name == "rzl"
                                      select bd).FirstOrDefault();

            if (device == null)
                throw new Exception("Named device not found.");

            BluetoothSocket _socket = null;
             _socket = device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            myConnection.thisSocket = _socket;

            try
            {
                myConnection.thisSocket.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("222");
                Log.Debug("BLUETOOTH", ex.Message);
                return;
            }
            Log.Debug(CLASS_TAG, "connected"); 

        }
        public static void disconnect()
        {
			
		}
        private class BluetoothConnection
        {
            public BluetoothSocket thisSocket { get; set; }
        }
    }
}