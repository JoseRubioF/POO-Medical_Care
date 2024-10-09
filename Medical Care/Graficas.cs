using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteDb;

namespace Medical_Care
{
    public partial class Graficas : Form
    {
        public SQLiteConn conn;
        public Graficas()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            SQLiteConn conn = new SQLiteConn("Medical.db");
            conn.Gaños();
            for(int i= 0; i<conn.AñosAry.Count;i++)
            {
                comboBox1.Items.Add(conn.AñosAry[i].ToString());
            }
            
            int año = DateTime.Now.Year;
            conn.Top5(año);
            conn.GMetodoPago(año);
            conn.GVendedor(año);
            conn.GAnual(año);
            charttop5.Series[0].Points.DataBindXY(conn.ProductoAry, conn.CantidadAry);
            chartMetodo.Series[0].Points.DataBindXY(conn.MetodoAry, conn.TotalAry);
            chartVendedores.Series[0].Points.DataBindXY(conn.NombreAry, conn.TotalAryV);
            chartVentaAnual.Series[0].Points.DataBindXY(conn.Mesary, conn.TotalAryT);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteConn conn = new SQLiteConn("Medical.db");
            int año = Convert.ToInt32(comboBox1.Text);
            conn.Top5(año);
            conn.GMetodoPago(año);
            conn.GVendedor(año);
            conn.GAnual(año);
            charttop5.Series[0].Points.DataBindXY(conn.ProductoAry, conn.CantidadAry);
            chartMetodo.Series[0].Points.DataBindXY(conn.MetodoAry, conn.TotalAry);
            chartVendedores.Series[0].Points.DataBindXY(conn.NombreAry, conn.TotalAryV);
            chartVentaAnual.Series[0].Points.DataBindXY(conn.Mesary, conn.TotalAryT);
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
