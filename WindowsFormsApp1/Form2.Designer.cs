
namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.advDataGridStok = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelArka = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTalepOlustur = new System.Windows.Forms.Button();
            this.tablePanelUrunKarti = new DevExpress.Utils.Layout.TablePanel();
            this.labelControlTalepBirimi = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTalepEden = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.buttonTalepGönder = new System.Windows.Forms.Button();
            this.labelTalepler = new DevExpress.XtraEditors.LabelControl();
            this.advDataGridUrun = new ADGV.AdvancedDataGridView();
            this.labelBirimi = new DevExpress.XtraEditors.LabelControl();
            this.labelTalepEden = new DevExpress.XtraEditors.LabelControl();
            this.labelTarih = new DevExpress.XtraEditors.LabelControl();
            this.labelControlUrunKarti = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSarfStok = new DevExpress.XtraEditors.LabelControl();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.advDataGridStok)).BeginInit();
            this.tableLayoutPanelArka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelUrunKarti)).BeginInit();
            this.tablePanelUrunKarti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advDataGridUrun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // advDataGridStok
            // 
            this.advDataGridStok.AllowUserToAddRows = false;
            this.advDataGridStok.AllowUserToDeleteRows = false;
            this.advDataGridStok.AllowUserToOrderColumns = true;
            this.advDataGridStok.AutoGenerateContextFilters = true;
            this.advDataGridStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advDataGridStok.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.advDataGridStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advDataGridStok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.advDataGridStok.DateWithTime = false;
            this.advDataGridStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advDataGridStok.Location = new System.Drawing.Point(3, 27);
            this.advDataGridStok.Name = "advDataGridStok";
            this.advDataGridStok.Size = new System.Drawing.Size(559, 538);
            this.advDataGridStok.TabIndex = 1;
            this.advDataGridStok.TimeFilter = false;
            this.advDataGridStok.SortStringChanged += new System.EventHandler(this.advDataGridStok_SortStringChanged);
            this.advDataGridStok.FilterStringChanged += new System.EventHandler(this.advDataGridStok_FilterStringChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Seçili";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tableLayoutPanelArka
            // 
            this.tableLayoutPanelArka.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelArka.ColumnCount = 2;
            this.tableLayoutPanelArka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelArka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelArka.Controls.Add(this.advDataGridStok, 0, 1);
            this.tableLayoutPanelArka.Controls.Add(this.buttonTalepOlustur, 0, 2);
            this.tableLayoutPanelArka.Controls.Add(this.tablePanelUrunKarti, 1, 1);
            this.tableLayoutPanelArka.Controls.Add(this.labelControlUrunKarti, 1, 0);
            this.tableLayoutPanelArka.Controls.Add(this.labelControlSarfStok, 0, 0);
            this.tableLayoutPanelArka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelArka.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelArka.Name = "tableLayoutPanelArka";
            this.tableLayoutPanelArka.RowCount = 3;
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.225352F));
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.77465F));
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanelArka.Size = new System.Drawing.Size(943, 611);
            this.tableLayoutPanelArka.TabIndex = 2;
            // 
            // buttonTalepOlustur
            // 
            this.buttonTalepOlustur.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonTalepOlustur.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonTalepOlustur.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTalepOlustur.ForeColor = System.Drawing.Color.White;
            this.buttonTalepOlustur.Location = new System.Drawing.Point(388, 571);
            this.buttonTalepOlustur.Name = "buttonTalepOlustur";
            this.buttonTalepOlustur.Size = new System.Drawing.Size(174, 37);
            this.buttonTalepOlustur.TabIndex = 2;
            this.buttonTalepOlustur.Text = "TALEP OLUŞTUR";
            this.buttonTalepOlustur.UseVisualStyleBackColor = false;
            this.buttonTalepOlustur.Click += new System.EventHandler(this.buttonTalepOlustur_Click);
            // 
            // tablePanelUrunKarti
            // 
            this.tablePanelUrunKarti.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.tablePanelUrunKarti.Appearance.Options.UseBackColor = true;
            this.tablePanelUrunKarti.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 8.86F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 51.14F)});
            this.tablePanelUrunKarti.Controls.Add(this.labelControlTalepBirimi);
            this.tablePanelUrunKarti.Controls.Add(this.labelControlTalepEden);
            this.tablePanelUrunKarti.Controls.Add(this.dateEdit1);
            this.tablePanelUrunKarti.Controls.Add(this.buttonTalepGönder);
            this.tablePanelUrunKarti.Controls.Add(this.labelTalepler);
            this.tablePanelUrunKarti.Controls.Add(this.advDataGridUrun);
            this.tablePanelUrunKarti.Controls.Add(this.labelBirimi);
            this.tablePanelUrunKarti.Controls.Add(this.labelTalepEden);
            this.tablePanelUrunKarti.Controls.Add(this.labelTarih);
            this.tablePanelUrunKarti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelUrunKarti.Location = new System.Drawing.Point(568, 27);
            this.tablePanelUrunKarti.Name = "tablePanelUrunKarti";
            this.tablePanelUrunKarti.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 378.58F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.42F)});
            this.tablePanelUrunKarti.Size = new System.Drawing.Size(372, 538);
            this.tablePanelUrunKarti.TabIndex = 3;
            this.tablePanelUrunKarti.UseSkinIndents = true;
            // 
            // labelControlTalepBirimi
            // 
            this.tablePanelUrunKarti.SetColumn(this.labelControlTalepBirimi, 1);
            this.labelControlTalepBirimi.Location = new System.Drawing.Point(65, 91);
            this.labelControlTalepBirimi.Name = "labelControlTalepBirimi";
            this.tablePanelUrunKarti.SetRow(this.labelControlTalepBirimi, 2);
            this.labelControlTalepBirimi.Size = new System.Drawing.Size(4, 13);
            this.labelControlTalepBirimi.TabIndex = 8;
            this.labelControlTalepBirimi.Text = "-";
            // 
            // labelControlTalepEden
            // 
            this.tablePanelUrunKarti.SetColumn(this.labelControlTalepEden, 1);
            this.labelControlTalepEden.Location = new System.Drawing.Point(65, 56);
            this.labelControlTalepEden.Name = "labelControlTalepEden";
            this.tablePanelUrunKarti.SetRow(this.labelControlTalepEden, 1);
            this.labelControlTalepEden.Size = new System.Drawing.Size(4, 13);
            this.labelControlTalepEden.TabIndex = 7;
            this.labelControlTalepEden.Text = "-";
            // 
            // dateEdit1
            // 
            this.tablePanelUrunKarti.SetColumn(this.dateEdit1, 1);
            this.dateEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEdit1.EditValue = new System.DateTime(2023, 7, 24, 14, 2, 4, 0);
            this.dateEdit1.Location = new System.Drawing.Point(65, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanelUrunKarti.SetRow(this.dateEdit1, 0);
            this.dateEdit1.Size = new System.Drawing.Size(105, 20);
            this.dateEdit1.TabIndex = 6;
            // 
            // buttonTalepGönder
            // 
            this.buttonTalepGönder.BackColor = System.Drawing.Color.CadetBlue;
            this.tablePanelUrunKarti.SetColumn(this.buttonTalepGönder, 1);
            this.buttonTalepGönder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTalepGönder.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTalepGönder.ForeColor = System.Drawing.Color.White;
            this.buttonTalepGönder.Location = new System.Drawing.Point(65, 496);
            this.buttonTalepGönder.Name = "buttonTalepGönder";
            this.tablePanelUrunKarti.SetRow(this.buttonTalepGönder, 4);
            this.buttonTalepGönder.Size = new System.Drawing.Size(294, 29);
            this.buttonTalepGönder.TabIndex = 5;
            this.buttonTalepGönder.Text = "TALEP GÖNDER";
            this.buttonTalepGönder.UseVisualStyleBackColor = false;
            // 
            // labelTalepler
            // 
            this.labelTalepler.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTalepler.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelTalepler.Appearance.Options.UseFont = true;
            this.labelTalepler.Appearance.Options.UseForeColor = true;
            this.tablePanelUrunKarti.SetColumn(this.labelTalepler, 0);
            this.labelTalepler.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTalepler.Location = new System.Drawing.Point(13, 117);
            this.labelTalepler.Name = "labelTalepler";
            this.tablePanelUrunKarti.SetRow(this.labelTalepler, 3);
            this.labelTalepler.Size = new System.Drawing.Size(48, 15);
            this.labelTalepler.TabIndex = 4;
            this.labelTalepler.Text = "TALEPLER :";
            // 
            // advDataGridUrun
            // 
            this.advDataGridUrun.AllowUserToAddRows = false;
            this.advDataGridUrun.AllowUserToDeleteRows = false;
            this.advDataGridUrun.AutoGenerateContextFilters = true;
            this.advDataGridUrun.BackgroundColor = System.Drawing.Color.White;
            this.tablePanelUrunKarti.SetColumn(this.advDataGridUrun, 1);
            this.advDataGridUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advDataGridUrun.DateWithTime = false;
            this.advDataGridUrun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advDataGridUrun.Location = new System.Drawing.Point(65, 117);
            this.advDataGridUrun.Name = "advDataGridUrun";
            this.tablePanelUrunKarti.SetRow(this.advDataGridUrun, 3);
            this.advDataGridUrun.Size = new System.Drawing.Size(294, 375);
            this.advDataGridUrun.TabIndex = 3;
            this.advDataGridUrun.TimeFilter = false;
            this.advDataGridUrun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advDataGridUrun_CellClick);
            this.advDataGridUrun.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.advDataGridUrun_EditingControlShowing);
            this.advDataGridUrun.Scroll += new System.Windows.Forms.ScrollEventHandler(this.advDataGridUrun_Scroll);
            this.advDataGridUrun.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Column_KeyPress);
            // 
            // labelBirimi
            // 
            this.labelBirimi.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBirimi.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelBirimi.Appearance.Options.UseFont = true;
            this.labelBirimi.Appearance.Options.UseForeColor = true;
            this.tablePanelUrunKarti.SetColumn(this.labelBirimi, 0);
            this.labelBirimi.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBirimi.Location = new System.Drawing.Point(13, 82);
            this.labelBirimi.Name = "labelBirimi";
            this.tablePanelUrunKarti.SetRow(this.labelBirimi, 2);
            this.labelBirimi.Size = new System.Drawing.Size(48, 15);
            this.labelBirimi.TabIndex = 2;
            this.labelBirimi.Text = "BİRİMİ :";
            // 
            // labelTalepEden
            // 
            this.labelTalepEden.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTalepEden.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelTalepEden.Appearance.Options.UseFont = true;
            this.labelTalepEden.Appearance.Options.UseForeColor = true;
            this.tablePanelUrunKarti.SetColumn(this.labelTalepEden, 0);
            this.labelTalepEden.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTalepEden.Location = new System.Drawing.Point(13, 47);
            this.labelTalepEden.Name = "labelTalepEden";
            this.tablePanelUrunKarti.SetRow(this.labelTalepEden, 1);
            this.labelTalepEden.Size = new System.Drawing.Size(48, 15);
            this.labelTalepEden.TabIndex = 1;
            this.labelTalepEden.Text = "TALEP EDEN :";
            // 
            // labelTarih
            // 
            this.labelTarih.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTarih.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelTarih.Appearance.Options.UseFont = true;
            this.labelTarih.Appearance.Options.UseForeColor = true;
            this.tablePanelUrunKarti.SetColumn(this.labelTarih, 0);
            this.labelTarih.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTarih.Location = new System.Drawing.Point(13, 12);
            this.labelTarih.Name = "labelTarih";
            this.tablePanelUrunKarti.SetRow(this.labelTarih, 0);
            this.labelTarih.Size = new System.Drawing.Size(48, 15);
            this.labelTarih.TabIndex = 0;
            this.labelTarih.Text = "TARİH :";
            // 
            // labelControlUrunKarti
            // 
            this.labelControlUrunKarti.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControlUrunKarti.Appearance.Options.UseFont = true;
            this.labelControlUrunKarti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControlUrunKarti.Location = new System.Drawing.Point(568, 3);
            this.labelControlUrunKarti.Name = "labelControlUrunKarti";
            this.labelControlUrunKarti.Size = new System.Drawing.Size(372, 18);
            this.labelControlUrunKarti.TabIndex = 4;
            this.labelControlUrunKarti.Text = "ÜRÜN KARTI";
            // 
            // labelControlSarfStok
            // 
            this.labelControlSarfStok.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControlSarfStok.Appearance.Options.UseFont = true;
            this.labelControlSarfStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControlSarfStok.Location = new System.Drawing.Point(3, 3);
            this.labelControlSarfStok.Name = "labelControlSarfStok";
            this.labelControlSarfStok.Size = new System.Drawing.Size(559, 18);
            this.labelControlSarfStok.TabIndex = 5;
            this.labelControlSarfStok.Text = "SARF STOK LİSTESİ";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 611);
            this.Controls.Add(this.tableLayoutPanelArka);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advDataGridStok)).EndInit();
            this.tableLayoutPanelArka.ResumeLayout(false);
            this.tableLayoutPanelArka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelUrunKarti)).EndInit();
            this.tablePanelUrunKarti.ResumeLayout(false);
            this.tablePanelUrunKarti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advDataGridUrun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView advDataGridStok;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArka;
        private System.Windows.Forms.Button buttonTalepOlustur;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.Utils.Layout.TablePanel tablePanelUrunKarti;
        private System.Windows.Forms.Button buttonTalepGönder;
        private DevExpress.XtraEditors.LabelControl labelTalepler;
        private ADGV.AdvancedDataGridView advDataGridUrun;
        private DevExpress.XtraEditors.LabelControl labelBirimi;
        private DevExpress.XtraEditors.LabelControl labelTalepEden;
        private DevExpress.XtraEditors.LabelControl labelTarih;
        private DevExpress.XtraEditors.LabelControl labelControlUrunKarti;
        private DevExpress.XtraEditors.LabelControl labelControlSarfStok;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlTalepBirimi;
        private DevExpress.XtraEditors.LabelControl labelControlTalepEden;
    }
}