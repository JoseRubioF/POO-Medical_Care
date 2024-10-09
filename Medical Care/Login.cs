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
using Medical_Care;
using Org.BouncyCastle.Operators;

namespace Medical_Care
{
    
    public partial class Login : Form
    {
        public SQLiteConn conn;
         
        public Login()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
        }

        private DialogResult Bienvenida(String rol)
        {
            Bienvenida Bien = new Bienvenida();
            Bien.lbl_Texto.Text = $"¡Bienvenido {rol}!";
            DialogResult Confirmación = Bien.ShowDialog();
            Bien.Close();
            return Confirmación;
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Acceder_Click(object sender, EventArgs e)
        {

            Loggear();
        }

        private void btn_Alternar_Click(object sender, EventArgs e)
        {
            logPacientes();
        }
        private void txtb_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Loggear();
            }
        }
        private void txtb_Paciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logPacientes();
            }
        }
        private void txtb_Contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Loggear();
            }
        }
        private void logPacientes()
        {
            conn = new SQLiteConn("Medical.db");
            string user = null;
            user = txtb_Paciente.Text;
            switch (conn.LoginPacientes(user))
            {
                case 1:
                    var Result = MessageBox.Show($"Accediendo a Ingresados con el Folio: {txtb_Paciente.Text}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        Globales.Nombre = conn.NombrePac(user);
                        Globales.Paciente_id1 = conn.HabitacionPac(user);
                        Ingresados ingres = new Ingresados();
                        ingres.Show();
                    }
                    break;
                default:
                    MessageBox.Show("Folio incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void Loggear()
        {
            conn = new SQLiteConn("Medical.db");
            string user = txtb_Usuario.Text;
            string pass = txtb_Contraseña.Text;
            string rol;
            switch (conn.Login(user, pass))
            {
                case 0:
                    Incorrecto error = new Incorrecto();
                    error.label2.Text = "Por favor ingrese un usuario y contraseña";
                    DialogResult Confirmación = new DialogResult();
                    Confirmación = error.ShowDialog();
                    if (Confirmación == DialogResult.OK)
                    {
                        error.Close();
                    }
                    break;
                case 1: //Secretaría
                    rol = "Secretaría";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Turno = conn.Turno(user);
                        Globales.Rol = conn.Rol(user);
                        Secretaría sec = new Secretaría();
                        this.Hide();
                        sec.Show();
                    }
                    break;
                case 2: //Enfermería
                    rol = "Enfermería";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Departamento = conn.Departamento(user);
                        Globales.Turno = conn.Turno(user);
                        Globales.Id = txtb_Usuario.Text;
                        Enfermería enf = new Enfermería();
                        this.Hide();
                        enf.Show();
                    }
                    break;
                case 3: //Intendencia
                    rol = "Intendencia";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Turno = conn.Turno(user);
                        Intendencia inte = new Intendencia();
                        this.Hide();
                        inte.Show();
                    }
                    break;
                case 4: //Vendedores
                    rol = "Vendedores";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Turno = conn.Turno(user);
                        Globales.Rol = conn.Rol(user);
                        Vendedores ven = new Vendedores();
                        this.Hide();
                        ven.Show();
                    }
                    break;
                case 5: //Doctores
                    rol = "Doctores";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Departamento = conn.Departamento(user);
                        Globales.Turno = conn.Turno(user);
                        Globales.Id = txtb_Usuario.Text;
                        Doctores doct = new Doctores();
                        this.Hide();
                        doct.Show();
                    }
                    break;
                case 6: //Ingresados
                    rol = "Ingresados";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Departamento = conn.Departamento(user);
                        Globales.Turno = conn.Turno(user);
                        Ingresados ingre = new Ingresados();
                        this.Hide();
                        ingre.Show();
                    }
                    break;
                case 7: //Administración
                    rol = "Administración";
                    if (Bienvenida(rol) == DialogResult.OK)
                    {
                        Globales.Nombre = conn.NombreDoc(user);
                        Globales.Turno = conn.Turno(user);
                        Globales.Rol = conn.Rol(user);
                        Administración admi = new Administración();
                        this.Hide();
                        admi.Show();
                    }
                    break;
                case 8: //Incorrecto
                    Incorrecto Inc = new Incorrecto();
                    Confirmación = Inc.ShowDialog();
                    if (Confirmación == DialogResult.OK)
                    {
                        Inc.Close();
                        txtb_Usuario.ResetText();
                        txtb_Contraseña.ResetText();
                    }
                    break;
            }
        }

        
    }
    static class Globales
    {
        public static string Nombre;
        public static string Departamento;
        public static string Turno;
        public static string Rol;
        public static string Id;
        public static string FDCita;
        public static string PaID;
        public static string Paciente_id1;
        public static string Aux;
    }

}
