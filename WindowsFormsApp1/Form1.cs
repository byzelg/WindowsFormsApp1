using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Drawing;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backstageViewControl1.Office2013StyleOptions.HeaderBackColor = Color.White;
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.146;Database=burka;Uid=root;Pwd=lgulver;");

        //
        public class CustomBackStageViewControl : BackstageViewControl
        {
            protected override BackstageViewPainter CreatePainter()
            {
                return new CustomBackstageViewPainter();
            }
        }

        public class CustomBackstageViewPainter : Office2013BackstageViewPainter
        {
            public CustomBackstageViewPainter()
            {
            }

            protected override void DrawBackground(GraphicsCache cache, BackstageViewInfo vi)
            {
                base.DrawBackground(cache, vi);
                Office2013BackstageViewInfo viewInfo = vi as Office2013BackstageViewInfo;
                int groupWidth = 150;
                cache.FillRectangle(cache.GetSolidBrush(Color.Green), new Rectangle(viewInfo.CaptionRect.Location, new Size(groupWidth, viewInfo.CaptionRect.Height)));
            }
        }

        [Browsable(false)]
        public override Color BackColor { get; set; }

        //

        private void backstageViewButtonItem1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            string sorgu = "select id, PlanlamaDurumu, teklifno, siparisno, işlemtarihi, temsilci from planlama.üretimplanlama";
            Urunler(advancedDataGridView1, sorgu);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "ONAY";
            btn1.Text = "Onayla";
            btn1.Name = "Onayla";
            btn1.UseColumnTextForButtonValue = true;
            btn1.DefaultCellStyle.BackColor = Color.Green;
            btn1.Width = 50;

            //Butonu kolon olarak ekliyoruz
            advancedDataGridView1.Columns.Add(btn1);
        }

        public void Urunler(DataGridView data, string query)
        {
            MySqlDataAdapter listele = new MySqlDataAdapter(query, connection);
            DataTable oku = new DataTable();
            listele.Fill(oku);
            data.DataSource = oku;
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
