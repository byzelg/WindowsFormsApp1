using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using MySql.Data.MySqlClient;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            this.sfDataGrid1.ShowGroupDropArea = true;
            this.sfDataGrid1.AllowGrouping = true;
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.50;Database=satinalma;Uid=localhost;Pwd=BYZroot1;");
        DataGridViewCellStyle renk = new DataGridViewCellStyle();

        public class NavBarGroupEventArgs : EventArgs { }
        MySqlDataAdapter da;
        DataSet ds;
        internal void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //kullanıcıya göre farklı kayıt sayısı gelecektir.
            if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
                txBoxBekleyen.Text = bilgi("SELECT count(id) as kayit FROM satinalma.sarftalep where durum='Depo Talebi' and miktar in ('Belirsiz','') and depoKabulTarihi is null", "kayit").ToString();
            else if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("YETKİLİ") != -1)
                txBoxBekleyen.Text = bilgi("SELECT count(id) as kayit FROM satinalma.sarftalep where durum='Depo Talebi' and miktar not in ('Belirsiz','') and depoKabulTarihi is null", "kayit").ToString();
            txBoxOnayli.Text = bilgi("SELECT count(id) as kayit FROM satinalma.sarftalep where durum = 'Talep Onay' and kullanici is null and depoKabulTarihi is null", "kayit").ToString();
            txBoxTalep.Text = bilgi("SELECT count(id) as kayit FROM satinalma.sarftalep where kullanici is not null and durum = 'Talep Onay' and depoKabulTarihi is null", "kayit").ToString();
            txBoxOnaySip.Text = bilgi("SELECT count(f.id) as kayit FROM satinalma.sarfteklif f left join satinalma.sarftalep p on substring(f.teklifNo,1,14) = p.talepNo where f.durum = 'Onaylandı' and siparisNo is null and depoKabulTarihi is null and grup is not null", "kayit").ToString();
            txBoxVerilen.Text = bilgi("SELECT count(f.id) as kayit FROM satinalma.sarfteklif f left join satinalma.sarftalep p on substring(f.teklifNo,1,14) = p.talepNo where f.durum = 'Onaylandı' and irsaliyeNo is null and siparisNo is not null and grup is not null", "kayit").ToString();
            txBoxTamamlanan.Text = bilgi("SELECT count(id) as kayit FROM satinalma.sarfteklif where durum = 'Onaylandı' and irsaliyeNo is not null", "kayit").ToString();


            //sfDataGrid - Satın alma kendi kullanıcısında tüm grubu atanmış teklifleri görür.
            if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
            {
                da = new MySqlDataAdapter("SELECT * FROM satinalma.sarftalep where grup is not null and kullanici = '" + labelTemsilci.Text + "'", connection);
                txBoxTeklif.Text = bilgi("SELECT count(distinct(grup)) as kayit FROM satinalma.sarftalep where kullanici = '" + labelTemsilci.Text + "' ", "kayit").ToString();
            }
            //sfDataGrid - Müdür teklifi girilmiş ve grubu atanmış tüm kullanıcıların tüm tekliflerini görür
            else if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("YETKİLİ") != -1)
            {
                da = new MySqlDataAdapter("SELECT * FROM satinalma.sarftalep where grup is not null and durum ='Teklif Girildi'", connection);
                txBoxTeklif.Text = bilgi("SELECT count(distinct(grup)) as kayit FROM satinalma.sarftalep", "kayit").ToString();
            }
                
            ds = new DataSet();
            da.Fill(ds, "grup");
            sfDataGrid1.DataSource = ds.Tables[0];

            this.sfDataGrid1.Style.HeaderStyle.BackColor = Color.AliceBlue;
            this.sfDataGrid1.Style.HeaderStyle.TextColor = Color.DarkSlateBlue;
            this.sfDataGrid1.Style.HeaderStyle.Font.Bold = true;

            this.sfDataGrid1.Style.SelectionStyle.BackColor = Color.LightSeaGreen;
            this.sfDataGrid1.Style.SelectionStyle.TextColor = Color.DarkBlue;
        }

        /*SFDATAGRİD*/
        string cellValue;
        private void sfDataGrid1_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (this.sfDataGrid1.CurrentCell != null)
            {
                //var currentCellRowIndex = this.sfDataGrid1.CurrentCell.RowIndex;
                //var currentCellColumnIndex = this.sfDataGrid1.CurrentCell.ColumnIndex;
                //var currentCellColumn = this.sfDataGrid1.CurrentCell.Column;
                var currentCellValue = sfDataGrid1.CurrentCell.CellRenderer.GetControlValue();
            }

            var rowIndex = this.sfDataGrid1.CurrentCell.RowIndex;
            var columnIndex = 18;       //grup sütunu değeri
            var cellValue = GetCellValue(sfDataGrid1, rowIndex, columnIndex);

            if (cellValue != null)
            {
                Form5 form5 = new Form5();
                form5.labelgrup.Text = cellValue;
                form5.labelTemsilci.Text = labelTemsilci.Text;
                form5.Show();
                this.WindowState = FormWindowState.Minimized;
                form5.calistir(sender, e);
            }
        }

        private static string GetCellValue(Syncfusion.WinForms.DataGrid.SfDataGrid dGrid, int rowIndex, int columnIndex)
        {
            string cellValue;
            if (columnIndex < 0)
                return string.Empty;
            var mappingName = dGrid.Columns[columnIndex].MappingName;
            var recordIndex = dGrid.TableControl.ResolveToRecordIndex(rowIndex);
            if (recordIndex < 0)
                return string.Empty;
            if (dGrid.View.TopLevelGroup != null)
            {
                var record = dGrid.View.TopLevelGroup.DisplayElements[recordIndex];
                if (!record.IsRecords)
                {
                    MessageBox.Show("Lütfen Aynı Gruba Ait Herhangi Satıra Tıklayınız.", "Hatırlatma", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                DataRowView record1 = dGrid.View.Records.GetItemAt(recordIndex) as DataRowView;
                cellValue = (record1[mappingName].ToString());
            }
            else
            {
                DataRowView record1 = dGrid.View.Records.GetItemAt(recordIndex) as DataRowView;
                cellValue = (record1[mappingName].ToString());
            }
            return cellValue;
        }
        /*SFDATAGRİD*/

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

        int kayit = 0;
        public int bilgi(string query, string sutun)
        {
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = query;
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            if (dr.Read())
            {
                try
                {
                    kayit = Convert.ToInt16(dr[sutun].ToString());
                    connection.Close();
                }
                catch { kayit = 0; connection.Close(); }
            }
            else
            {
                kayit = 0;
                connection.Close();
            }
            return kayit;
        }

        string kayitText = "";
        public string bilgiText(string query, string sutun)
        {
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = query;
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            if (dr.Read())
            {
                kayitText = dr[sutun].ToString();
                connection.Close();
            }
            else
            {
                kayitText = "";
                connection.Close();
            }
            return kayitText;
        }

        /*SATIN ALMA SÜREÇ*********/
        private void labelBekleyen_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            labelBaslik.Text = labelBekleyen.Text;
            btnSipBaslat.Visible = false;
            sfDataGrid1.Visible = false;
            advancedDataGridView1.Columns.Clear();

            /*İÇ TEDARİK SORUMLUSU
             Miktar girişi yapar - Onay-Red butonlarını göremez*/
            if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
            {
                buttonKayit.Enabled = true;
                FillAdvDataGridView(advancedDataGridView1, "SELECT id, talepNo, kullanici, urun, urunKategori, miktar, birim, durum, termin, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc FROM satinalma.sarftalep where durum='Depo Talebi' and miktar in ('Belirsiz','') and depoKabulTarihi is null", bindingSource1);
                advancedDataGridView1.Columns["kullanici"].Visible = false;

                //miktar sütununu renklendiriyoruz - değişiklik yapılabileceğini belirtmek için
                for (int i = 0; i < advancedDataGridView1.RowCount; i++)
                {
                    advancedDataGridView1.Rows[i].Cells["miktar"].Style.BackColor = Color.Orange;
                    advancedDataGridView1.Rows[i].Cells["miktar"].Style.ForeColor = Color.White;
                    advancedDataGridView1.Columns["miktar"].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                }
            }
            /*YETKİLİ
             Miktarı belli olanları görüntüler - Onay-Red butonları aktif olur*/
            else if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("YETKİLİ") != -1)
            {
                FillAdvDataGridView(advancedDataGridView1, "SELECT id, talepNo, kullanici, urun, urunKategori, miktar, birim, durum, termin, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc FROM satinalma.sarftalep where durum='Depo Talebi' and miktar not in ('Belirsiz','') and depoKabulTarihi is null", bindingSource1);
                advancedDataGridView1.Columns["kullanici"].Visible = false;

                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                btn1.HeaderText = "Onayla";
                btn1.Text = "ONAY";
                btn1.Name = "onay";
                btn1.UseColumnTextForButtonValue = true;
                btn1.DefaultCellStyle.BackColor = Color.Green;
                btn1.Width = 100;
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn2.HeaderText = "Reddet";
                btn2.Text = "RED";
                btn2.Name = "red";
                btn2.UseColumnTextForButtonValue = true;
                btn2.DefaultCellStyle.BackColor = Color.Red;
                btn2.Width = 100;
                DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
                btn3.HeaderText = "Geri Dönüş";
                btn3.Text = "GERİ DÖNÜŞ BİLDİR";
                btn3.Name = "donus";
                btn3.UseColumnTextForButtonValue = true;
                btn3.DefaultCellStyle.BackColor = Color.Orange;
                btn3.Width = 200;
                //Butonu kolon olarak ekliyoruz
                advancedDataGridView1.Columns.Add(btn1);
                advancedDataGridView1.Columns.Add(btn2);
                advancedDataGridView1.Columns.Add(btn3);
            }
        }

        private void buttonKayit_Click(object sender, EventArgs e)
        {
            //Talep Miktarı Güncelleme
            try
            {
                string query = "update satinalma.sarftalep set miktar = '" + advancedDataGridView1.CurrentRow.Cells["miktar"].Value.ToString() + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
                connect(query);
                MessageBox.Show(advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " Numaralı Talebin Miktarı Güncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelBekleyen_Click(sender, e);
                Form4_Load(sender, e);  //txBox.Text adetleri de güncellensin işlemden sonra
            }
            catch { MessageBox.Show("Veritabanı Erişiminde Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //FaturaNo Güncelleme
            try
            {
                string query = "update satinalma.sarfteklif set faturaNo = '" + advancedDataGridView1.CurrentRow.Cells["faturaNo"].Value.ToString() + "', faturaOnayTarihi = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
                connect(query);
                MessageBox.Show(advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " Numaralı Talebin Fatura Numarası Güncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelBekleyen_Click(sender, e);
                Form4_Load(sender, e);  //txBox.Text adetleri de güncellensin işlemden sonra
            }
            catch { MessageBox.Show("Veritabanı Erişiminde Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void labelOnayli_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
            { comboTemsilci.Visible = true; buttonAta.Visible = true; }
            else if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("YETKİLİ") != -1)
            { comboTemsilci.Visible = false; buttonAta.Visible = false; }
            buttonKayit.Enabled = false;
            btnSipBaslat.Visible = false;
            labelBaslik.Text = labelOnayli.Text;
            sfDataGrid1.Visible = false;

            //Combonun içi doldurulur
            comboTemsilci.Items.Clear();
            FillCombo(comboTemsilci);

            advancedDataGridView1.Columns.Clear();

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            CheckBox check = new CheckBox();
            checkColumn.HeaderText = "Grup";
            checkColumn.Width = 70;
            advancedDataGridView1.Columns.Add(checkColumn);

            FillAdvDataGridView(advancedDataGridView1, "SELECT id, talepNo, kullanici, urun, urunKategori, miktar, birim, durum, termin, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, tarih as talepOnayTarihi, talepOnayYetkilisi FROM satinalma.sarftalep where durum = 'Talep Onay' and kullanici is null and depoKabulTarihi is null", bindingSource1);
            advancedDataGridView1.Columns["kullanici"].Visible = false;

            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            //combo.HeaderText = "Talep Kullanıcı";
            //combo.Items.Add("Cuma ÇOLAK");
            //combo.Items.Add("Volkan ÇELİK");
            //combo.DefaultCellStyle.Font = new Font("Calibri", 10);
            //combo.Name = "ata";
            //advancedDataGridView1.Columns.Add(combo);

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Talep Atama";
            //btn.Text = "ATA";
            //btn.Name = "ata";
            //btn.UseColumnTextForButtonValue = true;
            //btn.DefaultCellStyle.BackColor = Color.Orange;
            //btn.Width = 100;
            //advancedDataGridView1.Columns.Add(btn);
        }

        int num = 0;    //Seçili checkbox sayısını vermesi için kullanılan fonksiyon.
        private void advancedDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                bool isChecked = (bool)advancedDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                if (isChecked)
                    num += 1;
                else
                    num -= 1;
                //labelSelectedSum.Text = "Selected Items: " + num;
            }
            catch { }

        }

        private void buttonAta_Click(object sender, EventArgs e)
        {
            //Gruplayarak Kullanici Atar.
            if (comboTemsilci.Text != "")
            {
                int sondort = bilgi("SELECT max(cast(right(grup,4)as decimal)) as sondort FROM satinalma.sarftalep where grup is not null", "sondort");
                string son = "GUR" + Convert.ToString(sondort + 1).PadLeft(4, '0');

                if(num < 6)//num : seçili checkbox sayısını verir.
                {
                    foreach (DataGridViewRow row in advancedDataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
                        {
                            string query = "update satinalma.sarftalep set kullanici = '" + comboTemsilci.Text.ToUpper() + "', grup = '" + son + "' where id = " + row.Cells["id"].Value.ToString() + " ";
                            connect(query);
                        }
                    }
                    MessageBox.Show("Seçili Talepler Satın Alma Sorumlusuna Atandı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                 MessageBox.Show("Gruplamak için 1-5 Arasında Satır Adedini Seçmeniz Gerekmektedir. 5 Adetten Fazla Talep, Aynı Grupta Bulunamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                num = 0;
                labelOnayli_Click(sender, e);
                Form4_Load(sender, e);
            }
            else { MessageBox.Show("Lütfen Temsilciyi Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
        }

        private void FillCombo(ComboBox combo)
        {
            connection.Open();
            //Combonun içi doldurulur
            MySqlCommand sorgu = new MySqlCommand("SELECT concat(ad, ' ', soyad) as adsoyad FROM ık.kullanıcı where birim like '%SARF SATINALMA%' and unvan like '%İÇ TEDARİK SORUMLUSU%'", connection);
            sorgu.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(sorgu);
            adp.Fill(dt);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                combo.Items.Add(dr["adsoyad"].ToString());
            }
            connection.Close();
        }

        internal void labelTalep_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            buttonKayit.Enabled = false;
            labelBaslik.Text = labelTalep.Text;
            btnSipBaslat.Visible = false;
            sfDataGrid1.Visible = false;

            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT id, talepNo, kullanici, urun, urunKategori, miktar, birim, durum, termin, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, tarih as talepOnayTarihi, talepOnayYetkilisi FROM satinalma.sarftalep where kullanici is not null and durum = 'Talep Onay' and depoKabulTarihi is null", bindingSource1);
        }

        private void comboKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT id, talepNo, kullanici, urun, urunKategori, miktar, birim, durum, termin, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, tarih as talepOnayTarihi, talepOnayYetkilisi FROM satinalma.sarftalep where durum = 'Talep Onay' and depoKabulTarihi is null", bindingSource1);
        }

        internal void labelTeklif_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            buttonKayit.Enabled = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            labelBaslik.Text = labelTeklif.Text;
            btnSipBaslat.Visible = false;
            advancedDataGridView1.Columns.Clear();

            sfDataGrid1.Visible = true;
        }

        private void labelOnaySip_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            buttonKayit.Enabled = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            sfDataGrid1.Visible = false;
            labelBaslik.Text = labelOnaySip.Text;
            if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
                btnSipBaslat.Visible = true;
            else if (bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "' ", "unvan").ToString().IndexOf("YETKİLİ") != -1)
                btnSipBaslat.Visible = false;

            //Onaylı Siparişler
            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT f.id, teklifNo, siparisNo, f.urun, f.miktar, f.birim, f.firma, f.durum, f.toplamFiyat, f.iskonto, f.genelToplam, f.onaylayan, f.birimFiyat, f.paraBirimi, f.tarih, f.kullanici, f.vade, f.kdv, f.sonToplam, f.terminSuresi, f.firmaIlgiliKisi, f.siparisMiktari, f.firmaAciklamasi, urunKategori, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, p.tarih as talepOnayTarihi, talepOnayYetkilisi, grup, depoKabulTarihi FROM satinalma.sarfteklif f left join satinalma.sarftalep p on substring(f.teklifNo,1,14) = p.talepNo where f.durum = 'Onaylandı' and siparisNo is null and depoKabulTarihi is null and grup is not null", bindingSource1);

            //siparisNo sütununu renklendiriyoruz - Siparişi Başlat butonu, bu alanı doldurmak içindir
            for (int i = 0; i < advancedDataGridView1.RowCount; i++)
            {
                advancedDataGridView1.Rows[i].Cells["siparisNo"].Style.BackColor = Color.PaleTurquoise;
            }
        }

        int no = 0, teklif = 0;
        string sonuc = "", kayitli = "", maks = "";
        private void btnSipBaslat_Click(object sender, EventArgs e)
        {
            //kategori
            string kategori = advancedDataGridView1.SelectedRows[0].Cells["teklifNo"].Value.ToString().Substring(2, 2);
            //tarih
            int gun = DateTime.Now.Day;
            string a = gun.ToString().PadLeft(2, '0');
            int ay = DateTime.Now.Month;
            string b = ay.ToString().PadLeft(2, '0');
            int c = DateTime.Now.Year;
            string tarih = a + b + c;
            //no
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = "select count(id) as kayitli from satinalma.sarfteklif where siparisNo like '%" + a + b + c + "%'";
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            if (dr.Read())
            {
                kayitli = dr["kayitli"].ToString();
                if (kayitli == "0") //varsayılan günde kayıt var mı kontrolü
                {
                    no += 1;
                    sonuc = no.ToString().PadLeft(2, '0');
                    connection.Close();
                }
                else
                {
                    connection.Close();
                    connection.Open();
                    mySqlCommand.Connection = connection;
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.CommandText = "select max(substring(siparisNo, -2, 2)) as siparisNumarasi from satinalma.sarfteklif where siparisNo like '%" + a + b + c + "%'";
                    MySqlDataReader dd = mySqlCommand.ExecuteReader();

                    if (dd.Read())
                    {
                        maks = dd["siparisNumarasi"].ToString();
                        teklif = Convert.ToInt16(maks);
                        teklif += 1;
                        sonuc = teklif.ToString().PadLeft(2, '0');
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("veritabanına erişilemedi");
                connection.Close();
            }

            string siparisNo = "T" + kategori + tarih + sonuc;
            for (int i = 0; i < advancedDataGridView1.SelectedRows.Count; i++)
            {
                if (bilgiText("select siparisNo from satinalma.sarfteklif where id = '" + advancedDataGridView1.SelectedRows[i].Cells["id"].Value.ToString() + "' ", "siparisNo") == String.Empty)
                {
                    try
                    {
                        string sorgu = "update satinalma.sarfteklif set siparisNo = '" + siparisNo + "' where id = '" + advancedDataGridView1.SelectedRows[i].Cells["id"].Value.ToString() + "' ";
                        connect(sorgu);
                        MessageBox.Show("Seçili Tekliflerin Sipariş Süreci Başlatıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch { MessageBox.Show("Sipariş Başlatılırken Hata ile Karşılaşıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void labelVerilen_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            buttonKayit.Enabled = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            labelBaslik.Text = labelVerilen.Text;
            btnSipBaslat.Visible = false;
            sfDataGrid1.Visible = false;

            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT f.id, teklifNo, siparisNo, f.urun, f.miktar, f.birim, f.firma, f.durum, f.toplamFiyat, f.iskonto, f.genelToplam, f.onaylayan, f.birimFiyat, f.paraBirimi, f.tarih, f.kullanici, f.vade, f.kdv, f.sonToplam, f.terminSuresi, f.firmaIlgiliKisi, f.firmaAciklamasi, urunKategori, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, p.tarih as talepOnayTarihi, talepOnayYetkilisi, grup, f.siparisMiktari, f.irsaliyeNo, depoKabulTarihi FROM satinalma.sarfteklif f left join satinalma.sarftalep p on substring(f.teklifNo,1,14) = p.talepNo where f.durum = 'Onaylandı' and irsaliyeNo is null and siparisNo is not null and grup is not null", bindingSource1);
        }

        private void labelTamam_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = false;
            buttonKayit.Enabled = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            labelBaslik.Text = labelTamam.Text;
            btnSipBaslat.Visible = false;
            sfDataGrid1.Visible = false;
            //advancedDataGridView1.ReadOnly = true;
            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT f.id, faturaNo, faturaOnayTarihi, teklifNo, siparisNo, f.urun, f.miktar, f.birim, f.firma, f.durum, f.toplamFiyat, f.iskonto, f.genelToplam, f.onaylayan, f.birimFiyat, f.paraBirimi, f.tarih, f.kullanici, f.vade, f.kdv, f.sonToplam, f.terminSuresi, f.firmaIlgiliKisi, f.firmaAciklamasi, urunKategori, aciklama, birimTalepTarihi, birimTalepYetkilisi, depoTalepTarihi, talepEden as depoTalepYetkilisi, sonuc, p.tarih as talepOnayTarihi, talepOnayYetkilisi, grup, f.siparisMiktari, f.irsaliyeNo, depoKabulTarihi FROM satinalma.sarfteklif f left join satinalma.sarftalep p on substring(f.teklifNo,1,14) = p.talepNo where f.durum = 'Onaylandı' and irsaliyeNo is not null", bindingSource1);

            //faturaNo sütununu renklendiriyoruz - değişiklik yapılabilmesi için
            for (int i = 0; i < advancedDataGridView1.RowCount; i++)
            {
                advancedDataGridView1.Rows[i].Cells["faturaNo"].Style.BackColor = Color.PaleTurquoise;
                advancedDataGridView1.Rows[i].Cells["faturaNo"].Style.ForeColor = Color.Black;
                advancedDataGridView1.Columns["faturaNo"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Regular);
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (labelBaslik.Text == "Birim Onay Bekleyen Talepler")
                labelBekleyen_Click(sender, e);
            else if (labelBaslik.Text == "Birim Onaylı Talepler")
                labelOnayli_Click(sender, e);
            else if (labelBaslik.Text == "Birim Talep / Teklif Listesi")
                labelTalep_Click(sender, e);
            else if (labelBaslik.Text == "Teklif Karar Formu")
                labelTeklif_Click(sender, e);
            else if (labelBaslik.Text == "Onaylı Siparişler")
                labelOnaySip_Click(sender, e);
            else if (labelBaslik.Text == "Verilen Siparişler")
                labelVerilen_Click(sender, e);
            else if (labelBaslik.Text == "Tamamlanan Siparişler")
                labelTamam_Click(sender, e);

            Form4_Load(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "˄")
            {//navbar kapanıyorsa
                label4.Text = "˅";

                txBoxBekleyen.Visible = false;
                txBoxOnayli.Visible = false;
                txBoxTalep.Visible = false;
                txBoxTeklif.Visible = false;
                txBoxOnaySip.Visible = false;
                txBoxVerilen.Visible = false;
                txBoxTamamlanan.Visible = false;

                // RowStyles index is index of the row you are dealing with
                for (int i = 1; i < 9; i++)
                {
                    tableLayoutPanelLink.RowStyles[i].SizeType = SizeType.Absolute;
                    tableLayoutPanelLink.RowStyles[i].Height = 0;
                }

                tableLayoutPanelLink.RowStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelLink.RowStyles[0].Height = 48;
            }
            else if (label4.Text == "˅")
            {//navBar açılıyorsa 
                label4.Text = "˄";

                txBoxBekleyen.Visible = true;
                txBoxOnayli.Visible = true;
                txBoxTalep.Visible = true;
                txBoxTeklif.Visible = true;
                txBoxOnaySip.Visible = true;
                txBoxVerilen.Visible = true;
                txBoxTamamlanan.Visible = true;

                //tableLayoutPanelLink.RowStyles[0].SizeType = SizeType.Absolute;
                //tableLayoutPanelLink.RowStyles[0].Height = 48;
                for (int i = 1; i < 9; i++)
                {
                    tableLayoutPanelLink.RowStyles[i].SizeType = SizeType.Absolute;
                    tableLayoutPanelLink.RowStyles[i].Height =20;
                }
            }
        }

        string query = "";
        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //MessageBox.Show(advancedDataGridView1.Columns[advancedDataGridView1.CurrentCell.ColumnIndex].HeaderText);
                if (advancedDataGridView1.Columns[advancedDataGridView1.CurrentCell.ColumnIndex].HeaderText == "Onayla")    //ONAY BUTONU
                {
                    query = "update satinalma.sarftalep set durum = 'Talep Onay', tarih = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', talepOnayYetkilisi = '" + labelTemsilci.Text + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
                    connect(query);
                    MessageBox.Show("Talep Onaylandı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelBekleyen_Click(sender, e);
                    Form4_Load(sender, e);
                }
                else if (advancedDataGridView1.Columns[advancedDataGridView1.CurrentCell.ColumnIndex].HeaderText == "Reddet")      //RED BUTONU --advancedDataGridView1.CurrentCell.ColumnIndex == 19
                {
                    query = "update satinalma.sarftalep set durum = 'Talep Red', tarih = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', talepOnayYetkilisi = '" + labelTemsilci.Text + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
                    connect(query);
                    MessageBox.Show("Talep Reddedildi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelBekleyen_Click(sender, e);
                    Form4_Load(sender, e);
                }
                else if (advancedDataGridView1.Columns[advancedDataGridView1.CurrentCell.ColumnIndex].HeaderText == "Talep Atama")      //ATA BUTONU
                {
                    query = "update satinalma.sarftalep set kullanici = '" + kullanici.ToUpper() + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
                    connect(query);
                    MessageBox.Show("Talep Satın Alma Sorumlusuna Atandı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelOnayli_Click(sender, e);
                    Form4_Load(sender, e);
                }
                else if (advancedDataGridView1.Columns[advancedDataGridView1.CurrentCell.ColumnIndex].HeaderText == "Geri Dönüş")      //GERİ DÖNÜŞ BUTONU
                {
                    panelDonus.Visible = true;
                }
            }
            catch { MessageBox.Show("Veritabanına Ulaşırken Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonRevize_Click(object sender, EventArgs e)
        {
            query = "update satinalma.sarftalep set geriDonus = '" + richTextBox1.Text.Replace("[%]", " % ").Replace("[\"]", "\"") + "', miktar = 'Belirsiz' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
            connect(query);
            MessageBox.Show("Talep, Revize Edilmesi için Satın Alma Sorumlusuna Geri Gönderildi .", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panelDonus.Visible = false;
            labelOnayli_Click(sender, e);
            Form4_Load(sender, e);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            query = "update satinalma.sarftalep set geriDonus = '" + richTextBox1.Text.Replace("[%]", " % ").Replace("[\"]", "\"") + "', durum = 'Talep Red', tarih = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', talepOnayYetkilisi = '" + labelTemsilci.Text + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
            connect(query);
            MessageBox.Show("Talep Reddedildi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panelDonus.Visible = false;
            labelBekleyen_Click(sender, e);
            Form4_Load(sender, e);
        }

        private void buttonOnay_Click(object sender, EventArgs e)
        {
            query = "update satinalma.sarftalep set geriDonus = '" + richTextBox1.Text.Replace("[%]", " % ").Replace("[\"]", "\"") + "', durum = 'Talep Onay', tarih = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', talepOnayYetkilisi = '" + labelTemsilci.Text + "' where id = " + advancedDataGridView1.CurrentRow.Cells["id"].Value.ToString() + " ";
            connect(query);
            MessageBox.Show("Talep Onaylandı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panelDonus.Visible = false;
            labelBekleyen_Click(sender, e);
            Form4_Load(sender, e);
        }

        /*STOKLAR******************/
        private void labelStok_Click(object sender, EventArgs e)
        {
            checkBoxKritik.Visible = true;
            checkBoxKritik.Checked = false;
            buttonKayit.Enabled = false;
            comboTemsilci.Visible = false;
            buttonAta.Visible = false;
            labelBaslik.Text = labelStok.Text;
            btnSipBaslat.Visible = false;
            sfDataGrid1.Visible = false;
            advancedDataGridView1.Columns.Clear();
            FillAdvDataGridView(advancedDataGridView1, "SELECT * FROM sarfdepo.sarfstok", bindingSource1);

            for (int i = 0; i < advancedDataGridView1.RowCount; i++)
            {
                if (Convert.ToInt32(advancedDataGridView1.Rows[i].Cells["Adet"].Value) <= 0)
                {
                    advancedDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                    advancedDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else if (Convert.ToInt32(advancedDataGridView1.Rows[i].Cells["Adet"].Value) <= 10)
                {
                    advancedDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    advancedDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void checkBoxKritik_CheckedChanged(object sender, EventArgs e)
        {   //Kritik Stok
            if (checkBoxKritik.Checked)
            {
                advancedDataGridView1.Columns.Clear();
                FillAdvDataGridView(advancedDataGridView1, "SELECT * FROM sarfdepo.sarfstok where cast(Adet as decimal) <= 10", bindingSource1);
                for (int i = 0; i < advancedDataGridView1.RowCount; i++)
                {
                    advancedDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                    advancedDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            else
                labelStok_Click(sender, e);
        }

        //Seçilen ComboBox Değerini Okuma-----
        private void advancedDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox; if (cb != null)
            {
                cb.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            }
        }

        string kullanici = "";
        public void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gecerli = advancedDataGridView1.CurrentCellAddress;
            var gelen = sender as DataGridViewComboBoxEditingControl;
            kullanici = gelen.EditingControlFormattedValue.ToString();
        }//Seçilen ComboBox Değerini Okuma Sonu-----

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = advancedDataGridView1.FilterString.Replace("[%]", "%").Replace("[\"]", "\"");
        }

        private void panelKapat_Click(object sender, EventArgs e)
        {
            panelDonus.Visible = false;
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = advancedDataGridView1.SortString;
        }

        /*YENİ ÜRÜN KARTI*****************/
        private void buttonYeniUrun_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
        }

        private void sfDataGrid1_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Get the "Country" column from the RowData   
            if (e.RowType == RowType.DefaultRow)
            {
                var dataRowView = e.RowData as DataRowView;
                if (dataRowView != null)
                {
                    var dataRow = dataRowView.Row;
                    var cellValue = dataRow["talepNo"].ToString();
                    var cellDurum = dataRow["durum"].ToString();

                    //Talebe ait teklif girilmişse
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand();
                    mySqlCommand.Connection = connection;
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.CommandText = "SELECT firma FROM satinalma.sarfteklif WHERE teklifNo like '" + cellValue + "%'";
                    MySqlDataReader dr = mySqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        e.Style.BackColor = Color.PaleTurquoise;
                    }
                    connection.Close();

                    //Talebe ait teklif reddedilmişse
                    if (cellDurum == "Teklif Red")
                        e.Style.BackColor = Color.IndianRed;
                }
            }
        }

    }
}
