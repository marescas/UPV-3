namespace GestDep.GUI
{
    partial class AsignarMonitor
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
            this.labelSeleccionaMonitor = new System.Windows.Forms.Label();
            this.comboBoxMonitores = new System.Windows.Forms.ComboBox();
            this.labelSeleccionaCurso = new System.Windows.Forms.Label();
            this.comboBoxCursos = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxInfoCurso = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelSeleccionaMonitor
            // 
            this.labelSeleccionaMonitor.AutoSize = true;
            this.labelSeleccionaMonitor.Location = new System.Drawing.Point(55, 175);
            this.labelSeleccionaMonitor.Name = "labelSeleccionaMonitor";
            this.labelSeleccionaMonitor.Size = new System.Drawing.Size(115, 13);
            this.labelSeleccionaMonitor.TabIndex = 0;
            this.labelSeleccionaMonitor.Text = "Selecciona un monitor:";
            this.labelSeleccionaMonitor.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxMonitores
            // 
            this.comboBoxMonitores.FormattingEnabled = true;
            this.comboBoxMonitores.Location = new System.Drawing.Point(204, 172);
            this.comboBoxMonitores.Name = "comboBoxMonitores";
            this.comboBoxMonitores.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMonitores.TabIndex = 1;
            this.comboBoxMonitores.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonitores_SelectedIndexChanged);
            // 
            // labelSeleccionaCurso
            // 
            this.labelSeleccionaCurso.AutoSize = true;
            this.labelSeleccionaCurso.Location = new System.Drawing.Point(55, 62);
            this.labelSeleccionaCurso.Name = "labelSeleccionaCurso";
            this.labelSeleccionaCurso.Size = new System.Drawing.Size(107, 13);
            this.labelSeleccionaCurso.TabIndex = 3;
            this.labelSeleccionaCurso.Text = "Selecciona un curso:";
            this.labelSeleccionaCurso.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // comboBoxCursos
            // 
            this.comboBoxCursos.FormattingEnabled = true;
            this.comboBoxCursos.Location = new System.Drawing.Point(201, 62);
            this.comboBoxCursos.Name = "comboBoxCursos";
            this.comboBoxCursos.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCursos.TabIndex = 4;
            this.comboBoxCursos.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursos_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxInfoCurso
            // 
            this.textBoxInfoCurso.Location = new System.Drawing.Point(84, 97);
            this.textBoxInfoCurso.Multiline = true;
            this.textBoxInfoCurso.Name = "textBoxInfoCurso";
            this.textBoxInfoCurso.ReadOnly = true;
            this.textBoxInfoCurso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfoCurso.Size = new System.Drawing.Size(238, 48);
            this.textBoxInfoCurso.TabIndex = 7;
            this.textBoxInfoCurso.Tag = "";
            this.textBoxInfoCurso.Text = "Información del curso seleccionado.";
            // 
            // AsignarMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 281);
            this.Controls.Add(this.textBoxInfoCurso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCursos);
            this.Controls.Add(this.labelSeleccionaCurso);
            this.Controls.Add(this.comboBoxMonitores);
            this.Controls.Add(this.labelSeleccionaMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AsignarMonitor";
            this.Text = "Asignar monitor";
            this.Load += new System.EventHandler(this.AsignarMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccionaMonitor;
        private System.Windows.Forms.ComboBox comboBoxMonitores;
        private System.Windows.Forms.Label labelSeleccionaCurso;
        private System.Windows.Forms.ComboBox comboBoxCursos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxInfoCurso;
    }
}