using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BluetoothApplication;


namespace Smart_Closet
{
    [Activity(Label = "DoneActivity")]
    public class DoneActivity : Activity
    {
        string username;
        int n;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.done);

            Button doneBTN = FindViewById<Button>(Resource.Id.button1);

            doneBTN.Click += mainDoneBTN_ClickAsync;

            TextView helloText = FindViewById<TextView>(Resource.Id.textView1);

            username = Intent.GetStringExtra("username") ?? string.Empty;
            n = Intent.GetIntExtra("currCell", 1);//todo

            helloText.Text = "Hello " + username + ",  Press the button when you finish:";
        }
        private async void mainDoneBTN_ClickAsync(object sender, EventArgs e)
        {
            if (n != 1)
            {
                await BluetoothHandler.sendAsync(9 - n);
            }
            Android.Content.Intent main2 = new Android.Content.Intent(this, typeof(MainActivity2));
            main2.PutExtra("username", username);
            StartActivity(main2);
        }
    }
}