using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public class cCajero
    {
        #region ATRIBUTOS
        private string aDNI;
        private string aNombres;
        private string aDireccion;
        private string aEmail;
        private string aTelefono;
        #endregion

        #region CONSTRUCTORES
        public cCajero()
        {
            aDNI = "";
            aNombres = "";
            aDireccion = "";
            aEmail = "";
            aTelefono = "";
        }

        public cCajero(string pDNI, string pNombres, string pDireccion, string pEmail, string pTelefono)
        {
            aDNI = pDNI;
            aNombres = pNombres;
            aDireccion = pDireccion;
            aEmail = pEmail;
            aTelefono = pTelefono;
        }
        #endregion

        #region PROPIEDADES
        public string DNI
        {
            get { return aDNI; }
            set { aDNI = value; }
        }

        public string Nombres
        {
            get { return aNombres; }
            set { aNombres = value; }
        }

        public string Direccion
        {
            get { return aDireccion; }
            set { aDireccion = value; }
        }

        public string Email
        {
            get { return aEmail; }
            set { aEmail = value; }
        }

        public string Telefono
        {
            get { return aTelefono; }
            set { aTelefono = value; }
        }
        #endregion

        #region MÉTODOS
        public override string ToString()
        {
            return aDNI;
        }

        public override bool Equals(object O)
        {
            return aDNI.Equals(O.ToString());
        }

        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DEL CAJERO");
            Console.WriteLine("=========================");
            Console.Write("DNI: ");
            aDNI = Console.ReadLine();
            Console.Write("Nombres: ");
            aNombres = Console.ReadLine();
            Console.Write("Dirección: ");
            aDireccion = Console.ReadLine();
            Console.Write("Email: ");
            aEmail = Console.ReadLine();
            Console.Write("Teléfono: ");
            aTelefono = Console.ReadLine();
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DEL CAJERO");
            Console.WriteLine("================");
            Console.WriteLine("DNI: " + aDNI);
            Console.WriteLine("Nombres: " + aNombres);
            Console.WriteLine("Dirección: " + aDireccion);
            Console.WriteLine("Email: " + aEmail);
            Console.WriteLine("Teléfono: " + aTelefono);
        }

        public void Escribir()
        {
            Console.WriteLine(aDNI.PadRight(12) + Nombres.PadRight(25) + Direccion.PadRight(30) + Email.PadRight(25) + Telefono.PadRight(15));
        }
        #endregion
    }
}
