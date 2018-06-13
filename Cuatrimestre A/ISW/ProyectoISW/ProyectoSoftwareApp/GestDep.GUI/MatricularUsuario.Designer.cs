namespace GestDep.GUI
{
    partial class MatricularUsuario
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxCursos = new System.Windows.Forms.ComboBox();
            this.labelSeleccionaCurso = new System.Windows.Forms.Label();
            this.checkBoxNuevoUsuario = new System.Windows.Forms.CheckBox();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.labelSeleccionaUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(341, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 46);
            this.button1.TabIndex = 13;
            this.button1.Text = "Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxCursos
            // 
            this.comboBoxCursos.FormattingEnabled = true;
            this.comboBoxCursos.Location = new System.Drawing.Point(219, 137);
            this.comboBoxCursos.Name = "comboBoxCursos";
            this.comboBoxCursos.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCursos.TabIndex = 11;
            this.comboBoxCursos.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursos_SelectedIndexChanged);
            // 
            // labelSeleccionaCurso
            // 
            this.labelSeleccionaCurso.AutoSize = true;
            this.labelSeleccionaCurso.Location = new System.Drawing.Point(73, 137);
            this.labelSeleccionaCurso.Name = "labelSeleccionaCurso";
            this.labelSeleccionaCurso.Size = new System.Drawing.Size(107, 13);
            this.labelSeleccionaCurso.TabIndex = 10;
            this.labelSeleccionaCurso.Text = "Selecciona un curso:";
            // 
            // checkBoxNuevoUsuario
            // 
            this.checkBoxNuevoUsuario.AutoSize = true;
            this.checkBoxNuevoUsuario.Location = new System.Drawing.Point(151, 91);
            this.checkBoxNuevoUsuario.Name = "checkBoxNuevoUsuario";
            this.checkBoxNuevoUsuario.Size = new System.Drawing.Size(133, 17);
            this.checkBoxNuevoUsuario.TabIndex = 9;
            this.checkBoxNuevoUsuario.Text = "Agregar nuevo usuario";
            this.checkBoxNuevoUsuario.UseVisualStyleBackColor = true;
            this.checkBoxNuevoUsuario.CheckedChanged += new System.EventHandler(this.checkBoxNuevoUsuario_CheckedChanged);
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(219, 54);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsuarios.TabIndex = 8;
            this.comboBoxUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // labelSeleccionaUsuario
            // 
            this.labelSeleccionaUsuario.AutoSize = true;
            this.labelSeleccionaUsuario.Location = new System.Drawing.Point(70, 57);
            this.labelSeleccionaUsuario.Name = "labelSeleccionaUsuario";
            this.labelSeleccionaUsuario.Size = new System.Drawing.Size(115, 13);
            this.labelSeleccionaUsuario.TabIndex = 7;
            this.labelSeleccionaUsuario.Text = "Selecciona un usuario:";
            // 
            // MatricularUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 289);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCursos);
            this.Controls.Add(this.labelSeleccionaCurso);
            this.Controls.Add(this.checkBoxNuevoUsuario);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.labelSeleccionaUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MatricularUsuario";
            this.Text = "Matricular Usuario";
            this.Load += new System.EventHandler(this.MatricularUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxCursos;
        private System.Windows.Forms.Label labelSeleccionaCurso;
        private System.Windows.Forms.CheckBox checkBoxNuevoUsuario;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Label labelSeleccionaUsuario;
    }
}