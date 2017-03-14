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
using Firebase.Auth;
using Firebase;
using Android.Gms.Tasks;

namespace SaleNotes.Droid
{
    [Activity(Label = "LoginActivity", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, Icon = "@drawable/LogoND")]
    public class LoginActivity : Activity, IOnCompleteListener
    {
        public FirebaseApp app;
        public FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            Button bt = FindViewById<Button>(Resource.Id.btLogin);
            bt.TextSize = 20;
            bt.Click += buttonLogin_Click;

            LoadLogo();
            //InitFirebaseAuth();
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:1078409326584:android:25da17737e424103")
                .SetApiKey("AIzaSyBpMxDiNyelgQ1ZMb8RpIG1BUlpjTzK-Ro")
                //.SetDatabaseUrl("https://tucnguyen-af6f4.firebaseio.com")
                //.SetStorageBucket("tucnguyen - af6f4.appspot.com")
                //.SetGcmSenderId("1078409326584")
                .Build();

            if (app == null)
            {
                app = FirebaseApp.InitializeApp(this, options);
            }
            auth = FirebaseAuth.GetInstance(app);
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var editName = FindViewById<EditText>(Resource.Id.tbUserName);
            var editPass = FindViewById<EditText>(Resource.Id.tbPassword);
            string name = editName.Text;
            string pass = editPass.Text;
            Login(name, pass);
        }

        private void Login(string name, string pass)
        {
            //auth.SignInWithEmailAndPassword(name, pass).AddOnCompleteListener(this);
            StartActivity(new Android.Content.Intent(this, typeof(Home)));
            Finish();
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                //Todo
                StartActivity(new Android.Content.Intent(this, typeof(Home)));
                Finish();
            }
            else
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
            }
        }
    }
}