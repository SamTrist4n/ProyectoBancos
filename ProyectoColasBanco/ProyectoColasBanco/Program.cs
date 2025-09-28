using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    public static class DataStore
    {
        public static List<cCliente> Clientes { get; } = new List<cCliente>();
        public static List<cCajero> Cajeros { get; } = new List<cCajero>();
        public static List<cServicio> Servicios { get; } = new List<cServicio>();
        public static List<cAtencion> Atenciones { get; } = new List<cAtencion>();
        public static List<cVentanilla> Ventanillas { get; } = new List<cVentanilla>();
    }


    // Managers (módulos) para operaciones CRUD y listados — usan tus clases originales
    public static class ClienteManager
    {
        public static void Registrar(cCliente c)
        {
            if (DataStore.Clientes.Any(x => x.DNI.Equals(c.DNI))) throw new InvalidOperationException("Cliente ya existe.");
            DataStore.Clientes.Add(c);
        }


        public static IEnumerable<cCliente> Listar() => DataStore.Clientes;


        public static cCliente Obtener(string dni) => DataStore.Clientes.FirstOrDefault(x => x.DNI == dni);
    }


    public static class CajeroManager
    {
        public static void Registrar(cCajero c)
        {
            if (DataStore.Cajeros.Any(x => x.DNI.Equals(c.DNI))) throw new InvalidOperationException("Cajero ya existe.");
            DataStore.Cajeros.Add(c);
        }


        public static IEnumerable<cCajero> Listar() => DataStore.Cajeros;


        public static cCajero Obtener(string dni) => DataStore.Cajeros.FirstOrDefault(x => x.DNI == dni);
    }


    public static class ServicioManager
    {
        public static void Registrar(cServicio s)
        {
            if (DataStore.Servicios.Any(x => x.IdServicio.Equals(s.IdServicio))) throw new InvalidOperationException("Servicio ya existe.");
            DataStore.Servicios.Add(s);
        }


        public static IEnumerable<cServicio> Listar() => DataStore.Servicios;


        public static cServicio Obtener(string id) => DataStore.Servicios.FirstOrDefault(x => x.IdServicio == id);
    }
}
internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bananita Dolphinita, LOL");
            Console.WriteLine("Esto11111111111 es necesariopppppp");

        }
    }
}
