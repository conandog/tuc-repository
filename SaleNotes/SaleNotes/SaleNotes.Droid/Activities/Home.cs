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
        private Button btToday;
        private ImageButton btPopupMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);
            LoadLogo();

            //btAddNewOrder = FindViewById<Button>(Resource.Id.btAddNewOrder);
            //String styledText = "<big> <big> <big>" + "+" + "</big> </big> </big>";
            //btAddNewOrder.TextFormatted = Android.Text.Html.FromHtml(styledText);
            //btAddNewOrder.TextSize = 
            //btAddNewOrder.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);

            btWaiting = FindViewById<Button>(Resource.Id.btWaiting);
            String styledText1 = "<big> <big> <big>"
            + "12" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng chưa xử lý";
            btWaiting.TextFormatted = Android.Text.Html.FromHtml(styledText1);

            btUrgent = FindViewById<Button>(Resource.Id.btUrgent);
            String styledText2 = "<big> <big> <big>"
            + "3" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng cần xử lý gấp";
            btUrgent.TextFormatted = Android.Text.Html.FromHtml(styledText2);

            btToday = FindViewById<Button>(Resource.Id.btToday);
            String styledText3 = "<big> <big> <big>"
            + "6" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng trong ngày";
            btToday.TextFormatted = Android.Text.Html.FromHtml(styledText3);
        }

        private void LoadLogo()
        {
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //Setters
            RelativeLayout layout = FindViewById<RelativeLayout>(Resource.Id.relativeLayoutLogo);
            layout.LayoutParameters.Height = (int)(heightInDp * 0.3);

            ImageView image = FindViewById<ImageView>(Resource.Id.imgLogo);
            image.SetImageResource(Resource.Drawable.LogoND);

            btPopupMenu = FindViewById<ImageButton>(Resource.Id.btPopupMenu);
            btPopupMenu.LayoutParameters.Width = (int)(widthInDp * 0.1);
            btPopupMenu.LayoutParameters.Height = (int)(heightInDp * 0.1);
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}