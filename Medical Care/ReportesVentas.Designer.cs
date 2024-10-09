namespace Medical_Care
{
    partial class ReportesVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesVentas));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MetodoPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Año = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmb_filtrar = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.Btn_filtrar = new System.Windows.Forms.Button();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.picb_Minimizar = new System.Windows.Forms.PictureBox();
            this.picb_Cerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.ProductoId,
            this.Descripcion,
            this.Cantidad,
            this.Precio,
            this.Total,
            this.MetodoPago,
            this.Dia,
            this.Mes,
            this.Año,
            this.Hora});
            this.listView1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 85);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(744, 304);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Nombre
            // 
            this.Nombre.Text = "VENDEDOR";
            this.Nombre.Width = 91;
            // 
            // ProductoId
            // 
            this.ProductoId.Text = "ID PRODUCTO";
            this.ProductoId.Width = 80;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "PRODUCTO";
            this.Descripcion.Width = 87;
            // 
            // Cantidad
            // 
            this.Cantidad.Text = "CANTIDAD";
            this.Cantidad.Width = 81;
            // 
            // Precio
            // 
            this.Precio.Text = "PRECIO";
            this.Precio.Width = 62;
            // 
            // Total
            // 
            this.Total.Text = "TOTAL";
            this.Total.Width = 57;
            // 
            // MetodoPago
            // 
            this.MetodoPago.Text = "METODO DE PAGO";
            this.MetodoPago.Width = 133;
            // 
            // Dia
            // 
            this.Dia.Text = "DIA";
            this.Dia.Width = 41;
            // 
            // Mes
            // 
            this.Mes.Text = "MES";
            this.Mes.Width = 42;
            // 
            // Año
            // 
            this.Año.Text = "AÑO";
            this.Año.Width = 47;
            // 
            // Hora
            // 
            this.Hora.Text = "HORA";
            this.Hora.Width = 57;
            // 
            // cmb_filtrar
            // 
            this.cmb_filtrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_filtrar.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_filtrar.FormattingEnabled = true;
            this.cmb_filtrar.Location = new System.Drawing.Point(11, 57);
            this.cmb_filtrar.Name = "cmb_filtrar";
            this.cmb_filtrar.Size = new System.Drawing.Size(121, 20);
            this.cmb_filtrar.TabIndex = 1;
            this.cmb_filtrar.SelectedIndexChanged += new System.EventHandler(this.cmb_filtrar_SelectedIndexChanged);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_filtro.Location = new System.Drawing.Point(137, 57);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(121, 20);
            this.txt_filtro.TabIndex = 2;
            // 
            // Btn_filtrar
            // 
            this.Btn_filtrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_filtrar.BackColor = System.Drawing.Color.Teal;
            this.Btn_filtrar.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_filtrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Btn_filtrar.Location = new System.Drawing.Point(263, 54);
            this.Btn_filtrar.Name = "Btn_filtrar";
            this.Btn_filtrar.Size = new System.Drawing.Size(75, 23);
            this.Btn_filtrar.TabIndex = 3;
            this.Btn_filtrar.Text = "FILTRAR";
            this.Btn_filtrar.UseVisualStyleBackColor = false;
            this.Btn_filtrar.Click += new System.EventHandler(this.Btn_filtrar_Click);
            // 
            // cmb_mes
            // 
            this.cmb_mes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_mes.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmb_mes.Location = new System.Drawing.Point(137, 57);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(121, 20);
            this.cmb_mes.TabIndex = 4;
            this.cmb_mes.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.picb_Minimizar);
            this.panel1.Controls.Add(this.picb_Cerrar);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 32);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Medical Care";
            // 
            // picb_Minimizar
            // 
            this.picb_Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_Minimizar.Image = ((System.Drawing.Image)(resources.GetObject("picb_Minimizar.Image")));
            this.picb_Minimizar.Location = new System.Drawing.Point(700, 5);
            this.picb_Minimizar.Margin = new System.Windows.Forms.Padding(2);
            this.picb_Minimizar.Name = "picb_Minimizar";
            this.picb_Minimizar.Size = new System.Drawing.Size(26, 23);
            this.picb_Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picb_Minimizar.TabIndex = 5;
            this.picb_Minimizar.TabStop = false;
            this.picb_Minimizar.Click += new System.EventHandler(this.picb_Minimizar_Click);
            // 
            // picb_Cerrar
            // 
            this.picb_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picb_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("picb_Cerrar.Image")));
            this.picb_Cerrar.Location = new System.Drawing.Point(730, 5);
            this.picb_Cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.picb_Cerrar.Name = "picb_Cerrar";
            this.picb_Cerrar.Size = new System.Drawing.Size(26, 23);
            this.picb_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picb_Cerrar.TabIndex = 5;
            this.picb_Cerrar.TabStop = false;
            this.picb_Cerrar.Click += new System.EventHandler(this.picb_Cerrar_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(9, 5);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(26, 23);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "FILTRO POR:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "DESCRIPCIÓN:";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_imprimir.BackColor = System.Drawing.Color.Teal;
            this.btn_imprimir.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir.ForeColor = System.Drawing.Color.White;
            this.btn_imprimir.Location = new System.Drawing.Point(344, 54);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(75, 23);
            this.btn_imprimir.TabIndex = 3;
            this.btn_imprimir.Text = "IMPRIMIR";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // ReportesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(765, 395);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.Btn_filtrar);
            this.Controls.Add(this.txt_filtro);
            this.Controls.Add(this.cmb_filtrar);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportesVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cmb_filtrar;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Button Btn_filtrar;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader ProductoId;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Cantidad;
        private System.Windows.Forms.ColumnHeader Precio;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader MetodoPago;
        private System.Windows.Forms.ColumnHeader Dia;
        private System.Windows.Forms.ColumnHeader Mes;
        private System.Windows.Forms.ColumnHeader Año;
        private System.Windows.Forms.ColumnHeader Hora;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picb_Minimizar;
        private System.Windows.Forms.PictureBox picb_Cerrar;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_imprimir;
    }
}