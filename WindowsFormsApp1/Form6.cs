using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string talep = "";
        MySqlConnection connection = new MySqlConnection("server=192.168.10.50;Database=satinalma;Uid=localhost;Pwd=BYZroot1;Allow Zero Datetime=true");

        private void Form6_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            string sorgu = "select * from satinalma.sarfteklif where teklifNo like '" + talep + "%' ";
            //MySqlDataAdapter da = new MySqlDataAdapter(sorgu, connection);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gridControlTeklif.DataSource = ds.Tables[0];
            FillAdvDataGridView(advTeklif, sorgu, bindingSource2);

            Form4 form = new Form4();
            //Giriş Yetkiliye Aitse
            if(form.bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='OSMAN DİRİ'", "unvan") == "YETKİLİ")
            { buttonYeniden.Enabled = true;     buttonOnayla.Enabled = true; }
            else
            { buttonYeniden.Enabled = false;    buttonOnayla.Enabled = false; }
            advTeklif.ClearSelection();
        }

        public void connect(string sorgu)
        {
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = sorgu;
            mySqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void FillAdvDataGridView(DataGridView data, string query, BindingSource sc)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            DataTable oku = new DataTable();
            da.Fill(oku);
            data.DataSource = oku;
            sc.DataSource = oku;
            connection.Close();
        }

        //public class NavBarGroupEventArgs : EventArgs { }

        private void buttonYeniden_Click(object sender, EventArgs e)
        {
            //int index = layoutView2.FocusedRowHandle;
            //int id = Convert.ToInt32(layoutView2.GetRowCellValue(index, "id"));
            //string talep = layoutView2.GetRowCellValue(index, "talepNo").ToString();
            int id = Convert.ToInt32(advTalep.Rows[0].Cells["id"].Value.ToString());
            string talep = advTalep.Rows[0].Cells["talepNo"].Value.ToString();
            try
            {
                string yeniden = "update satinalma.sarftalep set durum = 'Talep Onay' where id = " + id + " ";
                connect(yeniden);
                MessageBox.Show(talep + " Talep Numarasına Ait Teklifler Yeniden Araştırılmak Üzere Satın Alma Birimine Yönlendirilmiştir.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch { MessageBox.Show("Teklifler Yönlendirilirken Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.Close();
        }

        private void advTeklif_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource2.Filter = advTeklif.FilterString;
        }

        private void advTeklif_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource2.Sort = advTeklif.SortString;
        }

        int ID = 0;
        string teklif = "";
        //private void layoutView1_CardClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        //{   //Teklif Seçme Aşaması - Layout Carddaki id'yi alır
        //    int index = layoutView1.FocusedRowHandle;
        //    ID = 0;
        //    if (index >= 0)
        //    {
        //        ID = Convert.ToInt32(layoutView1.GetRowCellValue(index, "id").ToString());
        //        teklif = layoutView1.GetRowCellValue(index, "teklifNo").ToString();
        //    }  
        //}

        private void advTeklif_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   //Teklif Seçme Aşaması - Layout Carddaki id'yi alır
            ID = 0;
            if(advTeklif.SelectedRows.Count > 0)
            {
                ID = Convert.ToInt32(advTeklif.SelectedRows[0].Cells["id"].Value.ToString());
                teklif = advTeklif.SelectedRows[0].Cells["teklifNo"].Value.ToString();
            }
        }

        private void buttonOnayla_Click(object sender, EventArgs e)
        {
            //int index = layoutView2.FocusedRowHandle;
            //string talep = layoutView2.GetRowCellValue(index, "talepNo").ToString();
            string talep = advTalep.Rows[0].Cells["id"].Value.ToString();
            if (ID != 0)
            {
                try
                {
                    string onayTeklif = "update satinalma.sarfteklif set durum  ='Onaylandı' where id = " + ID + " ";
                    connect(onayTeklif);
                    string onayTalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talep + "' ";
                    connect(onayTalep);
                    MessageBox.Show(talep + " Talep Numarasına Verilen " + teklif + " Numaralı Teklif Onaylandı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Teklifler Onaylanırken Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
            else
                MessageBox.Show(talep + " Talep Numarasına Uygun Teklifi Seçmeyi Unutmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form4 satinalma = new Form4();
            satinalma.labelTeklif_Click(sender, e);
        }

        
    }
}
