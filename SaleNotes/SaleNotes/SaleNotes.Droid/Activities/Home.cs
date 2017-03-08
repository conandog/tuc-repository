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

namespace SaleNotes.Droid
{
    [Activity(Label = "Home", Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/icon")]
    public class Home : Activity
    {
        private Button btAddNewOrder;
        private Button btWaiting;
        private Button btUrgent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            //btAddNewOrder = FindViewById<Button>(Resource.Id.btAddNewOrder);
            //btAddNewOrder.Left = btAddNewOrder.Layout.Width;
            //btAddNewOrder.Click += buttonLogin_Click;
        }
    }
}