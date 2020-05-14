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
    [Activity(Label = "signUpActivity")]
    public class signUpActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signUp);

            Button signUpBTN = FindViewById<Button>(Resource.Id.button1);

            signUpBTN.Click += async (object sender, EventArgs e) =>
            {
                EditText userName = FindViewById<EditText>(Resource.Id.editText1);
                EditText password = FindViewById<EditText>(Resource.Id.editText2);

                try
                {
                   SqlConnection connection = new SqlConnection(
                            "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO USERS (USERNAME, PWD) VALUES( '" + userName.Text + "' , '" + password.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                }
                catch (SqlException err)
                {
                    Console.WriteLine(err);
                }

                StartActivity(typeof(signInActivity));
            };
        }
    }
}