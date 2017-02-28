using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class clsNCategoria
    {
        //metodo insertar que llama al metodo insertar de la clases clscategoria
        public static string Insertar(string nombre, string descripcion)
        {
            clsCaterogoria Obj = new clsCaterogoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);


        }
        //metodo editar que lllama al metodo editar de la clase clscategoria
        public static string Editar(string nombre, string descripcion, int idcategoria)
        {
            clsCaterogoria Obj = new clsCaterogoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);


        }
        //metodo eliminar que llama al metodo eliminar de la clase clscategoria
        public static string Eliminar(int idcategoria)
        {
            clsCaterogoria Obj = new clsCaterogoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);


        }
        //metodo mostrar que llama al metodo mostrar de la clase clscategoria
        public static DataTable Mostrar()
        {
            return new clsCaterogoria().Mostrar();
        }
        public static DataTable BuscarNomre(string textobuscar)
        {
            clsCaterogoria Obj = new clsCaterogoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }


    }
}
