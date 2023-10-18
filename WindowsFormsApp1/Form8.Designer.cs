
namespace WindowsFormsApp1
{
    partial class Form8
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowFiltering = true;
            this.sfDataGrid1.AllowResizingColumns = true;
            this.sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.sfDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDataGrid1.ExpanderColumnWidth = 35D;
            this.sfDataGrid1.IndentColumnWidth = 50D;
            this.sfDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(800, 450);
            this.sfDataGrid1.TabIndex = 0;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.sfDataGrid1_CellDoubleClick);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sfDataGrid1);
            this.Name = "Form8";
            this.Text = "Form 8";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
    }
}