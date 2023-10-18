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
using Windows.UI.Xaml;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=192.168.10.50;Database=satinalma;Uid=localhost;Pwd=BYZroot1;Allow Zero Datetime=true");

        private void Form7_Load(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            labelTemsilci.Text = form.labelTemsilci.Text;
            //Combonun içi doldurulur
            fillCombo(comboUrun, "SELECT id, Malzeme FROM sarfdepo.sarfstok group by Malzeme", "Malzeme", "id");
        }

        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();

            adapter.Fill(table);
            combo.DataSource = table; 
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

            connection.Close(); 
        }

        private void buttonYeniUrun_Click(object sender, EventArgs e)
        {
            //sarfstoğa yeni kayıt girilecek
        }
    }
}
