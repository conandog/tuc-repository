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
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace SaleNotes.Droid
{
    [Activity(Label = "Home", Icon = "@drawable/LogoND")]
    public class Home : AppCompatActivity
    {
        private ImageButton btAddNewOrder;
        private Button btWaiting;
        private Button btUrgent;
        private Button btToday;
        private ImageButton btPopupMenu;
        private List<HomeItem> items = new List<HomeItem>();
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            //var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

            //Enable support action bar to display hamburger
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.MenuIcon);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };

            Init();

            btAddNewOrder = FindViewById<ImageButton>(Resource.Id.btAddNewOrder);
            btAddNewOrder.Click += notImplemented_Click;

            btWaiting = FindViewById<Button>(Resource.Id.btWaiting);
            String styledText1 = "<big> <big> <big>"
            + "12" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng chưa xử lý";
            btWaiting.TextFormatted = Android.Text.Html.FromHtml(styledText1);
            btWaiting.Click += notImplemented_Click;

            btUrgent = FindViewById<Button>(Resource.Id.btUrgent);
            String styledText2 = "<big> <big> <big>"
            + "3" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng cần xử lý gấp";
            btUrgent.TextFormatted = Android.Text.Html.FromHtml(styledText2);
            btUrgent.Click += notImplemented_Click;

            btToday = FindViewById<Button>(Resource.Id.btToday);
            String styledText3 = "<big> <big> <big>"
            + "6" + "</big> </big> </big>" + "<br />"
            + "Đơn hàng trong ngày";
            btToday.TextFormatted = Android.Text.Html.FromHtml(styledText3);
            btToday.Click += notImplemented_Click;

            List<HomeItem> list = new List<HomeItem>();
            list.Add(new HomeItem()
            {
                Id = 1,
                Name = "Chị A",
                Phone = "0912345678"
            });
            list.Add(new HomeItem()
            {
                Id = 2,
                Name = "Anh B",
                Phone = "0xxxyyy"
            });
            list.Add(new HomeItem()
            {
                Id = 3,
                Name = "Chú Nguyễn Văn C",
                Phone = "0abcxyz"
            });
            list.Add(new HomeItem()
            {
                Id = 4,
                Name = "Khách X",
                Phone = ""
            });
            list.Add(new HomeItem()
            {
                Id = 5,
                Name = "Khách Y",
                Phone = ""
            });
            list.Add(new HomeItem()
            {
                Id = 6,
                Name = "Khách Z",
                Phone = ""
            });

            LoadItems(list);
        }

        private void Init()
        {
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //Setters
            var layoutHeaderHome = FindViewById<LinearLayout>(Resource.Id.relativeLayoutHeaderHome);
            layoutHeaderHome.LayoutParameters.Height = (int)(heightInDp * 0.6);
            //var layoutHomeSummary = FindViewById<LinearLayout>(Resource.Id.relativeLayoutHomeSummary);
            //layoutHomeSummary.LayoutParameters.Height = (int)(heightInDp * 0.3);
            var layoutItemHome = FindViewById<LinearLayout>(Resource.Id.linearLayoutHomeItemHome);
            layoutItemHome.LayoutParameters.Height = (int)(heightInDp * 0.4);

            var image = FindViewById<ImageView>(Resource.Id.imgLogo);
            image.SetImageResource(Resource.Drawable.LogoND);

            btPopupMenu = FindViewById<ImageButton>(Resource.Id.btPopupMenu);
            btPopupMenu.LayoutParameters.Width = (int)(widthInDp * 0.1);
            btPopupMenu.LayoutParameters.Height = (int)(heightInDp * 0.1);
            btPopupMenu.Click += btPopupMenu_Click;
        }

        private void btPopupMenu_Click(object sender, EventArgs e)
        {
            drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
        }

        private void notImplemented_Click(object sender, EventArgs e)
        {
            //AlertDialog.Builder builder = new AlertDialog.Builder(this);
            //builder.SetTitle("Thông báo");
            //builder.SetMessage("Chức năng này sẽ được cập nhật sau");
            //builder.SetPositiveButton("OK", (senderAlert, args) =>
            //{
            //    //close dialog automatically
            //});

            //AlertDialog alert = builder.Create();
            //alert.Show();
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void LoadItems(List<HomeItem> list)
        {
            items.Clear();
            items.AddRange(list);

            var listView = FindViewById<ListView>(Resource.Id.listViewHomeItem);
            listView.Adapter = new HomeAdapter(this, list);

            listView.ItemClick += (s, a) =>
            {
                var item = items[a.Position];
                Order.SelectedOrderId = item.Id;
                Intent intent = new Intent(this, typeof(Activities.Details));
                StartActivity(intent);
            };
        }
    }

    public class HomeAdapter : BaseAdapter<HomeItem>
    {
        List<HomeItem> items;
        Activity context;
        public HomeAdapter(Activity context, List<HomeItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override HomeItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.HomeItem, null);
            view.FindViewById<TextView>(Resource.Id.textName).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.textPhone).Text = item.Phone;

            if ((position % 2) == 0)
            {
                view.FindViewById<ImageView>(Resource.Id.imgViewHeader).SetImageResource(Resource.Drawable.EllipseEven);
            }

            return view;
        }
    }

    public class HomeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Order
    {
        public static int SelectedOrderId { get; set; }
    }
}