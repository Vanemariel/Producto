using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entitis;
using Datos;

namespace Negocios
{
    public class NegProductos
    {
        //instancio el objeto de la clase admisnis
        AdminisProductos DatosObjProducto = new AdminisProductos();

        public int abmProductos(string accion, Producto objProducto)
        {
            return DatosObjProducto.abmProductos(accion,objProducto);
        }
        public DataSet listadoProductos(string cual)
        {
            return DatosObjProducto.listadoProductos(cual);
        }
    }
}
