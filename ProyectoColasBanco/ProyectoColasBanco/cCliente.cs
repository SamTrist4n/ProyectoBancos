using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public class cCliente
    {
        #region *********************** ATRIBUTOS ************************
        private string aDNI;
        private string aNombres;
        private DateTime aFechaNacimiento;
        private bool aDiscapacidad;
        private int aNinos;
        private string aEmail;
        private string aTelefono;
        private double aMonto;
        #endregion *********************** ATRIBUTOS ************************

        #region *********************** METODOS ************************
        #region ==================== CONSTRUCTORES =======================
        public cCliente()
        {
            aDNI = "";
            aNombres = "";
            aFechaNacimiento = DateTime.MinValue;
            aDiscapacidad = false;
            aNinos = 0;
            aEmail = "";
            aTelefono = "";
            aMonto = 0.0;
        }

        public cCliente(string pDNI, string pNombres, DateTime pFechaNacimiento, bool pDiscapacidad, int pNinos, string pEmail, string pTelefono, double pMonto)
        {
            aDNI = pDNI;
            aNombres = pNombres;
            aFechaNacimiento = pFechaNacimiento;
            aDiscapacidad = pDiscapacidad;
            aNinos = pNinos;
            aEmail = pEmail;
            aTelefono = pTelefono;
            aMonto = pMonto >= 0 ? pMonto : 0.0;
        }
        #endregion ==================== CONSTRUCTORES =======================

        #region ==================== PROPIEDADES =======================
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

        public DateTime FechaNacimiento
        {
            get { return aFechaNacimiento; }
            set { aFechaNacimiento = value; }
        }

        public bool Discapacidad
        {
            get { return aDiscapacidad; }
            set { aDiscapacidad = value; }
        }

        public int Ninos
        {
            get { return aNinos; }
            set { aNinos = value >= 0 ? value : 0; }
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

        public double Monto
        {
            get { return aMonto; }
            set { aMonto = value >= 0 ? value : 0.0; }
        }
        #endregion ==================== PROPIEDADES =======================

        #region ==================== MÉTODOS PROCESO =======================
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
            Console.WriteLine("INGRESAR DATOS DEL CLIENTE");
            Console.WriteLine("=========================");
            Console.Write("DNI: ");
            aDNI = Console.ReadLine();
            Console.Write("Nombres: ");
            aNombres = Console.ReadLine();
            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out aFechaNacimiento);
            Console.Write("¿Tiene discapacidad? (s/n): ");
            string r = Console.ReadLine();
            aDiscapacidad = (r != null && (r.ToLower().StartsWith("s") || r == "1"));
            Console.Write("Número de niños a cargo: ");
            int.TryParse(Console.ReadLine(), out aNinos);
            Console.Write("Email: ");
            aEmail = Console.ReadLine();
            Console.Write("Teléfono: ");
            aTelefono = Console.ReadLine();
            Console.Write("Monto: ");
            double.TryParse(Console.ReadLine(), out aMonto);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE CLIENTE");
            Console.WriteLine("================");
            Console.WriteLine("DNI: " + aDNI);
            Console.WriteLine("Nombres: " + aNombres);
            Console.WriteLine("Fecha Nac.: " + (aFechaNacimiento == DateTime.MinValue ? "" : aFechaNacimiento.ToShortDateString()));
            Console.WriteLine("Discapacidad: " + (aDiscapacidad ? "Sí" : "No"));
            Console.WriteLine("Niños: " + aNinos);
            Console.WriteLine("Email: " + aEmail);
            Console.WriteLine("Teléfono: " + aTelefono);
            Console.WriteLine("Monto: " + aMonto.ToString("F2"));
        }

        public void Escribir()
        {
            Console.WriteLine(aDNI.PadRight(12) + Nombres.PadRight(25) + (aFechaNacimiento == DateTime.MinValue ? "".PadRight(12) : aFechaNacimiento.ToShortDateString().PadRight(12)) +
                (Discapacidad ? "SI".PadRight(10) : "NO".PadRight(10)) + Ninos.ToString().PadRight(6) + Email.PadRight(25) + Telefono.PadRight(15) + Monto.ToString("F2").PadLeft(10));
        }
        #endregion ==================== MÉTODOS PROCESO =======================

        #endregion *********************** METODOS ************************
    }
}
