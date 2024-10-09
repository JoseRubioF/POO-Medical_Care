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
    public partial class Ingresados : Form
    {
        public SQLiteConn conn;
        public Ingresados()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            label7.Text = Globales.Nombre;
            lbl_Habitacion.Text = Globales.Paciente_id1;
            conn = new SQLiteConn("Medical.db");
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ingresados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form CerrarSesion = new Logout();
            DialogResult Respuesta = new DialogResult();

            Respuesta = CerrarSesion.ShowDialog();

            if (Respuesta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (Respuesta == DialogResult.OK)
            {
                CerrarSesion.Close();
                Form Login = new Login();
                Login.Show();
            }
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void Ingresados_Load(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            foreach (Citas cita in conn.GetCitasDePacientes(Globales.Paciente_id1))
            {
                ListViewItem item = new ListViewItem();
                item = listView3.Items.Add(cita.Tipo);
                item.SubItems.Add(cita.Personal);
                item.SubItems.Add(cita.Fecha_de_Cita);
                item.SubItems.Add(cita.Instalacion);
                item.SubItems.Add(cita.Turno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{label7.Text}");
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Pacientes\" + $"{label7.Text}");
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Porgrama creado por: \n Aldo Andrade Muñoz \n Juan Carlos Cano Navarrete \n Miranda Patricia Heredia Delgado \n José Eduardo Rubio Fernández" +
                "\n David Villanueva Ojeda", "Acerca De", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\ManualDeUsuario_MedicalCare.pdf");
        }
    }
}
