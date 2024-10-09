namespace Medical_Care
{
    partial class Solicitar_intendencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Solicitar_intendencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picb_Cerrar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_observacion = new System.Windows.Forms.TextBox();
            this.cmb_instalacion = new System.Windows.Forms.ComboBox();
            this.cmb_nombre_Imt = new System.Windows.Forms.ComboBox();
            this.btn_solicitar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_Hora = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.picb_Cerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 40);
            this.panel1.TabIndex = 5;
            // 
            // picb_Cerrar
            // 
            this.picb_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("picb_Cerrar.Image")));
            this.picb_Cerrar.Location = new System.Drawing.Point(267, 6);
            this.picb_Cerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picb_Cerrar.Name = "picb_Cerrar";
            this.picb_Cerrar.Size = new System.Drawing.Size(35, 28);
            this.picb_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picb_Cerrar.TabIndex = 5;
            this.picb_Cerrar.TabStop = false;
            this.picb_Cerrar.Click += new System.EventHandler(this.picb_Cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Medical Care";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "INSTALACIÓN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "NOMBRE:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "HORA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "OBSERVACIÓN:";
            // 
            // txt_observacion
            // 
            this.txt_observacion.AllowDrop = true;
            this.txt_observacion.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_observacion.Location = new System.Drawing.Point(58, 212);
            this.txt_observacion.Multiline = true;
            this.txt_observacion.Name = "txt_observacion";
            this.txt_observacion.Size = new System.Drawing.Size(195, 53);
            this.txt_observacion.TabIndex = 11;
            // 
            // cmb_instalacion
            // 
            this.cmb_instalacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_instalacion.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_instalacion.FormattingEnabled = true;
            this.cmb_instalacion.Location = new System.Drawing.Point(58, 73);
            this.cmb_instalacion.Name = "cmb_instalacion";
            this.cmb_instalacion.Size = new System.Drawing.Size(195, 24);
            this.cmb_instalacion.TabIndex = 13;
            // 
            // cmb_nombre_Imt
            // 
            this.cmb_nombre_Imt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_nombre_Imt.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_nombre_Imt.FormattingEnabled = true;
            this.cmb_nombre_Imt.Location = new System.Drawing.Point(58, 120);
            this.cmb_nombre_Imt.Name = "cmb_nombre_Imt";
            this.cmb_nombre_Imt.Size = new System.Drawing.Size(195, 24);
            this.cmb_nombre_Imt.TabIndex = 14;
            // 
            // btn_solicitar
            // 
            this.btn_solicitar.BackColor = System.Drawing.Color.Teal;
            this.btn_solicitar.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_solicitar.ForeColor = System.Drawing.Color.White;
            this.btn_solicitar.Location = new System.Drawing.Point(58, 271);
            this.btn_solicitar.Name = "btn_solicitar";
            this.btn_solicitar.Size = new System.Drawing.Size(195, 36);
            this.btn_solicitar.TabIndex = 15;
            this.btn_solicitar.Text = "SOLICITAR";
            this.btn_solicitar.UseVisualStyleBackColor = false;
            this.btn_solicitar.Click += new System.EventHandler(this.btn_solicitar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_Hora
            // 
            this.txt_Hora.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hora.Location = new System.Drawing.Point(58, 167);
            this.txt_Hora.Name = "txt_Hora";
            this.txt_Hora.Size = new System.Drawing.Size(195, 22);
            this.txt_Hora.TabIndex = 12;
            // 
            // Solicitar_intendencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(311, 329);
            this.Controls.Add(this.btn_solicitar);
            this.Controls.Add(this.cmb_nombre_Imt);
            this.Controls.Add(this.cmb_instalacion);
            this.Controls.Add(this.txt_Hora);
            this.Controls.Add(this.txt_observacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Solicitar_intendencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitar Intendencia";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picb_Cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_observacion;
        private System.Windows.Forms.ComboBox cmb_instalacion;
        private System.Windows.Forms.ComboBox cmb_nombre_Imt;
        private System.Windows.Forms.Button btn_solicitar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_Hora;
    }
}