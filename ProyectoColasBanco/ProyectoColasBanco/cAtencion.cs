using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public class cAtencion
    {
        #region ATRIBUTOS
        private string aNroTicket;
        private DateTime aFechaHora;
        private string aIdCliente; 
        private string aIdCajero;  
        private string aIdServicio;
        private double aMonto;
        private int aSegundos;
        #endregion

        #region CONSTRUCTORES
        public cAtencion()
        {
            aNroTicket = "";
            aFechaHora = DateTime.MinValue;
            aIdCliente = "";
            aIdCajero = "";
            aIdServicio = "";
            aMonto = 0.0;
            aSegundos = 0;
        }

        public cAtencion(string pNroTicket, DateTime pFechaHora, string pIdCliente, string pIdCajero, string pIdServicio, double pMonto, int pSegundos)
        {
            aNroTicket = pNroTicket;
            aFechaHora = pFechaHora;
            aIdCliente = pIdCliente;
            aIdCajero = pIdCajero;
            aIdServicio = pIdServicio;
            aMonto = pMonto >= 0 ? pMonto : 0.0;
            aSegundos = pSegundos >= 0 ? pSegundos : 0;
        }
        #endregion

        #region PROPIEDADES
        public string NroTicket
        {
            get { return aNroTicket; }
            set { aNroTicket = value; }
        }

        public DateTime FechaHora
        {
            get { return aFechaHora; }
            set { aFechaHora = value; }
        }

        public string IdCliente
        {
            get { return aIdCliente; }
            set { aIdCliente = value; }
        }

        public string IdCajero
        {
            get { return aIdCajero; }
            set { aIdCajero = value; }
        }

        public string IdServicio
        {
            get { return aIdServicio; }
            set { aIdServicio = value; }
        }

        public double Monto
        {
            get { return aMonto; }
            set { aMonto = value >= 0 ? value : 0.0; }
        }

        public int Segundos
        {
            get { return aSegundos; }
            set { aSegundos = value >= 0 ? value : 0; }
        }
        #endregion

        #region MÉTODOS
        public override string ToString()
        {
            return aNroTicket;
        }

        public override bool Equals(object O)
        {
            return aNroTicket.Equals(O.ToString());
        }

        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DE ATENCION");
            Console.WriteLine("==========================");
            Console.Write("Nro Ticket: ");
            aNroTicket = Console.ReadLine();
            Console.Write("Fecha y Hora (yyyy-MM-dd HH:mm): ");
            DateTime.TryParse(Console.ReadLine(), out aFechaHora);
            Console.Write("DNI Cliente: ");
            aIdCliente = Console.ReadLine();
            Console.Write("DNI Cajero: ");
            aIdCajero = Console.ReadLine();
            Console.Write("Id Servicio: ");
            aIdServicio = Console.ReadLine();
            Console.Write("Monto: ");
            double.TryParse(Console.ReadLine(), out aMonto);
            Console.Write("Segundos (duración de atención): ");
            int.TryParse(Console.ReadLine(), out aSegundos);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE ATENCION");
            Console.WriteLine("=================");
            Console.WriteLine("Nro Ticket: " + aNroTicket);
            Console.WriteLine("Fecha y Hora: " + (aFechaHora == DateTime.MinValue ? "" : aFechaHora.ToString("g")));
            Console.WriteLine("DNI Cliente: " + aIdCliente);
            Console.WriteLine("DNI Cajero: " + aIdCajero);
            Console.WriteLine("Id Servicio: " + aIdServicio);
            Console.WriteLine("Monto: " + aMonto.ToString("F2"));
            Console.WriteLine("Segundos: " + aSegundos);
        }

        public void Escribir()
        {
            Console.WriteLine(NroTicket.PadRight(12) + (FechaHora == DateTime.MinValue ? "".PadRight(20) : FechaHora.ToString("g").PadRight(20)) +
                IdCliente.PadRight(12) + IdCajero.PadRight(12) + IdServicio.PadRight(12) + Monto.ToString("F2").PadLeft(10) + Segundos.ToString().PadLeft(8));
        }
        #endregion
    }
}
