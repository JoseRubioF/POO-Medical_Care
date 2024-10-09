using SQLiteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medical_Care
{
    public partial class Doctores : Form
    {
        public SQLiteConn conn;
        public Doctores()
        {
            InitializeComponent();
            conn = new SQLiteConn("Medical.db");
            WindowState = FormWindowState.Maximized;
            label3.Text = Globales.Nombre;
            label2.Text = Globales.Departamento;
            label8.Text = Globales.Turno;
            if (Globales.Turno == "Mixto")
            {
                btn_Consultas.Visible = true;
                btn_Ingresados.Visible = true;
            }
            else
            {
                btn_Consultas.Visible = false;
                btn_Ingresados.Visible = false;
            }

        }

        private void Actualizar()
        {
            lv_ingresados.Items.Clear();
            foreach (PxIngresado px in conn.GetIngresadosPorDr(label3.Text))
            {
                ListViewItem item;
                item = lv_ingresados.Items.Add(px.Paciente_id1);
                item.SubItems.Add(px.Instalacion_id2);
                item.SubItems.Add(px.Receta_id);
                item.SubItems.Add(px.Estado);
                
            }
        }
        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Doctores_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Doctores_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("T");
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lv_ingresados.Items.Clear();
            lv_Pacientes.Items.Clear();
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            foreach (Citas cita in conn.GetCitasDeDoctorPorDia(Globales.Id, FechaDeCita))
            {
                ListViewItem item = new ListViewItem();
                item = lv_Pacientes.Items.Add(cita.Paciente);
                item.SubItems.Add(cita.Tipo);
                item.SubItems.Add(cita.Personal);
                item.SubItems.Add(cita.Fila);
            }
        }


        private void btn_Alta_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show($"¿Seguro desea dar de alta a {lv_ingresados.SelectedItems[0].SubItems[0].Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                string Habitacion = conn.GetInstalacionIdDeInstalacion(lv_ingresados.SelectedItems[0].SubItems[1].Text);
                conn.DeletePacienteIngresado(Habitacion);
                Actualizar();
            }
        }

        private void btn_Consultas_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
        }

        private void btn_Ingresados_Click(object sender, EventArgs e)
        {
            lv_ingresados.Items.Clear();
            groupBox3.Visible = false;
            groupBox2.Visible = true;
            Actualizar();
        }

        private void hISTORIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{ lv_Pacientes.SelectedItems[0].SubItems[2].Text}");
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Pacientes\" + $"{ lv_Pacientes.SelectedItems[0].SubItems[2].Text}");
        }

        private void btn_receta_Click(object sender, EventArgs e)
        {
            try
            {
                Consulta consul = new Consulta();
                consul.lbl_paciente.Text = lv_ingresados.SelectedItems[0].SubItems[0].Text;
                Globales.FDCita = " ";
                consul.lbl_Edad.Text = conn.GetPacienteEdad().Find(x => x.NombreCompleto == lv_ingresados.SelectedItems[0].SubItems[0].Text).Paciente_id;
                consul.lbl_TipoDeSangre.Text = conn.GetPacienteTipoDeSangre().Find(x => x.NombreCompleto == lv_ingresados.SelectedItems[0].SubItems[0].Text).Paciente_id;
                consul.Show();
            }
            catch
            {
                MessageBox.Show("Por favor seleccione a un paciente de la tabla y vuelva a intentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lv_Pacientes_DoubleClick(object sender, EventArgs e)
        {
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            string Estado_de_la_Cita = conn.GetEstadoDeLaCita(lv_Pacientes.SelectedItems[0].SubItems[0].Text, FechaDeCita);
            if (Estado_de_la_Cita == "Completado")
            {
                MessageBox.Show("Esta cita ya está concluida");
            }
            if (Estado_de_la_Cita == "Pendiente")
            {
                Consulta consul = new Consulta();
                consul.lbl_paciente.Text = lv_Pacientes.SelectedItems[0].SubItems[2].Text;
                Globales.FDCita = Fecha.ToString().Substring(0, 10);
                Globales.PaID = lv_Pacientes.SelectedItems[0].SubItems[0].Text;
                consul.lbl_Edad.Text = conn.GetPacienteEdad().Find(x => x.NombreCompleto == lv_Pacientes.SelectedItems[0].SubItems[2].Text).Paciente_id;
                consul.lbl_TipoDeSangre.Text = conn.GetPacienteTipoDeSangre().Find(x => x.NombreCompleto == lv_Pacientes.SelectedItems[0].SubItems[2].Text).Paciente_id;
                consul.Show();
            }

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
