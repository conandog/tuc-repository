using DevExpress.Utils.Animation;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuLieuRibbon
{
    public partial class MapHoDauTieng_Form : Form
    {
        
        public MapHoDauTieng_Form()
        {
            InitializeComponent();
            LoadMap();
            LoadMarker();
            //LoadPolygon();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        void LoadMap()
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gmap.MinZoom = 8;
            gmap.MaxZoom = 13;
            gmap.Zoom = 11;
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            gmap.Position = new PointLatLng(11.467074, 106.325630);
            gmap.DragButton = MouseButtons.Left;
        }

        void LoadMarker()
        {
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(11.467074, 106.325630), GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);
        }
        void LoadPolygon()
        {
            GMapOverlay polygons = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(11.299782, 106.349090));
            points.Add(new PointLatLng(11.381445, 106.224972));
            points.Add(new PointLatLng(11.520699, 106.158014));
            points.Add(new PointLatLng(11.680675, 106.154748));
            points.Add(new PointLatLng(11.613496, 106.223339));
            //points.Add(new PointLatLng(11.514298, 106.275599));
            points.Add(new PointLatLng(11.595899, 106.309895));
            points.Add(new PointLatLng(11.578301, 106.494437));
            points.Add(new PointLatLng(11.487092, 106.497704));
            points.Add(new PointLatLng(11.312594, 106.363788));


            GMapPolygon polygon = new GMapPolygon(points, "Hồ Dầu Tiếng");
            

            polygon.Fill = new SolidBrush(Color.FromArgb(15, Color.Red));
            polygon.IsHitTestVisible = true;
            polygon.Stroke = new Pen(Color.Red, 2);
            polygons.Polygons.Add(polygon);
            gmap.Overlays.Add(polygons);

        }

        private void gmap_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            //MessageBox.Show(String.Format("Polygon {0} with tag {1} was clicked",item.Name, item.Tag));
            gmap.Position = new PointLatLng(11.481878, 106.117576);
            gmap.Zoom = 11;

            
            //Fade Label
            if (transitionManager1.IsTransition)
            {
                transitionManager1.EndTransition();
            }

            transitionManager1.StartTransition(labelControl1);
            try
            {
                labelControl1.Visible = !labelControl1.Visible;
            }
            finally
            {
                transitionManager1.EndTransition();
            }
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {   
            //gmap.Overlays.Remove(item.Overlay);
            //gmap.MarkersEnabled = false;
            LoadPolygon();
            gmap.Position = new PointLatLng(11.467074, 106.325630);
            item.Overlay.IsVisibile = false;
        }

        private void btn_MapZoomIn_Click(object sender, EventArgs e)
        {
            gmap.Zoom++;
        }

        private void btn_MapZoomOut_Click(object sender, EventArgs e)
        {
            gmap.Zoom--;
        }

        private void btn_MapCenter_Click(object sender, EventArgs e)
        {
            gmap.Position = new PointLatLng(11.467074, 106.325630);
            gmap.Zoom = 11;
        }


    }
}
