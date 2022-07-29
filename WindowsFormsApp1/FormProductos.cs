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

namespace WindowsFormsApp1
{
    public partial class FormProductos : Form
    {
        Producto NuevoProducto;
        Producto ProdExistente;
        bool nuevo = true;
        int fila;


        public FormProductos()
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

            NuevoProducto = new Producto(int.Parse(txtCodigo.Text), txtDescripcion.Text, int.Parse(txtStock.Text));

            lblCodigoMov.Text = NuevoProducto.p_codigo.ToString();
            lblDescripMov.Text = NuevoProducto.p_descripcion;
            lbl_StockMov.Text = "Hay " + NuevoProducto.p_stock.ToString() + " Unidades";

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


            if (nuevo == true)
            {
                if (rbIngreso.Checked == true)
                {
                    NuevoProducto.ingreso(int.Parse(txtCantidad.Text));
                }
                if (rbEgreso.Checked == true)
                {
                    NuevoProducto.Egreso(int.Parse(txtCantidad.Text));
                }
                LlevarProdAldgv(NuevoProducto, fila);
            }
            else
            {
                if (rbIngreso.Checked == true)
                {
                    ProdExistente.ingreso(int.Parse(txtCantidad.Text));
                }
                if (rbEgreso.Checked == true)
                {
                    ProdExistente.Egreso(int.Parse(txtCantidad.Text));
                }
                LlevarProdAldgv(ProdExistente, fila);
            }
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
            lblCodigoMov.Text = ProdExistente.p_codigo.ToString();
            lblDescripMov.Text = ProdExistente.p_descripcion;
            lbl_StockMov.Text = "Hay " + ProdExistente.p_stock.ToString() + "unidades";
            txtCantidad.Clear();
            fila = e.RowIndex;
            nuevo = false;
        }

        private void tabC_Control_Click(object sender, EventArgs e)
        {

        }

        private void btCargar_Click_1(object sender, EventArgs e)
        {
            NuevoProducto = new Producto(int.Parse(txtCodigo.Text), txtDescripcion.Text, int.Parse(txtStock.Text));

            lblCodigoMov.Text = NuevoProducto.p_codigo.ToString();
            lblDescripMov.Text = NuevoProducto.p_descripcion;
            lbl_StockMov.Text = "Hay " + NuevoProducto.p_stock.ToString() + " Unidades";

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

    }
}


