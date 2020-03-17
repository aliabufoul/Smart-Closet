using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Graphics;
using System.Data.SqlClient;
using BluetoothApplication;


namespace Smart_Closet
{
    [Activity(Label = "insertExistingActivity")]
    public class insertExistingActivity : Activity
    {
        string username;
        int[] idArr;
        int n;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.insert_existing);
            TextView helloText = FindViewById<TextView>(Resource.Id.textView1);
            username = Intent.GetStringExtra("username") ?? string.Empty;
            n = Intent.GetIntExtra("currCell", 1);//todo
            helloText.Text = "Hello " + username + ",  Choose the item you want to insert:";

            try
            {
                SqlConnection connection = new SqlConnection(
                         "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                connection.Open();
                SqlCommand command = new SqlCommand("select image , ide  from items where username = '" + username + "' and incloset = 0 ORDER BY cellnum ASC; ", connection);
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

                idArr = new int[8];
                int itr = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idArr[itr] = reader.GetInt32(1);
                        itr++;
                        var picArr = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                        reader.GetBytes(0, 0, picArr, 0, picArr.Length);
                        
                        Bitmap bitmapT = BitmapFactory.DecodeByteArray(picArr, 0, picArr.Length);
                        if (itr == 1)
                            imageButton1.SetImageBitmap(bitmapT);
                        else if (itr == 2)
                            imageButton2.SetImageBitmap(bitmapT);
                        else if (itr == 3)
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
            }
            catch (SqlException err)
            {
                 Console.WriteLine(err); //todo
            }
        }
        private async void onClick(int curCell)
        {
            //await BluetoothHandler.sendAsync(cellArr[curCell - 1] - 1);
            try
            {
                SqlConnection connection = new SqlConnection(
                         "Data Source = smartclosetdatabase.database.windows.net; Initial Catalog = smartclosetdb; User ID = HAGATZAR; Password = SCAMO236###; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE items SET incloset = 1, lastact=GetDate(), cellnum = (select min(CELLNUM) from (SELECT CELLNUM FROM CELLS except (SELECT CELLNUM FROM ITEMS WHERE username = '" + username + "' and incloset = 1)) diff)  WHERE ide = '" + idArr[curCell-1] + "' ; ", connection);
                SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException err)
            {
                Console.WriteLine(err); //todo
            }
            Android.Content.Intent done = new Android.Content.Intent(this, typeof(DoneActivity));
            done.PutExtra("username", username);
            done.PutExtra("currCell", n);
            StartActivity(done);
        }
        private async void imageButton1_ClickAsync(object sender, EventArgs e)
        {
            onClick(1);
        }
        private async void imageButton2_ClickAsync(object sender, EventArgs e)
        {
            onClick(2);
        }
        private async void imageButton3_ClickAsync(object sender, EventArgs e)
        {
            onClick(3);
        }
        private async void imageButton4_ClickAsync(object sender, EventArgs e)
        {
            onClick(4);
        }
        private async void imageButton5_ClickAsync(object sender, EventArgs e)
        {
            onClick(5);
        }
        private async void imageButton6_ClickAsync(object sender, EventArgs e)
        {
            onClick(6);
        }
        private async void imageButton7_ClickAsync(object sender, EventArgs e)
        {
            onClick(7);
        }
        private async void imageButton8_ClickAsync(object sender, EventArgs e)
        {
            onClick(8);
        }
    }
}