namespace GestDep.GUI
{
    partial class GestDepApp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.anadirCursoButton = new System.Windows.Forms.Button();
            this.asignarMonitorButton = new System.Windows.Forms.Button();
            this.matricularUsuarioButton = new System.Windows.Forms.Button();
            this.listarCallesLibresButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vaciarBDButton = new System.Windows.Forms.Button();
            this.iniciarBDButton = new System.Windows.Forms.Button();
            this.adminSelector = new System.Windows.Forms.RadioButton();
            this.employeeSelector = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.anadirUsuarioButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // anadirCursoButton
            // 
            this.anadirCursoButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anadirCursoButton.Location = new System.Drawing.Point(12, 145);
            this.anadirCursoButton.Name = "anadirCursoButton";
            this.anadirCursoButton.Size = new System.Drawing.Size(240, 26);
            this.anadirCursoButton.TabIndex = 0;
            this.anadirCursoButton.Text = "Añadir curso";
            this.anadirCursoButton.UseVisualStyleBackColor = true;
            this.anadirCursoButton.Click += new System.EventHandler(this.anadirCursoClick);
            // 
            // asignarMonitorButton
            // 
            this.asignarMonitorButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asignarMonitorButton.Location = new System.Drawing.Point(12, 177);
            this.asignarMonitorButton.Name = "asignarMonitorButton";
            this.asignarMonitorButton.Size = new System.Drawing.Size(240, 26);
            this.asignarMonitorButton.TabIndex = 1;
            this.asignarMonitorButton.Text = "Asignar monitor al curso";
            this.asignarMonitorButton.UseVisualStyleBackColor = true;
            this.asignarMonitorButton.Click += new System.EventHandler(this.asignarMonitorClick);
            // 
            // matricularUsuarioButton
            // 
            this.matricularUsuarioButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matricularUsuarioButton.Location = new System.Drawing.Point(12, 209);
            this.matricularUsuarioButton.Name = "matricularUsuarioButton";
            this.matricularUsuarioButton.Size = new System.Drawing.Size(240, 26);
            this.matricularUsuarioButton.TabIndex = 2;
            this.matricularUsuarioButton.Text = "Matricular usuario";
            this.matricularUsuarioButton.UseVisualStyleBackColor = true;
            this.matricularUsuarioButton.Click += new System.EventHandler(this.matricularUsuarioClick);
            // 
            // listarCallesLibresButton
            // 
            this.listarCallesLibresButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listarCallesLibresButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listarCallesLibresButton.Location = new System.Drawing.Point(12, 273);
            this.listarCallesLibresButton.Name = "listarCallesLibresButton";
            this.listarCallesLibresButton.Size = new System.Drawing.Size(240, 26);
            this.listarCallesLibresButton.TabIndex = 4;
            this.listarCallesLibresButton.Text = "Listar calles libres";
            this.listarCallesLibresButton.UseVisualStyleBackColor = true;
            this.listarCallesLibresButton.Click += new System.EventHandler(this.listarCallesLibresClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            // 
            // vaciarBDButton
            // 
            this.vaciarBDButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaciarBDButton.Location = new System.Drawing.Point(136, 113);
            this.vaciarBDButton.Name = "vaciarBDButton";
            this.vaciarBDButton.Size = new System.Drawing.Size(116, 26);
            this.vaciarBDButton.TabIndex = 8;
            this.vaciarBDButton.Text = "Vaciar BD";
            this.vaciarBDButton.UseVisualStyleBackColor = true;
            this.vaciarBDButton.Click += new System.EventHandler(this.vaciarBD);
            // 
            // iniciarBDButton
            // 
            this.iniciarBDButton.CausesValidation = false;
            this.iniciarBDButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciarBDButton.Location = new System.Drawing.Point(12, 113);
            this.iniciarBDButton.Name = "iniciarBDButton";
            this.iniciarBDButton.Size = new System.Drawing.Size(116, 26);
            this.iniciarBDButton.TabIndex = 9;
            this.iniciarBDButton.Text = "Iniciar BD";
            this.iniciarBDButton.UseVisualStyleBackColor = true;
            this.iniciarBDButton.Click += new System.EventHandler(this.iniciarBD);
            // 
            // adminSelector
            // 
            this.adminSelector.AutoSize = true;
            this.adminSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminSelector.Location = new System.Drawing.Point(19, 19);
            this.adminSelector.Name = "adminSelector";
            this.adminSelector.Size = new System.Drawing.Size(109, 21);
            this.adminSelector.TabIndex = 10;
            this.adminSelector.TabStop = true;
            this.adminSelector.Text = "Administrador";
            this.adminSelector.UseVisualStyleBackColor = true;
            this.adminSelector.Click += new System.EventHandler(this.GestionarPermisos);
            // 
            // employeeSelector
            // 
            this.employeeSelector.AutoSize = true;
            this.employeeSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeSelector.Location = new System.Drawing.Point(134, 19);
            this.employeeSelector.Name = "employeeSelector";
            this.employeeSelector.Size = new System.Drawing.Size(85, 21);
            this.employeeSelector.TabIndex = 11;
            this.employeeSelector.TabStop = true;
            this.employeeSelector.Text = "Empleado";
            this.employeeSelector.UseVisualStyleBackColor = true;
            this.employeeSelector.Click += new System.EventHandler(this.GestionarPermisos);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.employeeSelector);
            this.groupBox1.Controls.Add(this.adminSelector);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 50);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(30, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(201, 45);
            this.TitleLabel.TabIndex = 16;
            this.TitleLabel.Text = "GestDepApp";
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 319);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 17;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(225, 319);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(27, 13);
            this.VersionLabel.TabIndex = 18;
            this.VersionLabel.Text = "v1.0";
            // 
            // anadirUsuarioButton
            // 
            this.anadirUsuarioButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anadirUsuarioButton.Location = new System.Drawing.Point(12, 241);
            this.anadirUsuarioButton.Name = "anadirUsuarioButton";
            this.anadirUsuarioButton.Size = new System.Drawing.Size(240, 26);
            this.anadirUsuarioButton.TabIndex = 3;
            this.anadirUsuarioButton.Text = "Añadir usuario";
            this.anadirUsuarioButton.UseVisualStyleBackColor = true;
            this.anadirUsuarioButton.Click += new System.EventHandler(this.asignarUsuarioClick);
            // 
            // GestDepApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(264, 341);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iniciarBDButton);
            this.Controls.Add(this.vaciarBDButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listarCallesLibresButton);
            this.Controls.Add(this.anadirUsuarioButton);
            this.Controls.Add(this.matricularUsuarioButton);
            this.Controls.Add(this.asignarMonitorButton);
            this.Controls.Add(this.anadirCursoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GestDepApp";
            this.Text = "GestDepApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingApp);
            this.Load += new System.EventHandler(this.GestDepApp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button anadirCursoButton;
        private System.Windows.Forms.Button asignarMonitorButton;
        private System.Windows.Forms.Button matricularUsuarioButton;
        private System.Windows.Forms.Button listarCallesLibresButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button vaciarBDButton;
        private System.Windows.Forms.Button iniciarBDButton;
        private System.Windows.Forms.RadioButton adminSelector;
        private System.Windows.Forms.RadioButton employeeSelector;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button anadirUsuarioButton;
    }
}

