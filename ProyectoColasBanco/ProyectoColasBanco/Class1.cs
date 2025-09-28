using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public class cServicio
    {
        #region ATRIBUTOS
        private string aIdServicio;
        private string aDescripcion;
        #endregion

        #region CONSTRUCTORES
        public cServicio()
        {
            aIdServicio = "";
            aDescripcion = "";
        }

        public cServicio(string pIdServicio, string pDescripcion)
        {
            aIdServicio = pIdServicio;
            aDescripcion = pDescripcion;
        }
        #endregion

        #region PROPIEDADES
        public string IdServicio
        {
            get { return aIdServicio; }
            set { aIdServicio = value; }
        }

        public string Descripcion
        {
            get { return aDescripcion; }
            set { aDescripcion = value; }
        }
        #endregion

        #region MÉTODOS
        public override string ToString()
        {
            return aIdServicio;
        }

        public override bool Equals(object O)
        {
            return aIdServicio.Equals(O.ToString());
        }

        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DE SERVICIO");
            Console.WriteLine("==========================");
            Console.Write("Id Servicio: ");
            aIdServicio = Console.ReadLine();
            Console.Write("Descripción: ");
            aDescripcion = Console.ReadLine();
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE SERVICIO");
            Console.WriteLine("=================");
            Console.WriteLine("Id Servicio: " + aIdServicio);
            Console.WriteLine("Descripción: " + aDescripcion);
        }

        public void Escribir()
        {
            Console.WriteLine(aIdServicio.PadRight(12) + Descripcion.PadRight(50));
        }
        #endregion
    }

}
