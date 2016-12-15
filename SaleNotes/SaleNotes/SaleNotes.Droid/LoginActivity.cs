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
    [Activity(Label = "LoginActivity", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            Button bt = FindViewById<Button>(Resource.Id.btLogin);
            bt.TextSize = 20;
            bt.Click += button_Click;

            LoadLogo();
        }

        private void LoadLogo()
        {
            var metrics = Resources.DisplayMetrics;
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //Setters
            RelativeLayout layout = FindViewById<RelativeLayout>(Resource.Id.relativeLayoutLogo);
            layout.LayoutParameters.Height = (int)(heightInDp * 0.4);

            ImageView image = FindViewById<ImageView>(Resource.Id.imgLogo);
            image.SetImageResource(Resource.Drawable.LogoND);
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!Login())
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Cảnh báo");
                builder.SetMessage("Tên hoặc mật khẩu không chính xác\nVui lòng nhập lại");
                builder.SetPositiveButton("OK", (senderAlert, args) =>
                {
                    //close dialog automatically
                });

                AlertDialog alert = builder.Create();
                alert.Show();

                var editName = FindViewById<EditText>(Resource.Id.tbUserName);
                editName.RequestFocus();
            }
        }

        private bool Login()
        {
            var editName = FindViewById<EditText>(Resource.Id.tbUserName);
            var editPass = FindViewById<EditText>(Resource.Id.tbPassword);
            string name = editName.Text;
            string pass = editPass.Text;

            if (name.ToLower() == "admin" && pass == "ngocdang")
            {
                return true;
            }

            return false;

            //string userName = UserBus.GetByUserName(tbUserName.Text);

            //if (FormMain.user != null)
            //{
            //    string s = Crypto.EncryptText(tbPassword.Text);

            //    if (FormMain.user.Password == Crypto.EncryptText(tbPassword.Text))
            //    {
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        lbError.Text = Constant.MESSAGE_LOGIN_WRONG_PASS;

            //        FormMain.user = null;
            //    }
            //}
            //else
            //{
            //    lbError.Text = Constant.MESSAGE_LOGIN_WRONG_USERNAME;

            //    FormMain.user = null;
            //}
        }
    }
}