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
    public partial class Usuarios : Form
    {
        public SQLiteConn conn;
        
        public Usuarios()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            conn = new SQLiteConn("Medical.db");
            cmb_horario.DataSource = conn.GetTurnos();
            cmb_horario.ValueMember = "Turno_id";
            cmb_horario.DisplayMember = "Turno";
            cmb_agregar_rol.DataSource = conn.GetRoles();
            cmb_agregar_rol.ValueMember = "Rol_id";
            cmb_agregar_rol.DisplayMember = "Roles";
            cmb_especialidad.DataSource = conn.GetEspecialidades();
            cmb_especialidad.ValueMember = "Especialidad_id";
            cmb_especialidad.DisplayMember = "Especialidad";
            comboBox1.Items.Add("Nombre");
            comboBox1.Items.Add("Apellido");
            comboBox1.Items.Add("Rol");
            Actualizar();
            
        }
        


        public void Actualizar()
        {
            
            txtb_agregar_nombre.Clear();
            txtb_agregar_contraseña.Clear();
            txtb_agregar_apellido.Clear();
            txtb_agregar_telefono.Clear();
            cmb_agregar_rol.SelectedIndex = -1;
            cmb_horario.SelectedIndex = -1;
            comboBox2.DataSource = conn.GetPersonalMedico();
            comboBox2.ValueMember = "NombreMedico";
            comboBox2.DisplayMember = "Personal_id";
            comboBox2.SelectedIndex = -1;
            comboBox3.DataSource = conn.GetPersonalMedico();
            comboBox3.ValueMember = "Personal_id";
            comboBox3.DisplayMember = "NombreMedico";
            comboBox3.SelectedIndex = -1;
            cmb_Instalacion_Pers.DataSource = conn.GetInstalaciones();
            cmb_Instalacion_Pers.ValueMember = "Instalacion_id";
            cmb_Instalacion_Pers.DisplayMember = "Nombre";
            cmb_Instalacion_Pers.SelectedIndex = -1;
            cmb_Turno_Inst.DataSource = conn.GetPersonalMedico();
            cmb_Turno_Inst.ValueMember = "Personal_id";
            cmb_Turno_Inst.DisplayMember = "Turno";
            cmb_Turno_Inst.SelectedIndex = -1;

            ActLVUsuarios();
        }

        private void filtrar(int criterio1)
        {
            foreach (ListViewItem item in Lview_Usuarios.Items)
            {
                if (!item.SubItems[criterio1].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    Lview_Usuarios.Items.Remove(item);
                }
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
        
        private void btn_agregar_personal_Click(object sender, EventArgs e)
        {
            try
            {
                string rol = null;
                if (cmb_agregar_rol.SelectedValue == null) { }
                else
                {
                    rol = cmb_agregar_rol.SelectedValue.ToString();
                }
                string nombre = txtb_agregar_nombre.Text;
                string apellido = txtb_agregar_apellido.Text;
                string telefono = txtb_agregar_telefono.Text; //convertir a string
                string especialidad = cmb_especialidad.SelectedValue.ToString();
                string turno = Convert.ToString(cmb_horario.SelectedValue); 
                string contraseña = txtb_agregar_contraseña.Text;
                string id = nombre.Substring(0, 3) + apellido.Substring(0, 3);
                if (conn.GetPersonal().Exists(x => x.Personal_id == id))
                {
                    MessageBox.Show("Error el ID de personal ya esta en uso");
                }
                else
                {
                    if (conn.AgregarPersonal(id, nombre, apellido, telefono, especialidad, rol, turno, contraseña) == 1)
                    {
                        MessageBox.Show("Usuario Agregado con exito");

                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar usuario");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Asegurese de llenar todos los campos de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Dar_de_baja_Click(object sender, EventArgs e)
        {

            
            try
            {
                string id = Lview_Usuarios.SelectedItems[0].SubItems[0].Text;
                var result = MessageBox.Show($"Desaea Eliminar al usuario con el ID: {id}", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.EliminarPerosnal(id);
                    try
                    {
                        conn.DeleteInstalacionAPersonalMedico(id);
                    }
                    catch { }
                    Actualizar();
                }
            }
            catch 
            {
                MessageBox.Show("Favor de seleccionar un usario en la tabla");
            }
           
        }

        private void btn_Mostrar_Datos_Click(object sender, EventArgs e)
        {

            try
            {
                Agregar_personal.Visible = true;
                groupBox2.Visible = false;
                btn_agregar_personal.Visible = false;
                btn_Guardar_cambios.Visible = true;
                txtb_agregar_nombre.Text = Lview_Usuarios.SelectedItems[0].SubItems[1].Text;
                txtb_agregar_apellido.Text = Lview_Usuarios.SelectedItems[0].SubItems[2].Text;
                txtb_agregar_telefono.Text = Lview_Usuarios.SelectedItems[0].SubItems[3].Text;
                cmb_especialidad.Text = Lview_Usuarios.SelectedItems[0].SubItems[4].Text;
                cmb_agregar_rol.Text = Lview_Usuarios.SelectedItems[0].SubItems[5].Text;
                cmb_horario.Text = Lview_Usuarios.SelectedItems[0].SubItems[6].Text;
                txtb_agregar_contraseña.Text = Lview_Usuarios.SelectedItems[0].SubItems[7].Text;
                txtb_agregar_nombre.Enabled = false;
                txtb_agregar_apellido.Enabled = false;
            }
            catch { }

        
        }

        private void btn_Guardar_cambios_Click(object sender, EventArgs e)
        {
            string id = Lview_Usuarios.SelectedItems[0].SubItems[0].Text;
            string nombre = txtb_agregar_nombre.Text;
            string apellido = txtb_agregar_apellido.Text;
            string telefono = txtb_agregar_telefono.Text; //convertir a string
            string especialidad = null;
            string rol = cmb_agregar_rol.SelectedValue.ToString();
            string turno = Convert.ToString(cmb_horario.SelectedValue);
            string contraseña = txtb_agregar_contraseña.Text;
            txtb_agregar_nombre.Enabled = true;
            txtb_agregar_apellido.Enabled = true;
            if (cmb_especialidad.Text == "") especialidad = "0";
            else especialidad = cmb_especialidad.SelectedValue.ToString();

            if (conn.ActualizarPersonal(id, nombre, apellido, telefono, especialidad, rol, turno, contraseña) == 1)
            {
                MessageBox.Show("Datos Actualizados");
                btn_agregar_personal.Visible = true;
                btn_Guardar_cambios.Visible = false;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Eeeeerror");
                btn_agregar_personal.Visible = true;
                btn_Guardar_cambios.Visible = false;
            }
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int criterio1;
            Actualizar();
            if (comboBox1.Text == ("Nombre"))
            {
                criterio1 = 1;
                filtrar(criterio1);
            }
            else if (comboBox1.Text == "Apellido")
            {
                criterio1 = 2;
                filtrar(criterio1);
            }
            else if (comboBox1.Text == "Rol")
            {
                criterio1 = 6;
                filtrar(criterio1);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int criterio1;
            Actualizar();
            if (comboBox1.Text == ("Nombre"))
            {
                criterio1 = 1;
                filtrar(criterio1);
            }
            else if (comboBox1.Text == "Apellido")
            {
                criterio1 = 2;
                filtrar(criterio1);
            }
            else if (comboBox1.Text == "Rol")
            {
                criterio1 = 5;
                filtrar(criterio1);
            }
        }

        private void txtb_agregar_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validación.SoloLetras(e);
        }

        private void txtb_agregar_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validación.SoloNumeros(e);
        }

        private void cmb_agregar_rol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_especialidad.FindString("NA");
            cmb_especialidad.SelectedIndex = index;
            //cmb_especialidad.Text = "NA";
            if (cmb_agregar_rol.SelectedIndex == 1 || cmb_agregar_rol.SelectedIndex == 4) cmb_especialidad.Enabled = true;
            else cmb_especialidad.Enabled = false;
            
        }

        private void aSIGNARINSTALACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            Agregar_personal.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            Agregar_personal.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = Convert.ToString(comboBox2.SelectedValue);
            cmb_Turno_Inst.SelectedValue = comboBox3.SelectedValue;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = Convert.ToString(comboBox3.SelectedValue);
            try 
            {
                cmb_Turno_Inst.SelectedValue = comboBox3.SelectedValue;
            }
            catch
            {

            }
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void btn_AgregarUsuario_Click(object sender, EventArgs e)
        {
            btn_agregar_personal.Visible = true;
            btn_Guardar_cambios.Visible = false;
            groupBox2.Visible = false;
            Agregar_personal.Visible = true;
            Actualizar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Turno_Id = GetTurnoID();
            string Personal_Id = comboBox2.Text;
            string Instalacion = Convert.ToString(cmb_Instalacion_Pers.SelectedValue);
            if (conn.GetPersonalInstalacionTurno().Exists(x => x.Instalacion == Instalacion && x.Turno == Turno_Id))
            {
                MessageBox.Show("Error: La instalacion ya se encuentra ocupada en ese turno");
            }
            else if (conn.GetPersonalInstalacionTurno().Exists(x => x.Personal == Personal_Id))
            {
                var result = MessageBox.Show($"El Usuario ya cuenta con una instalacion assignada, desea reasignar a la Instalaicion: {cmb_Instalacion_Pers.Text}", "Mensage",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (conn.GetPersonalInstalacionTurno().Exists(x => x.Instalacion == Instalacion && x.Turno == Turno_Id))
                    {
                        MessageBox.Show("Error: La instalacion ya se encuentra ocupada en ese turno");
                    }
                    else
                    {
                        conn.Close();
                        conn.UpdateInstalacionAPersonalMedico(Instalacion, Personal_Id, Turno_Id);
                        MessageBox.Show("Instalacion asignada exitosamente");
                        groupBox2.Visible = false;
                        Agregar_personal.Visible = true;
                        ActLVUsuarios();
                    }
                }
            }
            else
            {
                conn.Close();
                conn.AddInstalacionAPersonalMedico(Instalacion, Personal_Id, Turno_Id);
                MessageBox.Show("Instalacion asignada exitosamente");
                groupBox2.Visible = false;
                Agregar_personal.Visible = true;
                ActLVUsuarios();
            }
        }

        private string GetTurnoID()
        {
            string Turno_Id = null;
            if (cmb_Turno_Inst.Text == "Matutino") Turno_Id = "1";
            if (cmb_Turno_Inst.Text == "Vespertino") Turno_Id = "2";
            if (cmb_Turno_Inst.Text == "Nocturno") Turno_Id = "3";
            if (cmb_Turno_Inst.Text == "Mixto") Turno_Id = "4";
            return Turno_Id;
        }

        private void btn_EliminarInst_Click(object sender, EventArgs e)
        {
            string Personal_Id = comboBox2.Text;
            conn.DeleteInstalacionAPersonalMedico(Personal_Id);
        }
        private void ActLVUsuarios()
        {
            Lview_Usuarios.Items.Clear();
            foreach (Personal personal in conn.GetPersonal())
            {
                ListViewItem item = new ListViewItem();
                item = Lview_Usuarios.Items.Add(personal.Personal_id);
                item.SubItems.Add(personal.Nombre);
                item.SubItems.Add(personal.Apellido);
                item.SubItems.Add(personal.Telefono);
                item.SubItems.Add(personal.Especialidad);
                item.SubItems.Add(personal.Rol);
                item.SubItems.Add(personal.Turno1);
                item.SubItems.Add(personal.Contraseña);
                if (conn.GetPersonalMedicoConInst().Exists(x => x.Personal_id == personal.Personal_id))
                {
                    string Instalacion = conn.GetPersonalMedicoConInst().Find(x => x.Personal_id == personal.Personal_id).Turno;
                    item.SubItems.Add(Instalacion);

                }
                else item.SubItems.Add("NA");
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
