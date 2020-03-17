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
using Android.Graphics;
using BluetoothApplication;

using System.Windows;
using System.IO;
using System.Data.SqlClient;


namespace Smart_Closet
{
    [Activity(Label = "selectActivity")]
    public class selectActivity : Activity
    {
        string username;
        string filterStr;
        int[] cellArr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.select);
            TextView helloText = FindViewById<TextView>(Resource.Id.textView1);
            username = Intent.GetStringExtra("username") ?? string.Empty;
            filterStr = Intent.GetStringExtra("filterStr") ?? string.Empty;
            helloText.Text = "Hello " + username + ",  Choose the item you want to get:";

            try
            {
                SqlConnection connection = new SqlConnection(
                         "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                connection.Open();
                SqlCommand command = new SqlCommand("select image , cellnum from items where username = '" + username + "' and incloset = 1 " + filterStr + " ORDER BY numofselects DESC; ", connection);
                SqlDataReader reader = command.ExecuteReader();
                ImageButton imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
                ImageButton imageButton2 = FindViewById<ImageButton>(Resource.Id.imageButton2);
                ImageButton imageButton3 = FindViewById<ImageButton>(Resource.Id.imageButton3);
                ImageButton imageButton4 = FindViewById<ImageButton>(Resource.Id.imageButton4);
                ImageButton imageButton5 = FindViewById<ImageButton>(Resource.Id.imageButton5);
                ImageButton imageButton6 = FindViewById<ImageButton>(Resource.Id.imageButton6);
                ImageButton imageButton7 = FindViewById<ImageButton>(Resource.Id.imageButton7);
                ImageButton imageButton8 = FindViewById<ImageButton>(Resource.Id.imageButton8);

                imageButton1.Click += imageButton1_ClickAsync;
                imageButton2.Click += imageButton2_ClickAsync;
                imageButton3.Click += imageButton3_ClickAsync;
                imageButton4.Click += imageButton4_ClickAsync;
                imageButton5.Click += imageButton5_ClickAsync;
                imageButton6.Click += imageButton6_ClickAsync;
                imageButton7.Click += imageButton7_ClickAsync;
                imageButton8.Click += imageButton8_ClickAsync;

                cellArr = new int[8];
                int  itr = 0;
                Console.WriteLine("test1:{0}", reader);
                if (reader.HasRows)
                {
                    while (reader.Read() )
                    {
                        cellArr[itr] = reader.GetInt32(1);
                        itr++;
                        var picArr = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                        reader.GetBytes(0, 0, picArr, 0, picArr.Length);
                        /*
                        byte[] picArr = new byte[10000000];
                        picArr = (byte[])reader["IMAGE"];
                        Console.WriteLine("reader:",reader["IMAGE"]);
                        Console.WriteLine("test: {0}",test);
                        Console.WriteLine("picArr: {0}", picArr[0]);
                        Console.WriteLine("picArr1: {0}", picArr[1]);
                        test++;
                       /* long len = reader.GetBytes(1, 0, null, 0, 0);
                        byte[] picArr = new byte[len];

                        reader.GetBytes(1, 0, picArr, 0, (int)len);*/
                        Bitmap bitmapT = BitmapFactory.DecodeByteArray(picArr, 0, picArr.Length);
                        if(itr==1)
                            imageButton1.SetImageBitmap(bitmapT);
                        else if(itr==2)
                            imageButton2.SetImageBitmap(bitmapT);
                        else if(itr==3)
                            imageButton3.SetImageBitmap(bitmapT);
                        else if (itr == 4)
                            imageButton4.SetImageBitmap(bitmapT);
                        else if (itr == 5)
                            imageButton5.SetImageBitmap(bitmapT);
                        else if (itr == 6)
                            imageButton6.SetImageBitmap(bitmapT);
                        else if (itr == 7)
                            imageButton7.SetImageBitmap(bitmapT);
                        else if (itr == 8)
                            imageButton8.SetImageBitmap(bitmapT);
                    }
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
            //  Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapdata, 0, bitmapdata.length);
            /* InputStream inputStream = new ByteArrayInputStream(bytes);
             BitmapFactory.Options o = new BitmapFactory.Options();
             BitmapFactory.decodeStream(inputStream, null, o);*/
            // Create your application here
        }
        private async void onClick(int curCell)
        {
            await BluetoothHandler.sendAsync(cellArr[curCell-1] - 1);
            try
            {
                SqlConnection connection = new SqlConnection(
                         "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE items SET incloset = 0, numofselects = numofselects + 1, lastact=GetDate()  WHERE incloset = 1 and username = '" + username + "' and cellnum = " + cellArr[curCell-1] + "; ", connection);
                SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException err)
            {
                 Console.WriteLine(err); //todo
            }
            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[curCell-1]);
            StartActivity(done);
        }
        private async void imageButton1_ClickAsync(object sender, EventArgs e)
        {
            onClick(1);/*
            await BluetoothHandler.sendAsync(cellArr[0]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[0]);
            StartActivity(done);*/
        }
        private async void imageButton2_ClickAsync(object sender, EventArgs e)
        {
            onClick(2);/*
            await BluetoothHandler.sendAsync(cellArr[1]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[1]);
            StartActivity(done);*/
        }
        private async void imageButton3_ClickAsync(object sender, EventArgs e)
        {
            onClick(3);/*
            await BluetoothHandler.sendAsync(cellArr[2]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[2]);
            StartActivity(done);*/
        }
        private async void imageButton4_ClickAsync(object sender, EventArgs e)
        {
            onClick(4);/*            await BluetoothHandler.sendAsync(cellArr[3]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[3]);
            StartActivity(done);
        */}
        private async void imageButton5_ClickAsync(object sender, EventArgs e)
        {
            onClick(5);/*  await BluetoothHandler.sendAsync(cellArr[4]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[4]);
            StartActivity(done);
        */}
        private async void imageButton6_ClickAsync(object sender, EventArgs e)
        {
            onClick(6);/*  await BluetoothHandler.sendAsync(cellArr[5]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[5]);
            StartActivity(done);
        */}
        private async void imageButton7_ClickAsync(object sender, EventArgs e)
        {
            onClick(7);/*  await BluetoothHandler.sendAsync(cellArr[6]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[6]);
            StartActivity(done);
        */}
        private async void imageButton8_ClickAsync(object sender, EventArgs e)
        {
            onClick(8);/*  await BluetoothHandler.sendAsync(cellArr[7]-1);

            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", cellArr[7]);
            StartActivity(done);
        */}
    }
}