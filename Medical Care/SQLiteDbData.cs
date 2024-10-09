using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using SQLiteDb;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Asn1.Crmf;

namespace SQLiteDb
{
    
    public sealed class Personal
    {
        public string Personal_id { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Telefono { get; }
        public string Especialidad { get; }
        public string Rol { get; }
        public string Turno1 { get; }
        public string FullName { get => $"{Nombre} {Apellido}"; }
        public string Contraseña { get; set; }

        public Personal(string personal_id, string nombre, string apellido, string telefono, string especialidad, string rol, string turno, string contraseña)
        {
            Personal_id = personal_id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Especialidad = especialidad;
            Rol = rol;
            Turno1 = turno;
            Contraseña = contraseña;
        }
    }

    public sealed class PersonalMedico
    {
        public string Personal_id { get; }
        public string NombreMedico { get; }
        public string Especialidad_id1 { get; }
        public string Rol_Id1 { get; }
        public string Turno_id1 { get; }
        public string Turno { get; }

        public PersonalMedico(string personal_id, string nombreMedico, string especialidad_id1, string rol_Id1, string turno_id1, string turno)
        {
            Personal_id = personal_id;
            NombreMedico = nombreMedico;
            Especialidad_id1 = especialidad_id1;
            Rol_Id1 = rol_Id1;
            Turno_id1 = turno_id1;
            Turno = turno;
        }
    }
    public sealed class PersonalMedicoDATA
    {
        public string Personal_id { get; }
        public string Roles { get; }
        public string NombreMedico { get; }
        public string Especialidad { get; }
        public string Telefono { get; }
        public string Instalacion { get; }
        public string Turno { get; }

        public PersonalMedicoDATA(string personal_id, string roles, string nombreMedico, string especialidad, string telefono, string instalacion, string turno)
        {
            Personal_id = personal_id;
            Roles = roles;
            NombreMedico = nombreMedico;
            Especialidad = especialidad;
            Telefono = telefono;
            Instalacion = instalacion;
            Turno = turno;
        }
    }
    public sealed class PersonalFechaFila
    {
        public string Personal_id { get; }
        public string Feha { get; }
        public string Fila { get; }

        public PersonalFechaFila(string personal_id, string feha, string fila)
        {
            Personal_id = personal_id;
            Feha = feha;
            Fila = fila;
        }
    }

    public sealed class PersonalMedicoConInstalacion
    {
        public string Personal_id { get; }
        public string Instalacion { get; }
        public string Turno { get; }

        public PersonalMedicoConInstalacion(string personal_id, string instalacion, string turno)
        {
            Personal_id = personal_id;
            Instalacion = instalacion;
            Turno = turno;
        }
    }
    public sealed class PersInstTur
    {
        public string Personal { get; }
        public string Instalacion { get; }
        public string Turno { get; }

        public PersInstTur(string personal, string instalacion, string turno)
        {
            Personal = personal;
            Instalacion = instalacion;
            Turno = turno;
        }
    }
    public sealed class Servicios
    {
        public int Servicio_id { get; }
        public string NombreDeServicio { get; }

        public Servicios(int servicio_id, string nombreDeServicio)
        {
            Servicio_id = servicio_id;
            NombreDeServicio = nombreDeServicio;
        }
    }
    public sealed class Serv_Intendencia
    {
        public Serv_Intendencia(string servicioInt_id, string personal_id1, string instalacion_id1, string hora, string observacion)
        {
            ServicioInt_id = servicioInt_id;
            Personal_id1 = personal_id1;
            Instalacion_id1 = instalacion_id1;
            Hora = hora;
            Observacion = observacion;
        }

        public string ServicioInt_id { get; }
        public string Personal_id1 { get; }
        public string Instalacion_id1 { get; }
        public string Hora { get; }
        public string Observacion { get; }
    }
    public sealed class Paciente
    {
        public string Paciente_id { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Telefono { get; }
        public string Fecha_Nacimiento { get; }
        public string Edad { get; }
        public string Genero { get; }
        public string Tipo_Sangre { get; }
        public string Diagnostico { get; }
        public string FullName { get => $"{Apellido} {Nombre}"; }

        public Paciente(string paciente_id, string nombre, string apellido, string telefono, string fecha_Nacimiento, string edad, string genero, string tipo_Sangre, string diagnostico)
        {
            Paciente_id = paciente_id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Fecha_Nacimiento = fecha_Nacimiento;
            Edad = edad;
            Genero = genero;
            Tipo_Sangre = tipo_Sangre;
            Diagnostico = diagnostico;
        }
    }

    public sealed class PacienteID
    {
        public string NombreCompleto { get; }
        public string Paciente_id { get; }

        public PacienteID(string nombreCompleto, string paciente_id)
        {
            NombreCompleto = nombreCompleto;
            Paciente_id = paciente_id;
        }
    }

    public sealed class NombrePaciente
    {
        public string Paciente_id { get; }
        public string NombreCompleto { get; }

        public NombrePaciente(string paciente_id, string nombreCompleto)
        {
            Paciente_id = paciente_id;
            NombreCompleto = nombreCompleto;
        }
    }

    public sealed class Citas
    {
        public string Citas_id { get; }
        public string Paciente { get; }
        public string Personal { get; }
        public string Instalacion { get; }
        public string Tipo { get; }
        public string Estado { get; }
        public string Fecha_de_Cita { get; }
        public string Turno { get; }
        public string Fila { get; }

        public Citas(string citas_id, string paciente, string personal, string instalacion, string tipo, string estado, string fecha_de_Cita, string turno, string fila)
        {
            Citas_id = citas_id;
            Paciente = paciente;
            Personal = personal;
            Instalacion = instalacion;
            Tipo = tipo;
            Estado = estado;
            Fecha_de_Cita = fecha_de_Cita;
            Turno = turno;
            Fila = fila;
        }
    }

    public sealed class Instalaciones
    {
        public int Instalacion_id { get; }
        public string Nombre { get; }
        public string Especialidad { get; }
        public string Tipo { get; }

        public Instalaciones(int instalacion_id, string nombre, string especialidad, string tipo)
        {
            Instalacion_id = instalacion_id;
            Nombre = nombre;
            Especialidad = especialidad;
            Tipo = tipo;
        }
    }
    public sealed class InstalacionesConDisponibilidad
    {
        public string Disponibilidad { get; }
        public string Nombre { get; }
        public string Especialidad { get; }
        public string Tipo { get; }

        public InstalacionesConDisponibilidad(string disponibilidad, string nombre, string especialidad, string tipo)
        {
            Disponibilidad = disponibilidad;
            Nombre = nombre;
            Especialidad = especialidad;
            Tipo = tipo;
        }
    }

    public sealed class Turnos
    {
        public string Turno_id { get; }
        public string Turno { get; }

        public Turnos(string turno_id, string turno)
        {
            Turno_id = turno_id;
            Turno = turno;
        }
    }

    public sealed class Especialidades
    {
        public string Especialidad_id { get; }
        public string Especialidad { get; }

        public Especialidades(string especialidad_id, string especialidad)
        {
            Especialidad_id = especialidad_id;
            Especialidad = especialidad;
        }
    }

    public sealed class Rol
    {
        public string Rol_id { get; }
        public string Roles { get; }

        public Rol(string rol_id, string roles)
        {
            Rol_id = rol_id;
            Roles = roles;
        }
    }

