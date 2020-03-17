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
                   // SqlConnection connection = new SqlConnection(
                    //         "Server=tcp:smartclosetdatabase.database.windows.net,1433;Initial Catalog=smartclosetdb;Persist Security Info=False;User ID={HAGATZAR};Password={SCAMO236###};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    SqlConnection connection = new SqlConnection(
                            "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                    connection.Open();
                  //  SqlCommand command = new SqlCommand("CREATE TABLE TESTTTT (ali int);", connection);// INSERT INTO USERS (USERNAME, PWD) VALUES( '" + userName.Text + "' , '" + password.Text + "');", connection);

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