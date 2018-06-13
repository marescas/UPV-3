namespace GestDep.GUI
{
    partial class ListarCallesLibres
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
            this.label1 = new System.Windows.Forms.Label();
            this.poolSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateSelector = new System.Windows.Forms.DateTimePicker();
            this.CallesLibresTable = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar piscina:";
            // 
            // poolSelector
            // 
            this.poolSelector.FormattingEnabled = true;
            this.poolSelector.Location = new System.Drawing.Point(154, 12);
            this.poolSelector.Name = "poolSelector";
            this.poolSelector.Size = new System.Drawing.Size(121, 21);
            this.poolSelector.TabIndex = 2;
            this.poolSelector.SelectedIndexChanged += new System.EventHandler(this.updateSelectedPool);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Elegir lunes de la semana:";
            // 
            // dateSelector
            // 
            this.dateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSelector.Location = new System.Drawing.Point(154, 63);
            this.dateSelector.Name = "dateSelector";
            this.dateSelector.Size = new System.Drawing.Size(200, 20);
            this.dateSelector.TabIndex = 5;
            this.dateSelector.CloseUp += new System.EventHandler(this.updateSelectedDate);
            // 
            // CallesLibresTable
            // 
            this.CallesLibresTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallesLibresTable.Location = new System.Drawing.Point(15, 121);
            this.CallesLibresTable.Name = "CallesLibresTable";
            this.CallesLibresTable.Size = new System.Drawing.Size(366, 284);
            this.CallesLibresTable.TabIndex = 6;
            this.CallesLibresTable.UseCompatibleStateImageBehavior = false;
            this.CallesLibresTable.View = System.Windows.Forms.View.Details;
            // 
            // ListarCallesLibres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 417);
            this.Controls.Add(this.CallesLibresTable);
            this.Controls.Add(this.dateSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.poolSelector);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListarCallesLibres";
            this.Text = "Calles libres";
            this.Load += new System.EventHandler(this.ListarCallesLibres_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox poolSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateSelector;
        private System.Windows.Forms.ListView CallesLibresTable;
    }
}