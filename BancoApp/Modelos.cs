using System;

namespace BancoApp
{
    public class Cliente
    {
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Discapacidad { get; set; }
        public int Niños { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public decimal Monto { get; set; }

        public int CalcularPrioridad()
        {
            if (Niños > 0) return 1;
            if (CalcularEdad() >= 60 || Discapacidad) return 2;
            return 3;
        }

        public int CalcularTiempoAtencion()
        {
            if (Niños > 0) return 5;
            if (CalcularEdad() >= 60) return 7;
            if (Discapacidad) return 6;
            return new Random().Next(3, 6); // Entre 3 y 5 segundos
        }

        private int CalcularEdad()
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }

    public class Cajero
    {
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }

    public class Servicio
    {
        public string IdServicio { get; set; }
        public string Descripcion { get; set; }
    }

    public class Atencion
    {
        public string NroTicket { get; set; }
        public DateTime FechaHora { get; set; }
        public string IdCliente { get; set; }
        public string IdCajero { get; set; }
        public string IdServicio { get; set; }
        public decimal Monto { get; set; }
        public int Segundos { get; set; }
    }

    public class Ventanilla
    {
        public int NroVentanilla { get; set; }
        public string DNICajero { get; set; }
        public string DNICliente { get; set; }
        public string NroTicket { get; set; }
        public bool Preferencial { get; set; }
        public bool Atendido { get; set; }
        public int TiempoRestante { get; set; }

        public void AsignarCliente(string dniCliente, string nroTicket, int tiempoAtencion)
        {
            DNICliente = dniCliente;
            NroTicket = nroTicket;
            Atendido = true;
            TiempoRestante = tiempoAtencion;
        }

        public void Liberar()
        {
            DNICliente = null;
            NroTicket = null;
            Atendido = false;
            TiempoRestante = 0;
        }
    }
}
