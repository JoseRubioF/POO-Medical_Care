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
    public partial class Administración : Form
    {
        public Administración()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            label15.Text = Globales.Nombre;
            label10.Text = Globales.Turno;
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Administración_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout CerrarSesion = new Logout();
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

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            Usuarios Usua = new Usuarios();
            Usua.Show();
        }

        private void Administración_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("T");
            label8.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void btn_Farmacias_Click_1(object sender, EventArgs e)
        {
            Vendedores vends = new Vendedores();
            vends.Show();
        }

        private void btn_Secretaria_Click(object sender, EventArgs e)
        {
            Secretaría sec = new Secretaría();
            sec.Show();
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
