namespace GestDep.GUI
{
    partial class AnadirCurso
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
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaInicioPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FinDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.duracionText = new System.Windows.Forms.TextBox();
            this.HoraInicioPicker = new System.Windows.Forms.DateTimePicker();
            this.checkDays = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.matriculaMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.matriculaMin = new System.Windows.Forms.TextBox();
            this.cancelCheck = new System.Windows.Forms.CheckBox();
            this.PriceText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedListBoxCalles = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(82, 24);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(190, 20);
            this.DescriptionBox.TabIndex = 0;
            this.DescriptionBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Inicio";
            // 
            // fechaInicioPicker
            // 
            this.fechaInicioPicker.Location = new System.Drawing.Point(82, 64);
            this.fechaInicioPicker.Name = "fechaInicioPicker";
            this.fechaInicioPicker.Size = new System.Drawing.Size(190, 20);
            this.fechaInicioPicker.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha fin";
            // 
            // FinDatePicker
            // 
            this.FinDatePicker.Location = new System.Drawing.Point(335, 63);
            this.FinDatePicker.Name = "FinDatePicker";
            this.FinDatePicker.Size = new System.Drawing.Size(190, 20);
            this.FinDatePicker.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Duración";
            // 
            // duracionText
            // 
            this.duracionText.Location = new System.Drawing.Point(335, 100);
            this.duracionText.Name = "duracionText";
            this.duracionText.Size = new System.Drawing.Size(190, 20);
            this.duracionText.TabIndex = 8;
            this.duracionText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numberpress);
            // 
            // HoraInicioPicker
            // 
            this.HoraInicioPicker.Location = new System.Drawing.Point(82, 101);
            this.HoraInicioPicker.Name = "HoraInicioPicker";
            this.HoraInicioPicker.Size = new System.Drawing.Size(190, 20);
            this.HoraInicioPicker.TabIndex = 9;
            // 
            // checkDays
            // 
            this.checkDays.FormattingEnabled = true;
            this.checkDays.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.checkDays.Location = new System.Drawing.Point(17, 172);
            this.checkDays.Name = "checkDays";
            this.checkDays.Size = new System.Drawing.Size(84, 94);
            this.checkDays.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Seleccionar días";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Max matrículas";
            // 
            // matriculaMax
            // 
            this.matriculaMax.Location = new System.Drawing.Point(335, 144);
            this.matriculaMax.Name = "matriculaMax";
            this.matriculaMax.Size = new System.Drawing.Size(190, 20);
            this.matriculaMax.TabIndex = 13;
            this.matriculaMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numberpress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Min matrículas";
            // 
            // matriculaMin
            // 
            this.matriculaMin.Location = new System.Drawing.Point(335, 184);
            this.matriculaMin.Name = "matriculaMin";
            this.matriculaMin.Size = new System.Drawing.Size(190, 20);
            this.matriculaMin.TabIndex = 15;
            this.matriculaMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numberpress);
            // 
            // cancelCheck
            // 
            this.cancelCheck.AutoSize = true;
            this.cancelCheck.Location = new System.Drawing.Point(392, 218);
            this.cancelCheck.Name = "cancelCheck";
            this.cancelCheck.Size = new System.Drawing.Size(68, 17);
            this.cancelCheck.TabIndex = 16;
            this.cancelCheck.Text = "Cancelar";
            this.cancelCheck.UseVisualStyleBackColor = true;
            // 
            // PriceText
            // 
            this.PriceText.Location = new System.Drawing.Point(335, 28);
            this.PriceText.Name = "PriceText";
            this.PriceText.Size = new System.Drawing.Size(190, 20);
            this.PriceText.TabIndex = 18;
            this.PriceText.TextChanged += new System.EventHandler(this.PriceText_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Precio";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(335, 241);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(190, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButtonClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Seleccionar calles";
            // 
            // checkedListBoxCalles
            // 
            this.checkedListBoxCalles.FormattingEnabled = true;
            this.checkedListBoxCalles.Location = new System.Drawing.Point(126, 172);
            this.checkedListBoxCalles.Name = "checkedListBoxCalles";
            this.checkedListBoxCalles.Size = new System.Drawing.Size(113, 94);
            this.checkedListBoxCalles.TabIndex = 20;
            this.checkedListBoxCalles.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // AnadirCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 299);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkedListBoxCalles);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.PriceText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancelCheck);
            this.Controls.Add(this.matriculaMin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.matriculaMax);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkDays);
            this.Controls.Add(this.HoraInicioPicker);
            this.Controls.Add(this.duracionText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FinDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaInicioPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AnadirCurso";
            this.Text = "Añadir curso";
            this.Load += new System.EventHandler(this.AnadirCurso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaInicioPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FinDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox duracionText;
        private System.Windows.Forms.DateTimePicker HoraInicioPicker;
        private System.Windows.Forms.CheckedListBox checkDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox matriculaMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox matriculaMin;
        private System.Windows.Forms.CheckBox cancelCheck;
        private System.Windows.Forms.TextBox PriceText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBoxCalles;
    }
}