    public sealed class producto
    {
        public int Medicamento_id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Qty_caja { get; set; }
        public int Price { get; set; }
        public int Qty_stock { get; set; }

        public producto(int medicamento_id, string nombre, string marca, int qty_caja, int price, int qty_stock)
        {
            Medicamento_id = medicamento_id;
            Nombre = nombre;
            Marca = marca;
            Qty_caja = qty_caja;
            Price = price;
            Qty_stock = qty_stock;
        }
    
        
        }
    public sealed class Reportes
    {
        public string Nombre { get; }
        public int Produto_id { get; }
        public string Descripcion { get; }
        public int Cantidad { get; }
        public double precio { get; }
        public double total { get; }
        public string MetodoPago { get; }
        public int Dia { get; }
        public string Mes { get; }
        public int Año { get; }
        public string Hora { get; }

        public Reportes(string nombre, int produto_id, string descripcion, int cantidad, double precio, double total, string metodoPago, int dia, string mes, int año, string hora)
        {
            Nombre = nombre;
            Produto_id = produto_id;
            Descripcion = descripcion;
            Cantidad = cantidad;
            this.precio = precio;
            this.total = total;
            MetodoPago = metodoPago;
            Dia = dia;
            Mes = mes;
            Año = año;
            Hora = hora;
        }
    }

    public sealed class PersonalIntendencia
    {
        public string Personal_id { get; }
        public string NombreMedico { get; }
        public string Rol_Id1 { get; }
        public string Turno_id1 { get; }
        public string Turno { get; }

        public PersonalIntendencia(string personal_id, string nombreMedico, string rol_Id1, string turno_id1, string turno)
        {
            Personal_id = personal_id;
            NombreMedico = nombreMedico;
            Rol_Id1 = rol_Id1;
            Turno_id1 = turno_id1;
            Turno = turno;
        }
    }
    public sealed class ServiciosInt
    {
        public string ServicioInt_id { get; }
        public string Personal_id1 { get; }
        public string Instalacion_id1 { get; }
        public string Hora { get; }
        public string Observacion { get; }

        public ServiciosInt(string servicioint_id, string personal_id1, string instalacion_id1, string hora, string observacion)
        {
            ServicioInt_id = servicioint_id;
            Personal_id1 = personal_id1;
            Instalacion_id1 = instalacion_id1;
            Hora = hora;
            Observacion = observacion;
        }
    }

    public sealed class PxIngresado
    {
        public string Paciente_id1 { get; }
        public string Personal_id1 { get; }
        public string Instalacion_id2 { get; }
        public string Receta_id { get; }
        public string Estado { get; }

        public PxIngresado(string paciente_id1, string personal_id1, string instalacion_id2, string receta_id, string estado)
        {
            Paciente_id1 = paciente_id1;
            Personal_id1 = personal_id1;
            Instalacion_id2 = instalacion_id2;
            Receta_id = receta_id;
            Estado = estado;
        }
    }
    public partial class SQLiteConn
    {
        public int Login(string user, string pass)
        {
            //Busca el user y el pass en la base de datos, dependiendo de la respuesta regresa un entero
            //que se resuelve con un switch, requiere abrir y cerrar la conexión para su uso
            if (pass == "" || user == "")
            {
                return 0;
            }
            else
            {
                string val = null;
                //string actividad = null;
                string query = ($"SELECT Roles FROM Personal INNER JOIN Rol ON Rol.Rol_id = Personal.Rol_Id1 WHERE Personal_id = '{user}' AND Contraseña = '{pass}'");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                int num = 0;
                if (dr.Read())
                {
                    val = (dr["Roles"].ToString());
                    if (val == "Secretaría") num = 1;
                    else if (val == "Enfermería") num = 2;
                    else if (val == "Intendencia") num = 3;
                    else if (val == "Vendedores") num = 4;
                    else if (val == "Doctor") num = 5;
                    else if (val == "Ingresados") num = 6;
                    else if (val == "Administrador") num = 7;
                    dr.Close();
                    conn.Close();
                    return num;

                }
                else
                {
                    conn.Close();
                    return 8;
                }
                //conn.Close();
            }
        }

        public int LoginPacientes(string user)
        {
            //Busca el user y el pass en la base de datos, dependiendo de la respuesta regresa un entero
            //que se resuelve con un switch, requiere abrir y cerrar la conexión para su uso
            if (user == "")
            {
                return 0;
            }
            else
            {
                //string val = null;
                //string actividad = null;
                string query = ($"SELECT Paciente_id FROM Pacientes WHERE Paciente_id = '{user}'");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    conn.Close();
                    return 1;
                }
                else
                {
                    dr.Close();
                    conn.Close();
                    return 8;
                }
                //conn.Close();
            }
        }

