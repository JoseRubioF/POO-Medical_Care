using SQLiteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using iText.Kernel.Geom;
using System.Resources;
using iText.IO.Image;
using System.Security.Policy;
using iText.Kernel.Pdf.Xobject;
using iText.IO.Font.Otf;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;

namespace Medical_Care
{
    public partial class ReportesVentas : Form
    {
        public SQLiteConn conn;
        public ReportesVentas()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cmb_filtrar.Items.Add("Dia");
            cmb_filtrar.Items.Add("Mes");
            cmb_filtrar.Items.Add("Año");


        }

        private void Btn_filtrar_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn = new SQLiteConn("Medical.db");

            try
            {
                if (cmb_filtrar.Text == "Dia")
                {
                    int filtro = Convert.ToInt32(txt_filtro.Text);
                    List<Reportes> reportes = conn.GetReportesbyDay(filtro);
                    foreach (Reportes r in reportes)
                    {
                        ListViewItem item = new ListViewItem();
                        item = listView1.Items.Add(r.Nombre);
                        item.SubItems.Add(Convert.ToString(r.Produto_id));
                        item.SubItems.Add(r.Descripcion);
                        item.SubItems.Add(Convert.ToString(r.Cantidad));
                        item.SubItems.Add(Convert.ToString(r.precio));
                        item.SubItems.Add(Convert.ToString(r.total));
                        item.SubItems.Add(r.MetodoPago);
                        item.SubItems.Add(Convert.ToString(r.Dia));
                        item.SubItems.Add(Convert.ToString(r.Mes));
                        item.SubItems.Add(Convert.ToString(r.Año));
                        item.SubItems.Add(r.Hora);

                    }
                }
                else if (cmb_filtrar.Text == "Mes")
                {
                    string filtromes = cmb_mes.Text;
                    List<Reportes> reportes = conn.GetReportesbyMonth(filtromes);
                    foreach (Reportes r in reportes)
                    {
                        ListViewItem item = new ListViewItem();
                        item = listView1.Items.Add(r.Nombre);
                        item.SubItems.Add(Convert.ToString(r.Produto_id));
                        item.SubItems.Add(r.Descripcion);
                        item.SubItems.Add(Convert.ToString(r.Cantidad));
                        item.SubItems.Add(Convert.ToString(r.precio));
                        item.SubItems.Add(Convert.ToString(r.total));
                        item.SubItems.Add(r.MetodoPago);
                        item.SubItems.Add(Convert.ToString(r.Dia));
                        item.SubItems.Add(Convert.ToString(r.Mes));
                        item.SubItems.Add(Convert.ToString(r.Año));
                        item.SubItems.Add(r.Hora);

                    }
                }
                else if (cmb_filtrar.Text == "Año")
                {
                    int filtro = Convert.ToInt32(txt_filtro.Text);
                    List<Reportes> reportes = conn.GetReportesbyYear(filtro);
                    foreach (Reportes r in reportes)
                    {
                        ListViewItem item = new ListViewItem();
                        item = listView1.Items.Add(r.Nombre);
                        item.SubItems.Add(Convert.ToString(r.Produto_id));
                        item.SubItems.Add(r.Descripcion);
                        item.SubItems.Add(Convert.ToString(r.Cantidad));
                        item.SubItems.Add(Convert.ToString(r.precio));
                        item.SubItems.Add(Convert.ToString(r.total));
                        item.SubItems.Add(r.MetodoPago);
                        item.SubItems.Add(Convert.ToString(r.Dia));
                        item.SubItems.Add(Convert.ToString(r.Mes));
                        item.SubItems.Add(Convert.ToString(r.Año));
                        item.SubItems.Add(r.Hora);

                    }
                }
            }
            catch { }

        }

        private void cmb_filtrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_filtrar.Text == "Mes")
            {
                cmb_mes.Visible = true;
                txt_filtro.Visible = false;
            }
            else if (cmb_filtrar.Text == "Dia" || cmb_filtrar.Text == "Año")
            {
                cmb_mes.Visible = false;
                txt_filtro.Visible = true;
            }
        }

        private void picb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picb_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string SRC = Application.StartupPath + @"\Reportes\" + $"{cmb_filtrar.Text}{date.ToString("dd-MMM-yyy H.mm")}1.pdf";
            string Dest = Application.StartupPath + @"\Reportes\" + $"{cmb_filtrar.Text}{date.ToString("dd-MMM-yyy H.mm")}.pdf";
            string urllogo = (Application.StartupPath + @"\Medical Care logos\Medical Logo.png");
            string Marcadeagua = (Application.StartupPath + @"\Medical Care logos\MC_Azul.png");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Reportes\");
            using (PdfWriter pdfWriter = new PdfWriter(SRC))
            using (PdfDocument pdfDocument = new PdfDocument(pdfWriter))
            using (Document document = new Document(pdfDocument))
            {
                //Establecemos los margenes
                document.SetMargins(5, 5, 10, 10);


                //Configuramos la marca de agua
                PageSize pageSize = PageSize.LETTER.Rotate();
                PdfCanvas canvas = new PdfCanvas(pdfDocument.AddNewPage());
                ImageData image = ImageDataFactory.Create(Marcadeagua);
                canvas.SaveState();
                PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
                canvas.SetExtGState(state);
                canvas.AddImage(image, 0, 0, pageSize.GetWidth(), false);
                canvas.RestoreState();


                //seteamos las propiedades del logo
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(urllogo));
                logo.Scale(5, 5);
                logo.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                document.Add(logo);

                //Agregamos los parrafos iniciales, donde se cargan los datos del usuario y la fecha.
                Paragraph titulo = new Paragraph($"MEDICAL CARE \n Reporte por {cmb_filtrar.Text}");
                titulo.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                titulo.SetFontSize(16);
                titulo.SetBold();
                document.Add(titulo);
                Paragraph fecha = new Paragraph($"{date.ToString()}");
                fecha.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                fecha.SetFontSize(12);
                document.Add(fecha);
                Paragraph vendedor = new Paragraph($"{Globales.Nombre}");
                fecha.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                fecha.SetFontSize(12);
                document.Add(vendedor);
                document.Add(new Paragraph(" "));

                //Creamos y configuramos la tabla que lleva los datos de nuestro listview
                Table table = new Table(listView1.Columns.Count);
                table.SetFontSize(9);
                table.UseAllAvailableWidth();

                //Cargamos los datos del listview
                foreach (ColumnHeader column in listView1.Columns)
                {
                    Cell cell = new Cell();
                    cell.Add(new Paragraph(column.Text));
                    table.AddCell(cell);
                }
                foreach (ListViewItem itemrow in listView1.Items)
                {
                    int i = 0;
                    for (i = 0; i < itemrow.SubItems.Count; i++)
                    {
                        table.AddCell(itemrow.SubItems[i].Text);
                    }
                }
                document.Add(table);
                document.Close();

                PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC), new PdfWriter(Dest));
                Document doc = new Document(pdfDoc);
                //Configuramos la numeración de las paginas
                int numberOfPages = pdfDoc.GetNumberOfPages();
                
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph($"Página {i} de {numberOfPages}"),
                            559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                }


                doc.Close();
                try
                {
                    File.Delete(SRC);
                }
                catch { }
                MessageBox.Show("Reporte creado");
            }

        }
    }
}