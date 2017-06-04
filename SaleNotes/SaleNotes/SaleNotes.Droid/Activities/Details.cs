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
    [Activity(Label = "Details", Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/LogoND")]
    public class Details : Activity
    {
        private ImageButton btBack;
        private Button btDeliver;
        private Button btEdit;
        private Button btDelete;
        private List<DetailsItem> items = new List<DetailsItem>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Details);

            btDeliver = FindViewById<Button>(Resource.Id.btDeliverDetails);
            btDeliver.Click += NotImplemented_Click;
            btEdit = FindViewById<Button>(Resource.Id.btEditDetails);
            btEdit.Click += (object sender, EventArgs args) =>
            {
                StartActivity(new Android.Content.Intent(this, typeof(DetailsEdit)));
                Finish();
            };
            
            btDelete = FindViewById<Button>(Resource.Id.btDeleteDetails);
            btDelete.Click += NotImplemented_Click;

            btBack = FindViewById<ImageButton>(Resource.Id.btBackDetails);
            btBack.Click += (object sender, EventArgs args) =>
            {
                this.Finish();
            };

            List<DetailsItem> list = new List<DetailsItem>();
            list.Add(new DetailsItem()
            {
                Id = 1,
                Name = "Áo sơ mi ABC",
                Code = "ASM-1",
                Quantity = 5,
                Price = 150000
            });
            list.Add(new DetailsItem()
            {
                Id = 2,
                Name = "Quần kaki DEF",
                Code = "QKK-1",
                Quantity = 3,
                Price = 200000
            });
            list.Add(new DetailsItem()
            {
                Id = 3,
                Name = "Giày XYZ",
                Code = "G-1",
                Quantity = 1,
                Price = 120000
            });

            LoadItems(list);
            InitReadonly();
        }

        private void InitReadonly()
        {
            EditText control = FindViewById<EditText>(Resource.Id.editTextNameValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextPhoneValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextAddressValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextCountValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextNotesValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextTotalValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextDateValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextStatusValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextDateDeliverValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextDeliverManValueDetails);
            control.InputType = Android.Text.InputTypes.Null;

            control = FindViewById<EditText>(Resource.Id.editTextUserConfirmValueDetails);
            control.InputType = Android.Text.InputTypes.Null;
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

        private void LoadItems(List<DetailsItem> list)
        {
            items.Clear();
            items.AddRange(list);

            var listView = FindViewById<ListView>(Resource.Id.listViewDetailsItemDetails);
            listView.Adapter = new DetailsAdapter(this, list);
            SetListViewHeightBasedOnChildren(listView);
            //listView.Focusable = false;
            var scrollViewMain = FindViewById<ScrollView>(Resource.Id.scrollViewAllDetails);
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

    public class DetailsAdapter : BaseAdapter<DetailsItem>
    {
        private const string SYMBOL_LINK_MONEY = ".";
        private const string DEFAULT_FORMAT_MONEY = "#" + SYMBOL_LINK_MONEY + "###";
        private const string DEFAULT_MONEY_SUBFIX = "VND";
        List<DetailsItem> items;
        Activity context;
        public DetailsAdapter(Activity context, List<DetailsItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override DetailsItem this[int position]
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
            //view.FindViewById<RelativeLayout>(Resource.Id.relativeLayoutDetailsItemEdit).Visibility = ViewStates.Gone;
            view.FindViewById<RelativeLayout>(Resource.Id.relativeLayoutBinDetailsItemEdit).Visibility = ViewStates.Gone;
            EditText control = view.FindViewById<EditText>(Resource.Id.editTextNameValueDetailsItemEdit);
            control.Text = item.Name;
            control.InputType = Android.Text.InputTypes.Null;

            control = view.FindViewById<EditText>(Resource.Id.editTextCodeValueDetailsItemEdit);
            control.Text = item.Code;
            control.InputType = Android.Text.InputTypes.Null;

            control = view.FindViewById<EditText>(Resource.Id.editTextQuantityValueDetailsItemEdit);
            control.Text = item.Quantity.ToString();
            control.InputType = Android.Text.InputTypes.Null;

            control = view.FindViewById<EditText>(Resource.Id.editTextPriceValueDetailsItemEdit);
            control.Text = item.Price.ToString(DEFAULT_FORMAT_MONEY) + " VND/[đơn vị]";
            control.InputType = Android.Text.InputTypes.Null;

            if ((position % 2) == 0)
            {
                view.FindViewById<ImageView>(Resource.Id.iconHeaderDetailsItem).SetImageResource(Resource.Drawable.DetailsItemRectangleEven);
            }

            return view;
        }
    }

    public class DetailsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
    }
}