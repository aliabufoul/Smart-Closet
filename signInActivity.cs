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
using System.Data.SqlClient;


namespace Smart_Closet
{
    [Activity(Label = "signInActivity")]
    public class signInActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signIn);

            Button signInBTN = FindViewById<Button>(Resource.Id.button1);

            EditText userN = FindViewById<EditText>(Resource.Id.editText1);
            EditText pwd = FindViewById<EditText>(Resource.Id.editText2);

            signInBTN.Click += async (object sender, EventArgs e) =>
            {
                Android.Content.Intent selectInsert = new Android.Content.Intent(this, typeof(MainActivity2));
                try
                {
                    SqlConnection connection = new SqlConnection(
                             "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT USERNAME FROM USERS WHERE USERNAME='" + userN.Text + "' AND PWD = '" + pwd.Text + "';", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        selectInsert.PutExtra("username", userN.Text);
                        StartActivity(selectInsert);
                    }
                    else
                    {
                        StartActivity(typeof(MainActivity));
                    }
                }
                catch (SqlException err)
                {
                    Console.WriteLine(err);
                }
            };
        }
    }
}