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
    public partial class Vendedores : Form
    {
        public SQLiteConn conn;
        //public Login log;
        public List<ProductosVendidos> auxVentas = new List<ProductosVendidos>();
        public Vendedores()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            lbl_nombre.Text = Globales.Nombre;
            label10.Text = Globales.Turno;
            button4.Enabled = false;
            if (Globales.Rol == "Vendedores")
            {
                btn_Inventario.Enabled = true;
                btn_reportes.Enabled = false;
                button1.Enabled = false;
                btn_inveditar.Enabled = false;
                btn_invdel.Enabled = false;
                groupBox1.Enabled = false;
            }
            else if (Globales.Rol == "Administración")
            {
                btn_Inventario.Enabled = true;
                btn_reportes.Enabled = true;
                button1.Enabled = true;
            }
            conn = new SQLiteConn("Medical.db");

            ActualizarVentas();
            txt_efectivo.Enabled = true;
            cmb_filtro.Items.Clear();
            cmb_filtro.Items.Add("Codigo");
            cmb_filtro.Items.Add("Nombre");

           

        }

        public void ActualizarVentas()
        {
            cmb_codigo.SelectedIndex = -1;
            cmb_descripcion.SelectedIndex = -1;
            txt_cantidad.Clear();

            cmb_codigo.DataSource = conn.GetProductosBD();
            cmb_codigo.DisplayMember = "Product_id";
            cmb_codigo.ValueMember = "nombre";

            cmb_codigo.AutoCompleteCustomSource = CargarIDdb();
            cmb_codigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cmb_metodo.DataSource = conn.GetMetodoPagos();
            cmb_metodo.DisplayMember = "Descripcion";
            cmb_metodo.ValueMember = "Metodo_id";

            cmb_descripcion.DataSource = conn.GetProductosDescripcionBD();
            cmb_descripcion.DisplayMember = "Nombre";
            cmb_descripcion.ValueMember = "Product_id";

            cmb_descripcion.AutoCompleteCustomSource = CargarDatosDB();
            cmb_descripcion.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_descripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
       

            if (cmb_metodo.Text != "Efectivo")
            {
                txt_efectivo.Text = Convert.ToString(Total());
                txt_efectivo.Enabled = false;
            }

            else
            {
                txt_efectivo.Enabled = true;
            }
        }

        private AutoCompleteStringCollection CargarDatosDB()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            try
            {

                foreach (InventarioBd p in conn.GetProductosBD())
                {
                    datos.Add(p.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datos;
        }

        private AutoCompleteStringCollection CargarIDdb()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            try
            {

                foreach (InventarioBd p in conn.GetProductosBD())
                {
                    datos.Add(p.Product_id.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datos;
        }
        public void Actualizarinventario()
        {
            listView2.Items.Clear();

            foreach (InventarioBd inv in conn.GetProductosBD())
            {
                ListViewItem item;
                item = listView2.Items.Add(inv.Product_id.ToString());
                item.SubItems.Add(inv.Nombre);
                item.SubItems.Add(inv.Marca);
                item.SubItems.Add(inv.Qty_Caja.ToString());
                item.SubItems.Add(inv.stock.ToString());
                item.SubItems.Add(inv.Precio.ToString());
            }


        }

        private void Filtrar_inv(int criterio1)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                if (!item.SubItems[criterio1].ToString().ToLower().Contains(txt_filtrardesc.Text.ToLower()))
                {
                    listView2.Items.Remove(item);
                }
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

        private void Vendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globales.Rol == "Administración")
            {
                this.Close();
            }
            else if (Globales.Rol == "Vendedores")
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

        private void btn_Ventas_Click(object sender, EventArgs e)
        {
            pnl_Ventas.Visible = true;
            pnl_Inventario.Visible = false;
            ActualizarVentas();
        }

        private void btn_Inventario_Click(object sender, EventArgs e)
        {
            pnl_Ventas.Visible = false;
            pnl_Inventario.Visible = true;
            Actualizarinventario();
        }

        private void txt_filtrardesc_TextChanged(object sender, EventArgs e)
        {
            int criterio1;
            Actualizarinventario();
            if (cmb_filtro.Text == ("Codigo"))
            {
                criterio1 = 0;
                Filtrar_inv(criterio1);
            }
            else if (cmb_filtro.Text == "Nombre")
            {
                criterio1 = 1;
                Filtrar_inv(criterio1);
            }

        }

        private void btn_invadd_Click(object sender, EventArgs e)
        {
            try
            {
                int product_id = Convert.ToInt32(txt_id.Text);
                string nombre = txt_addDescripcion.Text;
                string marca = txt_marca.Text;
                int qty_caja = Convert.ToInt32(txt_qty.Text);
                double precio = Convert.ToDouble(txt_price.Text);
                int stock = Convert.ToInt32(txt_stock.Text);
                if (conn.GetProductosBD().Exists(x => x.Product_id == Convert.ToInt32(txt_id.Text)))
                {
                    MessageBox.Show("El id ya esta en uso actualmente");
                }
                else if (conn.GetProductosBD().Exists(x => x.Nombre == $"{txt_addDescripcion.Text} {txt_marca.Text}"))
                {
                    MessageBox.Show("Ya existe un producto con nombre y marca similares");
                }
                else
                {
                    conn.AddProducto(product_id, nombre, marca, qty_caja, precio, stock);
                    txt_stock.Clear();
                    txt_qty.Clear();
                    txt_price.Clear();
                    txt_marca.Clear();
                    txt_addDescripcion.Clear();
                    txt_id.Clear();
                    Actualizarinventario();
                }
            }
            catch
            {
                MessageBox.Show("Asegurese de llenar todos los campos de datos", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private void btn_inveditar_Click(object sender, EventArgs e)
        {

            try
            {
                btn_guardar.Visible = true;
                btn_invadd.Visible = false;
                txt_id.Text = listView2.SelectedItems[0].SubItems[0].Text;
                txt_addDescripcion.Text = listView2.SelectedItems[0].SubItems[1].Text;
                txt_marca.Text = listView2.SelectedItems[0].SubItems[2].Text;
                txt_qty.Text = listView2.SelectedItems[0].SubItems[3].Text;
                txt_stock.Text = listView2.SelectedItems[0].SubItems[4].Text;
                txt_price.Text = listView2.SelectedItems[0].SubItems[5].Text;
            }
            catch
            {
                btn_guardar.Visible = false;
                btn_invadd.Visible = true;
            }


        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int product_id = Convert.ToInt32(txt_id.Text);
                string nombre = txt_addDescripcion.Text;
                string marca = txt_marca.Text;
                int qty_caja = Convert.ToInt32(txt_qty.Text);
                double precio = Convert.ToDouble(txt_price.Text);
                int stock = Convert.ToInt32(txt_stock.Text);
                conn.ActualizarProducto(product_id, nombre, marca, qty_caja, precio, stock);
                Actualizarinventario();
                btn_guardar.Visible = false;
                btn_invadd.Visible = true;
                txt_stock.Clear();
                txt_qty.Clear();
                txt_price.Clear();
                txt_marca.Clear();
                txt_addDescripcion.Clear();
                txt_id.Clear();
            }
            catch
            {
                MessageBox.Show("Asegurese de llenar los campos de datos", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_invdel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
            conn.EliminarProducto(id);
            Actualizarinventario();

        }

        private void cmb_codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_descripcion.Text = Convert.ToString(cmb_codigo.SelectedValue);
        }

        private void cmb_descripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_codigo.Text = Convert.ToString(cmb_descripcion.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_cantidad.Text == "0" || txt_cantidad.Text == "")
            {
                MessageBox.Show("0 no es valido para cantidad");
            }
            else if (txt_cantidad.Text != "0")
            {
                


                ListViewItem item1;
                InventarioBd p = cmb_descripcion.SelectedItem as InventarioBd;
                int id = p.Product_id;
                string descripcion = p.Nombre;
                string marca = p.Marca;
                double precio = p.Precio;
                int qty_caja = p.Qty_Caja;
                int qty = Convert.ToInt32(txt_cantidad.Text);
                List<ProductosVendidos> listaproductos = new List<ProductosVendidos>();
                ProductosVendidos productosVendidos = new ProductosVendidos(id, descripcion, marca, precio, qty_caja, qty);

                item1 = listView1.FindItemWithText(p.Product_id.ToString());
                if (p.stock < qty || p.stock == 0)
                {
                    MessageBox.Show("No hay suficiente stock para realizar la venta");
                }
                else if (item1 == null)
                {
                    //listView1.Clear();

                    button4.Enabled = true;

                    listaproductos.Add(productosVendidos);
                    auxVentas.Add(productosVendidos);
                    foreach (ProductosVendidos productos in listaproductos)
                    {
                        ListViewItem item;
                        item = listView1.Items.Add(productos.Product_id.ToString());
                        item.SubItems.Add(productos.Nombre);
                        item.SubItems.Add(productos.Marca);
                        item.SubItems.Add(Convert.ToString($"{productos.Qty_Caja}"));
                        item.SubItems.Add(Convert.ToString($"{productos.Qty}"));
                        item.SubItems.Add(Convert.ToString($"{productos.Precio}"));
                    }
                    if (cmb_metodo.Text != "Efectivo")
                    {
                        txt_efectivo.Text = Convert.ToString(Total());
                    }
                    Total();
                }
                else
                {
                    MessageBox.Show("Ya existe");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems==null)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                if (txt_cantidad.Text == "0" || txt_cantidad.Text == "")
                {
                    MessageBox.Show("No hay productos a eliminar");
                }
                else if (txt_cantidad.Text != "0")
                {
                    foreach (ListViewItem item in listView1.Items)
                        if (item.Selected)
                            listView1.Items.Remove(item);
                    //ListViewItem item1;
                    InventarioBd p = cmb_descripcion.SelectedItem as InventarioBd;
                    int id = p.Product_id;
                    string descripcion = p.Nombre;
                    string marca = p.Marca;
                    double precio = p.Precio;
                    int qty_caja = p.Qty_Caja;
                    int qty = Convert.ToInt32(txt_cantidad.Text);
                    List<ProductosVendidos> listaproductos = new List<ProductosVendidos>();
                    ProductosVendidos productosVendidos = new ProductosVendidos(id, descripcion, marca, precio, qty_caja, qty);

                    listaproductos.Remove(productosVendidos);
                    auxVentas.Remove(productosVendidos);
                    foreach (ProductosVendidos productos in listaproductos)
                    {
                        ListViewItem item;
                        item = listView1.Items.Add(productos.Product_id.ToString());
                        item.SubItems.Add(productos.Nombre);
                        item.SubItems.Add(productos.Marca);
                        item.SubItems.Add(Convert.ToString($"{productos.Qty_Caja}"));
                        item.SubItems.Add(Convert.ToString($"{productos.Qty}"));
                        item.SubItems.Add(Convert.ToString($"{productos.Precio}"));
                    }
                    Total();
                }
            }


        }

        private double Total()
        {
            double total = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                total += Convert.ToDouble(item.SubItems[4].Text) * Convert.ToDouble(item.SubItems[5].Text);
            }

            txt_total.Text = ($"{total:c}");
            return total;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                double cambio;
                double pago;
                double total;
                string user = lbl_nombre.Text;

                DateTime fecha = DateTime.Today;
                string Metodopago = cmb_metodo.Text;
                int dia = Convert.ToInt32(fecha.Day);
                string mes = Convert.ToString(fecha.Month);
                int año = Convert.ToInt32(fecha.Year);
                //string nombremes = fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"));
                string hora = label11.Text;
                string Nombrecompleto = lbl_nombre.Text;
                if (txt_efectivo.Text == "0")
                {
                    MessageBox.Show("Inserte la cantidad de efectivo");

                }
                pago = Convert.ToDouble(txt_efectivo.Text);
                total = Total();
                cambio = (pago - total);
                DialogResult r = MessageBox.Show("¿Seguro que desea realizar la venta?",
                     "Atención",
                     MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    if (total > pago)
                    {
                        MessageBox.Show("El cobro no puede ser menor al total de la compra");
                    }
                    else
                    {
                        txt_cambio.Text = ($"{cambio:c}");

                        foreach (ProductosVendidos p in auxVentas)
                        {
                            conn.ActualizarProductoV(p.Product_id, p.Qty);
                            conn.ActualizarReportes(user, p.Product_id, p.Nombre, p.Precio, total, p.Qty, Metodopago, dia, mes, año, hora);

                        }
                        ImprimirPDF();


                        MessageBox.Show("Venta realizada con exito");


                        txt_efectivo.Clear();
                        ActualizarVentas();
                        listView1.Items.Clear();
                        auxVentas.Clear();
                    }
                }
                else
                {

                }


            }
            else MessageBox.Show("Agregue productos");

        }

        private void cmb_metodo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_metodo.Text != "Efectivo")
            {
                txt_efectivo.Text = Convert.ToString(Total());
                txt_efectivo.Enabled = false;
            }

            else
            {
                txt_efectivo.Enabled = true;
            }

        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validación.SoloNumeros(e);
        }

        private void Vendedores_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("T");
            label8.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void txt_efectivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            ReportesVentas reportesVentas = new ReportesVentas();
            reportesVentas.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graficas graficas = new Graficas();
            graficas.Show();

        }

        private void txt_cantidad_Leave(object sender, EventArgs e)
        {
            if (txt_cantidad.Text == "") /// este era mi error
            {
                txt_cantidad.Text = "1";
            }
        }

        private void solicitarIntendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Solicitar_intendencia soli = new Solicitar_intendencia();
            soli.Show();
        }

        private void ImprimirPDF()
        {
            //string texto = null;
            string urllogo = (Application.StartupPath + @"\Medical Care logos\Medical Logo.png");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Ventas\" + $"{label8.Text}" + @"\" + $"{lbl_nombre.Text}");
            string Marcadeagua = (Application.StartupPath + @"\Medical Care logos\MC_Azul.png");
            using (PdfWriter pdfWriter = new PdfWriter(Application.StartupPath + @"\Ventas\" + $"{label8.Text}" + @"\" + $"{lbl_nombre.Text}" + @"\" + $"Venta {label8.Text},{label11.Text.Substring(0, 2)}.{label11.Text.Substring(3, 2)}.pdf"))
            using (PdfDocument pdfDocument = new PdfDocument(pdfWriter))
            using (Document document = new Document(pdfDocument))
            {
                //Configuramos la marca de agua
                PageSize pageSize = PageSize.LETTER.Rotate();
                PdfCanvas canvas = new PdfCanvas(pdfDocument.AddNewPage());
                ImageData image = ImageDataFactory.Create(Marcadeagua);
                canvas.SaveState();
                PdfExtGState state = new PdfExtGState().SetFillOpacity(0.6f);
                canvas.SetExtGState(state);
                canvas.AddImage(image, 0, 0, pageSize.GetWidth(), false);
                canvas.RestoreState();

                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(urllogo));
                //logo.SetAutoScale(true);
                logo.Scale(5, 5);
                logo.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                document.Add(logo);
                document.SetMargins(5, 5, 10, 10);
                Paragraph titulo = new Paragraph("MEDICAL CARE");
                titulo.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                titulo.SetFontSize(16);
                titulo.SetBold();
                document.Add(titulo);
                Paragraph fecha = new Paragraph($"{label8.Text},{label11.Text}");
                fecha.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                fecha.SetFontSize(12);
                document.Add(fecha);
                Paragraph vendedor = new Paragraph($"{lbl_nombre.Text}");
                fecha.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                fecha.SetFontSize(12);
                document.Add(vendedor);
                document.Add(new Paragraph(" "));
                Table table = new Table(listView1.Columns.Count);
                //table.SetWidth(2);
                table.SetFontSize(9);
                //table.SetHeight(2);
                table.UseAllAvailableWidth();

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
                document.Add(new Paragraph(" "));
                Table resumen = new Table(2);
                resumen.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);
                resumen.AddCell("Total:");
                resumen.AddCell($"{txt_total.Text}");
                resumen.AddCell("Metodo de pago:");
                resumen.AddCell($"{cmb_metodo.Text}");
                resumen.AddCell("Su cambio:");
                resumen.AddCell($"{txt_cambio.Text}");
                document.Add(resumen);


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
