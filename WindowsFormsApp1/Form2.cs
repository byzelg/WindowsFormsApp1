using DevExpress.XtraGrid;
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
    public partial class Form2 : Form
    {
        DateTimePicker DateTimePicker1 = new DateTimePicker();
        Rectangle _Rectangle;
        public Form2()
        {
            InitializeComponent();
            advDataGridUrun.Controls.Add(DateTimePicker1);
            DateTimePicker1.Visible = false;
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.TextChanged += new EventHandler(DateTimePicker1_TextChange);
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.146;Database=sarfdepo;Uid=root;Pwd=lgulver;");


        private void DateTimePicker1_TextChange(Object sender, EventArgs e)
        {
            advDataGridUrun.CurrentCell.Value = DateTimePicker1.Text.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Sarf Stok İçerisindeki Datagrid İçin
            string sorgu = "select * from sarfstok";
            advGetir(advDataGridStok, sorgu, bindingSource1);

            //Ürün Kartı İçerisindeki Datagrid İçin
            advDataGridUrun.ColumnCount = 5;
            advDataGridUrun.Columns[0].HeaderText = "ID";
            advDataGridUrun.Columns[1].HeaderText = "MALZEME";
            //advDataGridUrun.Columns[2].HeaderText = "KATEGORİ";           //column[kategori] combo
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Items.AddRange("a", "b", "c", "d", "f", "g");
            combo.HeaderText = "KATEGORİ";
            advDataGridUrun.Columns.Add(combo);
            int sayi = advDataGridUrun.Columns.Count - 1;
            advDataGridUrun.Columns[sayi].DisplayIndex = 2;
            advDataGridUrun.Columns[2].HeaderText = "MİKTAR";
            //advDataGridUrun.Columns[4].HeaderText = "BİRİM";              //column[birim] combo
            DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn();
            combo1.Items.AddRange("Adet", "Boy", "Çift", "IBC", "Kilogram", "Litre", "Makara", "Metre", "Paket", "Plaka", "Teneke", "Varil");
            combo1.HeaderText = "BİRİM";
            advDataGridUrun.Columns.Add(combo1);
            int sayi1 = advDataGridUrun.Columns.Count - 1;
            advDataGridUrun.Columns[sayi1].DisplayIndex = 4;
            advDataGridUrun.Columns[3].HeaderText = "TERMİN";
            advDataGridUrun.Columns[3].Name = "TERMİN";
            advDataGridUrun.Columns[4].HeaderText = "AÇIKLAMA";
        }

        //private void getir(DataGridView grid, string sorgu)
        //{
        //    MySqlDataAdapter listele = new MySqlDataAdapter(sorgu, connection);
        //    DataTable oku = new DataTable();
        //    listele.Fill(oku);
        //    grid.DataSource = oku;
        //    connection.Close();
        //}

        public void advGetir(DataGridView data, string query, BindingSource sc)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            DataTable oku = new DataTable();
            da.Fill(oku);
            data.DataSource = oku;
            sc.DataSource = oku;
            connection.Close();
        }

        private void advDataGridStok_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = advDataGridStok.FilterString.Replace("[%]", "%").Replace("[\"]", "\"");
        }

        private void advDataGridStok_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = advDataGridStok.SortString;
        }

        int j = 0;
        private void buttonTalepOlustur_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in advDataGridStok.Rows)
            {
                if (dr.Cells[0].Value != null && (bool)dr.Cells[0].Value)
                    advDataGridUrun.Rows.Add(dr.Cells[1].Value.ToString(), dr.Cells[4].Value.ToString(), "", "", "", "", "");
                else if (dr.Cells[0].Value == null)
                    j++;
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (advDataGridUrun.CurrentCell.ColumnIndex == 2)           //column[3] sadece sayı virgül girişi
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)       //KeyChar = 8 -> Backspace tuşu
                    e.Handled = true;
            }
            else                                                        //column[6] açıklama - tüm karakterler girilebilmeli
                e.Handled = false;
        }

        //public void cb_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var gecerli = advDataGridUrun.CurrentCellAddress;
        //    var gelen = sender as DataGridViewComboBoxEditingControl;
        //    DataGridViewTextBoxCell hucre = (DataGridViewTextBoxCell)advDataGridUrun.Rows[gecerli.Y].Cells[0];
        //    hucre.Value = gelen.EditingControlFormattedValue.ToString();
        //}

        private void advDataGridUrun_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //ComboBox cb = e.Control as ComboBox; if (cb != null)
            //{
            //    cb.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);
            //    cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            //}

            //column[3] sadece sayı virgül girişi
            if (advDataGridUrun.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null) 
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
            }
            //column[0], column[1] değiştirilemez
            if (advDataGridUrun.CurrentCell.ColumnIndex == 0 || advDataGridUrun.CurrentCell.ColumnIndex == 1)
            {
                foreach(DataGridViewRow row in advDataGridUrun.Rows)
                {
                    if((!row.Cells[0].Value.Equals(null) || !row.Cells[0].Value.Equals(String.Empty)) && (!row.Cells[1].Value.Equals(null) || !row.Cells[1].Value.Equals(String.Empty)))
                    {
                        row.Cells[0].ReadOnly = true;
                        row.Cells[1].ReadOnly = true;
                    }
                }
            }
        }

        //private void DatePickerTextChanged(object sender, EventArgs e)
        //{
        //    advDataGridUrun.CurrentCell.Value = DateTimePicker1.Text.ToString();
        //}

        //private void DatePickerClose(object sender, EventArgs e)
        //{
        //    advDataGridUrun.Visible = false;
        //}

        private void advDataGridUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //column[termin] datetime - cell üzerine tıklanınca açılacaktır
            //if (e.ColumnIndex == 3)
            //{
            //    DateTimePicker DateTimePicker1 = new DateTimePicker();
            //    advDataGridUrun.Controls.Add(DateTimePicker1);
            //    DateTimePicker1.Format = DateTimePickerFormat.Short;
            //    DateTimePicker1.CustomFormat = "dd/MM/yyyy";
            //    Rectangle displaycalender = advDataGridUrun.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    DateTimePicker1.Size = new Size(displaycalender.Width, displaycalender.Height);
            //    DateTimePicker1.Location = new Point(displaycalender.X, displaycalender.Y);
            //}
            switch(advDataGridUrun.Columns[e.ColumnIndex].Name)
            {
                case "TERMİN":
                    _Rectangle = advDataGridUrun.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    DateTimePicker1.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    DateTimePicker1.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    DateTimePicker1.Visible = true;
                    break;
            }
        }

        private void advDataGridUrun_Scroll(object sender, ScrollEventArgs e)
        {
            DateTimePicker1.Visible = false;
        }

    }

}
