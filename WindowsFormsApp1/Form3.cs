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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.146;Database=satinalma;Uid=root;Pwd=lgulver;");

        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillGridControl("select * from satinalma.sarftalep");
        }

        private void FillGridControl(string sorgu)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sorgu, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();

            string sorgu = "select * from satinalma.sarftalep where id = '" + id + "' ";
            MySqlDataAdapter da = new MySqlDataAdapter(sorgu, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl2.DataSource = ds.Tables[0];
        }
    }
}
