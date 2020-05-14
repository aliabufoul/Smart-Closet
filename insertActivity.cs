
//#r "System.Data"
//#r "Newtonsoft.Json"
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
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Android.Provider;
using Android.Graphics;

//#r "System.Data"
//#r "Newtonsoft.Json"
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Smart_Closet
{
    [Activity(Label = "insertActivity")]
    public class insertActivity : Activity
    {
        ImageView imageView;
        ImageView imageView2;
        byte[] picArr;
        string username;
        int n;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.insert);

            TextView helloText = FindViewById<TextView>(Resource.Id.textView4);

            Button insertBTN = FindViewById<Button>(Resource.Id.button1);

            Button takePicBTN = FindViewById<Button>(Resource.Id.button2);
            imageView = FindViewById<ImageView>(Resource.Id.imageView1);

            username = Intent.GetStringExtra("username") ?? string.Empty;
            n = Intent.GetIntExtra("currCell", 1);//todo

            helloText.Text = "Hello " + username + ",  Fill the properties below:";

            takePicBTN.Click += (object sender, EventArgs e) =>
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            insertBTN.Click += async (object sender, EventArgs e) =>
            {
                RadioGroup radioGroupWeath = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
                RadioButton radioButtonWeath = FindViewById<RadioButton>(radioGroupWeath.CheckedRadioButtonId);

                RadioGroup radioGroupColor = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
                RadioButton radioButtonColor = FindViewById<RadioButton>(radioGroupColor.CheckedRadioButtonId);

                RadioGroup radioGroupType = FindViewById<RadioGroup>(Resource.Id.radioGroup3);
                RadioButton radioButtonType = FindViewById<RadioButton>(radioGroupType.CheckedRadioButtonId);

                try
                {
                    SqlConnection connection = new SqlConnection(
                             "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO ITEMS (COLOR, WEATHER, TYPE, FIRSTINSERT, LASTACT, IMAGE, NUMOFSELECTS, INCLOSET, USERNAME, CELLNUM) VALUES( '" + radioButtonColor.Text + "' , '" + radioButtonWeath.Text + "' , '" + radioButtonType.Text + "' ,GetDate(),GetDate(), @picArr ,0,1, '" + username + "',(select min(CELLNUM) from (SELECT CELLNUM FROM CELLS except (SELECT CELLNUM FROM ITEMS WHERE username = '" + username + "' and incloset = 1)) diff));", connection);
                    command.Parameters.Add("@picArr", SqlDbType.VarBinary, picArr.Length).Value = picArr;
                    SqlDataReader reader = command.ExecuteReader();
                }
                catch (SqlException err)
                {
                   // Console.WriteLine(err); //todo
                }
                Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
                done.PutExtra("username", username);
                done.PutExtra("currCell", n);
                StartActivity(done);
            };
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imageView.SetImageBitmap(bitmap);

            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            picArr = stream.ToArray();

        }
    }
} 