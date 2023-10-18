using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.Data;
using DevExpress.PivotGrid.PivotTable;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();

            this.sfDataGrid1.ShowGroupDropArea = true;
            this.sfDataGrid1.AllowGrouping = true;

            //this.sfDataGrid1.Columns["id"].AllowGrouping = true;
            //this.sfDataGrid1.Columns["grup"].AllowGrouping = true;
        }
        
        MySqlConnection cn;
        MySqlDataAdapter da;
        DataSet ds;
        private void Form8_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Form4 form4 = new Form4();                  // Kullanıcıya ait olan gruplu talepleri tabloya getirir 
            cn = new MySqlConnection("server=192.168.10.50;Database=satinalma;Uid=localhost;Pwd=BYZroot1;");
            da = new MySqlDataAdapter("SELECT * FROM satinalma.sarftalep where grup is not null and kullanici = '" + form4.labelTemsilci.Text + "'", cn);
            ds = new DataSet();
            da.Fill(ds, "grup");
            sfDataGrid1.DataSource = ds.Tables[0];

            this.sfDataGrid1.Style.HeaderStyle.BackColor = Color.AliceBlue;
            this.sfDataGrid1.Style.HeaderStyle.TextColor = Color.DarkSlateBlue;
            this.sfDataGrid1.Style.HeaderStyle.Font.Bold = true;

            //this.sfDataGrid1.Columns["id"].HeaderStyle.BackColor = Color.LightCoral;
            //this.sfDataGrid1.Columns["id"].HeaderStyle.TextColor = Color.DarkRed;
            //this.sfDataGrid1.Columns["id"].HeaderStyle.Font.Bold = true;

            this.sfDataGrid1.Style.SelectionStyle.BackColor = Color.LightSeaGreen;
            this.sfDataGrid1.Style.SelectionStyle.TextColor = Color.DarkBlue;
        }

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

            if(cellValue != null)
            {
                Form5 form5 = new Form5();
                form5.labelgrup.Text = cellValue;
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
    }
}
