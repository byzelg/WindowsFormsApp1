
namespace WindowsFormsApp1
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.tableLayoutPanelArka = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelUst = new System.Windows.Forms.TableLayoutPanel();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.labelTemsilci = new System.Windows.Forms.Label();
            this.tableLayoutPanelOrta = new System.Windows.Forms.TableLayoutPanel();
            this.panelAlt = new System.Windows.Forms.Panel();
            this.buttonYeniden = new System.Windows.Forms.Button();
            this.buttonOnayla = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.advTalep = new ADGV.AdvancedDataGridView();
            this.advTeklif = new ADGV.AdvancedDataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelTalep = new System.Windows.Forms.Label();
            this.labelTeklif = new System.Windows.Forms.Label();
            this.tableLayoutPanelArka.SuspendLayout();
            this.tableLayoutPanelUst.SuspendLayout();
            this.tableLayoutPanelOrta.SuspendLayout();
            this.panelAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTalep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTeklif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelArka
            // 
            this.tableLayoutPanelArka.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelArka.ColumnCount = 1;
            this.tableLayoutPanelArka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArka.Controls.Add(this.tableLayoutPanelUst, 0, 0);
            this.tableLayoutPanelArka.Controls.Add(this.tableLayoutPanelOrta, 0, 1);
            this.tableLayoutPanelArka.Controls.Add(this.panelAlt, 0, 2);
            this.tableLayoutPanelArka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelArka.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelArka.Name = "tableLayoutPanelArka";
            this.tableLayoutPanelArka.RowCount = 3;
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.970451F));
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.45543F));
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.574123F));
            this.tableLayoutPanelArka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelArka.Size = new System.Drawing.Size(1129, 598);
            this.tableLayoutPanelArka.TabIndex = 0;
            // 
            // tableLayoutPanelUst
            // 
            this.tableLayoutPanelUst.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanelUst.ColumnCount = 3;
            this.tableLayoutPanelUst.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelUst.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelUst.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelUst.Controls.Add(this.labelBaslik, 1, 0);
            this.tableLayoutPanelUst.Controls.Add(this.labelTemsilci, 2, 0);
            this.tableLayoutPanelUst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUst.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelUst.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelUst.Name = "tableLayoutPanelUst";
            this.tableLayoutPanelUst.RowCount = 1;
            this.tableLayoutPanelUst.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUst.Size = new System.Drawing.Size(1125, 31);
            this.tableLayoutPanelUst.TabIndex = 23;
            // 
            // labelBaslik
            // 
            this.labelBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBaslik.AutoSize = true;
            this.labelBaslik.BackColor = System.Drawing.Color.Transparent;
            this.labelBaslik.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBaslik.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBaslik.Location = new System.Drawing.Point(283, 0);
            this.labelBaslik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(558, 31);
            this.labelBaslik.TabIndex = 22;
            this.labelBaslik.Text = "Sarf Teklif Onay";
            this.labelBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTemsilci
            // 
            this.labelTemsilci.AutoSize = true;
            this.labelTemsilci.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTemsilci.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTemsilci.ForeColor = System.Drawing.Color.White;
            this.labelTemsilci.Location = new System.Drawing.Point(1042, 0);
            this.labelTemsilci.Name = "labelTemsilci";
            this.labelTemsilci.Size = new System.Drawing.Size(80, 31);
            this.labelTemsilci.TabIndex = 23;
            this.labelTemsilci.Text = "labelTemsilci";
            // 
            // tableLayoutPanelOrta
            // 
            this.tableLayoutPanelOrta.BackColor = System.Drawing.Color.RosyBrown;
            this.tableLayoutPanelOrta.ColumnCount = 1;
            this.tableLayoutPanelOrta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOrta.Controls.Add(this.labelTeklif, 0, 2);
            this.tableLayoutPanelOrta.Controls.Add(this.advTalep, 0, 1);
            this.tableLayoutPanelOrta.Controls.Add(this.advTeklif, 0, 4);
            this.tableLayoutPanelOrta.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanelOrta.Controls.Add(this.labelTalep, 0, 0);
            this.tableLayoutPanelOrta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOrta.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanelOrta.Name = "tableLayoutPanelOrta";
            this.tableLayoutPanelOrta.RowCount = 5;
            this.tableLayoutPanelOrta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.249344F));
            this.tableLayoutPanelOrta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.94751F));
            this.tableLayoutPanelOrta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.986877F));
            this.tableLayoutPanelOrta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.986877F));
            this.tableLayoutPanelOrta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.8294F));
            this.tableLayoutPanelOrta.Size = new System.Drawing.Size(1123, 505);
            this.tableLayoutPanelOrta.TabIndex = 25;
            // 
            // panelAlt
            // 
            this.panelAlt.Controls.Add(this.buttonYeniden);
            this.panelAlt.Controls.Add(this.buttonOnayla);
            this.panelAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlt.Location = new System.Drawing.Point(3, 549);
            this.panelAlt.Name = "panelAlt";
            this.panelAlt.Size = new System.Drawing.Size(1123, 46);
            this.panelAlt.TabIndex = 26;
            // 
            // buttonYeniden
            // 
            this.buttonYeniden.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.buttonYeniden.FlatAppearance.BorderSize = 5;
            this.buttonYeniden.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonYeniden.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonYeniden.Location = new System.Drawing.Point(3, 2);
            this.buttonYeniden.Name = "buttonYeniden";
            this.buttonYeniden.Size = new System.Drawing.Size(150, 40);
            this.buttonYeniden.TabIndex = 1;
            this.buttonYeniden.Text = "Yeniden Araştırılsın";
            this.buttonYeniden.UseVisualStyleBackColor = true;
            this.buttonYeniden.Click += new System.EventHandler(this.buttonYeniden_Click);
            // 
            // buttonOnayla
            // 
            this.buttonOnayla.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonOnayla.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOnayla.ForeColor = System.Drawing.Color.White;
            this.buttonOnayla.Location = new System.Drawing.Point(158, 2);
            this.buttonOnayla.Name = "buttonOnayla";
            this.buttonOnayla.Size = new System.Drawing.Size(150, 40);
            this.buttonOnayla.TabIndex = 0;
            this.buttonOnayla.Text = "Seçimi Onayla";
            this.buttonOnayla.UseVisualStyleBackColor = false;
            this.buttonOnayla.Click += new System.EventHandler(this.buttonOnayla_Click);
            // 
            // advTalep
            // 
            this.advTalep.AutoGenerateContextFilters = true;
            this.advTalep.BackgroundColor = System.Drawing.Color.LightGray;
            this.advTalep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advTalep.DateWithTime = false;
            this.advTalep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTalep.Location = new System.Drawing.Point(3, 29);
            this.advTalep.Name = "advTalep";
            this.advTalep.Size = new System.Drawing.Size(1117, 94);
            this.advTalep.TabIndex = 27;
            this.advTalep.TimeFilter = false;
            // 
            // advTeklif
            // 
            this.advTeklif.AutoGenerateContextFilters = true;
            this.advTeklif.BackgroundColor = System.Drawing.Color.LightGray;
            this.advTeklif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advTeklif.DateWithTime = false;
            this.advTeklif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTeklif.Location = new System.Drawing.Point(3, 179);
            this.advTeklif.Name = "advTeklif";
            this.advTeklif.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advTeklif.Size = new System.Drawing.Size(1117, 323);
            this.advTeklif.TabIndex = 28;
            this.advTeklif.TimeFilter = false;
            this.advTeklif.SortStringChanged += new System.EventHandler(this.advTeklif_SortStringChanged);
            this.advTeklif.FilterStringChanged += new System.EventHandler(this.advTeklif_FilterStringChanged);
            this.advTeklif.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advTeklif_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1117, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tekliflerden Herhangi Birini Onaylamak için \"Seçimi Onayla\" Butonuna Basmadan Önc" +
    "e Teklif Satırını Seçmeyi Unutmayınız!";
            // 
            // labelTalep
            // 
            this.labelTalep.AutoSize = true;
            this.labelTalep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTalep.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTalep.Location = new System.Drawing.Point(3, 8);
            this.labelTalep.Name = "labelTalep";
            this.labelTalep.Size = new System.Drawing.Size(1117, 18);
            this.labelTalep.TabIndex = 30;
            this.labelTalep.Text = "Talep Bilgileri";
            // 
            // labelTeklif
            // 
            this.labelTeklif.AutoSize = true;
            this.labelTeklif.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTeklif.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTeklif.Location = new System.Drawing.Point(3, 133);
            this.labelTeklif.Name = "labelTeklif";
            this.labelTeklif.Size = new System.Drawing.Size(1117, 18);
            this.labelTeklif.TabIndex = 31;
            this.labelTeklif.Text = "Teklif Bilgileri";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 598);
            this.Controls.Add(this.tableLayoutPanelArka);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Form6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.tableLayoutPanelArka.ResumeLayout(false);
            this.tableLayoutPanelUst.ResumeLayout(false);
            this.tableLayoutPanelUst.PerformLayout();
            this.tableLayoutPanelOrta.ResumeLayout(false);
            this.tableLayoutPanelOrta.PerformLayout();
            this.panelAlt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTalep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTeklif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArka;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUst;
        private System.Windows.Forms.Label labelBaslik;
        internal System.Windows.Forms.Label labelTemsilci;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOrta;
        private System.Windows.Forms.Panel panelAlt;
        private System.Windows.Forms.Button buttonYeniden;
        private System.Windows.Forms.Button buttonOnayla;
        private ADGV.AdvancedDataGridView advTeklif;
        private System.Windows.Forms.BindingSource bindingSource2;
        internal ADGV.AdvancedDataGridView advTalep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTeklif;
        private System.Windows.Forms.Label labelTalep;
    }
}