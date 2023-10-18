
namespace WindowsFormsApp1
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.buttonYeniUrun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUrun = new System.Windows.Forms.Label();
            this.labelKategori = new System.Windows.Forms.Label();
            this.labelMiktar = new System.Windows.Forms.Label();
            this.labelBirim = new System.Windows.Forms.Label();
            this.labelAçıklama = new System.Windows.Forms.Label();
            this.comboUrun = new System.Windows.Forms.ComboBox();
            this.comboKategori = new System.Windows.Forms.ComboBox();
            this.textMiktar = new System.Windows.Forms.TextBox();
            this.comboBirim = new System.Windows.Forms.ComboBox();
            this.richTextAciklama = new System.Windows.Forms.RichTextBox();
            this.labelTemsilci = new System.Windows.Forms.Label();
            this.labelKonum = new System.Windows.Forms.Label();
            this.richTextKonum = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonYeniUrun
            // 
            this.buttonYeniUrun.BackColor = System.Drawing.Color.Brown;
            this.buttonYeniUrun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonYeniUrun.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonYeniUrun.ForeColor = System.Drawing.Color.White;
            this.buttonYeniUrun.Location = new System.Drawing.Point(0, 395);
            this.buttonYeniUrun.Name = "buttonYeniUrun";
            this.buttonYeniUrun.Size = new System.Drawing.Size(303, 25);
            this.buttonYeniUrun.TabIndex = 7;
            this.buttonYeniUrun.Text = "Yeni Ürün Kartı Oluştur";
            this.buttonYeniUrun.UseVisualStyleBackColor = false;
            this.buttonYeniUrun.Click += new System.EventHandler(this.buttonYeniUrun_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.labelKonum, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelUrun, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelKategori, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelMiktar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelBirim, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAçıklama, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboUrun, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboKategori, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textMiktar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBirim, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextAciklama, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelTemsilci, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextKonum, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 363);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // labelUrun
            // 
            this.labelUrun.AutoSize = true;
            this.labelUrun.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelUrun.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUrun.Location = new System.Drawing.Point(37, 54);
            this.labelUrun.Name = "labelUrun";
            this.labelUrun.Size = new System.Drawing.Size(43, 50);
            this.labelUrun.TabIndex = 0;
            this.labelUrun.Text = "Ürün : ";
            // 
            // labelKategori
            // 
            this.labelKategori.AutoSize = true;
            this.labelKategori.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelKategori.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKategori.Location = new System.Drawing.Point(18, 104);
            this.labelKategori.Name = "labelKategori";
            this.labelKategori.Size = new System.Drawing.Size(62, 50);
            this.labelKategori.TabIndex = 1;
            this.labelKategori.Text = "Kategori : ";
            // 
            // labelMiktar
            // 
            this.labelMiktar.AutoSize = true;
            this.labelMiktar.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMiktar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMiktar.Location = new System.Drawing.Point(27, 154);
            this.labelMiktar.Name = "labelMiktar";
            this.labelMiktar.Size = new System.Drawing.Size(53, 50);
            this.labelMiktar.TabIndex = 2;
            this.labelMiktar.Text = "Miktar : ";
            // 
            // labelBirim
            // 
            this.labelBirim.AutoSize = true;
            this.labelBirim.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelBirim.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBirim.Location = new System.Drawing.Point(34, 204);
            this.labelBirim.Name = "labelBirim";
            this.labelBirim.Size = new System.Drawing.Size(46, 50);
            this.labelBirim.TabIndex = 3;
            this.labelBirim.Text = "Birim : ";
            // 
            // labelAçıklama
            // 
            this.labelAçıklama.AutoSize = true;
            this.labelAçıklama.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelAçıklama.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAçıklama.Location = new System.Drawing.Point(14, 254);
            this.labelAçıklama.Name = "labelAçıklama";
            this.labelAçıklama.Size = new System.Drawing.Size(66, 50);
            this.labelAçıklama.TabIndex = 4;
            this.labelAçıklama.Text = "Açıklama : ";
            // 
            // comboUrun
            // 
            this.comboUrun.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboUrun.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboUrun.FormattingEnabled = true;
            this.comboUrun.Location = new System.Drawing.Point(86, 57);
            this.comboUrun.Name = "comboUrun";
            this.comboUrun.Size = new System.Drawing.Size(190, 26);
            this.comboUrun.TabIndex = 5;
            // 
            // comboKategori
            // 
            this.comboKategori.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboKategori.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboKategori.FormattingEnabled = true;
            this.comboKategori.Items.AddRange(new object[] {
            "HIRDAVAT",
            "YAĞ",
            "DİĞER"});
            this.comboKategori.Location = new System.Drawing.Point(86, 107);
            this.comboKategori.Name = "comboKategori";
            this.comboKategori.Size = new System.Drawing.Size(190, 26);
            this.comboKategori.TabIndex = 6;
            // 
            // textMiktar
            // 
            this.textMiktar.Dock = System.Windows.Forms.DockStyle.Right;
            this.textMiktar.Enabled = false;
            this.textMiktar.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textMiktar.Location = new System.Drawing.Point(86, 157);
            this.textMiktar.Name = "textMiktar";
            this.textMiktar.Size = new System.Drawing.Size(190, 26);
            this.textMiktar.TabIndex = 7;
            this.textMiktar.Text = "0";
            this.textMiktar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBirim
            // 
            this.comboBirim.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBirim.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBirim.FormattingEnabled = true;
            this.comboBirim.Items.AddRange(new object[] {
            "Adet",
            "Boy",
            "Çift",
            "IBC",
            "Kilogram",
            "Litre",
            "Makara",
            "Metre",
            "Paket",
            "Plaka",
            "Teneke",
            "Varil"});
            this.comboBirim.Location = new System.Drawing.Point(86, 207);
            this.comboBirim.Name = "comboBirim";
            this.comboBirim.Size = new System.Drawing.Size(190, 26);
            this.comboBirim.TabIndex = 8;
            // 
            // richTextAciklama
            // 
            this.richTextAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextAciklama.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextAciklama.Location = new System.Drawing.Point(86, 257);
            this.richTextAciklama.Name = "richTextAciklama";
            this.richTextAciklama.Size = new System.Drawing.Size(190, 44);
            this.richTextAciklama.TabIndex = 9;
            this.richTextAciklama.Text = "";
            // 
            // labelTemsilci
            // 
            this.labelTemsilci.AutoSize = true;
            this.labelTemsilci.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTemsilci.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTemsilci.ForeColor = System.Drawing.Color.Brown;
            this.labelTemsilci.Location = new System.Drawing.Point(196, 0);
            this.labelTemsilci.Name = "labelTemsilci";
            this.labelTemsilci.Size = new System.Drawing.Size(80, 54);
            this.labelTemsilci.TabIndex = 10;
            this.labelTemsilci.Text = "labelTemsilci";
            // 
            // labelKonum
            // 
            this.labelKonum.AutoSize = true;
            this.labelKonum.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelKonum.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKonum.Location = new System.Drawing.Point(26, 304);
            this.labelKonum.Name = "labelKonum";
            this.labelKonum.Size = new System.Drawing.Size(54, 59);
            this.labelKonum.TabIndex = 11;
            this.labelKonum.Text = "Konum : ";
            // 
            // richTextKonum
            // 
            this.richTextKonum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextKonum.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextKonum.Location = new System.Drawing.Point(86, 307);
            this.richTextKonum.Name = "richTextKonum";
            this.richTextKonum.Size = new System.Drawing.Size(190, 53);
            this.richTextKonum.TabIndex = 12;
            this.richTextKonum.Text = "";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(303, 420);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonYeniUrun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonYeniUrun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelUrun;
        private System.Windows.Forms.Label labelKategori;
        private System.Windows.Forms.Label labelMiktar;
        private System.Windows.Forms.Label labelBirim;
        private System.Windows.Forms.Label labelAçıklama;
        private System.Windows.Forms.ComboBox comboUrun;
        private System.Windows.Forms.ComboBox comboKategori;
        private System.Windows.Forms.TextBox textMiktar;
        private System.Windows.Forms.ComboBox comboBirim;
        private System.Windows.Forms.RichTextBox richTextAciklama;
        private System.Windows.Forms.Label labelTemsilci;
        private System.Windows.Forms.Label labelKonum;
        private System.Windows.Forms.RichTextBox richTextKonum;
    }
}