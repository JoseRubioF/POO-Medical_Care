using SQLiteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medical_Care
{
    public partial class Enfermería : Form
    {
        public SQLiteConn conn;
        public Enfermería()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            label2.Text = Globales.Nombre;
            label1.Text = Globales.Departamento;
            label7.Text = Globales.Turno;
            conn = new SQLiteConn("Medical.db");
        }

        private void picb_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Enfermería_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("T");
            label5.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void Enfermería_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lv_Pacientes.Items.Clear();
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            foreach (Citas cita in conn.GetCitasDeDoctorPorDia(Globales.Id, FechaDeCita))
            {
                ListViewItem item = new ListViewItem();
                item = lv_Pacientes.Items.Add(cita.Tipo);
                item.SubItems.Add(cita.Paciente);
                item.SubItems.Add(cita.Personal);
                item.SubItems.Add(cita.Instalacion);
            }
        }

        private void lv_Pacientes_DoubleClick(object sender, EventArgs e)
        {
            string PaID = null;
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            try
            {
                PaID = lv_Pacientes.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
            string CITASID = conn.GetCitasDeDoctorPorDia(Globales.Id, FechaDeCita).Find(x => x.Fecha_de_Cita == FechaDeCita && x.Paciente == PaID).Citas_id;
            try
            {
                PaID = lv_Pacientes.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
            if (txt_estado.Text == "Pendiente") conn.ActualizarEstado("Completado", CITASID);
            else if (txt_estado.Text == "Completado") conn.ActualizarEstado("Pendiente", CITASID);
            Actualizar();
        }

        private void lv_Pacientes_Click(object sender, EventArgs e)
        {
            string FechaDeCita = null;
            string PaID = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            //MessageBox.Show(PacienteID);
            try
            {
                PaID = lv_Pacientes.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
            txt_estado.Text = conn.GetEstadoDeLaCita(PaID, FechaDeCita);
            //MessageBox.Show(conn.GetEstadoDeLaCita(PacienteID, FechaDeCita));
            if (txt_estado.Text == "Completado") txt_estado.BackColor = Color.Green;
            if (txt_estado.Text == "Pendiente") txt_estado.BackColor = Color.Orange;
        }
        private void Actualizar()
        {
            string PaID = null;
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            try
            {
                PaID = lv_Pacientes.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
            string CITASID = conn.GetCitasDeDoctorPorDia(Globales.Id, FechaDeCita).Find(x => x.Fecha_de_Cita == FechaDeCita && x.Paciente == PaID).Citas_id;
            try
            {
                PaID = lv_Pacientes.SelectedItems[0].SubItems[1].Text;
            }
            catch { }
            txt_estado.Text = conn.GetEstadoDeLaCita(PaID, FechaDeCita);
            if (txt_estado.Text == "Completado") txt_estado.BackColor = Color.Green;
            if (txt_estado.Text == "Pendiente") txt_estado.BackColor = Color.Orange;
        }

        private void hISTORIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{ lv_Pacientes.SelectedItems[0].SubItems[2].Text}");
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Pacientes\" + $"{ lv_Pacientes.SelectedItems[0].SubItems[2].Text}");
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