        // Almacenar en listas datos de la BD
        public List<Personal> GetPersonal()
        {
            List<Personal> personalbd = new List<Personal>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Personal_id, Nombre, Apellido, Telefono, Especialidad, Roles, Turno, Contraseña FROM Personal INNER JOIN Rol ON Rol.Rol_id = Personal.Rol_Id1 INNER JOIN Turnos on Turnos.Turno_id = personal.Turno_id1 INNER JOIN Especialidades ON Especialidades.Especialidad_id = Personal.Especialidad_id1");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new Personal(pr.GetString("Personal_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Apellido"),
                        pr.GetString("Telefono"),
                        pr.GetString("Especialidad"),
                        pr.GetString("Roles"),
                        pr.GetString("Turno"),
                        pr.GetString("Contraseña")));
                }
            }
            conn.Close();

            return personalbd;
        }
        public List<PersonalMedico> GetPersonalMedicoConInst()
        {
            List<PersonalMedico> personalbd = new List<PersonalMedico>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT p.Personal_id, p.Nombre||' '||p.Apellido AS NombreMedico, p.Especialidad_id1, p.Rol_Id1, p.Turno_id1, i.Nombre "
                                    + "FROM Personal p "
                                    + "INNER JOIN PersonalMedico pm ON pm.Personal_id1 = p.Personal_id "
                                    + "INNER JOIN Instalaciones i ON i.Instalacion_id = pm.Instalacion_id1; ");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new PersonalMedico(pr.GetString("Personal_id"),
                        pr.GetString("NombreMedico"),
                        pr.GetString("Especialidad_id1"),
                        pr.GetString("Rol_Id1"),
                        pr.GetString("Turno_id1"),
                        pr.GetString("Nombre")));
                }
            }
            pr.Close();
            conn.Close();

            return personalbd;
        }
        public List<Personal> GetPersonalId()
        {
            List<Personal> personalbd = new List<Personal>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Personal_id, Nombre||' '||Apellido AS Nombre, Apellido, Telefono, Especialidad, Roles, Turno, Contraseña FROM Personal INNER JOIN Rol ON Rol.Rol_id = Personal.Rol_Id1 INNER JOIN Turnos on Turnos.Turno_id = personal.Turno_id1 INNER JOIN Especialidades ON Especialidades.Especialidad_id = Personal.Especialidad_id1");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new Personal(pr.GetString("Personal_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Apellido"),
                        pr.GetString("Telefono"),
                        pr.GetString("Especialidad"),
                        pr.GetString("Roles"),
                        pr.GetString("Turno"),
                        pr.GetString("Contraseña")));
                }
            }
            conn.Close();

            return personalbd;
        }

        public List<PxIngresado> GetIngresadosPorDr(string NombreCompletoDelDoctor)
        {
            List<PxIngresado> ing = new List<PxIngresado>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT pa.Nombre || ' ' || pa.Apellido AS NCP, i.Personal_id1, ins.Nombre AS Instalacion, i.Receta_id, i.Estado "
                                               + "FROM Ingresados i "
                                               + "INNER JOIN Pacientes pa ON pa.Paciente_id = i.Paciente_id1 "
                                               + "INNER JOIN Instalaciones ins ON ins.Instalacion_id = i.Instalacion_id2 " 
                                               + "INNER JOIN Personal p ON p.Personal_id = i.Personal_id1 "
                                               + $"WHERE p.Nombre|| ' ' ||p.Apellido = '{NombreCompletoDelDoctor}'");
            {
                while (pr.NextRecord())
                {
                    ing.Add(new PxIngresado(pr.GetString("NCP"),
                        pr.GetString("Personal_id1"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Receta_id"),
                        pr.GetString("Estado")));
                }
            }
            pr.Close();
            conn.Close();
            return ing;
        }
        public List<PxIngresado> GetIngresadosPorPaciente(string NombreCompletoDelPaciente)
        {
            List<PxIngresado> ing = new List<PxIngresado>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT pa.Nombre || ' ' || pa.Apellido AS NCP, i.Paciente_id1, ins.Nombre AS Instalacion, i.Receta_id, i.Estado "
                                               + "FROM Ingresados i "
                                               + "INNER JOIN Pacientes pa ON pa.Paciente_id = i.Paciente_id1 "
                                               + "INNER JOIN Instalaciones ins ON ins.Instalacion_id = i.Instalacion_id2 "
                                               + "INNER JOIN Personal p ON p.Personal_id = i.Personal_id1 "
                                               + $"WHERE pa.Nombre||' '||pa.Apellido = '{NombreCompletoDelPaciente}'");
            {
                while (pr.NextRecord())
                {
                    ing.Add(new PxIngresado(pr.GetString("NCP"),
                        pr.GetString("Paciente_id1"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Receta_id"),
                        pr.GetString("Estado")));
                }
            }
            pr.Close();
            conn.Close();
            return ing;
        }
        public List<PxIngresado> GetIngresados()
        {
            List<PxIngresado> ing = new List<PxIngresado>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT pa.Nombre || ' ' || pa.Apellido AS NCP, i.Personal_id1, i.Instalacion_id2 AS Instalacion, i.Receta_id, i.Estado "
                                               + "FROM Ingresados i "
                                               + "INNER JOIN Pacientes pa ON pa.Paciente_id = i.Paciente_id1 "
                                               + "INNER JOIN Personal p ON p.Personal_id = i.Personal_id1;");
            {
                while (pr.NextRecord())
                {
                    ing.Add(new PxIngresado(pr.GetString("NCP"),
                        pr.GetString("Personal_id1"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Receta_id"),
                        pr.GetString("Estado")));
                }
            }
            pr.Close();
            conn.Close();
            return ing;
        }
        public void ActualizarPacientes(string id_viejo, string id, string nombre, string apellido, string celular, string dia, string mes, string año, string edad, string genero, string tipo_de_sangre)
        {
            conn.Open();
            string query = $"UPDATE Pacientes SET Paciente_id = '{id}', Nombre = '{nombre}', Apellido = '{apellido}', " +
                $"Telefono = '{celular}', Fecha_nacimiento = '{dia}/{mes}/{año}', Genero = '{genero}', " +
                $"Tipo_sangre = '{tipo_de_sangre}' " +
                $"WHERE Paciente_id = '{id_viejo}';";
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            upd.ExecuteNonQuery();
            conn.Close();
        }
        
        public void ActualizarCitasParaElNuevoID (string id_viejo, string id)
        {
            conn.Open();
            string query = $"UPDATE Citas SET Paciente_id1 = '{id}' " +
                    $"WHERE Paciente_id1 = '{id_viejo}';";
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            upd.ExecuteNonQuery();
            conn.Close();
        }
        public List<PersInstTur> GetPersonalInstalacionTurno()
        {
            List<PersInstTur> personalbd = new List<PersInstTur>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT * FROM PersonalMedico;");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new PersInstTur(pr.GetString("Personal_id1"),
                        Convert.ToString(pr.GetInt32("Instalacion_id1")),
                        pr.GetString("Turno_id1")));
                }
            }
            pr.Close();
            conn.Close();
            return personalbd;
        }

        public List<Citas> GetCitasDePacientes(string PacienteID)
        {
            List<Citas> citasbd = new List<Citas>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT c.Citas_id, c.Paciente_id1, p.Nombre || ' ' || p.Apellido AS NombreCompletoDeMedico, "
                                    + "i.Nombre AS Instalacion, t.descripcion AS TipoDeServicio, c.Estado, c.Fecha_de_Cita, t2.Turno, c.Fila AS NoFila "
                                    + "FROM Citas c "
                                    + "INNER JOIN Personal p ON p.Personal_id = c.Personal_id1 "
                                    + "INNER JOIN Instalaciones i ON i.Instalacion_id = c.Instalacion_id2 "
                                    + "INNER JOIN Tipo_cons t ON t.Tipo_id = c.Tipo "
                                    + "INNER JOIN Turnos t2 ON t2.Turno_id = c.Turno_id1 "
                                    + $"WHERE c.Paciente_id1 = '{PacienteID}';");
            {
                while (pr.NextRecord())
                {
                    citasbd.Add(new Citas(pr.GetString("Citas_id"),
                        pr.GetString("Paciente_id1"),
                        pr.GetString("NombreCompletoDeMedico"),
                        pr.GetString("Instalacion"),
                        pr.GetString("TipoDeServicio"),
                        pr.GetString("Estado"),
                        pr.GetString("Fecha_de_Cita"),
                        pr.GetString("Turno"),
                        pr.GetString("NoFila")));
                }
            }
            pr.Close();
            conn.Close();

            return citasbd;
        }

        public List<Citas> GetCitas()
        {
            List<Citas> citasbd = new List<Citas>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT * FROM Citas ");
            {
                while (pr.NextRecord())
                {
                    citasbd.Add(new Citas(pr.GetString("Citas_id"),
                        pr.GetString("Paciente_id1"),
                        pr.GetString("Personal_id1"),
                        Convert.ToString(pr.GetInt32("Instalacion_id2")),
                        pr.GetString("Tipo"),
                        pr.GetString("Estado"),
                        pr.GetString("Fecha_de_Cita"),
                        pr.GetString("Turno_id1"),
                        pr.GetString("Fila")));
                }
            }
            pr.Close();
            conn.Close();

            return citasbd;
        }
        public string GetEstadoDeLaCita(string PacienteID, string FechaDeCita)
        {
            string estado = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Estado FROM Citas WHERE Paciente_id1 = '{PacienteID}' AND Fecha_de_Cita = '{FechaDeCita}';", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                estado = rd["Estado"].ToString();
            }
            rd.Close();
            conn.Close();

            return estado;
        }

        public void ActualizarEstado(string EstadoTexto, string CITASID)
        {
            if (conn.State != ConnectionState.Closed) conn.Close();
            conn.Open();
            string query = $"UPDATE Citas SET Estado = '{EstadoTexto}' WHERE Citas_id = '{CITASID}'";
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            upd.ExecuteNonQuery();
            conn.Close();
        }
        public void ActualizarDiagnosticoDePaciente(string NoDiag, string NombreCompletoDePaciente)
        {
            if (conn.State != ConnectionState.Closed) conn.Close();
            conn.Open();
            string query = $"UPDATE Pacientes SET Diagnosticos = '{NoDiag}' WHERE Nombre||' '||Apellido = '{NombreCompletoDePaciente}'";
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            upd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Citas> GetCitasDeDoctorPorDia(string Personal_id, string FechaDeCita)
        {
            List<Citas> citasbd = new List<Citas>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT c.Citas_id, c.Paciente_id1, pa.Nombre || ' ' || pa.Apellido AS NombreDePaciente, "
                                    + "i.Nombre AS Instalacion, t.descripcion AS TipoDeServicio, c.Estado, c.Fecha_de_Cita, t2.Turno, c.Fila AS NoFila "
                                    + "FROM Citas c "
                                    + "INNER JOIN Pacientes pa ON pa.Paciente_id = c.Paciente_id1 "
                                    + "INNER JOIN Instalaciones i ON i.Instalacion_id = c.Instalacion_id2 "
                                    + "INNER JOIN Tipo_cons t ON t.Tipo_id = c.Tipo "
                                    + "INNER JOIN Turnos t2 ON t2.Turno_id = c.Turno_id1 "
                                    + $"WHERE c.Personal_id1 = '{Personal_id}' AND c.Fecha_de_Cita = '{FechaDeCita}';");
            {
                while (pr.NextRecord())
                {
                    citasbd.Add(new Citas(pr.GetString("Citas_id"),
                        pr.GetString("Paciente_id1"),
                        pr.GetString("NombreDePaciente"),
                        pr.GetString("Instalacion"),
                        pr.GetString("TipoDeServicio"),
                        pr.GetString("Estado"),
                        pr.GetString("Fecha_de_Cita"),
                        pr.GetString("Turno"),
                        pr.GetString("NoFila")));
                }
            }
            pr.Close();
            conn.Close();
            return citasbd;
        }

        public List<PersonalMedico> GetPersonalMedico()
        {
            List<PersonalMedico> personalbd = new List<PersonalMedico>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Personal_id, Nombre||' '||Apellido AS NombreMedico, Especialidad_id1, Rol_Id1, Turno_id1, Turno "
                                            + "FROM Personal "
                                            +"INNER JOIN Turnos ON Turnos.Turno_id = personal.Turno_id1 "
                                            +"WHERE Rol_Id1 = '2' OR Rol_Id1 = '5'; ");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new PersonalMedico(pr.GetString("Personal_id"),
                        pr.GetString("NombreMedico"),
                        pr.GetString("Especialidad_id1"),
                        pr.GetString("Rol_Id1"),
                        pr.GetString("Turno_id1"),
                        pr.GetString("Turno")));
                }
            }
            conn.Close();

            return personalbd;
        }
        public List<PersonalMedico> GetPersonalMedicoPorServicio(string FiltroInstalacion)
        {
            List<PersonalMedico> personalbd = new List<PersonalMedico>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT p.Personal_id1, pe.Nombre||' '||pe.Apellido AS NombreMedico, pe.Especialidad_id1, pe.Rol_Id1, pe.Turno_id1, t.Turno  "
                                        + "FROM PersonalMedico p "
                                        + "INNER JOIN Personal pe ON pe.Personal_id = p.Personal_id1 "
                                        + "INNER JOIN Turnos t ON t.Turno_id = pe.Turno_id1 "
                                        + "INNER JOIN Instalaciones i ON i.Instalacion_id = p.Instalacion_id1 "
                                        + $"WHERE i.Tipo_id1 = '{FiltroInstalacion}';");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new PersonalMedico(pr.GetString("Personal_id1"),
                        pr.GetString("NombreMedico"),
                        pr.GetString("Especialidad_id1"),
                        pr.GetString("Rol_Id1"),
                        pr.GetString("Turno_id1"),
                        pr.GetString("Turno")));
                }
            }
            pr.Close();
            conn.Close();
            return personalbd;
        }

        public List<PersonalMedicoDATA> GetPersonalMedicoDATA()
        {
            List<PersonalMedicoDATA> personalbd = new List<PersonalMedicoDATA>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT pm.Personal_id1, r.Roles, p.Nombre||' '||p.Apellido AS NombreMedico, e.Especialidad, p.Telefono, i.Nombre AS Instalacion, t.Turno "
                                            + "FROM PersonalMedico pm "
                                            + "INNER JOIN Personal p ON p.Personal_id = pm.Personal_id1 "
                                            + "INNER JOIN Rol r ON r.Rol_id = p.Rol_Id1 "
                                            + "INNER JOIN Especialidades e ON e.Especialidad_id = p.Especialidad_id1 "
                                            + "INNER JOIN Instalaciones i ON i.Instalacion_id = pm.Instalacion_id1 "
                                            + "INNER JOIN Turnos t ON t.Turno_id = pm.Turno_id1 "
                                            + "ORDER BY pm.Personal_id1;");
            {
                while (pr.NextRecord())
                {
                    personalbd.Add(new PersonalMedicoDATA(pr.GetString("Personal_id1"),
                        pr.GetString("Roles"),
                        pr.GetString("NombreMedico"),
                        pr.GetString("Especialidad"),
                        pr.GetString("Telefono"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Turno"))); ;
                }
            }
            pr.Close();
            conn.Close();
            return personalbd;
        }
        public List<PacienteID> GetPacientesPorID()
        {
            List<PacienteID> pacientebd = new List<PacienteID>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Paciente_id, Apellido||' '||Nombre AS NombreCompleto "
                + "FROM Pacientes ORDER BY Paciente_id;");
            {
                while (pr.NextRecord())
                {
                    pacientebd.Add(new PacienteID(pr.GetString("NombreCompleto"),
                        pr.GetString("Paciente_id")));
                }
            }
            pr.Close();
            conn.Close();
            return pacientebd;
        }
        public List<PacienteID> GetPacienteID()
        {
            List<PacienteID> pacientebd = new List<PacienteID>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Paciente_id, Nombre||' '||Apellido AS NombreCompleto "
                + "FROM Pacientes ORDER BY Paciente_id;");
            {
                while (pr.NextRecord())
                {
                    pacientebd.Add(new PacienteID(pr.GetString("NombreCompleto"),
                        pr.GetString("Paciente_id")));
                }
            }
            pr.Close();
            conn.Close();
            return pacientebd;
        }
        public List<PacienteID> GetPacienteTipoDeSangre()
        {
            List<PacienteID> pacientebd = new List<PacienteID>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Tipo_sangre, Nombre||' '||Apellido AS NombreCompleto "
                + "FROM Pacientes");
            {
                while (pr.NextRecord())
                {
                    pacientebd.Add(new PacienteID(pr.GetString("NombreCompleto"),
                        pr.GetString("Tipo_sangre")));
                }
            }
            pr.Close();
            conn.Close();
            return pacientebd;
        }
        public List<PacienteID> GetPacienteEdad()
        {
            List<PacienteID> pacientebd = new List<PacienteID>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Edad, Nombre||' '||Apellido AS NombreCompleto "
                + "FROM Pacientes;");
            {
                while (pr.NextRecord())
                {
                    pacientebd.Add(new PacienteID(pr.GetString("NombreCompleto"),
                        Convert.ToString(pr.GetInt32("Edad"))));
                }
            }
            pr.Close();
            conn.Close();
            return pacientebd;
        }

        public List<PersonalMedicoConInstalacion> GetInstalacionAsignadaAlPersonalMedico(string PersonalID)
        {
            List<PersonalMedicoConInstalacion> Intalacionbd = new List<PersonalMedicoConInstalacion>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Personal_id1, Nombre AS Instalacion, Turno "
                                        + "FROM PersonalMedico p "
                                        + "INNER JOIN Instalaciones i ON i.Instalacion_id = p.Instalacion_id1 "
                                        + "INNER JOIN Turnos t ON t.Turno_id = p.Turno_id1 "
                                        +$"WHERE Personal_id1 = '{PersonalID}';");
            {
                while (pr.NextRecord())
                {
                    Intalacionbd.Add(new PersonalMedicoConInstalacion(pr.GetString("Personal_id1"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Turno")));
                }
            }
            pr.Close();
            conn.Close();
            return Intalacionbd;
        }
        public List<NombrePaciente> GetPacientesPorApellido()
        {
            List<NombrePaciente> pacientebd = new List<NombrePaciente>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT Paciente_id, Apellido||' '||Nombre AS NombreCompleto "
                + "FROM Pacientes ORDER BY Apellido;");
            {
                while (pr.NextRecord())
                {
                    pacientebd.Add(new NombrePaciente(pr.GetString("Paciente_id"),
                        pr.GetString("NombreCompleto")));
                }
            }
            pr.Close();
            conn.Close();
            return pacientebd;
        }

        public List<Paciente> GetPacientes()
        {
            List<Paciente> citas_pacientesbd = new List<Paciente>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT * FROM Pacientes;");
            {
                while (pr.NextRecord())
                {
                    citas_pacientesbd.Add(new Paciente(pr.GetString("Paciente_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Apellido"),
                        pr.GetString("Telefono"),
                        pr.GetString("Fecha_nacimiento"),
                        Convert.ToString(pr.GetInt32("Edad")),
                        pr.GetString("Genero"),
                        pr.GetString("Tipo_sangre"),
                        pr.GetString("Diagnosticos")));
                }
            }
            pr.Close();
            conn.Close();
            return citas_pacientesbd;
        }

        public List<Instalaciones> GetInstalaciones()
        {
            List<Instalaciones> instalacionesbd = new List<Instalaciones>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Instalacion_id, Nombre, Especialidad, Tipo "
                                + "FROM Instalaciones i "
                                + "INNER JOIN Especialidades e ON i.Especialidad_id1 = e.Especialidad_id "
                                + "INNER JOIN Tipo_instalacion t ON i.Tipo_id1 = t.Tipo_id "
                                + "WHERE i.Tipo_id1 != 4;");
            {
                while (pr.NextRecord())
                {
                    instalacionesbd.Add(new Instalaciones(pr.GetInt32("Instalacion_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Especialidad"),
                        pr.GetString("Tipo")));
                }
            }
            pr.Close();
            conn.Close();
            return instalacionesbd;
        }
        public List<Instalaciones> GetHabitaciones()
        {
            List<Instalaciones> instalacionesbd = new List<Instalaciones>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Instalacion_id, Nombre, Especialidad, Tipo "
                                + "FROM Instalaciones i "
                                + "INNER JOIN Especialidades e ON i.Especialidad_id1 = e.Especialidad_id "
                                + "INNER JOIN Tipo_instalacion t ON i.Tipo_id1 = t.Tipo_id "
                                + "WHERE i.Tipo_id1 = 4;");
            {
                while (pr.NextRecord())
                {
                    instalacionesbd.Add(new Instalaciones(pr.GetInt32("Instalacion_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Especialidad"),
                        pr.GetString("Tipo")));
                }
            }
            pr.Close();
            conn.Close();
            return instalacionesbd;
        }
        public string GetHabitacionesConDisponibilidad(string InstalacionID)
        {
            string InsID = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Instalacion_id2 FROM Ingresados WHERE Instalacion_id2 = '{InstalacionID}';", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                InsID = rd["Instalacion_id2"].ToString();
            }
            rd.Close();
            conn.Close();
            return InsID;
        }

        public List<Turnos> GetTurnos()
        {
            List<Turnos> turnosbd = new List<Turnos>();
            conn.Open();
            SQLiteRecordSet hb = ExecuteQuery("SELECT * FROM Turnos");
            {
                while (hb.NextRecord())
                {
                    turnosbd.Add(new Turnos(hb.GetString("Turno_id"),
                        hb.GetString("Turno")));
                }
            }
            conn.Close();
            return turnosbd;
        }

        public List<PersonalIntendencia> GetPersonalIntendencia()
        {
            List<PersonalIntendencia> personalInt = new List<PersonalIntendencia>();

            conn.Open();

            SQLiteRecordSet pr = ExecuteQuery("SELECT Personal_id, Nombre||' '||Apellido AS NombreInt, Rol_Id1, Turno_id1, Turno "
                                            + "FROM Personal "
                                            + "INNER JOIN Turnos ON Turnos.Turno_id = personal.Turno_id1 "
                                            + "WHERE Rol_Id1 = '6'; ");
            {
                while (pr.NextRecord())
                {
                    personalInt.Add(new PersonalIntendencia(pr.GetString("Personal_id"),
                        pr.GetString("NombreInt"),
                        pr.GetString("Rol_Id1"),
                        pr.GetString("Turno_id1"),
                        pr.GetString("Turno")));
                }
            }
            pr.Close();
            conn.Close();

            return personalInt;
        }

        public List<ServiciosInt> GetServiciosInt()
        {
            List<ServiciosInt> serviciosint = new List<ServiciosInt>();
            conn.Open();
            SQLiteRecordSet hb = ExecuteQuery("SELECT * FROM Servicios_Int");
            {
                while (hb.NextRecord())
                {
                    serviciosint.Add(new ServiciosInt(hb.GetString("ServicioInt_id"),
                        hb.GetString("Personal_id1"),
                        hb.GetString("Instalacion_id1"),
                        hb.GetString("Hora"),
                        hb.GetString("Observacion")));
                }
            }
            conn.Close();
            return serviciosint;
        }

        public void AgregarServiciosInt(string servicioInt_id, string personal_id1, string instalacion_id1, string hora, string observacion)
        {

            conn.Open();
            string query = "INSERT INTO Servicios_Int (ServicioInt_id, Personal_id1,Instalacion_id1, Hora, Observacion) "
                            + $"VALUES ('{servicioInt_id}','{personal_id1}','{instalacion_id1}','{hora}','{observacion}');";
            SQLiteCommand add = new SQLiteCommand(query, conn);
            add.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteServ_Intendencia(string serv_intendencia_id)
        {
            string query = $"DELETE FROM Servicios_Int WHERE ServicioInt_id = '{serv_intendencia_id}';";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public List<Serv_Intendencia> GetIntendencia()
        {
            List<Serv_Intendencia> intendenciabd = new List<Serv_Intendencia>();
            conn.Open();
            SQLiteRecordSet pr = ExecuteQuery("SELECT s.ServicioInt_id, s.Personal_id1, i.Nombre AS Instalacion, s.Hora, s.Observacion "
                + "FROM Servicios_Int s "
                + "INNER JOIN Instalaciones i ON i.Instalacion_id = s.Instalacion_id1 ");
            {
                while (pr.NextRecord())
                {
                    intendenciabd.Add(new Serv_Intendencia(pr.GetString("ServicioInt_id"),
                        pr.GetString("Personal_id1"),
                        pr.GetString("Instalacion"),
                        pr.GetString("Hora"),
                        pr.GetString("Observacion")));
                }
            }
            pr.Close();
            conn.Close();

            return intendenciabd;
        }
        
        public string GetInstalacionIdDeInstalacion(string Instalacion)
        {
            string InstalacionID = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Instalacion_id FROM Instalaciones WHERE Nombre = '{Instalacion}';", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                InstalacionID = rd["Instalacion_id"].ToString();
            }
            rd.Close();
            conn.Close();
            return InstalacionID;
        }
        
        public string GetTurnoIdDeTurno(string Turno)
        {
            string TurnoID = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Turno_id FROM Turnos WHERE Turno = '{Turno}';", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                TurnoID = rd["Turno_id"].ToString();
            }
            rd.Close();
            conn.Close();
            return TurnoID;
        }
        public string GetDiagnostico(string NombreCompletoDePaciente)
        {
            string BinarioDiagnostico = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Diagnosticos FROM Pacientes WHERE Nombre||' '||Apellido = '{NombreCompletoDePaciente}';", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                BinarioDiagnostico = rd["Diagnosticos"].ToString();
            }
            rd.Close();
            conn.Close();
            return BinarioDiagnostico;
        }
        public string GetFilaDeCitas(string Personal_id, string Fecha)
        {
            string NoFila = null;
            int NumeroAUX = 1;
            List<PersonalFechaFila> ContadorDeCitas = new List<PersonalFechaFila>();
            conn.Open();
            SQLiteRecordSet rbd = ExecuteQuery($"SELECT Personal_id1, Fecha_de_Cita, Fila FROM Citas WHERE Personal_id1 = '{Personal_id}' AND Fecha_de_Cita = '{Fecha}';");
            {
                while (rbd.NextRecord())
                {
                    ContadorDeCitas.Add(new PersonalFechaFila(rbd.GetString("Personal_id1"),
                        rbd.GetString("Fecha_de_Cita"),
                        rbd.GetString("Fila")));
                }
            }
            rbd.Close();
            conn.Close();
            for (int i = 0; i < ContadorDeCitas.Count; i++)
            {
                NumeroAUX++;
                if (i == 9) return NoFila = "Error";
            }
            //if (NumeroAUX == 1) NumeroAUX = 1;
            if (NumeroAUX < 10)NoFila = 0+Convert.ToString(NumeroAUX);
            else NoFila = Convert.ToString(NumeroAUX);
            return NoFila;
        }
        public List<Rol> GetRoles()
        {
            List<Rol> Rolesbd = new List<Rol>();
            conn.Open();
            SQLiteRecordSet rbd = ExecuteQuery("SELECT * FROM Rol");
            {
                while (rbd.NextRecord())
                {
                    Rolesbd.Add(new Rol(rbd.GetString("Rol_id"),
                        rbd.GetString("Roles")));
                }
            }
            conn.Close();
            return Rolesbd;
        }


        public List<Especialidades> GetEspecialidades()
        {
            List<Especialidades> especialidadesbd = new List<Especialidades>();
            conn.Open();
            SQLiteRecordSet ebd = ExecuteQuery("SELECT * FROM Especialidades");
            {
                while (ebd.NextRecord())
                {
                    especialidadesbd.Add(new Especialidades(ebd.GetString("Especialidad_id"),
                        ebd.GetString("Especialidad")));
                }
            }
            conn.Close();
            return especialidadesbd;
        }



        //Termina sección de listas


        //Enviar Querys a la DB
        public string NombreDoc(string user)
        {
            string nombre = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Personal Where Personal_id = '{user}'", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                nombre = rd["Nombre"].ToString() + " " + rd["Apellido"].ToString();
            }
            rd.Close();
            conn.Close();
            return nombre;
        }

        public string NombrePac(string user)
        {
            string nombre = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Pacientes Where Paciente_id = '{user}'", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                nombre = rd["Nombre"].ToString() + " " + rd["Apellido"].ToString();
            }
            rd.Close();
            conn.Close();
            return nombre;
        }

        public string HabitacionPac(string user)
        {
            string habitacion = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Ingresados p INNER JOIN Instalaciones e ON p.Instalacion_id2 = e.Instalacion_id Where Paciente_id1 = '{user}'", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                habitacion = rd["Nombre"].ToString();
            }
            rd.Close();
            conn.Close();
            return habitacion;
        }

        public string Departamento(string user)
        {
            string departamento = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Personal p INNER JOIN Especialidades e ON p.Especialidad_id1 = e.Especialidad_id WHERE Personal_id = '{user}'", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                departamento = rd["Especialidad"].ToString();
            }
            rd.Close();
            conn.Close();

            return departamento;
        }

        public string Turno(string user)
        {
            string turno = null;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Personal p INNER JOIN Turnos e ON p.turno_id1 = e.Turno_id WHERE Personal_id = '{user}'", conn);
            SQLiteDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                turno = rd["Turno"].ToString();
            }
            rd.Close();
            conn.Close();

            return turno;
        }

         public string Rol(string user)
         {
             string rol = null;
             conn.Open();
             SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Personal p INNER JOIN Rol e ON p.rol_id1 = e.Rol_Id WHERE Personal_id = '{user}'", conn);
             SQLiteDataReader rd = cmd.ExecuteReader();
             if (rd.Read())
             {
                 rol = rd["Roles"].ToString();
             }
             conn.Close();
        
             return rol;
         }

        public void AddInstalacionAPersonalMedico(string Instalacion_id, string Personal_id, string Turno_id)
        {
            conn.Open();
            string query = "INSERT INTO PersonalMedico (Personal_id1, Instalacion_id1, Turno_id1) "
                            + $"VALUES ('{Personal_id}','{Instalacion_id}','{Turno_id}');";
            SQLiteCommand add = new SQLiteCommand(query, conn);
            add.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateInstalacionAPersonalMedico(string Instalacion_id, string Personal_id, string Turno_id)
        {
            if (conn.State != ConnectionState.Closed) conn.Close();
            conn.Open();
            string query = "UPDATE PersonalMedico "
                         + $"SET Instalacion_id1 = '{Instalacion_id}' WHERE Personal_id1 = '{Personal_id}' AND Turno_id1 = '{Turno_id}';";
            SQLiteCommand update = new SQLiteCommand(query, conn);
            update.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteInstalacionAPersonalMedico(string Personal_id)
        {
            string query = $"DELETE FROM PersonalMedico WHERE Personal_id1 = '{Personal_id}'";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        
        public void DeletePacienteIngresado(string Habitacion)
        {
            string query = $"DELETE FROM Ingresados WHERE Instalacion_id2 = '{Habitacion}';";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void AddCita(string Citas_id, string Paciente_id, string Personal_id, string Instalacion_id, string Tipo, string Estado, string Fecha_de_Cita, string Turn_id, string Fila)
        {
            if(conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn.Open();
            string query = "INSERT INTO Citas (Citas_id, Paciente_id1, Personal_id1, Instalacion_id2, Tipo, Estado, Fecha_de_Cita, Turno_id1, Fila) "
                            + $"VALUES ('{Citas_id}','{Paciente_id}','{Personal_id}','{Instalacion_id}','{Tipo}','{Estado}','{Fecha_de_Cita}','{Turn_id}','{Fila}');";
            SQLiteCommand add = new SQLiteCommand(query, conn);
            add.ExecuteNonQuery();
            conn.Close();
        }
        public void AddIngresado(string PacienteID, string PersonalID, string InstalaconID)
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn.Open();
            string query = "INSERT INTO Ingresados (Paciente_id1, Personal_id1, Instalacion_id2, Receta_id, Estado) "
                        + $"VALUES ('{PacienteID}','{PersonalID}','{InstalaconID}','','Pendiente');";
            SQLiteCommand add = new SQLiteCommand(query, conn);
            add.ExecuteNonQuery();
            conn.Close();
        }
        public int AgregarPersonal(string id, string nombre, string apellido, string telefono, string especialidad, string rol, string turno, string contraseña)
        {
            int result = -1;
            string query = $"INSERT INTO Personal VALUES ('{id}', '{nombre}', '{apellido}', '{telefono}', '{especialidad}', '{rol}', '{turno}', '{contraseña}')";
            conn.Open();
            SQLiteCommand add = new SQLiteCommand(query, conn);
            result = Convert.ToInt32(add.ExecuteNonQuery());
            conn.Close();
            return result;
        }

        public void AgregarPaciente(string id, string nombre, string apellido, string celular, string dia, string mes, string año, string edad, string genero, string tipo_de_sangre)
        {
            conn.Open();

            string query = $"INSERT INTO Pacientes (Paciente_id, Nombre, Apellido, Telefono, Fecha_nacimiento, Edad, Genero, Tipo_sangre, Diagnosticos)"
                            + $" VALUES ('{id}', '{nombre}', '{apellido}', '{celular}', '{dia}/{mes}/{año}', '{edad}', '{genero}', '{tipo_de_sangre}', '00000000000000000')";
            SQLiteCommand add = new SQLiteCommand(query, conn);
            add.ExecuteNonQuery();
            conn.Close();
        }

        public int ActualizarPersonal(string id, string nombre, string apellido, string telefono, string especialidad, string rol, string turno, string contraseña)
        {
            int result = 0;
            string query = $"UPDATE Personal SET Nombre = '{nombre}', Apellido = '{apellido}', Telefono = '{telefono}', Especialidad_id1 = '{especialidad}', Rol_id1 = '{rol}', Turno_id1 = '{turno}', Contraseña = '{contraseña}' WHERE Personal_id = '{id}'";
            conn.Open();
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            result = Convert.ToInt32(upd.ExecuteNonQuery());
            conn.Close();
            return result;
        }

        public void EliminarPerosnal(string id)
        {
            string query = $"DELETE FROM Personal WHERE Personal_id = '{id}'";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }


        public void EliminarCita(string personal, string fecha, string fila)
        {
            string query = $"DELETE FROM Citas WHERE Personal_id1 = '{personal}' AND Fecha_de_Cita = '{fecha}' AND Fila ='{fila}';";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        // VENTAS
        public List<MetodoPago> GetMetodoPagos()
        {
            List<MetodoPago> metodoPagos = new List<MetodoPago>();
            conn.Open();
            using (SQLiteRecordSet mp = ExecuteQuery("SELECT * FROM metodo_pago"))
            {
                while (mp.NextRecord())
                {
                    metodoPagos.Add(new MetodoPago(mp.GetInt32("Metodo_id"),
                        mp.GetString("descripcion")));
                }
            }
            conn.Close();
            return metodoPagos;
        }

        public List<InventarioBd> GetProductosBD()
        {
            List<InventarioBd> inventarioBd = new List<InventarioBd>();
            conn.Open();
            using (SQLiteRecordSet pr = ExecuteQuery("SELECT Medicamento_id, Nombre|| ' '||Marca AS Nombre, Marca, price, Qty_caja, qty_stock "
                + "FROM Inventario ORDER BY Medicamento_id;"))
            {
                while (pr.NextRecord())
                {
                    inventarioBd.Add(new InventarioBd(pr.GetInt32("Medicamento_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Marca"),
                        pr.GetInt32("price"),
                        pr.GetInt32("Qty_caja"),
                        pr.GetInt32("qty_stock")));
                }
            }
            conn.Close();
            return inventarioBd;
        }

        public List<Servicios> GetServicios()
        {
            List<Servicios> serviciosbd = new List<Servicios>();
            conn.Open();
            using (SQLiteRecordSet pr = ExecuteQuery("SELECT * "
                                                 + "FROM Servicios "
                                                 + "ORDER BY NombreDeServicio;"))
            {
                while (pr.NextRecord())
                {
                    serviciosbd.Add(new Servicios(pr.GetInt32("Servicio_id"),
                        pr.GetString("NombreDeServicio")));
                }
            }
            conn.Close();
            return serviciosbd;
        }

        public List<InventarioBd> GetProductosDescripcionBD()
        {
            List<InventarioBd> inventarioBd = new List<InventarioBd>();
            conn.Open();
            using (SQLiteRecordSet pr = ExecuteQuery("SELECT Medicamento_id, Nombre|| ' '||Marca AS Nombre, Marca, price, Qty_caja, qty_stock "
                                                    + "FROM Inventario ORDER BY Nombre;"))
            {
                while (pr.NextRecord())
                {
                    inventarioBd.Add(new InventarioBd(pr.GetInt32("Medicamento_id"),
                        pr.GetString("Nombre"),
                        pr.GetString("Marca"),
                        pr.GetInt32("price"),
                        pr.GetInt32("Qty_caja"),
                        pr.GetInt32("qty_stock")));
                }
            }
            conn.Close();
            return inventarioBd;
        }

        public List<Reportes> GetReportesbyDay(int dia)
        {
            List<Reportes> reportes = new List<Reportes>();
            conn.Open();
            SQLiteRecordSet rep = ExecuteQuery($"SELECT Nombre, Productoid, Descripcion, Cantidad, Precio, Total, MetodoPago, Dia, MesName, Año, Hora FROM Reportes INNER JOIN Meses ON Meses.Mes_num = Reportes.Mes WHERE Dia = '{dia}'");
            while (rep.NextRecord())
            {
                reportes.Add(new Reportes(rep.GetString("Nombre"),
                    rep.GetInt32("Productoid"),
                    rep.GetString("Descripcion"),
                    rep.GetInt32("Cantidad"),
                    rep.GetInt32("Precio"),
                    rep.GetInt32("Total"),
                    rep.GetString("MetodoPago"),
                    rep.GetInt32("Dia"),
                    rep.GetString("MesName"),
                    rep.GetInt32("Año"),
                    rep.GetString("Hora")));
            }
            return reportes;
        }

        public List<Reportes> GetReportesbyMonth(string mes)
        {
            List<Reportes> reportes = new List<Reportes>();
            conn.Open();
            SQLiteRecordSet rep = ExecuteQuery($"SELECT Nombre, Productoid, Descripcion, Cantidad, Precio, total, MetodoPago, Dia, MesName, Año, Hora FROM Reportes INNER JOIN Meses ON Meses.Mes_num = Reportes.Mes WHERE MesName = '{mes}'");
            while (rep.NextRecord())
            {
                reportes.Add(new Reportes(rep.GetString("Nombre"),
                    rep.GetInt32("Productoid"),
                    rep.GetString("Descripcion"),
                    rep.GetInt32("Cantidad"),
                    rep.GetInt32("Precio"),
                    rep.GetInt32("Total"),
                    rep.GetString("MetodoPago"),
                    rep.GetInt32("Dia"),
                    rep.GetString("MesName"),
                    rep.GetInt32("Año"),
                    rep.GetString("Hora")));
            }
            return reportes;
        }

        public List<Reportes> GetReportesbyYear(int Año)
        {
            List<Reportes> reportes = new List<Reportes>();
            conn.Open();
            SQLiteRecordSet rep = ExecuteQuery($"SELECT Nombre, Productoid, Descripcion, Cantidad, Precio, total, MetodoPago, Dia, MesName, Año, Hora FROM Reportes INNER JOIN Meses ON Meses.Mes_num = Reportes.Mes WHERE Año = '{Año}'");
            while (rep.NextRecord())
            {
                reportes.Add(new Reportes(rep.GetString("Nombre"),
                    rep.GetInt32("Productoid"),
                    rep.GetString("Descripcion"),
                    rep.GetInt32("Cantidad"),
                    rep.GetInt32("Precio"),
                    rep.GetInt32("Total"),
                    rep.GetString("MetodoPago"),
                    rep.GetInt32("Dia"),
                    rep.GetString("MesName"),
                    rep.GetInt32("Año"),
                    rep.GetString("Hora")));
            }
            return reportes;
        }
        public void AddProducto(int product_id, string nombre, string marca, int qty_caja, double precio, int stock )
        {
            conn.Open();
            using (SQLiteRecordSet rs = ExecuteQuery($"INSERT INTO Inventario (Medicamento_id, Nombre, Marca, Qty_Caja , price, qty_stock)" +
                $" VALUES ({product_id}, '{nombre}','{marca}','{qty_caja}', '{precio}', '{stock}')")) { }
            conn.Close();
        }

        public void ActualizarProducto(int product_id, string nombre, string marca, int qty_caja, double precio, int stock)
        {
            conn.Open();
            using (SQLiteRecordSet rs = ExecuteQuery($"UPDATE Inventario SET Nombre = '{nombre}', Marca = '{marca}' , price = '{precio}', qty_stock = '{stock}', Qty_caja = '{qty_caja}'" +
                $" WHERE Medicamento_id = '{product_id}'")) { }
            conn.Close();
        }

        public void EliminarProducto(int id)
        {
            string query = $"DELETE FROM Inventario WHERE Medicamento_id = '{id}'";
            conn.Open();
            SQLiteCommand delete = new SQLiteCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }

        public void ActualizarProductoV(int product_id, int stock)
        {
            conn.Open();
            using (SQLiteRecordSet rs = ExecuteQuery($"UPDATE Inventario SET qty_stock = qty_stock - {stock} WHERE Medicamento_id = {product_id}")) { }
            conn.Close();
        }

        public void ActualizarReportes(string Nombrecompleto, int productoid, string descripcion, double precio, double total, int cantidad, string metodopago, int dia, string mes, int año, string hora)
        {
            string query = $"INSERT INTO reportes VALUES ('{Nombrecompleto}', '{productoid}','{descripcion}','{cantidad}','{precio}', '{total}','{metodopago}','{dia}','{mes}','{año}', '{hora}')";
            conn.Open();
            SQLiteCommand upd = new SQLiteCommand(query, conn);
            upd.ExecuteNonQuery();
            conn.Close();
        }

        //Al ser información de solo lectura no es necesario crear una clase para almacenar la información
        //Por lo que se optó por usar un arraylist donde se almacene la información

        public ArrayList ProductoAry = new ArrayList();
        public ArrayList CantidadAry = new ArrayList();
        public void Top5(int año)
        {
            string query = ($"SELECT Descripcion, SUM(Cantidad) AS cnt FROM Reportes WHERE Año = '{año}' GROUP BY Descripcion ORDER BY cnt DESC LIMIT 5;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductoAry.Add(dr.GetString(0));
                CantidadAry.Add(dr.GetInt32(1));
            }
            conn.Close();

        }
        public ArrayList MetodoAry = new ArrayList();
        public ArrayList TotalAry = new ArrayList();
        public void GMetodoPago(int año)
        {
            string query = $"SELECT MetodoPago, SUM(Total) AS cnt FROM Reportes WHERE Año = '{año}' GROUP BY MetodoPago ORDER BY cnt DESC;";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MetodoAry.Add(dr.GetString(0));
                TotalAry.Add(dr.GetInt32(1));
            }
            conn.Close();
        }

        public ArrayList NombreAry = new ArrayList();
        public ArrayList TotalAryV = new ArrayList();
        public void GVendedor(int año)
        {
            string query = $"SELECT Nombre, SUM(Total) AS cnt FROM Reportes WHERE Año = '{año}' GROUP BY Nombre ORDER BY cnt DESC;";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NombreAry.Add(dr.GetString(0));
                TotalAryV.Add(dr.GetInt32(1));
            }
            conn.Close();
        }

        public ArrayList Mesary = new ArrayList();
        public ArrayList TotalAryT = new ArrayList();
        public void GAnual(int año)
        {
            string query = $"SELECT MesName, SUM(Total) AS cnt FROM Reportes INNER JOIN Meses ON Meses.Mes_num = Reportes.Mes WHERE Año = '{año}' GROUP BY Mes ORDER BY Mes ;";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Mesary.Add(dr.GetString(0));
                TotalAryT.Add(dr.GetInt32(1));
            }
            conn.Close();
        }

        public ArrayList AñosAry = new ArrayList();
        public void Gaños()
        {
            string query = $"SELECT Año From Reportes GROUP BY Año;";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AñosAry.Add(dr.GetInt32(0));
                
            }
            conn.Close();
        }
    }

        public sealed class MetodoPago
        {
            public int Metodo_id { get; }
            public string Descripcion { get; }

            public MetodoPago(int metodo_id, string descripcion)
            {
                Metodo_id = metodo_id;
                Descripcion = descripcion;
            }
        }
    
        public abstract class Inventario
        {
            public int Product_id { get; set; }
            public string Nombre { get; set; }
            public string Marca { get; set; }
            public int Qty_Caja { get; set; }
            public double Precio { get; set; }

            public Inventario(int product_id, string nombre, string marca, int qty_caja, double precio)
            {
                Product_id = product_id;
                Nombre = nombre;
                Marca = marca;
                Qty_Caja = qty_caja;
                Precio = precio;
            }
        }
        public sealed class InventarioBd : Inventario
        {
            public int stock { get; set; }

            public InventarioBd(int product_id, string nombre, string marca, int precio, int qty_caja, int stock) :
                base(product_id, nombre, marca, qty_caja, precio)
            {
                this.stock = stock;
            }
        }
        public sealed class ProductosVendidos : Inventario
        {
  

        public int Qty { get; set; }

            public ProductosVendidos(int product_id, string nombre, string marca, double precio, int qty_caja, int qty) :
                base(product_id, nombre, marca, qty_caja, precio)
            {
                this.Qty = qty;
            }
        }




}



   


    

