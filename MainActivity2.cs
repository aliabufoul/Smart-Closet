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
using System.Data.SqlClient;



namespace Smart_Closet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity2 : AppCompatActivity
    {
        string username;
        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main2);

            Button insertBTN = FindViewById<Button>(Resource.Id.button1);
            Button selectBTN = FindViewById<Button>(Resource.Id.button2);

            TextView helloText = FindViewById<TextView>(Resource.Id.textView1);

            insertBTN.Click += mainInsertBTN_ClickAsync;
            selectBTN.Click += mainSelectBTN_Click;

            username = Intent.GetStringExtra("username") ?? string.Empty;

            helloText.Text = "Hello " + username + ",  Choose Your Activity:";

        }

        private async void mainInsertBTN_ClickAsync(object sender, EventArgs e)
        {
            int n=0;
            try
            {
                SqlConnection connection = new SqlConnection(
                         "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                connection.Open();
                SqlCommand command = new SqlCommand("(select min(CELLNUM) from (SELECT CELLNUM FROM CELLS except (SELECT CELLNUM FROM ITEMS WHERE username = '" + username + "' and incloset = 1)) diff)", connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("test1:{0}", reader);
                if (reader.HasRows)
                {
                    reader.Read();
                     n = reader.GetInt32(0);
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            catch (SqlException err)
            {
                // Console.WriteLine(err); //todo
            }
            await BluetoothHandler.sendAsync(n-1);

            Android.Content.Intent insert = new Android.Content.Intent(this, typeof(insertMainActivity));
            insert.PutExtra("username", username);
            insert.PutExtra("currCell", n);
            StartActivity(insert);
        }
        private void mainSelectBTN_Click(object sender, EventArgs e)
        {
            Android.Content.Intent select = new Android.Content.Intent(this, typeof(FilterActivity));
            select.PutExtra("username", username);
            StartActivity(select);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}