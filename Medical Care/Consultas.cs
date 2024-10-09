using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Security.Cryptography.X509Certificates;
using SQLiteDb;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.IO.Image;

namespace Medical_Care
{
    public partial class Consulta : Form
    {
        public SQLiteConn conn;
        public Consulta()
        {
            InitializeComponent();
            timer1.Start();
            conn = new SQLiteConn("Medical.db");
            WindowState = FormWindowState.Maximized;
            cmb_descripcion.DataSource = conn.GetProductosDescripcionBD();
            cmb_descripcion.DisplayMember = "Nombre";
            cmb_descripcion.ValueMember = "Product_id";
            cmb_descripcion.SelectedIndex = -1;
            lbl_doctor.Text = Globales.Nombre;
            lbl_departamento.Text = Globales.Departamento;
        }
     
          
        private void btn_generar_receta_Click(object sender, EventArgs e)
        {
            PdfFont Times = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            PdfFont Times_negrita = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            TextAlignment textR = TextAlignment.RIGHT;
            TextAlignment textC = TextAlignment.CENTER;
            string urllogo = (Application.StartupPath + @"\Medical Care logos\Medical Care.jpeg");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Pacientes\" + $"{lbl_paciente.Text}");
            using (PdfWriter pdfWriter = new PdfWriter(Application.StartupPath + @"\Pacientes\" + $"{ lbl_paciente.Text}" + @"\" + $"{ lbl_paciente.Text},{txtb_diagnostico.Text},{lbl_fecha.Text},{lbl_hora.Text.Substring(0, 2)}.{lbl_hora.Text.Substring(3, 2)}.pdf"))
            using (PdfDocument pdfDocument = new PdfDocument(pdfWriter))
            using (Document document = new Document(pdfDocument))
            {
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(urllogo));
                //logo.SetAutoScale(true);
                logo.Scale(5, 5);
                logo.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                document.Add(logo);
                document.SetMargins(5, 5, 10, 10);
                document.Add(new Paragraph($"Medical care {lbl_fecha.Text}").SetFont(Times).SetTextAlignment(textR));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"Dr.{lbl_doctor.Text}, {lbl_departamento.Text}").SetFont(Times));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"{lbl_paciente.Text} " + "fue recibido presentando los sintomas").SetFont(Times));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"Peso: {txt_peso.Text} Estatura: {txt_estatura.Text}").SetFont(Times));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"{txtb_sintomas.Text}.").SetFont(Times));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("Por lo que fue diagnosticado con").SetFont(Times));
                document.Add(new Paragraph($"{txtb_diagnostico.Text}").SetFont(Times_negrita).SetTextAlignment(textC));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("Medicinas recetadas:").SetFont(Times));
                document.Add(new Paragraph(" "));
                int NumerodeMedicina = 0;
                foreach (ListViewItem item in ltw_medicamentos.Items)
                {
                    NumerodeMedicina++;
                    string NoMed = Convert.ToString(NumerodeMedicina);

                    document.Add(new Paragraph(NoMed + ".- MEDICAMENTO: " + item.SubItems[0].Text).SetFont(Times));
                    document.Add(new Paragraph("DOSIS: " + item.SubItems[1].Text).SetFont(Times_negrita).SetTextAlignment(textC));
                    document.Add(new Paragraph(" "));
                }
                document.Add(new Paragraph("Y se le recomienda seguir las siguientes indicaciones:").SetFont(Times));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph($"{txtb_tratamiento.Text}").SetFont(Times_negrita));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("______________________________________________").SetTextAlignment(textC));
                document.Add(new Paragraph($"Dr.{lbl_doctor.Text}, {lbl_departamento.Text}").SetFont(Times_negrita).SetTextAlignment(textC));
            }
            MessageBox.Show("Receta generada con exito");

            string pacienteid = conn.GetPacienteID().Find(x => x.NombreCompleto == lbl_paciente.Text).Paciente_id;

            if (conn.GetIngresadosPorPaciente(lbl_paciente.Text).Exists(x => x.Paciente_id1 == pacienteid) == false)
            {
                try
                {
                    conn.Close();
                    string CITASID = conn.GetCitasDeDoctorPorDia(Globales.Id, Globales.FDCita).Find(x => x.Paciente == pacienteid).Citas_id;
                    conn.ActualizarEstado("Completado", CITASID);
                }
                catch { }
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("T");
            lbl_fecha.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
                ListViewItem item = new ListViewItem();
                item = ltw_medicamentos.Items.Add(cmb_descripcion.Text);
                item.SubItems.Add(txtb_dosis.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ltw_medicamentos.Items)
                if (item.Selected)
                    ltw_medicamentos.Items.Remove(item);
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ActualizarDatosDePaciente_Click(object sender, EventArgs e)
        {
            string diagnostico = BinarioDiagnostico();
        }

        private string BinarioDiagnostico()
        {
            string NoDiag = null;
            foreach (Control c in groupBox2.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked) NoDiag = "1" + NoDiag;
                    else NoDiag = "0" + NoDiag;
                }
            }
            MessageBox.Show("SE HA ACTUALIZADO LA LISTA DE ENFERMEDADES A LA BASE DE DATOS");
            conn.ActualizarDiagnosticoDePaciente(NoDiag, lbl_paciente.Text);
            return NoDiag;

        }
        private void DiagnosticoCheckUncheck()
        {
            string binario = conn.GetDiagnostico(lbl_paciente.Text);
            int countAUX = 16;
            //MessageBox.Show(binario);
            foreach (Control c in groupBox2.Controls)
            {
                if (c is CheckBox)
                {
                    if (binario.Substring(countAUX, 1) == "1") ((CheckBox)c).Checked = true;
                    if (binario.Substring(countAUX, 1) == "0") ((CheckBox)c).Checked = false;
                    countAUX--;
                }
            }
            MessageBox.Show("SE HA ACTUALIZADO LA LISTA DE ENFERMEDADES SEGUN LA BASE DE DATOS");
        }

        private void btn_Act_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Globales.PaID);
            DiagnosticoCheckUncheck();
        }

        private void btn_EnfermedadesCronicas_Click(object sender, EventArgs e)
        {
            DiagnosticoCheckUncheck();
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

    }
}
