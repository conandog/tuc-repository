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
using static Android.Views.View;

namespace SaleNotes.Droid.Activities
{
    [Activity(Label = "DetailsEdit", Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/LogoND")]
    public class DetailsEdit : Activity
    {
        private ImageButton btBack;
        private Button btFinish;
        private Button btCancel;
        private List<DetailsItemEdit> items = new List<DetailsItemEdit>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DetailsEdit);

            btFinish = FindViewById<Button>(Resource.Id.btFinishDetailsEdit);
            btFinish.Click += (object sender, EventArgs args) =>
            {
                this.Finish();
            };

            btCancel = FindViewById<Button>(Resource.Id.btCancelDetailsEdit);
            btCancel.Click += (object sender, EventArgs args) =>
            {
                this.Finish();
            };

            btBack = FindViewById<ImageButton>(Resource.Id.btBackDetailsEdit);
            btBack.Click += (object sender, EventArgs args) =>
            {
                this.Finish();
            };

            List<DetailsItemEdit> list = new List<DetailsItemEdit>();
            list.Add(new DetailsItemEdit()
            {
                Id = 1,
                Name = "Áo sơ mi ABC",
                Code = "ASM-1",
                Quantity = 5,
                Price = 150000
            });
            list.Add(new DetailsItemEdit()
            {
                Id = 2,
                Name = "Quần kaki DEF",
                Code = "QKK-1",
                Quantity = 3,
                Price = 200000
            });
            list.Add(new DetailsItemEdit()
            {
                Id = 3,
                Name = "Giày XYZ",
                Code = "G-1",
                Quantity = 1,
                Price = 120000
            });

            LoadItems(list);
        }

        private void NotImplemented_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Thông báo");
            builder.SetMessage("Chức năng này sẽ được cập nhật sau");
            builder.SetPositiveButton("OK", (senderAlert, args) =>
            {
                //close dialog automatically
            });

            AlertDialog alert = builder.Create();
            alert.Show();
        }

        private void LoadItems(List<DetailsItemEdit> list)
        {
            items.Clear();
            items.AddRange(list);

            var listView = FindViewById<ListView>(Resource.Id.listViewDetailsItemEdit);
            listView.Adapter = new DetailsEditAdapter(this, list);
            SetListViewHeightBasedOnChildren(listView);
            //listView.Focusable = false;
            var scrollViewMain = FindViewById<ScrollView>(Resource.Id.scrollViewAllDetailsEdit);
            scrollViewMain.SmoothScrollTo(0, 0);
        }

        public void SetListViewHeightBasedOnChildren(ListView listView)
        {
            var listAdapter = listView.Adapter;
            if (listAdapter == null)
                return;

            int desiredWidth = MeasureSpec.MakeMeasureSpec(listView.Width, MeasureSpecMode.Unspecified);
            int totalHeight = 0;
            View view = null;
            for (int i = 0; i < listAdapter.Count; i++)
            {
                view = listAdapter.GetView(i, view, listView);
                if (i == 0)
                    view.LayoutParameters = new ViewGroup.LayoutParams(desiredWidth, WindowManagerLayoutParams.WrapContent);

                view.Measure(MeasureSpec.MakeMeasureSpec(desiredWidth, MeasureSpecMode.AtMost), MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified));
                totalHeight += view.MeasuredHeight;
            }
            ViewGroup.LayoutParams param = listView.LayoutParameters;
            param.Height = totalHeight + (listView.DividerHeight * (listAdapter.Count - 1));
            listView.LayoutParameters = param;
        }
    }

    public class DetailsEditAdapter : BaseAdapter<DetailsItemEdit>
    {
        private const string SYMBOL_LINK_MONEY = ".";
        private const string DEFAULT_FORMAT_MONEY = "#" + SYMBOL_LINK_MONEY + "###";
        private const string DEFAULT_MONEY_SUBFIX = "VND";
        List<DetailsItemEdit> items;
        Activity context;
        public DetailsEditAdapter(Activity context, List<DetailsItemEdit> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override DetailsItemEdit this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.DetailsItem, null);
            //view.FindViewById<RelativeLayout>(Resource.Id.relativeLayoutDetailsItemView).Visibility = ViewStates.Gone;
            view.FindViewById<EditText>(Resource.Id.editTextNameValueDetailsItemEdit).Text = item.Name;
            view.FindViewById<EditText>(Resource.Id.editTextCodeValueDetailsItemEdit).Text = item.Code;
            view.FindViewById<EditText>(Resource.Id.editTextQuantityValueDetailsItemEdit).Text = item.Quantity.ToString();
            view.FindViewById<EditText>(Resource.Id.editTextPriceValueDetailsItemEdit).Text = item.Price.ToString(DEFAULT_FORMAT_MONEY) + " VND/[đơn vị]";
            view.FindViewById<ImageButton>(Resource.Id.btBinDetailsItemEdit).Click += (object sender, EventArgs args) =>
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(convertView.Context);
                builder.SetTitle("Thông báo");
                builder.SetMessage("Chức năng này sẽ được cập nhật sau");
                builder.SetPositiveButton("OK", (senderAlert, e) =>
                {
                    //close dialog automatically
                });

                AlertDialog alert = builder.Create();
                alert.Show();
            };

            if ((position % 2) == 0)
            {
                view.FindViewById<ImageView>(Resource.Id.iconHeaderDetailsItem).SetImageResource(Resource.Drawable.DetailsItemRectangleEven);
            }

            return view;
        }
    }

    public class DetailsItemEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
    }
}