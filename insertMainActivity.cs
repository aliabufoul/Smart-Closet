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

namespace Smart_Closet
{
    [Activity(Label = "insetMainActivity")]
    public class insertMainActivity : Activity
    {
        string username;
        int n;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.insert_main);

            Button newBTN = FindViewById<Button>(Resource.Id.button1);
            Button existBTN = FindViewById<Button>(Resource.Id.button2);

            TextView helloText = FindViewById<TextView>(Resource.Id.textView1);

            newBTN.Click += mainNewBTN_Click;
            existBTN.Click += mainExistBTN_Click;

            username = Intent.GetStringExtra("username") ?? string.Empty;
            n = Intent.GetIntExtra("currCell", 1);//todo
            helloText.Text = "Hello " + username + ",  Choose Your Activity:";
        }
        private void mainNewBTN_Click(object sender, EventArgs e)
        {
            Android.Content.Intent newI = new Android.Content.Intent(this, typeof(insertActivity));
            newI.PutExtra("username", username);
            newI.PutExtra("currCell", n);
            StartActivity(newI);
        }
        private void mainExistBTN_Click(object sender, EventArgs e)
        {
            Android.Content.Intent exist = new Android.Content.Intent(this, typeof(insertExistingActivity));
            exist.PutExtra("username", username);
            exist.PutExtra("currCell", n);
            StartActivity(exist);
        }
    }
}