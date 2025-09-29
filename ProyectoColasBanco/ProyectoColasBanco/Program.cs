using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoColasBanco
{
    class Program
    {
        static List<cCliente> clientes = new List<cCliente>();
        static List<cCajero> cajeros = new List<cCajero>();
        static List<cServicio> servicios = new List<cServicio>();
        static List<cAtencion> atenciones = new List<cAtencion>();
        static List<cVentanilla> ventanillas = new List<cVentanilla>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Registrar Cajero");
                Console.WriteLine("3. Registrar Servicio");
                Console.WriteLine("4. Registrar Atención");
                Console.WriteLine("5. Registrar Ventanilla");
                Console.WriteLine("6. Listar Clientes");
                Console.WriteLine("7. Listar Cajeros");
                Console.WriteLine("8. Listar Servicios");
                Console.WriteLine("9. Listar Atenciones");
                Console.WriteLine("10. Listar Ventanillas");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        var cliente = new cCliente();
                        cliente.Leer();   // Usa el método de la clase
                        clientes.Add(cliente);
                        break;
                    case 2:
                        var cajero = new cCajero();
                        cajero.Leer();
                        cajeros.Add(cajero);
                        break;
                    case 3:
                        var servicio = new cServicio();
                        servicio.Leer();
                        servicios.Add(servicio);
                        break;
                    case 4:
                        var atencion = new cAtencion();
                        atencion.Leer();
                        atenciones.Add(atencion);
                        break;
                    case 5:
                        var ventanilla = new cVentanilla();
                        ventanilla.Leer();
                        ventanillas.Add(ventanilla);
                        break;
                    case 6:
                        Console.WriteLine("\n=== CLIENTES ===");
                        foreach (var c in clientes) c.Mostrar();
                        break;
                    case 7:
                        Console.WriteLine("\n=== CAJEROS ===");
                        foreach (var c in cajeros) c.Mostrar();
                        break;
                    case 8:
                        Console.WriteLine("\n=== SERVICIOS ===");
                        foreach (var s in servicios) s.Mostrar();
                        break;
                    case 9:
                        Console.WriteLine("\n=== ATENCIONES ===");
                        foreach (var a in atenciones) a.Mostrar();
                        break;
                    case 10:
                        Console.WriteLine("\n=== VENTANILLAS ===");
                        foreach (var v in ventanillas) v.Mostrar();
                        break;
                }

            } while (opcion != 0);
        }
    }
}
