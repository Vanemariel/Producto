using Entitis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entitis;
using Negocios;

namespace WindowsFormsApp1
{
    public partial class FormProductos : Form
    {
        Producto NuevoProducto;
        Producto ProdExistente;
        NegProductos ObjNegProducto = new NegProductos();
        bool nuevo = true;
        int fila;

        public FormProductos()
        {
            InitializeComponent();
            CrearDgv();
            //trae datod de la base
            LlenarDGV();
        }
        private void LlenarDGV()
        {
            dgv_Producto.Rows.Clear();

            DataSet ds = new DataSet();
            ds = ObjNegProducto.listadoProductos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Lo que quieres mostrar esta en dr[0].ToString(), dr[1].ToString(),
                    dgv_Producto.Rows.Add(dr[0].ToString(), dr[1]);
                }
            }
            else
                MessageBox.Show( "No hay productos cargados en el sistema");
        }
        private void CrearDgv()
        {
            InitializeComponent();
            dgv_Producto.Columns.Add("0", "Código");
            dgv_Producto.Columns.Add("1", "Descripción");
            dgv_Producto.Columns.Add("2", "Stock");
            dgv_Producto.Columns[0].Width = 100;
            dgv_Producto.Columns[1].Width = 300;
            dgv_Producto.Columns[2].Width = 60;


        }
        public void btCargar_Click(object sender, EventArgs e)
        {
            int nGrabados = -1;
            //instanciamos utilizando el contructor con parametros

            NuevoProducto = new Producto(int.Parse(txtCodigo.Text), txtDescripcion.Text, int.Parse(txtStock.Text));

            nGrabados = ObjNegProducto.abmProductos("Alta", NuevoProducto);
            if (nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar el producto en el sistema");
            }
            else
            {
                lblCodigoMov.Text = NuevoProducto.p_codigo.ToString();
                lblDescripMov.Text = NuevoProducto.p_descripcion;
                lbl_StockMov.Text = "Hay " + NuevoProducto.p_stock.ToString() + " Unidades";

                
                txtCantidad.Clear();
                txtCantidad.Focus();

                nuevo = true;
                LlenarDGV();
            }


            //tabC_Productos.SelectedTab = tabP_Movimiento;
            //txb_Movim.Clear();
            //txb_Movim.Focus(); 

            LlevarProdAldgv(NuevoProducto);
            nuevo = true;

            void LlevarProdAldgv(Producto Prod)
            {
                dgv_Producto.Rows.Add(Prod.p_codigo.ToString(), Prod.p_descripcion,
                Prod.p_stock.ToString());
                fila = (dgv_Producto.Rows.Count - 1);
            }

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

                if (rbIngreso.Checked == true)
                {
                    ProdExistente.ingreso(int.Parse(txtCantidad.Text));
                }
                if (rbEgreso.Checked == true)
                {
                    ProdExistente.Egreso(int.Parse(txtCantidad.Text));
                }
            // LlevarProdAldgv(NuevoProducto, fila);
            int nResultado = -1;
            nResultado = ObjNegProducto.abmProductos("Modificar", ProdExistente);

            if (nResultado != -1)
            {
                LlenarDGV();
            }
            else
              
                MessageBox.Show("Error", "Se produjo error añ insertar modificar al producto");
            
            
            void LlevarProdAldgv(Producto Prod, int lugar)
            {
                dgv_Producto[0, lugar].Value = Prod.p_codigo.ToString();
                dgv_Producto[1, lugar].Value = Prod.p_descripcion;
                dgv_Producto[2, lugar].Value = Prod.p_stock.ToString();
            }

        }

        private void dgv_Producto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdExistente = new
               Producto(Convert.ToInt32(dgv_Producto.CurrentRow.Cells[0].Value),
               dgv_Producto.CurrentRow.Cells[1].Value.ToString(),
               Convert.ToInt32(dgv_Producto.CurrentRow.Cells[2].Value));

            DataSet ds = new DataSet();

            ds = ObjNegProducto.listadoProductos(ProdExistente.p_codigo.ToString());
            if (ds.Tables[0].Rows.Count>0)
            {
                Ds_a_Controles(ds);
            }
        }
        private void Ds_a_Controles(DataSet ds)
        {
            lblCodigoMov.Text = ds.Tables[0].Rows[0]["codigo"].ToString();
            lblDescripMov.Text = ds.Tables[0].Rows[0]["descripcion"].ToString();
            lbl_StockMov.Text = ds.Tables[0].Rows[0]["stock"].ToString() +  "unidades";

        }


        private void tabC_Control_Click(object sender, EventArgs e)
        {

        }

        /*private void btCargar_Click_1(object sender, EventArgs e)
        {
            NuevoProducto = new Producto(int.Parse(txtCodigo.Text), txtDescripcion.Text, int.Parse(txtStock.Text));

            lblCodigoMov.Text = NuevoProducto.p_codigo.ToString();
            lblDescripMov.Text = NuevoProducto.p_descripcion;
            lbl_StockMov.Text = "Hay" + NuevoProducto.p_stock.ToString() + " Unidades";

            //tabC_Productos.SelectedTab = tabP_Movimiento;
            //txb_Movim.Clear();
            //txb_Movim.Focus(); 

            LlevarProdAldgv(NuevoProducto);
            nuevo = true;

            void LlevarProdAldgv(Producto Prod)
            {
                dgv_Producto.Rows.Add(Prod.p_codigo.ToString(), Prod.p_descripcion,
                Prod.p_stock.ToString());
                fila = (dgv_Producto.Rows.Count - 1);
            }

        }*/

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void tabC_Control_Click_1(object sender, EventArgs e)
        {

        }
    }
}


