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
    public partial class Intendencia : Form
    {
        public SQLiteConn conn;
        public Intendencia()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            label15.Text = Globales.Nombre;
            label10.Text = Globales.Turno;
            conn = new SQLiteConn("Medical.db");
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Intendencia_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Intendencia_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listView1.Items.Clear();
            foreach (Serv_Intendencia intendencia in conn.GetIntendencia())
            {
                ListViewItem item = new ListViewItem();
                item = listView1.Items.Add(intendencia.ServicioInt_id);
                item.SubItems.Add(intendencia.Instalacion_id1);
                item.SubItems.Add(intendencia.Personal_id1);
                item.SubItems.Add(intendencia.Hora);
                item.SubItems.Add(intendencia.Observacion);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("T");
            label8.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var Result = MessageBox.Show($"¿Desea marcar la actividad como conlcuida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                string id_del_servicio = listView1.SelectedItems[0].SubItems[0].Text;
                try
                {
                    conn.DeleteServ_Intendencia(id_del_servicio);
                    MessageBox.Show("Solicitud concluida exitosamente");
                }
                catch { }
                listView1.Items.Clear();
                conn.Close();
                foreach (Serv_Intendencia intendencia in conn.GetIntendencia())
                {
                    ListViewItem item = new ListViewItem();
                    item = listView1.Items.Add(intendencia.ServicioInt_id);
                    item.SubItems.Add(intendencia.Instalacion_id1);
                    item.SubItems.Add(intendencia.Personal_id1);
                    item.SubItems.Add(intendencia.Hora);
                    item.SubItems.Add(intendencia.Observacion);
                }
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
