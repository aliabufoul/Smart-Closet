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
    [Activity(Label = "FilterActivity")]
    public class FilterActivity : Activity
    {
        string username;
        string filterStr = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.filters);

            TextView helloText = FindViewById<TextView>(Resource.Id.textView4);

            Button doneBTN = FindViewById<Button>(Resource.Id.button1);
            CheckBox weatherCB = FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBox whiteCB = FindViewById<CheckBox>(Resource.Id.checkBox2);
            CheckBox blackCB = FindViewById<CheckBox>(Resource.Id.checkBox3);
            CheckBox redCB = FindViewById<CheckBox>(Resource.Id.checkBox4);
            CheckBox blueCB = FindViewById<CheckBox>(Resource.Id.checkBox5);
            CheckBox pinkCB = FindViewById<CheckBox>(Resource.Id.checkBox6);
            CheckBox greyCB = FindViewById<CheckBox>(Resource.Id.checkBox7);
            CheckBox purpleCB = FindViewById<CheckBox>(Resource.Id.checkBox8);
            CheckBox orangeCB = FindViewById<CheckBox>(Resource.Id.checkBox9);
            CheckBox yellowCB = FindViewById<CheckBox>(Resource.Id.checkBox10);
            CheckBox greenCB = FindViewById<CheckBox>(Resource.Id.checkBox11);
            CheckBox casualCB = FindViewById<CheckBox>(Resource.Id.checkBox12);
            CheckBox formalCB = FindViewById<CheckBox>(Resource.Id.checkBox13);

            whiteCB.Checked = true;
             blackCB.Checked = true;
            redCB.Checked = true;
            blueCB.Checked = true;
            pinkCB.Checked = true;
            greyCB.Checked = true;
            purpleCB.Checked = true;
            orangeCB.Checked = true;
            yellowCB.Checked = true;
            greenCB.Checked = true;
            casualCB.Checked = true;
            formalCB.Checked = true;

            username = Intent.GetStringExtra("username") ?? string.Empty;

            helloText.Text = "Hello " + username + ",  Set the Filters:";

            doneBTN.Click += (object sender, EventArgs e) =>
            {
                filterStr = "";
                if (weatherCB.Checked == true)
                {
                    string sMonth = DateTime.Now.Month.ToString();
                    Console.WriteLine("month:{0}", sMonth);
                    if(sMonth == "1" || sMonth == "2")
                    {
                        filterStr = filterStr + " and weather <> 'summer' and weather <> 'Fall/Spring' ";
                    }
                    else if (sMonth == "12" || sMonth == "3")
                    {
                        filterStr = filterStr + " and weather <> 'summer' ";
                    }else if(sMonth == "4" || sMonth == "5" || sMonth == "10" || sMonth == "11")
                    {
                        filterStr = filterStr + " and weather <> 'summer' and weather <> 'winter' ";
                    }
                    else if (sMonth == "7" || sMonth == "8")
                    {
                        filterStr = filterStr + " and weather <> 'Fall/Spring' and weather <> 'winter' ";
                    } else if(sMonth == "6" || sMonth == "9")
                    {
                        filterStr = filterStr + " and weather <> 'winter' ";
                    }
                }
                if (whiteCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'White' ";
                }
                if (blackCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Black' ";
                }
                if (redCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Red' ";
                }
                if (blueCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Blue' ";
                }
                if (pinkCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Pink' ";
                }
                if (greyCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Grey' ";
                }
                if (purpleCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Purple' ";
                }
                if (orangeCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Orange' ";
                }
                if (yellowCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Yellow' ";
                }
                if (greenCB.Checked == false)
                {
                    filterStr = filterStr + " and color <> 'Green' ";
                }
                if (casualCB.Checked == false)
                {
                    filterStr = filterStr + " and type <> 'casual' ";
                }
                if (formalCB.Checked == false)
                {
                    filterStr = filterStr + " and type <> 'formal' ";
                }
                Android.Content.Intent select = new Android.Content.Intent(this, typeof(selectActivity));
                select.PutExtra("username", username);
                select.PutExtra("filterStr", filterStr);
                StartActivity(select);
            };
        }
    }
}