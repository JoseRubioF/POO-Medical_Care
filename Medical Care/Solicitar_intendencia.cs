using System;
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
    public partial class Solicitar_intendencia : Form
    {
        public SQLiteConn conn;
        public Solicitar_intendencia()
        {
            InitializeComponent();
            conn = new SQLiteConn("Medical.db");
            cmb_instalacion.DataSource = conn.GetInstalaciones();
            cmb_instalacion.ValueMember = "Instalacion_id";
            cmb_instalacion.DisplayMember = "Nombre";
            cmb_nombre_Imt.DataSource = conn.GetPersonalIntendencia();
            cmb_nombre_Imt.ValueMember = "Personal_id";
            cmb_nombre_Imt.DisplayMember = "NombreInt";
            txt_Hora.Text = DateTime.Now.ToString("T");
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_solicitar_Click(object sender, EventArgs e)
        {
            string personal_id1 = cmb_nombre_Imt.Text;
            string instalacion_id1 = conn.GetInstalacionIdDeInstalacion(cmb_instalacion.Text);
            string hora = txt_Hora.Text;
            string observacion = txt_observacion.Text;
            string servicioInt_id = cmb_instalacion.Text.Substring(0, 3) + txt_Hora.Text.Substring(0, 2) + txt_Hora.Text.Substring(3, 2);
            conn.AgregarServiciosInt(servicioInt_id, personal_id1, instalacion_id1,hora, observacion);
            txt_observacion.Clear();
            MessageBox.Show("Servicio solicitado con con exito");
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
