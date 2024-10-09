using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteDb;

namespace Medical_Care
{
    public partial class Secretaría : Form
    {
        public SQLiteConn conn;
        public Secretaría()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            lbl_Nombre_del_Usuario.Text = Globales.Nombre;
            lbl_Turno.Text = Globales.Turno;
            conn = new SQLiteConn("Medical.db");
            cmb_Nombre_agenda.Items.Add("Folio");//inicializamos los ComboBox de los filtros de 2 lisview (Agenda de doctores e Intalaciones)
            cmb_Nombre_agenda.Items.Add("Nombre");
            cmb_Nombre_agenda.Items.Add("Especialidad");
            cmb_tipo_instalaciones.Items.Add("Tipo");
            cmb_tipo_instalaciones.Items.Add("Nombre");
            cmb_tipo_instalaciones.Items.Add("Departamento");
            Actualizar();
            cmb_paciente_pacientes.SelectedIndex = -1;
            cmb_folio_pacientes.SelectedIndex = -1;
        }
        //Boton personalizado para cerar la ventana
        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Boton personalizado para minimizar la ventana
        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Determinamos una accion al cerrar la ventanda dependiendo del usuario que haya ingresado
        private void Secretaría_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globales.Rol == "Administración")
            {
                this.Close();
            }
            else if (Globales.Rol == "Secretaría")
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
        }
        //Filtros para llenar formularios de codigo
        private void txtb_nombre_crear_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validación.SoloLetras(e);
        }
        //Filtros para llenar formularios de codigo
        private void txtb_edad_crear_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validación.SoloNumeros(e);
        }
        //Asigna Variables del timer a los labels  de fecha y hora del sistema
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToString("T");
            lbl_Fecha.Text = DateTime.Now.ToString("dd MMM yyyy");
        }
        //Inicializa el Timer
        private void Secretaría_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //Calculadora de Edad al generar o editar datos de un paciente
        public int CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }
        //Boton "Ingresar pacientes al sistema", que abre el panel respectivo para llenar los datos
        private void btn_crear_pacientes_Click(object sender, EventArgs e)
        {
            pnl_Agregar_pacientes.Visible = true;
            pnl_Agendar.Visible = false;
            btn_crear_crear.Visible = true;
            btn_guardar.Visible = false;
        }
        //Crea al paciente haciendo un INSERT en la tabla de Pacientes y crea ID y una ruta en la carpeta de instalacion para los pdf de consulta
        private void btn_crear_crear_Click(object sender, EventArgs e)
        {
            string nombre = txtb_nombre_crear.Text;
            string apellido = txtb_apellido_crear.Text;
            string dia = dateTimePicker1.Text.Substring(0, 2);
            string mes = dateTimePicker1.Text.Substring(3, 2);
            string año = dateTimePicker1.Text.Substring(6, 4);
            string edad = txtb_edad_crear.Text;
            string celular = txtb_celular_crear.Text;
            string tipo_de_sangre = txtb_tipo_de_sangre_crear.Text;
            string genero = null;
            string id = nombre.Substring(0, 3) + apellido.Substring(0, 3) + dia.Substring(0, 2) + mes.Substring(0, 2) + año.Substring(2, 2);
            if (rdb_f_crear.Checked == true) genero = "F";
            if (rbtn_M_crear.Checked == true) genero = "M";
            var Result = MessageBox.Show($"Confirmar Datos: \n Nombre: {nombre}  {apellido} \n Fecha de nacimiento: {dia}/{mes}/{año} \n Edad: {edad} \n Genero: {genero} \n Tipo de sangre: {tipo_de_sangre} \n Celular: {celular}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                //crear su carpeta
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{ txtb_nombre_crear.Text}" + " " + $"{ txtb_apellido_crear.Text}");
                conn.AgregarPaciente(id, nombre, apellido, celular, dia, mes, año, edad, genero, tipo_de_sangre);
                txtb_nombre_crear.Clear();
                txtb_apellido_crear.Clear();
                txtb_celular_crear.Clear();
                txtb_edad_crear.Clear();
                txtb_tipo_de_sangre_crear.SelectedIndex = -1;
                rbtn_M_crear.Checked = false;
                rdb_f_crear.Checked = false;

                MessageBox.Show("Usuario Agregado con exito");

                Actualizar();
            }
        }
        //Boton "Agendar Cita", que abre el panel respectivo para llenar los datos
        private void btn_agendar_pacientes_Click(object sender, EventArgs e)
        {
            comboBox3.DataSource = conn.GetPersonalMedico();
            comboBox3.ValueMember = "Personal_id";
            comboBox3.DisplayMember = "Turno";
            comboBox3.SelectedIndex = -1;
            cmb_Servicio_general.DataSource = conn.GetServicios();
            cmb_Servicio_general.ValueMember = "Servicio_id";
            cmb_Servicio_general.DisplayMember = "NombreDeServicio";
            try { cmb_Servicio_general.SelectedIndex = -1; }
            catch { }
            pnl_Agregar_pacientes.Visible = false;
            pnl_Agendar.Visible = true;
            gpb_Agenda.Visible = false;
        }
        //Actualiza el texto del nombre del paciente  y llama a la funcion que Actualiza datos a desplegar
        private void cmb_folio_pacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_paciente_pacientes.Text = Convert.ToString(cmb_folio_pacientes.SelectedValue);
            ActualizarLwPacientes();
        }
        //Actualiza el texto del folio del paciente  y llama a la funcion que Actualiza datos a desplegar
        private void cmb_paciente_pacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_folio_pacientes.Text = Convert.ToString(cmb_paciente_pacientes.SelectedValue);
            ActualizarLwPacientes();
        }
        //Actualiza el texto del nombre del personal Medico al generar cita y llama a la funcion Instalacion para colocar la instalacion asignada al PM
        private void cmb_folio_de_persoanl_generar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox4.Text = Convert.ToString(cmb_folio_de_persoanl_generar.SelectedValue);
                comboBox3.SelectedValue = comboBox4.SelectedValue;
            }
            catch { }
            Instalacion();
        }
        //Actualiza el texto del Folio del personal Medico al generar cita y llama a la funcion Instalacion para colocar la instalacion asignada al PM
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                cmb_folio_de_persoanl_generar.Text = Convert.ToString(comboBox4.SelectedValue);
                comboBox3.SelectedValue = comboBox4.SelectedValue;
            }
            catch { }
            Instalacion();
        }
        //Genera la cita e ingresa los datos a la base de datos
        private void btn_generar_generar_Click(object sender, EventArgs e)
        {
            string CitasID = null;
            string PacienteID = cmb_folio_pacientes.Text;
            string PersonalID = cmb_folio_de_persoanl_generar.Text;
            string InstalaconID = conn.GetInstalacionIdDeInstalacion(cmb_instalacion_general.Text);
            string Tipo = Convert.ToString(cmb_Servicio_general.SelectedValue);
            string Estado = "Pendiente";
            string FechaDeCita = null;
            string Turno_id = conn.GetTurnoIdDeTurno(comboBox3.Text);
            string Fila = null;
            //MessageBox.Show($"{Tipo}");
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0,10);
            Fila = conn.GetFilaDeCitas(PersonalID, FechaDeCita);
            if (conn.GetPacientesPorID().Exists(x => x.Paciente_id == PacienteID) == false)
            {
                MessageBox.Show("Error: El Folio del Paciente seleccionado no existe en el sistema, intente de nuevo.");
            }
            else if (conn.GetCitas().Exists(x => x.Fecha_de_Cita == FechaDeCita && x.Turno == Turno_id && x.Paciente == PacienteID))
            {
                MessageBox.Show("Error: El paciente ya cuenta con una cita \n agendada en el mismo turno y fecha");
            }
            else if (conn.GetCitas().Exists(x => x.Fecha_de_Cita == FechaDeCita && x.Turno == Turno_id && x.Paciente == PacienteID) == false)
            {
                if(cmb_Servicio_general.Text == "Cirugia")
                {
                    string HabitacionID = conn.GetInstalacionIdDeInstalacion(cmb_Habitación.Text);
                    if (conn.GetIngresados().Exists(x => x.Instalacion_id2 == HabitacionID))
                    {
                        MessageBox.Show("Error: La habitacion ya tiene asignado a un paciente");
                    }
                    else
                    {
                        try
                        {
                            CitasID = PersonalID.Substring(0, 3) + FechaDeCita.Substring(0, 2) + FechaDeCita.Substring(3, 2) + comboBox3.Text.Substring(0, 3) + Fila.Substring(0, 2);
                            conn.AddCita(CitasID, PacienteID, PersonalID, InstalaconID, Tipo, Estado, FechaDeCita, Turno_id, Fila);
                            conn.AddIngresado(PacienteID, PersonalID, HabitacionID);
                            MessageBox.Show("CIRUGIA AGENDADA Y HABITACION SEPARADA EXITOSAMENTE!");
                            cmb_Servicio_general.SelectedIndex = -1;
                            cmb_folio_de_persoanl_generar.SelectedIndex = -1;
                            comboBox4.SelectedIndex = -1;
                            cmb_instalacion_general.SelectedIndex = -1;
                            cmb_Habitación.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;
                            ActualizarLwPacientes();
                            listView2.Items.Clear();
                            foreach (Instalaciones instalacion in conn.GetInstalaciones())
                            {
                                ListViewItem item = new ListViewItem();
                                item = listView2.Items.Add(instalacion.Tipo);
                                item.SubItems.Add(instalacion.Nombre);
                                item.SubItems.Add(instalacion.Especialidad);
                                item.SubItems.Add("NA");
                            }
                            foreach (Instalaciones habitacion in conn.GetHabitaciones())
                            {
                                ListViewItem item = new ListViewItem();
                                item = listView2.Items.Add(habitacion.Tipo);
                                item.SubItems.Add(habitacion.Nombre);
                                item.SubItems.Add(habitacion.Especialidad);
                                if (conn.GetHabitacionesConDisponibilidad(Convert.ToString(habitacion.Instalacion_id)) == null) item.SubItems.Add("Disponible");
                                else item.SubItems.Add("Ocupada");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Asegurese de llenar las casillas correspondientes", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        
                    }
                }
                else
                {
                    if (Fila == "Error")
                    {
                        MessageBox.Show("Ya no hay espacio de citas disponibles para esta fecha");
                    }
                    else
                    {
                        CitasID = PersonalID.Substring(0, 3) + FechaDeCita.Substring(0, 2) + FechaDeCita.Substring(3, 2) + comboBox3.Text.Substring(0, 3) + Fila.Substring(0, 2);
                        conn.AddCita(CitasID, PacienteID, PersonalID, InstalaconID, Tipo, Estado, FechaDeCita, Turno_id, Fila);
                        MessageBox.Show("CITA AGENDADA EXITOSAMENTE!");
                        cmb_Servicio_general.SelectedIndex = -1;
                        cmb_folio_de_persoanl_generar.SelectedIndex = -1;
                        comboBox4.SelectedIndex = -1;
                        cmb_instalacion_general.SelectedIndex = -1;
                        cmb_Habitación.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        ActualizarLwPacientes();
                    }
                }
            }
            
        }
        //Filtro de la LV del Personal Medico para ver agendas
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int criterio1;
            Actualizar();
            if (cmb_Nombre_agenda.Text == ("Nombre"))
            {
                criterio1 = 2;
                filtrarAgenda(criterio1);
            }
            else if (cmb_Nombre_agenda.Text == "Folio")
            {
                criterio1 = 0;
                filtrarAgenda(criterio1);
            }
            else if (cmb_Nombre_agenda.Text == "Especialidad")
            {
                criterio1 = 3;
                filtrarAgenda(criterio1);
            }
        }
        //Filtro de la LV del Personal Medico para ver agendas
        private void filtrarAgenda(int criterio1)
        {
            foreach (ListViewItem item in lv_PersonalMedico.Items)
            {
                if (!item.SubItems[criterio1].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    lv_PersonalMedico.Items.Remove(item);
                }
            }
        }
        //Filtro de busqueda para el LV de las instalaciones
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int Criterio2;
            Actualizar();
            if (cmb_tipo_instalaciones.Text == ("Tipo"))
            {
                Criterio2 = 0;
                filtrarInstalacion(Criterio2);
            }
            else if (cmb_tipo_instalaciones.Text == "Nombre")
            {
                Criterio2 = 1;
                filtrarInstalacion(Criterio2);
            }
            else if (cmb_tipo_instalaciones.Text == "Departamento")
            {
                Criterio2 = 2;
                filtrarInstalacion(Criterio2);
            }
        }
        //Filtro de busqueda para el LV de las instalaciones
        private void filtrarInstalacion(int Criterio2)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                if (!item.SubItems[Criterio2].ToString().ToLower().Contains(textBox2.Text.ToLower()))
                {
                    listView2.Items.Remove(item);
                }
            }
        }
        //Despliga el panel para ver la lista del personal medico y porder acceder a sus agendas
        private void button1_Click(object sender, EventArgs e)
        {
            gpb_Istalaciones.Visible = false;
            gpb_Medicos.Visible = true;
            gpb_Agenda.Visible = false;
        }
        //Despliga el panel para ver las instalaciones 
        private void button2_Click(object sender, EventArgs e)
        {
            gpb_Istalaciones.Visible = true;
            gpb_Medicos.Visible = false;
            gpb_Agenda.Visible = false;
        }
        //Elimina la cita de la base de datos segun la cita selecionada en el LV de los pacientes
        private void btn_eliminiar_Cita_de_pacientes_Click(object sender, EventArgs e)
        {
            string personal = conn.GetPersonalId().Find(x => x.Nombre == lv_CitasDePaciente.SelectedItems[0].SubItems[2].Text).Personal_id;
            string fecha = lv_CitasDePaciente.SelectedItems[0].SubItems[3].Text;
            string fila = lv_CitasDePaciente.SelectedItems[0].SubItems[5].Text;
            conn.EliminarCita(personal , fecha, fila);
            MessageBox.Show("Cita eliminada exitosamente");
            ActualizarLwPacientes();
        }
        //Despliega el Panel para Editar los datos del paciente
        private void btn_EliminarPacienteDelSistema_Click(object sender, EventArgs e)
        {
            pnl_Agregar_pacientes.Visible = true;
            pnl_Agendar.Visible = false;
            btn_guardar.Visible = true;
            btn_crear_crear.Visible = false;
            string id = cmb_folio_pacientes.Text;
            List<Paciente> datos = conn.GetPacientes();
            foreach (Paciente c in datos)
            {
                if(c.Paciente_id == id)
                {
                    txtb_nombre_crear.Text = c.Nombre;
                    txtb_apellido_crear.Text = c.Apellido;
                    dateTimePicker1.Text = c.Fecha_Nacimiento;
                    txtb_celular_crear.Text = c.Telefono;
                    txtb_tipo_de_sangre_crear.Text = c.Tipo_Sangre;
                    txtb_edad_crear.Text = c.Edad;
                    if (c.Genero == "M") rbtn_M_crear.Checked = true;
                    if (c.Genero == "F") rdb_f_crear.Checked = true;
                }
            } 
            Globales.Paciente_id1 = cmb_folio_pacientes.Text;
            Globales.Aux = txtb_nombre_crear.Text + " " + txtb_apellido_crear.Text;
        }
        //Evento que actualiza la LV de la agenda de los doctores segun el dia selecionado
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (gpb_Agenda.Visible == true)
            {
                ActualizarListaDeCitasDeDoctor();
            }
        }
        //Boton de "Volver" que se muestra en la agenda de los doctores
        private void button3_Click(object sender, EventArgs e)
        {
            gpb_Agenda.Visible = false;
        }
        //Calculadora de edad
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string dia = dateTimePicker1.Text.Substring(0, 2);
            string mes = dateTimePicker1.Text.Substring(3, 2);
            string año = dateTimePicker1.Text.Substring(6, 4);
            DateTime cumpleaños = new DateTime(Convert.ToInt32(año), Convert.ToInt32(mes), Convert.ToInt32(dia));
            DateTime ahora = DateTime.Now;
            int edadcalulada = CalcularEdad(cumpleaños, ahora);
            txtb_edad_crear.Text = edadcalulada.ToString();
        }
        //Filtro para generar citas segun el tipo de servicio seleccionado
        private void cmb_Servicio_general_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Servicio_general.Text == "Cirugia")
            {
                ActualizarComboBoxDeDoctoresDeCitas("1");
                cmb_Habitación.Visible = true;
                txt_habitacion.Visible = true;
                try 
                { 
                    cmb_Habitación.SelectedIndex = -1;
                    cmb_folio_de_persoanl_generar.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                }
                catch { }
            }
            if (cmb_Servicio_general.Text == "Consulta")
            {
                ActualizarComboBoxDeDoctoresDeCitas("2");
                cmb_Habitación.Visible = false;
                txt_habitacion.Visible = false;
                try
                { 
                    cmb_folio_de_persoanl_generar.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                }
                catch { }
            }
            if (cmb_Servicio_general.Text == "Estudio")
            {
                ActualizarComboBoxDeDoctoresDeCitas("3");
                cmb_Habitación.Visible = false;
                txt_habitacion.Visible = false;
                try
                {
                    cmb_folio_de_persoanl_generar.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                }
                catch { }
            }
        }
        //Actualiza la LV de la agenda del doctor seleccionado
        private void ActualizarListaDeCitasDeDoctor()
        {
            listView1.Items.Clear();
            string FechaDeCita = null;
            DateTime Fecha = monthCalendar1.SelectionStart;
            FechaDeCita = Fecha.ToString().Substring(0, 10);
            foreach (Citas cita in conn.GetCitasDeDoctorPorDia(Globales.PaID, FechaDeCita))
            {
                ListViewItem item = new ListViewItem();
                item = listView1.Items.Add(cita.Paciente);
                item.SubItems.Add(cita.Tipo);
                item.SubItems.Add(cita.Personal);
                item.SubItems.Add(cita.Fila);
            }
        }
        //Actualiza el CMB de Folio y Nombre del Personal Medico de segun el tipo de Servicio que se vaya a crear en crear citas
        private void ActualizarComboBoxDeDoctoresDeCitas(string Numero)
        {
            cmb_folio_de_persoanl_generar.DataSource = null;
            comboBox4.DataSource = null;
            cmb_folio_de_persoanl_generar.DataSource = conn.GetPersonalMedicoPorServicio(Numero);
            cmb_folio_de_persoanl_generar.ValueMember = "NombreMedico";
            cmb_folio_de_persoanl_generar.DisplayMember = "Personal_id";
            comboBox4.DataSource = conn.GetPersonalMedicoPorServicio(Numero);
            comboBox4.ValueMember = "Personal_id";
            comboBox4.DisplayMember = "NombreMedico";
            cmb_Habitación.Visible = false;
            txt_habitacion.Visible = false;
        }
        //Habre el panel con la agenda del doctor que se selecciono
        private void lv_PersonalMedico_DoubleClick(object sender, EventArgs e)
        {
            Globales.PaID = lv_PersonalMedico.SelectedItems[0].SubItems[0].Text;
            gpb_Istalaciones.Visible = false;
            gpb_Agenda.Visible = true;
            gpb_Agenda.BringToFront();
            gpb_Agenda.Text = "AGENDA: " + lv_PersonalMedico.SelectedItems[0].SubItems[2].Text;
            ActualizarListaDeCitasDeDoctor();
        }
        //Actualiza la informacion del paciente en las respectivas tablas de la base de datos y actualiza la ruta de guardado del expediente de pdf
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            btn_crear_crear.Visible = true;
            btn_guardar.Visible = false;
            string nombre = txtb_nombre_crear.Text;
            string apellido = txtb_apellido_crear.Text;
            string dia = dateTimePicker1.Text.Substring(0, 2);
            string mes = dateTimePicker1.Text.Substring(3, 2);
            string año = dateTimePicker1.Text.Substring(6, 4);
            string edad = txtb_edad_crear.Text;
            string celular = txtb_celular_crear.Text;
            string tipo_de_sangre = txtb_tipo_de_sangre_crear.Text;
            string genero = null;
            string id = nombre.Substring(0, 3) + apellido.Substring(0, 3) + dia.Substring(0, 2) + mes.Substring(0, 2) + año.Substring(2, 2);
            string Viejoid = Globales.Paciente_id1;
            string ViejoNombre = Globales.Aux;
            if (rdb_f_crear.Checked == true) genero = "F";
            if (rbtn_M_crear.Checked == true) genero = "M";
            conn.ActualizarPacientes(Viejoid, id, nombre, apellido, celular, dia, mes, año, edad, genero, tipo_de_sangre);
            conn.ActualizarCitasParaElNuevoID(Viejoid, id);
            MessageBox.Show("Los datos se han actualizado exitosamente");
            Actualizar();
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{ txtb_nombre_crear.Text}" + " " + $"{ txtb_apellido_crear.Text}");
            //Actualizar ubicacion de archivos del historial del paciente
            if (System.IO.Directory.Exists(Application.StartupPath + @"\Pacientes\" + $"{ViejoNombre}"))
            {
                foreach (var file in new System.IO.DirectoryInfo(Application.StartupPath + @"\Pacientes\" + $"{ViejoNombre}").GetFiles())
                {
                    file.MoveTo(Application.StartupPath + @"\Pacientes\" + $"{ txtb_nombre_crear.Text}" + " " + $"{ txtb_apellido_crear.Text}" + @"\" + file.Name);
                }
            }
            System.IO.Directory.Delete(Application.StartupPath + @"\Pacientes\" + $"{ViejoNombre}");
        }
        //Llama a un cuadro que presenta los nombres de los programadores del proyecto
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Porgrama creado por: \n Aldo Andrade Muñoz \n Juan Carlos Cano Navarrete \n Miranda Patricia Heredia Delgado \n José Eduardo Rubio Fernández" +
                "\n David Villanueva Ojeda", "Acerca De", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Manda a llamar a la ventana de solicitudes de intendencia
        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }
        //Manda a abrir el buscador de archivos con la carpeta del manual de usuario
        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\ManualDeUsuario_MedicalCare.pdf");
        }
        //Funcion que llena los combo box de Folio y Nombre de pacientes y hace Refresh de las LisView de Instalaciones y Personal Medico
        public void Actualizar()
        {
            cmb_folio_pacientes.DataSource = null;
            cmb_paciente_pacientes.DataSource = null;
            cmb_Habitación.DataSource = conn.GetHabitaciones();
            cmb_Habitación.ValueMember = "Instalacion_id";
            cmb_Habitación.DisplayMember = "Nombre";
            cmb_Habitación.SelectedIndex = -1;
            cmb_folio_pacientes.DataSource = conn.GetPacientesPorID();
            cmb_folio_pacientes.ValueMember = "NombreCompleto";
            cmb_folio_pacientes.DisplayMember = "Paciente_id";
            cmb_paciente_pacientes.DataSource = conn.GetPacientesPorApellido();
            cmb_paciente_pacientes.ValueMember = "Paciente_id";
            cmb_paciente_pacientes.DisplayMember = "NombreCompleto";

            listView2.Items.Clear();
            foreach (Instalaciones instalacion in conn.GetInstalaciones())
            {
                ListViewItem item = new ListViewItem();
                item = listView2.Items.Add(instalacion.Tipo);
                item.SubItems.Add(instalacion.Nombre);
                item.SubItems.Add(instalacion.Especialidad);
                item.SubItems.Add("NA");
            }
            foreach (Instalaciones habitacion in conn.GetHabitaciones())
            {
                ListViewItem item = new ListViewItem();
                item = listView2.Items.Add(habitacion.Tipo);
                item.SubItems.Add(habitacion.Nombre);
                item.SubItems.Add(habitacion.Especialidad);
                if (conn.GetHabitacionesConDisponibilidad(Convert.ToString(habitacion.Instalacion_id)) == null) item.SubItems.Add("Disponible");
                else item.SubItems.Add("Ocupada");
            }

            lv_PersonalMedico.Items.Clear();
            foreach (PersonalMedicoDATA pm in conn.GetPersonalMedicoDATA())
            {
                ListViewItem item = new ListViewItem();
                item = lv_PersonalMedico.Items.Add(pm.Personal_id);
                item.SubItems.Add(pm.Roles);
                item.SubItems.Add(pm.NombreMedico);
                item.SubItems.Add(pm.Especialidad);
                item.SubItems.Add(pm.Telefono);
                item.SubItems.Add(pm.Instalacion);
                item.SubItems.Add(pm.Turno);
            }

        }
        //Actualiza la LisView del registro de citas de los pacientes y las citas de la agenda del Personal Medico
        private void ActualizarLwPacientes()
        {
            lv_CitasDePaciente.Items.Clear();
            foreach (Citas cita in conn.GetCitasDePacientes(cmb_folio_pacientes.Text))
            {
                ListViewItem item = new ListViewItem();
                item = lv_CitasDePaciente.Items.Add(cita.Tipo);
                item.SubItems.Add(cita.Instalacion);
                item.SubItems.Add(cita.Personal);
                item.SubItems.Add(cita.Fecha_de_Cita);
                item.SubItems.Add(cita.Turno);
                item.SubItems.Add(cita.Fila);
            }
            lv_PersonalMedico.Items.Clear();
            foreach (PersonalMedicoDATA pm in conn.GetPersonalMedicoDATA())
            {
                ListViewItem item = new ListViewItem();
                item = lv_PersonalMedico.Items.Add(pm.Personal_id);
                item.SubItems.Add(pm.Roles);
                item.SubItems.Add(pm.NombreMedico);
                item.SubItems.Add(pm.Especialidad);
                item.SubItems.Add(pm.Telefono);
                item.SubItems.Add(pm.Instalacion);
                item.SubItems.Add(pm.Turno);
            }
            ActualizarListaDeCitasDeDoctor();
        }
        //Asigna la instalacion en el formulario de generar cita segun el folio o el nombre del PM
        private void Instalacion()
        {
            try
            {
                cmb_instalacion_general.DataSource = conn.GetInstalacionAsignadaAlPersonalMedico(cmb_folio_de_persoanl_generar.Text); ;
                cmb_instalacion_general.ValueMember = "Personal_id";
                cmb_instalacion_general.DisplayMember = "Instalacion";
            }
            catch
            {

            }
        }
    }
}
