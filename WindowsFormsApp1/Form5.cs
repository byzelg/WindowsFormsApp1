using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.Mail;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        decimal miktar = 0;
        decimal birimFiyat = 0;
        decimal toplam;
        decimal genelTop;
        decimal iskonto = 0;
        decimal kdv = 0;
        decimal sonToplam;
        string mevcut = "";
        int teklif = 0;
        string sonuc = "";
        string teklifNo = "";
        Form4 obj = (Form4)Application.OpenForms["Form4"]; 
        public string talep = "";

        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.50;Database=satinalma;Uid=localhost;Pwd=BYZroot1;Allow Zero Datetime=true");

        private void Form5_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (obj.bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "'", "unvan").ToString().IndexOf("İÇ TEDARİK SORUMLUSU") != -1)
            {//Satın alma yetkisi-checkboxlar kapalı
                tableLayoutFirma1.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma1.ColumnStyles[0].Width = 0;
                tableLayoutFirma2.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma2.ColumnStyles[0].Width = 0;
                tableLayoutFirma3.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma3.ColumnStyles[0].Width = 0;
                tableLayoutFirma4.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma4.ColumnStyles[0].Width = 0;
                tableLayoutFirma5.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma5.ColumnStyles[0].Width = 0;

                btnSonuc.Text = "Kaydet";
                btnSonuc.BackColor = Color.DarkGreen;
            }
            else if (obj.bilgiText("SELECT unvan FROM ık.kullanıcı where concat(ad,' ',soyad) ='" + labelTemsilci.Text + "'", "unvan").ToString().IndexOf("YETKİLİ") != -1)
            {//Müdür yetkisi-checkboxlar açık
                tableLayoutFirma1.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma1.ColumnStyles[0].Width = 100;
                tableLayoutFirma2.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma2.ColumnStyles[0].Width = 100;
                tableLayoutFirma3.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma3.ColumnStyles[0].Width = 100;
                tableLayoutFirma4.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma4.ColumnStyles[0].Width = 100;
                tableLayoutFirma5.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutFirma5.ColumnStyles[0].Width = 100;

                btnSonuc.Text = "Yayınla";
                btnSonuc.BackColor = Color.Brown;
            }

            FillCombo("SELECT distinct(firmaKisaAd) as firma FROM satinalma.sarftedarikci order by firmaKisaAd asc", "firma", comboFirma1);
            FillCombo("SELECT distinct(firmaKisaAd) as firma FROM satinalma.sarftedarikci order by firmaKisaAd asc", "firma", comboFirma2);
            FillCombo("SELECT distinct(firmaKisaAd) as firma FROM satinalma.sarftedarikci order by firmaKisaAd asc", "firma", comboFirma3);
            FillCombo("SELECT distinct(firmaKisaAd) as firma FROM satinalma.sarftedarikci order by firmaKisaAd asc", "firma", comboFirma4);
            FillCombo("SELECT distinct(firmaKisaAd) as firma FROM satinalma.sarftedarikci order by firmaKisaAd asc", "firma", comboFirma5);
        }

        internal void calistir(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand komut = new MySqlCommand("SELECT urunKategori, talepNo, urun, miktar, birim FROM satinalma.sarftalep where grup = '" + labelgrup.Text + "' ", connection);
            MySqlDataReader read = komut.ExecuteReader();
            int b = 0;
            int a = tableLayoutSol.Controls.Count - 1;
            while (read.Read())
            {
                while (a > -1)
                {
                    if (tableLayoutSol.Controls[a] is TableLayoutPanel)
                    {
                        TableLayoutPanel panel = (TableLayoutPanel)tableLayoutSol.Controls[a];
                        //int b = panel.Controls.Count - 1;
                        if (b < 5)
                        {
                            int index = 0;
                            while (panel.Controls[b] is Label)
                            {
                                if ((panel.Controls[index]).Name == "kategori" + (b + 1))
                                    (panel.Controls[index]).Text = read["urunKategori"].ToString();
                                else if ((panel.Controls[index]).Name == "talepno" + (b + 1))
                                    (panel.Controls[index]).Text = read["talepNo"].ToString();
                                else if ((panel.Controls[index]).Name == "talepbirim" + (b + 1))
                                    (panel.Controls[index]).Text = "";
                                else if ((panel.Controls[index]).Name == "urun" + (b + 1))
                                    (panel.Controls[index]).Text = read["urun"].ToString();
                                else if ((panel.Controls[index]).Name == "miktar" + (b + 1))
                                    (panel.Controls[index]).Text = read["miktar"].ToString();
                                else if ((panel.Controls[index]).Name == "birim" + (b + 1))
                                    (panel.Controls[index]).Text = read["birim"].ToString();
                                index++;
                                if (index == 6)
                                    break;
                            }
                            b++;
                            break;
                        }
                    }
                    a--;
                }
                a--;
            }
            connection.Close();
            if (miktar5.Text == "Miktar")
            { tableLayout21.Enabled = false; tableLayout22.Enabled = false; tableLayout23.Enabled = false; tableLayout24.Enabled = false; tableLayout25.Enabled = false; tableLayoutTalep5.Enabled = false; }
            if (miktar4.Text == "Miktar")
            { tableLayout16.Enabled = false; tableLayout17.Enabled = false; tableLayout18.Enabled = false; tableLayout19.Enabled = false; tableLayout20.Enabled = false; tableLayoutTalep4.Enabled = false; }
            if (miktar3.Text == "Miktar")
            { tableLayout11.Enabled = false; tableLayout12.Enabled = false; tableLayout13.Enabled = false; tableLayout14.Enabled = false; tableLayout15.Enabled = false; tableLayoutTalep3.Enabled = false; }
            if (miktar2.Text == "Miktar")
            { tableLayout6.Enabled = false; tableLayout7.Enabled = false; tableLayout8.Enabled = false; tableLayout9.Enabled = false; tableLayout10.Enabled = false; tableLayoutTalep2.Enabled = false; }
            if (miktar1.Text == "Miktar")
            { tableLayout1.Enabled = false; tableLayout2.Enabled = false; tableLayout3.Enabled = false; tableLayout4.Enabled = false; tableLayout5.Enabled = false; tableLayoutTalep1.Enabled = false; }

            //Kayıtlı Teklifin Firmasını Getirme
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = "SELECT firma FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%'";
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            while (dr.Read())
            {
                doldur = true;
                if (comboFirma1.Text == String.Empty)
                    comboFirma1.Text = dr["firma"].ToString();
                else if (comboFirma2.Text == String.Empty)
                    comboFirma2.Text = dr["firma"].ToString();
                else if (comboFirma3.Text == String.Empty)
                    comboFirma3.Text = dr["firma"].ToString();
                else if (comboFirma4.Text == String.Empty)
                    comboFirma4.Text = dr["firma"].ToString();
                else if (comboFirma5.Text == String.Empty)
                    comboFirma5.Text = dr["firma"].ToString();
            }
            connection.Close();
            doldur = false;
            comboFirma1_SelectedIndexChanged(sender, e);
            getir(talepno1, comboFirma1, birimfiyat1, iskonto1, kdv1, termin1, combo1);
            getir(talepno2, comboFirma1, birimfiyat6, iskonto6, kdv6, termin6, combo6);
            getir(talepno3, comboFirma1, birimfiyat11, iskonto11, kdv11, termin11, combo11);
            getir(talepno4, comboFirma1, birimfiyat16, iskonto16, kdv16, termin16, combo16);
            getir(talepno5, comboFirma1, birimfiyat21, iskonto21, kdv21, termin21, combo21);
            comboFirma2_SelectedIndexChanged(sender, e);
            getir(talepno1, comboFirma2, birimfiyat2, iskonto2, kdv2, termin2, combo2);
            getir(talepno2, comboFirma2, birimfiyat7, iskonto7, kdv7, termin7, combo7);
            getir(talepno3, comboFirma2, birimfiyat12, iskonto12, kdv12, termin12, combo12);
            getir(talepno4, comboFirma2, birimfiyat17, iskonto17, kdv17, termin17, combo17);
            getir(talepno5, comboFirma2, birimfiyat22, iskonto22, kdv22, termin22, combo22);
            comboFirma3_SelectedIndexChanged(sender, e);
            getir(talepno1, comboFirma3, birimfiyat3, iskonto3, kdv3, termin3, combo3);
            getir(talepno2, comboFirma3, birimfiyat8, iskonto8, kdv8, termin8, combo8);
            getir(talepno3, comboFirma3, birimfiyat13, iskonto13, kdv13, termin13, combo13);
            getir(talepno4, comboFirma3, birimfiyat18, iskonto18, kdv18, termin18, combo18);
            getir(talepno5, comboFirma3, birimfiyat23, iskonto23, kdv23, termin23, combo23);
            comboFirma4_SelectedIndexChanged(sender, e);
            getir(talepno1, comboFirma4, birimfiyat4, iskonto4, kdv4, termin4, combo4);
            getir(talepno2, comboFirma4, birimfiyat9, iskonto9, kdv9, termin9, combo9);
            getir(talepno3, comboFirma4, birimfiyat14, iskonto14, kdv14, termin14, combo14);
            getir(talepno4, comboFirma4, birimfiyat19, iskonto19, kdv19, termin19, combo19);
            getir(talepno5, comboFirma4, birimfiyat24, iskonto24, kdv24, termin24, combo24);
            comboFirma5_SelectedIndexChanged(sender, e);
            getir(talepno1, comboFirma5, birimfiyat5, iskonto5, kdv5, termin5, combo5);
            getir(talepno2, comboFirma5, birimfiyat10, iskonto10, kdv10, termin10, combo10);
            getir(talepno3, comboFirma5, birimfiyat15, iskonto15, kdv15, termin15, combo15);
            getir(talepno4, comboFirma5, birimfiyat20, iskonto20, kdv20, termin20, combo20);
            getir(talepno5, comboFirma5, birimfiyat25, iskonto25, kdv25, termin25, combo25);
        }
        Boolean doldur; //comboBox_SelectedIndexChanged Olayında connection.Close() çalıştırmaması için

        private void getir(Label TalepNo, ComboBox ComboFirma, TextBox BirimFiyat, TextBox Iskonto, TextBox Kdv, TextBox Termin, ComboBox ParaBirim)
        {
            //Firmaya Bağlı Kayıtlı Teklifi Getirme
            connection.Open();
            MySqlCommand mySqlCommand1 = new MySqlCommand();
            mySqlCommand1.Connection = connection;
            mySqlCommand1.CommandType = CommandType.Text;
            mySqlCommand1.CommandText = "SELECT birimFiyat,iskonto,kdv,terminSuresi,paraBirimi FROM satinalma.sarfteklif WHERE teklifNo like '" + TalepNo.Text + "%' and firma = '" + ComboFirma.Text + "' ";
            MySqlDataReader dr1 = mySqlCommand1.ExecuteReader();
            if (dr1.Read())
            {
                BirimFiyat.Text= dr1["birimFiyat"].ToString().Replace(".", ",");
                Iskonto.Text = dr1["iskonto"].ToString().Replace(".", ",");
                Kdv.Text = dr1["kdv"].ToString().Replace(".", ",");
                Termin.Text = dr1["terminSuresi"].ToString();
                ParaBirim.Text = dr1["paraBirimi"].ToString();
            }
            connection.Close();
        }

        private void tableLayout1Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar1, birimfiyat1, iskonto1, kdv1, toplam1, genel1, son1);
        }

        private void tableLayout2Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar1, birimfiyat2, iskonto2, kdv2, toplam2, genel2, son2);
        }

        private void tableLayout3Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar1, birimfiyat3, iskonto3, kdv3, toplam3, genel3, son3);
        }

        private void tableLayout4Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar1, birimfiyat4, iskonto4, kdv4, toplam4, genel4, son4);
        }

        private void tableLayout5Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar1, birimfiyat5, iskonto5, kdv5, toplam5, genel5, son5);
        }

        private void tableLayout6Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar2, birimfiyat6, iskonto6, kdv6, toplam6, genel6, son6);
        }

        private void tableLayout7Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar2, birimfiyat7, iskonto7, kdv7, toplam7, genel7, son7);
        }

        private void tableLayout8Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar2, birimfiyat8, iskonto8, kdv8, toplam8, genel8, son8);
        }

        private void tableLayout9Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar2, birimfiyat9, iskonto9, kdv9, toplam9, genel9, son9);
        }

        private void tableLayout10Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar2, birimfiyat10, iskonto10, kdv10, toplam10, genel10, son10);
        }

        private void tableLayout11Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar3, birimfiyat11, iskonto11, kdv11, toplam11, genel11, son11);
        }

        private void tableLayout12Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar3, birimfiyat12, iskonto12, kdv12, toplam12, genel12, son12);
        }

        private void tableLayout13Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar3, birimfiyat13, iskonto13, kdv13, toplam13, genel13, son13);
        }

        private void tableLayout14Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar3, birimfiyat14, iskonto14, kdv14, toplam14, genel14, son14);
        }

        private void tableLayout15Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar3, birimfiyat15, iskonto15, kdv15, toplam15, genel15, son15);
        }

        private void tableLayout16Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar4, birimfiyat16, iskonto16, kdv16, toplam16, genel16, son16);
        }

        private void tableLayout17Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar4, birimfiyat17, iskonto17, kdv17, toplam17, genel17, son17);
        }

        private void tableLayout18Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar4, birimfiyat18, iskonto18, kdv18, toplam18, genel18, son18);
        }

        private void tableLayout19Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar4, birimfiyat19, iskonto19, kdv19, toplam19, genel19, son19);
        }

        private void tableLayout20Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar4, birimfiyat20, iskonto20, kdv20, toplam20, genel20, son20);
        }

        private void tableLayout21Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar5, birimfiyat21, iskonto21, kdv21, toplam21, genel21, son21);
        }
        private void tableLayout22Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar5, birimfiyat22, iskonto22, kdv22, toplam22, genel22, son22);
        }

        private void tableLayout23Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar5, birimfiyat23, iskonto23, kdv23, toplam23, genel23, son23);
        }

        private void tableLayout24Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar5, birimfiyat24, iskonto24, kdv24, toplam24, genel24, son24);
        }

        private void tableLayout25Text_TextChanged(object sender, EventArgs e)
        {
            hesap_TextChanged(miktar5, birimfiyat25, iskonto25, kdv25, toplam25, genel25, son25);
        }

        private void hesap_TextChanged(Label Miktar, TextBox Birim, TextBox Iskonto, TextBox Kdv, Label Top, Label Genel, Label Son)
        {
            try
            {
                //toplamFiyat
                miktar = Convert.ToDecimal(Miktar.Text);
                birimFiyat = Convert.ToDecimal(Birim.Text);
                toplam = miktar * birimFiyat;
                Top.Text = string.Format("{0:#.####}", Convert.ToDecimal(toplam)).Replace("₺", "").Replace(" ", "");
                try
                {
                    //genelToplam
                    iskonto = Convert.ToDecimal(Iskonto.Text);
                    genelTop = toplam - (toplam * iskonto) / 100;
                    Genel.Text = string.Format("{0:#.####}", Convert.ToDecimal(genelTop)).Replace("₺", "").Replace(" ", "");
                    try
                    {
                        //SonToplam
                        kdv = Convert.ToDecimal(Kdv.Text);
                        sonToplam = genelTop * (1 + kdv / 100);
                        Son.Text = string.Format("{0:#.####}", Convert.ToDecimal(sonToplam)).Replace("₺", "").Replace(" ", "");
                    }
                    catch { Son.Text = "0"; }
                }
                catch { Genel.Text = "0"; Son.Text = "0"; }
            }
            catch { Top.Text = "0"; Genel.Text = "0"; Son.Text = "0"; }
        }

        private void kaydet(Label Talepno, Label Urun, Label Miktar, Label Birim, ComboBox Firma, Label Vade, Label Ilgili, ComboBox Parabirim, TextBox BirimFiyat, TextBox Iskonto, TextBox Kdv, Label Top, Label Genel, Label Son, TextBox Termin, RichTextBox RichTextBox)
        {
            //tarih
            int gun = DateTime.Now.Day;
            string a = gun.ToString().PadLeft(2, '0');
            int ay = DateTime.Now.Month;
            string b = ay.ToString().PadLeft(2, '0');
            int c = DateTime.Now.Year;
            string tarih = c + "-" + b + "-" + a;

            //kullanici
            string kullanici = labelTemsilci.Text;

            //teklifNo
            string talepNumara = Talepno.Text;
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = "select max(substring(teklifNo,15,2)) as a from satinalma.sarfteklif where teklifNo like '" + talepNumara + "%'";
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            if (dr.Read())
            {
                mevcut = dr["a"].ToString();
                if (mevcut == "")
                {
                    teklif = 1;
                    sonuc = teklif.ToString().PadLeft(2, '0');
                    teklifNo = talepNumara + sonuc;
                    connection.Close();
                }
                else
                {
                    teklif = Int32.Parse(mevcut);
                    teklif += 1;
                    sonuc = teklif.ToString().PadLeft(2, '0');
                    teklifNo = talepNumara + sonuc;
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Veritabanına Erişilemedi");
                connection.Close();
            }

            //miktar
            miktar = Convert.ToDecimal(Miktar.Text);
            string mikt = miktar.ToString().Replace(",", ".");

            //iskonto
            iskonto = Convert.ToDecimal(Iskonto.Text);
            string iskont = iskonto.ToString().Replace(",", ".");

            //kdv
            kdv = Convert.ToDecimal(Kdv.Text);
            string kdV = kdv.ToString().Replace(",", ".");

            //veritabanına yazma komutu
            //decimal genelT = Convert.ToDecimal(Genel.Text);
            string genelT = Genel.Text.ToString().Replace(",", ".");
            //decimal top = Convert.ToDecimal(Top.Text);
            string top = Top.Text.ToString().Replace(",", ".");
            //decimal sonT = Convert.ToDecimal(Son.Text);
            string sonT = Son.Text.ToString().Replace(",", ".");

            string query = "insert into satinalma.sarfteklif(teklifNo, tarih, kullanici, urun, miktar, birim, firma, vade, toplamFiyat, iskonto, genelToplam, birimFiyat, paraBirimi, kdv, sonToplam, terminSuresi,firmaIlgiliKisi, firmaAciklamasi) values('" + teklifNo + "', '" + tarih + "', '" + kullanici.ToUpper() + "', '" + Urun.Text + "', '" + mikt + "', '" + Birim.Text.ToUpper() + "', '" + Firma.Text.ToUpper() + "', '" + Vade.Text.ToUpper() + "', '" + top + "', '" + iskont + "', '" + genelT + "', '" + BirimFiyat.Text.Replace(",", ".") + "', '" + Parabirim.Text.ToUpper() + "', '" + kdV + "', '" + sonT + "','" + Termin.Text + "', '" + Ilgili.Text + "', '" + RichTextBox.Text + "')";
            connect(query);
            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepNumara + "'";
            connect(query2);
        }


        public void FillCombo(string query, string sutun, ComboBox combo)
        {
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = query;
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            while (dr.Read())
            {
                combo.Items.Add(dr[sutun].ToString());
            }
            connection.Close();
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

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            //geldiğim ekranı günceller
            obj.labelTeklif_Click(sender, e);
            
        }

        private void txBox_KeyPress(object sender, KeyPressEventArgs e)
        {   //sadece sayı ve virgül girişi sağlandı
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8;
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is RichTextBox)
            {
                Control cntrl = (Control)sender;
                cntrl.Text = "";
            }
        }

        private void richTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RichTextBox)
            {
                Control cntrl = (Control)sender;
                cntrl.Text = "Açıklama...";
            }
        }

        void comboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.ForeColor = SystemColors.WindowText;
        }

        void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.ForeColor = Color.Red;
        }

        Form4 form4 = new Form4();
        string queryteklif, querytalep;
        private void btnSonuc_Click(object sender, EventArgs e)
        {
            /*sarfteklif tablosuna kayıt*/
            if (btnSonuc.Text == "Kaydet")
            {
                int s = 0, k = 0;
                if (comboFirma1.Text == "")
                    comboBox_DropDown(comboFirma1, e);
                if (comboFirma2.Text == "")
                    comboBox_DropDown(comboFirma2, e);
                if (comboFirma3.Text == "")
                    comboBox_DropDown(comboFirma3, e);
                if (comboFirma4.Text == "")
                    comboBox_DropDown(comboFirma4, e);
                if (comboFirma5.Text == "")
                    comboBox_DropDown(comboFirma5, e);
                if (comboFirma1.ForeColor != Color.Red && comboFirma2.ForeColor != Color.Red && comboFirma3.ForeColor != Color.Red && comboFirma4.ForeColor != Color.Red && comboFirma5.ForeColor != Color.Red)
                {
                    //Zorunlu alanlar boş mu kontrolü
                    if (birimfiyat1.Text != String.Empty && iskonto1.Text != String.Empty && kdv1.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%' AND firma = '" + comboFirma1.Text + "' ", "satir") < 1)
                        { kaydet(talepno1, urun1, miktar1, birim1, comboFirma1, labelVade1, labelIlgili1, combo1, birimfiyat1, iskonto1, kdv1, toplam1, genel1, son1, termin1, richTextBox1); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat1.Text + "', iskonto = '" + iskonto1.Text + "', kdv = '" + kdv1.Text + "', terminSuresi = '" + termin1.Text + "', paraBirimi = '" + combo1.Text + "', toplamFiyat = '" + toplam1.Text + "', genelToplam = '" + genel1.Text + "', sonToplam = '" + son1.Text + "' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma1.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno1.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat2.Text != String.Empty && iskonto2.Text != String.Empty && kdv2.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%' AND firma = '" + comboFirma2.Text + "' ", "satir") < 1)
                        { kaydet(talepno1, urun1, miktar1, birim1, comboFirma2, labelVade2, labelIlgili2, combo2, birimfiyat2, iskonto2, kdv2, toplam2, genel2, son2, termin2, richTextBox2); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat2.Text + "', iskonto = '" + iskonto2.Text + "', kdv = '" + kdv2.Text + "', terminSuresi = '" + termin2.Text + "', paraBirimi = '" + combo2.Text + "', toplamFiyat = '" + toplam2.Text + "', genelToplam = '" + genel2.Text + "', sonToplam = '" + son2.Text + "' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma2.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno1.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat3.Text != String.Empty && iskonto3.Text != String.Empty && kdv3.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%' AND firma = '" + comboFirma3.Text + "' ", "satir") < 1)
                        { kaydet(talepno1, urun1, miktar1, birim1, comboFirma3, labelVade3, labelIlgili3, combo3, birimfiyat3, iskonto3, kdv3, toplam3, genel3, son3, termin3, richTextBox3); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat3.Text + "', iskonto = '" + iskonto3.Text + "', kdv = '" + kdv3.Text + "', terminSuresi = '" + termin3.Text + "', paraBirimi = '" + combo3.Text + "', toplamFiyat = '" + toplam3.Text + "', genelToplam = '" + genel3.Text + "', sonToplam = '" + son3.Text + "' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma3.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno1.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat4.Text != String.Empty && iskonto4.Text != String.Empty && kdv4.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%' AND firma = '" + comboFirma4.Text + "' ", "satir") < 1)
                        { kaydet(talepno1, urun1, miktar1, birim1, comboFirma4, labelVade4, labelIlgili4, combo4, birimfiyat4, iskonto4, kdv4, toplam4, genel4, son4, termin4, richTextBox4); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat4.Text + "', iskonto = '" + iskonto4.Text + "', kdv = '" + kdv4.Text + "', terminSuresi = '" + termin4.Text + "', paraBirimi = '" + combo4.Text + "', toplamFiyat = '" + toplam4.Text + "', genelToplam = '" + genel4.Text + "', sonToplam = '" + son4.Text + "' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma4.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno1.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat5.Text != String.Empty && iskonto5.Text != String.Empty && kdv5.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno1.Text + "%' AND firma = '" + comboFirma5.Text + "' ", "satir") < 1)
                        { kaydet(talepno1, urun1, miktar1, birim1, comboFirma5, labelVade5, labelIlgili5, combo5, birimfiyat5, iskonto5, kdv5, toplam5, genel5, son5, termin5, richTextBox5); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat5.Text + "', iskonto = '" + iskonto5.Text + "', kdv = '" + kdv5.Text + "', terminSuresi = '" + termin5.Text + "', paraBirimi = '" + combo5.Text + "', toplamFiyat = '" + toplam5.Text + "', genelToplam = '" + genel5.Text + "', sonToplam = '" + son5.Text + "' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma5.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno1.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat6.Text != String.Empty && iskonto6.Text != String.Empty && kdv6.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno2.Text + "%' AND firma = '" + comboFirma1.Text + "' ", "satir") < 1)
                        { kaydet(talepno2, urun2, miktar2, birim2, comboFirma1, labelVade1, labelIlgili1, combo6, birimfiyat6, iskonto6, kdv6, toplam6, genel6, son6, termin6, richTextBox1); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat6.Text + "', iskonto = '" + iskonto6.Text + "', kdv = '" + kdv6.Text + "', terminSuresi = '" + termin6.Text + "', paraBirimi = '" + combo6.Text + "', toplamFiyat = '" + toplam6.Text + "', genelToplam = '" + genel6.Text + "', sonToplam = '" + son6.Text + "' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma1.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno2.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat7.Text != String.Empty && iskonto7.Text != String.Empty && kdv7.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno2.Text + "%' AND firma = '" + comboFirma2.Text + "' ", "satir") < 1)
                        { kaydet(talepno2, urun2, miktar2, birim2, comboFirma2, labelVade2, labelIlgili2, combo7, birimfiyat7, iskonto7, kdv7, toplam7, genel7, son7, termin7, richTextBox2); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat7.Text + "', iskonto = '" + iskonto7.Text + "', kdv = '" + kdv7.Text + "', terminSuresi = '" + termin7.Text + "', paraBirimi = '" + combo7.Text + "', toplamFiyat = '" + toplam7.Text + "', genelToplam = '" + genel7.Text + "', sonToplam = '" + son7.Text + "' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma2.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno2.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat8.Text != String.Empty && iskonto8.Text != String.Empty && kdv8.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno2.Text + "%' AND firma = '" + comboFirma3.Text + "' ", "satir") < 1)
                        { kaydet(talepno2, urun2, miktar2, birim2, comboFirma3, labelVade3, labelIlgili3, combo8, birimfiyat8, iskonto8, kdv8, toplam8, genel8, son8, termin8, richTextBox3); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat8.Text + "', iskonto = '" + iskonto8.Text + "', kdv = '" + kdv8.Text + "', terminSuresi = '" + termin8.Text + "', paraBirimi = '" + combo8.Text + "', toplamFiyat = '" + toplam8.Text + "', genelToplam = '" + genel8.Text + "', sonToplam = '" + son8.Text + "' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma3.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno2.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat9.Text != String.Empty && iskonto9.Text != String.Empty && kdv9.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno2.Text + "%' AND firma = '" + comboFirma4.Text + "' ", "satir") < 1)
                        { kaydet(talepno2, urun2, miktar2, birim2, comboFirma4, labelVade4, labelIlgili4, combo9, birimfiyat9, iskonto9, kdv9, toplam9, genel9, son9, termin9, richTextBox4); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat9.Text + "', iskonto = '" + iskonto9.Text + "', kdv = '" + kdv9.Text + "', terminSuresi = '" + termin9.Text + "', paraBirimi = '" + combo9.Text + "', toplamFiyat = '" + toplam9.Text + "', genelToplam = '" + genel9.Text + "', sonToplam = '" + son9.Text + "' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma4.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno2.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat10.Text != String.Empty && iskonto10.Text != String.Empty && kdv10.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno2.Text + "%' AND firma = '" + comboFirma5.Text + "' ", "satir") < 1)
                        { kaydet(talepno2, urun2, miktar2, birim2, comboFirma5, labelVade5, labelIlgili5, combo10, birimfiyat10, iskonto10, kdv10, toplam10, genel10, son10, termin10, richTextBox5); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat10.Text + "', iskonto = '" + iskonto10.Text + "', kdv = '" + kdv10.Text + "', terminSuresi = '" + termin10.Text + "', paraBirimi = '" + combo10.Text + "', toplamFiyat = '" + toplam10.Text + "', genelToplam = '" + genel10.Text + "', sonToplam = '" + son10.Text + "' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma5.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno2.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat11.Text != String.Empty && iskonto11.Text != String.Empty && kdv11.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno3.Text + "%' AND firma = '" + comboFirma1.Text + "' ", "satir") < 1)
                        { kaydet(talepno3, urun3, miktar3, birim3, comboFirma1, labelVade1, labelIlgili1, combo11, birimfiyat11, iskonto11, kdv11, toplam11, genel11, son11, termin11, richTextBox1); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat11.Text + "', iskonto = '" + iskonto11.Text + "', kdv = '" + kdv11.Text + "', terminSuresi = '" + termin11.Text + "', paraBirimi = '" + combo11.Text + "', toplamFiyat = '" + toplam11.Text + "', genelToplam = '" + genel11.Text + "', sonToplam = '" + son11.Text + "' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma1.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno3.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat12.Text != String.Empty && iskonto12.Text != String.Empty && kdv12.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno3.Text + "%' AND firma = '" + comboFirma2.Text + "' ", "satir") < 1)
                        { kaydet(talepno3, urun3, miktar3, birim3, comboFirma2, labelVade2, labelIlgili2, combo12, birimfiyat12, iskonto12, kdv12, toplam12, genel12, son12, termin12, richTextBox2); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat12.Text + "', iskonto = '" + iskonto12.Text + "', kdv = '" + kdv12.Text + "', terminSuresi = '" + termin12.Text + "', paraBirimi = '" + combo12.Text + "', toplamFiyat = '" + toplam12.Text + "', genelToplam = '" + genel12.Text + "', sonToplam = '" + son12.Text + "' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma2.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno3.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat13.Text != String.Empty && iskonto13.Text != String.Empty && kdv13.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno3.Text + "%' AND firma = '" + comboFirma3.Text + "' ", "satir") < 1)
                        { kaydet(talepno3, urun3, miktar3, birim3, comboFirma3, labelVade3, labelIlgili3, combo13, birimfiyat13, iskonto13, kdv13, toplam13, genel13, son13, termin13, richTextBox3); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat13.Text + "', iskonto = '" + iskonto13.Text + "', kdv = '" + kdv13.Text + "', terminSuresi = '" + termin13.Text + "', paraBirimi = '" + combo13.Text + "', toplamFiyat = '" + toplam13.Text + "', genelToplam = '" + genel13.Text + "', sonToplam = '" + son13.Text + "' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma3.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno3.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat14.Text != String.Empty && iskonto14.Text != String.Empty && kdv14.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno3.Text + "%' AND firma = '" + comboFirma4.Text + "' ", "satir") < 1)
                        { kaydet(talepno3, urun3, miktar3, birim3, comboFirma4, labelVade4, labelIlgili4, combo14, birimfiyat14, iskonto14, kdv14, toplam14, genel14, son14, termin14, richTextBox4); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat14.Text + "', iskonto = '" + iskonto14.Text + "', kdv = '" + kdv14.Text + "', terminSuresi = '" + termin14.Text + "', paraBirimi = '" + combo14.Text + "', toplamFiyat = '" + toplam14.Text + "', genelToplam = '" + genel14.Text + "', sonToplam = '" + son14.Text + "' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma4.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno3.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat15.Text != String.Empty && iskonto15.Text != String.Empty && kdv15.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno3.Text + "%' AND firma = '" + comboFirma5.Text + "' ", "satir") < 1)
                        { kaydet(talepno3, urun3, miktar3, birim3, comboFirma5, labelVade5, labelIlgili5, combo15, birimfiyat15, iskonto15, kdv15, toplam15, genel15, son15, termin15, richTextBox5); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat15.Text + "', iskonto = '" + iskonto15.Text + "', kdv = '" + kdv15.Text + "', terminSuresi = '" + termin15.Text + "', paraBirimi = '" + combo15.Text + "', toplamFiyat = '" + toplam15.Text + "', genelToplam = '" + genel15.Text + "', sonToplam = '" + son15.Text + "' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma5.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno3.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat16.Text != String.Empty && iskonto16.Text != String.Empty && kdv16.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno4.Text + "%' AND firma = '" + comboFirma1.Text + "' ", "satir") < 1)
                        { kaydet(talepno4, urun4, miktar4, birim4, comboFirma1, labelVade1, labelIlgili1, combo16, birimfiyat16, iskonto16, kdv16, toplam16, genel16, son16, termin16, richTextBox1); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat16.Text + "', iskonto = '" + iskonto16.Text + "', kdv = '" + kdv16.Text + "', terminSuresi = '" + termin16.Text + "', paraBirimi = '" + combo16.Text + "', toplamFiyat = '" + toplam16.Text + "', genelToplam = '" + genel16.Text + "', sonToplam = '" + son16.Text + "' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma1.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno4.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat17.Text != String.Empty && iskonto17.Text != String.Empty && kdv17.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno4.Text + "%' AND firma = '" + comboFirma2.Text + "' ", "satir") < 1)
                        { kaydet(talepno4, urun4, miktar4, birim4, comboFirma2, labelVade2, labelIlgili2, combo17, birimfiyat17, iskonto17, kdv17, toplam17, genel17, son17, termin17, richTextBox2); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat17.Text + "', iskonto = '" + iskonto17.Text + "', kdv = '" + kdv17.Text + "', terminSuresi = '" + termin17.Text + "', paraBirimi = '" + combo17.Text + "', toplamFiyat = '" + toplam17.Text + "', genelToplam = '" + genel17.Text + "', sonToplam = '" + son17.Text + "' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma2.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno4.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat18.Text != String.Empty && iskonto18.Text != String.Empty && kdv18.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno4.Text + "%' AND firma = '" + comboFirma3.Text + "' ", "satir") < 1)
                        { kaydet(talepno4, urun4, miktar4, birim4, comboFirma3, labelVade3, labelIlgili3, combo18, birimfiyat18, iskonto18, kdv18, toplam18, genel18, son18, termin18, richTextBox3); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat18.Text + "', iskonto = '" + iskonto18.Text + "', kdv = '" + kdv18.Text + "', terminSuresi = '" + termin18.Text + "', paraBirimi = '" + combo18.Text + "', toplamFiyat = '" + toplam18.Text + "', genelToplam = '" + genel18.Text + "', sonToplam = '" + son18.Text + "' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma3.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno4.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat19.Text != String.Empty && iskonto19.Text != String.Empty && kdv19.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno4.Text + "%' AND firma = '" + comboFirma4.Text + "' ", "satir") < 1)
                        { kaydet(talepno4, urun4, miktar4, birim4, comboFirma4, labelVade4, labelIlgili4, combo19, birimfiyat19, iskonto19, kdv19, toplam19, genel19, son19, termin19, richTextBox4); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat19.Text + "', iskonto = '" + iskonto19.Text + "', kdv = '" + kdv19.Text + "', terminSuresi = '" + termin19.Text + "', paraBirimi = '" + combo19.Text + "', toplamFiyat = '" + toplam19.Text + "', genelToplam = '" + genel19.Text + "', sonToplam = '" + son19.Text + "' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma4.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno4.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat20.Text != String.Empty && iskonto20.Text != String.Empty && kdv20.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno4.Text + "%' AND firma = '" + comboFirma5.Text + "' ", "satir") < 1)
                        { kaydet(talepno4, urun4, miktar4, birim4, comboFirma5, labelVade5, labelIlgili5, combo20, birimfiyat20, iskonto20, kdv20, toplam20, genel20, son20, termin20, richTextBox5); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat20.Text + "', iskonto = '" + iskonto20.Text + "', kdv = '" + kdv20.Text + "', terminSuresi = '" + termin20.Text + "', paraBirimi = '" + combo20.Text + "', toplamFiyat = '" + toplam20.Text + "', genelToplam = '" + genel20.Text + "', sonToplam = '" + son20.Text + "' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma5.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno4.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat21.Text != String.Empty && iskonto21.Text != String.Empty && kdv21.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno5.Text + "%' AND firma = '" + comboFirma1.Text + "' ", "satir") < 1)
                        { kaydet(talepno5, urun5, miktar5, birim5, comboFirma1, labelVade1, labelIlgili1, combo21, birimfiyat21, iskonto21, kdv21, toplam21, genel21, son21, termin21, richTextBox1); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat21.Text + "', iskonto = '" + iskonto21.Text + "', kdv = '" + kdv21.Text + "', terminSuresi = '" + termin21.Text + "', paraBirimi = '" + combo21.Text + "', toplamFiyat = '" + toplam21.Text + "', genelToplam = '" + genel21.Text + "', sonToplam = '" + son21.Text + "' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma1.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno5.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat22.Text != String.Empty && iskonto22.Text != String.Empty && kdv22.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno5.Text + "%' AND firma = '" + comboFirma2.Text + "' ", "satir") < 1)
                        { kaydet(talepno5, urun5, miktar5, birim5, comboFirma2, labelVade2, labelIlgili2, combo22, birimfiyat22, iskonto22, kdv22, toplam22, genel22, son22, termin22, richTextBox2); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat22.Text + "', iskonto = '" + iskonto22.Text + "', kdv = '" + kdv22.Text + "', terminSuresi = '" + termin22.Text + "', paraBirimi = '" + combo22.Text + "', toplamFiyat = '" + toplam22.Text + "', genelToplam = '" + genel22.Text + "', sonToplam = '" + son22.Text + "' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma2.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno5.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat23.Text != String.Empty && iskonto23.Text != String.Empty && kdv23.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno5.Text + "%' AND firma = '" + comboFirma3.Text + "' ", "satir") < 1)
                        { kaydet(talepno5, urun5, miktar5, birim5, comboFirma3, labelVade3, labelIlgili3, combo23, birimfiyat23, iskonto23, kdv23, toplam23, genel23, son23, termin23, richTextBox3); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat23.Text + "', iskonto = '" + iskonto23.Text + "', kdv = '" + kdv23.Text + "', terminSuresi = '" + termin23.Text + "', paraBirimi = '" + combo23.Text + "', toplamFiyat = '" + toplam23.Text + "', genelToplam = '" + genel23.Text + "', sonToplam = '" + son23.Text + "' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma3.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno5.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat24.Text != String.Empty && iskonto24.Text != String.Empty && kdv24.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno5.Text + "%' AND firma = '" + comboFirma4.Text + "' ", "satir") < 1)
                        { kaydet(talepno5, urun5, miktar5, birim5, comboFirma4, labelVade4, labelIlgili4, combo24, birimfiyat24, iskonto24, kdv24, toplam24, genel24, son24, termin24, richTextBox4); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat24.Text + "', iskonto = '" + iskonto24.Text + "', kdv = '" + kdv24.Text + "', terminSuresi = '" + termin24.Text + "', paraBirimi = '" + combo24.Text + "', toplamFiyat = '" + toplam24.Text + "', genelToplam = '" + genel24.Text + "', sonToplam = '" + son24.Text + "' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma4.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno5.Text + "'";
                            connect(query2);
                        }
                    }
                    if (birimfiyat25.Text != String.Empty && iskonto25.Text != String.Empty && kdv25.Text != String.Empty)
                    {
                        if (form4.bilgi("SELECT count(id) as satir FROM satinalma.sarfteklif WHERE teklifNo like '" + talepno5.Text + "%' AND firma = '" + comboFirma5.Text + "' ", "satir") < 1)
                        { kaydet(talepno5, urun5, miktar5, birim5, comboFirma5, labelVade5, labelIlgili5, combo25, birimfiyat25, iskonto25, kdv25, toplam25, genel25, son25, termin25, richTextBox5); s++; }
                        else
                        { 
                            string query = "update satinalma.sarfteklif set birimFiyat = '" + birimfiyat25.Text + "', iskonto = '" + iskonto25.Text + "', kdv = '" + kdv25.Text + "', terminSuresi = '" + termin25.Text + "', paraBirimi = '" + combo25.Text + "', toplamFiyat = '" + toplam25.Text + "', genelToplam = '" + genel25.Text + "', sonToplam = '" + son25.Text + "' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma5.Text + "' "; connect(query); k++;
                            string query2 = "update satinalma.sarftalep set durum = 'Teklif Girildi' where talepNo = '" + talepno5.Text + "'";
                            connect(query2);
                        }
                    }
                }
                else
                    MessageBox.Show("Mükerrer Firmanız Bulunmaktadır. Kontrol Ediniz.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Hand);


                if (s != 0 || k != 0) 
                { MessageBox.Show("Taleplere Ait " + s + " Adet Teklif Girişi, " + k + " Adet Teklif Güncellemesi Yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
                else
                    MessageBox.Show("İşaretli Alanları Boş Bırakmayınız", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Hand); /*işaretli alanlar : birimfiyat, iskonto, kdv */
                //comboBox_DropDownClosed(comboFirma5, e);
            }
            else if (btnSonuc.Text == "Yayınla")
            { /*sarfteklif tablosunda durum değişikliği*/
                try
                {
                    foreach (object eleman in dizi)
                    {
                        if (eleman == "checkBox1")
                        { 
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma1.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno1.Text + "' ";
                            connect(queryteklif);
                            //teklifi onaylanan talebin durumunu değiştirme komutu
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox2")
                        { 
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma2.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno1.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox3")
                        { 
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma3.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno1.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox4")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma4.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno1.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox5")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno1.Text + "%' and firma = '" + comboFirma5.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno1.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox6")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma1.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno2.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox7")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma2.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno2.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox8")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma3.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno2.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox9")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma4.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno2.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox10")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno2.Text + "%' and firma = '" + comboFirma5.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno2.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox11")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma1.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno3.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox12")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma2.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno3.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox13")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma3.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno3.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox14")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma4.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno3.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox15")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno3.Text + "%' and firma = '" + comboFirma5.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno3.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox16")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma1.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno4.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox17")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma2.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno4.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox18")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma3.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno4.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox19")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma4.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno4.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox20")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno4.Text + "%' and firma = '" + comboFirma5.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno4.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox21")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma1.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno5.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox22")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma2.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno5.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox23")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma3.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno5.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox24")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma4.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno5.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                        else if (eleman == "checkBox25")
                        {
                            queryteklif = "update satinalma.sarfteklif set onaylayan = '" + labelTemsilci.Text + "', durum = 'Onaylandı' where teklifNo like '" + talepno5.Text + "%' and firma = '" + comboFirma5.Text + "' ";
                            querytalep = "update satinalma.sarftalep set durum = 'Onaylandı' where talepNo = '" + talepno5.Text + "' ";
                            connect(queryteklif);
                            connect(querytalep);
                        }
                    }
                    MessageBox.Show("Teklifler Yayınlanmıştır.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                } 
                catch { MessageBox.Show("Teklif Yayınlama Esnasında Hata ile Karşılaşıldı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
            }
            else
                MessageBox.Show("Sistemde Beklenmedik Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void PanelOrtalama(Panel panel, int width, int height)
        {
            float x = (Convert.ToInt32(width) - Convert.ToInt32(panel.Width)) / 2;
            float y = (Convert.ToInt32(height) - Convert.ToInt32(panel.Height)) / 2;
            panel.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));
        }

        private void btnCariEkle_Click(object sender, EventArgs e)
        {
            panelFirmaEkle.Visible = true;
            buttonTemizle_Click(sender, e); //tüm textboxlar temizlenir
            PanelOrtalama(panelFirmaEkle, 1500, 700);
        }

        private void panelKapat_Click(object sender, EventArgs e)
        {
            panelFirmaEkle.Visible = false;
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {//tüm textboxlar temizlenir
            foreach (Control item in panelFirmaEkle.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox" || item.GetType().ToString() == "System.Windows.Forms.RichTextBox" || item.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                    item.Text = "";
            }
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            // veritabanına ekleme komutu
            string firma = "insert into satinalma.sarftedarikci(firmaKisaAd, firmaUzunAd, adres, telefon, vade, ilgili) values('" + textBoxKisa.Text.ToUpper() + "', '" + textBoxTam.Text.ToUpper() + "', '" + richTextAdres.Text + "', '" + maskedTextTelefon.Text + "', '" + textBoxVade.Text + "', '" + textBoxIlgili.Text + "')";
            connect(firma);
            panelFirmaEkle.Visible = false;
            comboFirma1.Items.Clear();
            comboFirma2.Items.Clear();
            comboFirma3.Items.Clear();
            comboFirma4.Items.Clear();
            comboFirma5.Items.Clear();
            Form5_Load(sender, e);
        }

        private void allComboSelectedChange(ComboBox Combo, Label Vade, Label Ilgili)
        {
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = "select vade, ilgili from sarftedarikci where firmaKisaAd = '" + Combo.Text + "' ";
            MySqlDataReader dr = mySqlCommand.ExecuteReader();

            if (dr.Read())
            {
                Vade.Text = dr["vade"].ToString();
                Ilgili.Text = dr["ilgili"].ToString();
            }
            connection.Close();
        }

        private void comboFirma1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vade - İlgili doldurur
            if(doldur == false)
                allComboSelectedChange(comboFirma1, labelVade1, labelIlgili1);
            //Tek üründe mükerrer firma seçilemez kontrolü
            if(comboFirma2.Text == comboFirma1.Text || comboFirma3.Text == comboFirma1.Text || comboFirma4.Text == comboFirma1.Text || comboFirma5.Text == comboFirma1.Text)
                comboBox_DropDownClosed(comboFirma1, e);
        }

        private void comboFirma2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(doldur == false)
                allComboSelectedChange(comboFirma2, labelVade2, labelIlgili2);

            if (comboFirma1.Text == comboFirma2.Text || comboFirma3.Text == comboFirma2.Text || comboFirma4.Text == comboFirma2.Text || comboFirma5.Text == comboFirma2.Text)
                comboBox_DropDownClosed(comboFirma2, e);
        }

        private void comboFirma3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(doldur == false)
                allComboSelectedChange(comboFirma3, labelVade3, labelIlgili3);

            if (comboFirma2.Text == comboFirma3.Text || comboFirma1.Text == comboFirma3.Text || comboFirma4.Text == comboFirma3.Text || comboFirma5.Text == comboFirma3.Text)
                comboBox_DropDownClosed(comboFirma3, e);
        }

        private void comboFirma4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(doldur == false)
                allComboSelectedChange(comboFirma4, labelVade4, labelIlgili4);

            if (comboFirma2.Text == comboFirma4.Text || comboFirma1.Text == comboFirma4.Text || comboFirma3.Text == comboFirma4.Text || comboFirma5.Text == comboFirma4.Text)
                comboBox_DropDownClosed(comboFirma4, e);
        }

        private void comboFirma5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(doldur == false)
                allComboSelectedChange(comboFirma5, labelVade5, labelIlgili5);

            if (comboFirma2.Text == comboFirma5.Text || comboFirma1.Text == comboFirma5.Text || comboFirma4.Text == comboFirma5.Text || comboFirma3.Text == comboFirma5.Text)
                comboBox_DropDownClosed(comboFirma5, e);
        }

        string linkName;
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkName = "";
            LinkLabel l = (LinkLabel)sender;
            linkName = l.Name;  //linkLabel'ın adını aldım.

            panelFirmaGuncelle.Visible = true;
            txVade.Text = "";
            txIlgili.Text = "";
            checkDb.Checked = false;
            PanelOrtalama(panelFirmaGuncelle, 1500, 700);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (linkName == "linkLabel1")
            {
                labelVade1.Text = txVade.Text;
                labelIlgili1.Text = txIlgili.Text;
                if (checkDb.Checked)
                {
                    string sorgu = "update satinalma.sarftedarikci set vade = '" + txVade.Text + "', ilgili = '" + txIlgili.Text + "' where firmaKisaAd = '" + comboFirma1.Text + "'";
                    connect(sorgu);
                }
            }
            else if (linkName == "linkLabel2")
            {
                labelVade2.Text = txVade.Text;
                labelIlgili2.Text = txIlgili.Text;
                if (checkDb.Checked)
                {
                    string sorgu = "update satinalma.sarftedarikci set vade = '" + txVade.Text + "', ilgili = '" + txIlgili.Text + "' where firmaKisaAd = '" + comboFirma2.Text + "'";
                    connect(sorgu);
                }
            }
            else if (linkName == "linkLabel3")
            {
                labelVade3.Text = txVade.Text;
                labelIlgili3.Text = txIlgili.Text;
                if (checkDb.Checked)
                {
                    string sorgu = "update satinalma.sarftedarikci set vade = '" + txVade.Text + "', ilgili = '" + txIlgili.Text + "' where firmaKisaAd = '" + comboFirma3.Text + "'";
                    connect(sorgu);
                }
            }
            else if (linkName == "linkLabel4")
            {
                labelVade4.Text = txVade.Text;
                labelIlgili4.Text = txIlgili.Text;
                if (checkDb.Checked)
                {
                    string sorgu = "update satinalma.sarftedarikci set vade = '" + txVade.Text + "', ilgili = '" + txIlgili.Text + "' where firmaKisaAd = '" + comboFirma4.Text + "'";
                    connect(sorgu);
                }
            }
            else if (linkName == "linkLabel5")
            {
                labelVade5.Text = txVade.Text;
                labelIlgili5.Text = txIlgili.Text;
                if (checkDb.Checked)
                {
                    string sorgu = "update satinalma.sarftedarikci set vade = '" + txVade.Text + "', ilgili = '" + txIlgili.Text + "' where firmaKisaAd = '" + comboFirma5.Text + "'";
                    connect(sorgu);
                }
            }
            else
                MessageBox.Show("Beklenmedik Hata ile Karşılaşıldı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            panelFirmaGuncelle.Visible = false;
        }

        private void btnYeniden_Click(object sender, EventArgs e)
        {
            try
            {
                string red = "UPDATE satinalma.sarftalep set durum = 'Teklif Red' where grup = '" + labelgrup.Text + "' ";
                connect(red);
                MessageBox.Show("Gruba Ait Teklif Satın Alma Birimine Yönlendirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch { MessageBox.Show("Beklenmedik Bir Hata ile Karşılaşıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.Close();
        }

        //string[] dizi;
        ArrayList dizi = new ArrayList();
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
                dizi.Add(c.Name);
        }
    }
}
