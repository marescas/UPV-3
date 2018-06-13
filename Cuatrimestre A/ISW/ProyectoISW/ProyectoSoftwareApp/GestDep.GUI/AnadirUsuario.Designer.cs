namespace GestDep.GUI
{
    partial class AnadirUsuario
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
            this.buttonAnadirUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIban = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxCodigoPostal = new System.Windows.Forms.TextBox();
            this.textBoxIban = new System.Windows.Forms.TextBox();
            this.dateTimeNacimiento = new System.Windows.Forms.DateTimePicker();
            this.checkBoxJubilado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonAnadirUsuario
            // 
            this.buttonAnadirUsuario.Location = new System.Drawing.Point(279, 194);
            this.buttonAnadirUsuario.Name = "buttonAnadirUsuario";
            this.buttonAnadirUsuario.Size = new System.Drawing.Size(85, 29);
            this.buttonAnadirUsuario.TabIndex = 0;
            this.buttonAnadirUsuario.Text = "Añadir usuario";
            this.buttonAnadirUsuario.UseVisualStyleBackColor = true;
            this.buttonAnadirUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Código postal:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelIban
            // 
            this.labelIban.AutoSize = true;
            this.labelIban.Location = new System.Drawing.Point(145, 154);
            this.labelIban.Name = "labelIban";
            this.labelIban.Size = new System.Drawing.Size(35, 13);
            this.labelIban.TabIndex = 5;
            this.labelIban.Text = "IBAN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha de nacimiento:";
            // 
            // textBoxDni
            // 
            this.textBoxDni.Location = new System.Drawing.Point(73, 23);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(80, 20);
            this.textBoxDni.TabIndex = 9;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(235, 23);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(127, 20);
            this.textBoxNombre.TabIndex = 10;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(73, 64);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(133, 20);
            this.textBoxDireccion.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxCodigoPostal
            // 
            this.textBoxCodigoPostal.Location = new System.Drawing.Point(305, 64);
            this.textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            this.textBoxCodigoPostal.Size = new System.Drawing.Size(59, 20);
            this.textBoxCodigoPostal.TabIndex = 13;
            this.textBoxCodigoPostal.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBoxIban
            // 
            this.textBoxIban.Location = new System.Drawing.Point(186, 151);
            this.textBoxIban.Name = "textBoxIban";
            this.textBoxIban.Size = new System.Drawing.Size(178, 20);
            this.textBoxIban.TabIndex = 14;
            this.textBoxIban.TextChanged += new System.EventHandler(this.textBoxIban_TextChanged);
            // 
            // dateTimeNacimiento
            // 
            this.dateTimeNacimiento.Location = new System.Drawing.Point(127, 107);
            this.dateTimeNacimiento.Name = "dateTimeNacimiento";
            this.dateTimeNacimiento.Size = new System.Drawing.Size(237, 20);
            this.dateTimeNacimiento.TabIndex = 15;
            // 
            // checkBoxJubilado
            // 
            this.checkBoxJubilado.AutoSize = true;
            this.checkBoxJubilado.Location = new System.Drawing.Point(41, 154);
            this.checkBoxJubilado.Name = "checkBoxJubilado";
            this.checkBoxJubilado.Size = new System.Drawing.Size(65, 17);
            this.checkBoxJubilado.TabIndex = 16;
            this.checkBoxJubilado.Text = "Jubilado";
            this.checkBoxJubilado.UseVisualStyleBackColor = true;
            this.checkBoxJubilado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AnadirUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 241);
            this.Controls.Add(this.checkBoxJubilado);
            this.Controls.Add(this.dateTimeNacimiento);
            this.Controls.Add(this.textBoxIban);
            this.Controls.Add(this.textBoxCodigoPostal);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelIban);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnadirUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AnadirUsuario";
            this.Text = "Añadir usuario";
            this.Load += new System.EventHandler(this.AnadirUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnadirUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIban;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxCodigoPostal;
        private System.Windows.Forms.TextBox textBoxIban;
        private System.Windows.Forms.DateTimePicker dateTimeNacimiento;
        private System.Windows.Forms.CheckBox checkBoxJubilado;
    }
}