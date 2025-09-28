using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public class cVentanilla
    {
        #region ATRIBUTOS
        private int aNroVentanilla;
        private string aDNI_Cajero;
        private string aDNI_Cliente;
        private string aNroTicket;
        private bool aPreferencial;
        private bool aAtendido;
        #endregion

        #region CONSTRUCTORES
        public cVentanilla()
        {
            aNroVentanilla = 0;
            aDNI_Cajero = "";
            aDNI_Cliente = "";
            aNroTicket = "";
            aPreferencial = false;
            aAtendido = false;
        }

        public cVentanilla(int pNroVentanilla, string pDNI_Cajero, string pDNI_Cliente, string pNroTicket, bool pPreferencial, bool pAtendido)
        {
            aNroVentanilla = pNroVentanilla;
            aDNI_Cajero = pDNI_Cajero;
            aDNI_Cliente = pDNI_Cliente;
            aNroTicket = pNroTicket;
            aPreferencial = pPreferencial;
            aAtendido = pAtendido;
        }
        #endregion

        #region PROPIEDADES
        public int NroVentanilla
        {
            get { return aNroVentanilla; }
            set { aNroVentanilla = value >= 0 ? value : 0; }
        }

        public string DNI_Cajero
        {
            get { return aDNI_Cajero; }
            set { aDNI_Cajero = value; }
        }

        public string DNI_Cliente
        {
            get { return aDNI_Cliente; }
            set { aDNI_Cliente = value; }
        }

        public string NroTicket
        {
            get { return aNroTicket; }
            set { aNroTicket = value; }
        }

        public bool Preferencial
        {
            get { return aPreferencial; }
            set { aPreferencial = value; }
        }

        public bool Atendido
        {
            get { return aAtendido; }
            set { aAtendido = value; }
        }
        #endregion

        #region MÉTODOS
        public override string ToString()
        {
            return aNroVentanilla.ToString();
        }

        public override bool Equals(object O)
        {
            return aNroVentanilla.ToString().Equals(O.ToString());
        }
        public override int GetHashCode()
        {
            return aNroVentanilla.GetHashCode();
        }
        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DE VENTANILLA");
            Console.WriteLine("============================");
            Console.Write("Nro Ventanilla: ");
            int.TryParse(Console.ReadLine(), out aNroVentanilla);
            Console.Write("DNI Cajero: ");
            aDNI_Cajero = Console.ReadLine();
            Console.Write("DNI Cliente: ");
            aDNI_Cliente = Console.ReadLine();
            Console.Write("Nro Ticket: ");
            aNroTicket = Console.ReadLine();
            Console.Write("¿Preferencial? (s/n): ");
            string r = Console.ReadLine();
            aPreferencial = (r != null && (r.ToLower().StartsWith("s") || r == "1"));
            Console.Write("¿Atendido? (s/n): ");
            r = Console.ReadLine();
            aAtendido = (r != null && (r.ToLower().StartsWith("s") || r == "1"));
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE VENTANILLA");
            Console.WriteLine("===================");
            Console.WriteLine("Nro Ventanilla: " + aNroVentanilla);
            Console.WriteLine("DNI Cajero: " + aDNI_Cajero);
            Console.WriteLine("DNI Cliente: " + aDNI_Cliente);
            Console.WriteLine("Nro Ticket: " + aNroTicket);
            Console.WriteLine("Preferencial: " + (aPreferencial ? "Sí" : "No"));
            Console.WriteLine("Atendido: " + (aAtendido ? "Sí" : "No"));
        }

        public void Escribir()
        {
            Console.WriteLine(NroVentanilla.ToString().PadRight(8) + DNI_Cajero.PadRight(12) + DNI_Cliente.PadRight(12) + NroTicket.PadRight(12) + (Preferencial ? "SI".PadRight(12) : "NO".PadRight(12)) + (Atendido ? "SI" : "NO"));
        }
        #endregion
    }
}

