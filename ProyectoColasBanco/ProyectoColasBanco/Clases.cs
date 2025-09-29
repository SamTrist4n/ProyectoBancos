using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
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

        // ----------------------- I/O --------------------------------

        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DEL CLIENTE");
            Console.WriteLine("==========================");

            Console.Write("DNI: ");
            DNI = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nombres: ");
            Nombres = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Fecha de Nacimiento (dd/MM/yyyy) : ");
            var sFecha = Console.ReadLine();
            FechaNacimiento = ParseFechaDDMMYYYY(sFecha, DateTime.MinValue);

            Console.Write("¿Tiene discapacidad? (s/n): ");
            Discapacidad = ParseBoolFlexible(Console.ReadLine());

            Console.Write("Número de niños a cargo: ");
            Niños = ParseIntSafe(Console.ReadLine(), 0);

            Console.Write("Email: ");
            Email = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Teléfono: ");
            Telefono = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Monto: ");
            Monto = ParseDecimalSafe(Console.ReadLine(), 0m);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DEL CLIENTE");
            Console.WriteLine("=================");
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Fecha Nac.: " + (FechaNacimiento == DateTime.MinValue ? "" : FechaNacimiento.ToString("dd/MM/yyyy")));
            Console.WriteLine("Discapacidad: " + (Discapacidad ? "Sí" : "No"));
            Console.WriteLine("Niños: " + Niños);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Teléfono: " + Telefono);
            Console.WriteLine("Monto: " + Monto.ToString("F2", CultureInfo.InvariantCulture));
        }

        public void Escribir()
        {
            Console.WriteLine(
                (DNI ?? "").PadRight(12) +
                (Nombres ?? "").PadRight(25) +
                (FechaNacimiento == DateTime.MinValue ? "".PadRight(12) : FechaNacimiento.ToString("dd/MM/yyyy").PadRight(12)) +
                (Discapacidad ? "SI".PadRight(10) : "NO".PadRight(10)) +
                Niños.ToString().PadRight(6) +
                (Email ?? "").PadRight(25) +
                (Telefono ?? "").PadRight(15) +
                Monto.ToString("F2", CultureInfo.InvariantCulture).PadLeft(10)
            );
        }

        public override string ToString() => DNI;

        // ---------- helpers ----------
        private DateTime ParseFechaDDMMYYYY(string s, DateTime defecto)
        {
            if (string.IsNullOrWhiteSpace(s)) return defecto;
            s = s.Trim();
            DateTime dt;
            // Primero forzamos dd/MM/yyyy y dd/MM/yyyy HH:mm
            string[] formatosPreferidos = { "dd/MM/yyyy", "dd/MM/yyyy HH:mm" };
            foreach (var f in formatosPreferidos)
            {
                if (DateTime.TryParseExact(s, f, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    return dt;
            }
            // Luego intentamos algunos formatos alternativos como respaldo
            string[] formatosAlt = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm", "s" };
            foreach (var f in formatosAlt)
            {
                if (DateTime.TryParseExact(s, f, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    return dt;
            }
            if (DateTime.TryParse(s, out dt)) return dt;
            return defecto;
        }

        private bool ParseBoolFlexible(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim().ToLower();
            if (s == "s" || s == "si" || s == "sí" || s == "1" || s == "true") return true;
            return false;
        }

        private int ParseIntSafe(string s, int def)
        {
            if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
            if (int.TryParse(s, out v)) return v;
            return def;
        }

        private decimal ParseDecimalSafe(string s, decimal def)
        {
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
            if (decimal.TryParse(s, out v)) return v;
            return def;
        }
    }

    public class Cajero
    {
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // ----------------------- I/O --------------------------------
        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DEL CAJERO");
            Console.WriteLine("=========================");

            Console.Write("DNI: ");
            DNI = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nombres: ");
            Nombres = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Dirección: ");
            Direccion = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Email: ");
            Email = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Teléfono: ");
            Telefono = Console.ReadLine()?.Trim() ?? "";
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DEL CAJERO");
            Console.WriteLine("================");
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Teléfono: " + Telefono);
        }

        public void Escribir()
        {
            Console.WriteLine(
                (DNI ?? "").PadRight(12) +
                (Nombres ?? "").PadRight(25) +
                (Direccion ?? "").PadRight(30) +
                (Email ?? "").PadRight(25) +
                (Telefono ?? "").PadRight(15)
            );
        }

        public override string ToString() => DNI;
    }

    public class Servicio
    {
        public string IdServicio { get; set; }
        public string Descripcion { get; set; }

        // ----------------------- I/O --------------------------------
        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DEL SERVICIO");
            Console.WriteLine("===========================");

            Console.Write("Id Servicio: ");
            IdServicio = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Descripción: ");
            Descripcion = Console.ReadLine()?.Trim() ?? "";
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DEL SERVICIO");
            Console.WriteLine("==================");
            Console.WriteLine("Id Servicio: " + IdServicio);
            Console.WriteLine("Descripción: " + Descripcion);
        }

        public void Escribir()
        {
            Console.WriteLine((IdServicio ?? "").PadRight(12) + (Descripcion ?? "").PadRight(50));
        }

        public override string ToString() => IdServicio;
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

        // ----------------------- I/O --------------------------------
        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DE ATENCION");
            Console.WriteLine("==========================");

            Console.Write("Nro Ticket: ");
            NroTicket = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Fecha y Hora (dd/MM/yyyy HH:mm o dd/MM/yyyy): ");
            FechaHora = ParseFechaDDMMYYYY(Console.ReadLine(), DateTime.Now);

            Console.Write("DNI Cliente: ");
            IdCliente = Console.ReadLine()?.Trim() ?? "";

            Console.Write("DNI Cajero: ");
            IdCajero = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Id Servicio: ");
            IdServicio = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Monto: ");
            Monto = ParseDecimalSafe(Console.ReadLine(), 0m);

            Console.Write("Segundos (duración en segundos): ");
            Segundos = ParseIntSafe(Console.ReadLine(), 0);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE ATENCION");
            Console.WriteLine("=================");
            Console.WriteLine("Nro Ticket: " + NroTicket);
            Console.WriteLine("Fecha y Hora: " + FechaHora.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine("DNI Cliente: " + IdCliente);
            Console.WriteLine("DNI Cajero: " + IdCajero);
            Console.WriteLine("Id Servicio: " + IdServicio);
            Console.WriteLine("Monto: " + Monto.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Segundos: " + Segundos);
        }

        public void Escribir()
        {
            Console.WriteLine(
                (NroTicket ?? "").PadRight(12) +
                (FechaHora.ToString("dd/MM/yyyy HH:mm")).PadRight(20) +
                (IdCliente ?? "").PadRight(12) +
                (IdCajero ?? "").PadRight(12) +
                (IdServicio ?? "").PadRight(12) +
                Monto.ToString("F2", CultureInfo.InvariantCulture).PadLeft(10) +
                Segundos.ToString().PadLeft(8)
            );
        }

        public override string ToString() => NroTicket;

        // ---------- helpers ----------
        private DateTime ParseFechaDDMMYYYY(string s, DateTime defecto)
        {
            if (string.IsNullOrWhiteSpace(s)) return defecto;
            s = s.Trim();
            DateTime dt;
            string[] formatosPreferidos = { "dd/MM/yyyy HH:mm", "dd/MM/yyyy" };
            foreach (var f in formatosPreferidos)
            {
                if (DateTime.TryParseExact(s, f, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    return dt;
            }
            // respaldo
            if (DateTime.TryParse(s, out dt)) return dt;
            return defecto;
        }

        private int ParseIntSafe(string s, int def)
        {
            if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
            if (int.TryParse(s, out v)) return v;
            return def;
        }

        private decimal ParseDecimalSafe(string s, decimal def)
        {
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
            if (decimal.TryParse(s, out v)) return v;
            return def;
        }
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

        // ----------------------- I/O --------------------------------
        public void Leer()
        {
            Console.WriteLine();
            Console.WriteLine("INGRESAR DATOS DE VENTANILLA");
            Console.WriteLine("============================");

            Console.Write("Nro Ventanilla: ");
            NroVentanilla = ParseIntSafe(Console.ReadLine(), 0);

            Console.Write("DNI Cajero: ");
            DNICajero = Console.ReadLine()?.Trim() ?? "";

            Console.Write("DNI Cliente (opcional): ");
            DNICliente = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nro Ticket (opcional): ");
            NroTicket = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Preferencial? (s/n): ");
            Preferencial = ParseBoolFlexible(Console.ReadLine());

            Console.Write("Atendido? (s/n): ");
            Atendido = ParseBoolFlexible(Console.ReadLine());

            Console.Write("Tiempo Restante (segundos): ");
            TiempoRestante = ParseIntSafe(Console.ReadLine(), 0);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("DATOS DE VENTANILLA");
            Console.WriteLine("===================");
            Console.WriteLine("Nro Ventanilla: " + NroVentanilla);
            Console.WriteLine("DNI Cajero: " + DNICajero);
            Console.WriteLine("DNI Cliente: " + DNICliente);
            Console.WriteLine("Nro Ticket: " + NroTicket);
            Console.WriteLine("Preferencial: " + (Preferencial ? "Sí" : "No"));
            Console.WriteLine("Atendido: " + (Atendido ? "Sí" : "No"));
            Console.WriteLine("Tiempo Restante: " + TiempoRestante + "s");
        }

        public void Escribir()
        {
            Console.WriteLine(
                NroVentanilla.ToString().PadRight(8) +
                (DNICajero ?? "").PadRight(12) +
                (DNICliente ?? "").PadRight(12) +
                (NroTicket ?? "").PadRight(12) +
                (Preferencial ? "SI".PadRight(12) : "NO".PadRight(12)) +
                (Atendido ? "SI".PadRight(6) : "NO".PadRight(6)) +
                TiempoRestante.ToString().PadLeft(6)
            );
        }

        public override string ToString() => NroVentanilla.ToString();

        // helpers
        private bool ParseBoolFlexible(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim().ToLower();
            if (s == "s" || s == "si" || s == "sí" || s == "1" || s == "true") return true;
            return false;
        }

        private int ParseIntSafe(string s, int def)
        {
            if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
            if (int.TryParse(s, out v)) return v;
            return def;
        }
    }
}
