using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Bluetooth;
using System.Linq;
using System.Text;
using BluetoothApplication;



namespace Smart_Closet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button signInBTN = FindViewById<Button>(Resource.Id.button1);
            Button signUpBTN = FindViewById<Button>(Resource.Id.button2);

            signInBTN.Click += mainSignInBTN_Click;
            signUpBTN.Click += mainSignUpBTN_Click;

            //Button buttonConnect = FindViewById<Button>(Resource.Id.button3);
            // Button buttonDisconnect = FindViewById<Button>(Resource.Id.button4);

            TextView connected = FindViewById<TextView>(Resource.Id.textView1);

            BluetoothHandler.connect();
            connected.Text = "Connected";
    
        }

        private void mainSignInBTN_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(signInActivity));
        }
        private void mainSignUpBTN_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(signUpActivity));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}