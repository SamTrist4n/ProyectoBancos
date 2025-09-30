using System;
using System.IO;
using System.Linq;

namespace ProyectoColasBanco
{
    class Program
    {
        static SistemaBanco sistema;
        static CsvLoader loader;

        static void Main(string[] args)
        {
            sistema = new SistemaBanco();
            loader = new CsvLoader(sistema);

            // Intentar cargar archivos desde la carpeta de ejecución (bin)
            CargarCsvInicial();

            MostrarMenu();
        }

        //agreguemos los archivos csv dentro del proyecto en github, no lo tengo descargado xd
        //cosa que si se clona el proyecto , se copien los archivos csv a la carpeta bin
        //y no tendremos que descargar uno por uno aparte

        static void CargarCsvInicial()
        {
            Console.WriteLine("Buscando CSV en carpeta de ejecución: " + AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                // Si quieres que CargarTodo use nombres relativos (esperados por tu CsvLoader), solo posiciona los CSV en bin.
                // Tu CsvLoader.CargarTodo() llama a CargarClientes("Clientes.csv") etc.
                loader.CargarTodo();
                Console.WriteLine("Carga inicial completada.");
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("No se encontró algún CSV: " + fnf.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar CSVs: " + ex.Message);
            }
        }

        static void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Registrar Cajero");
                Console.WriteLine("3. Registrar Servicio");
                Console.WriteLine("4. Registrar Atención (manual)");
                Console.WriteLine("5. Registrar Ventanilla");
                Console.WriteLine("6. Listar Clientes");
                Console.WriteLine("7. Listar Cajeros");
                Console.WriteLine("8. Listar Servicios");
                Console.WriteLine("9. Listar Atenciones");
                Console.WriteLine("10. Listar Ventanillas");
                Console.WriteLine("11. Configurar Ventanillas (normales / preferenciales)");
                Console.WriteLine("12. Procesar atenciones (una iteración)");
                Console.WriteLine("13. Exportar reporte transacciones (últimos 2 meses)");
                Console.WriteLine("14. Exportar reporte ventanillas");
                Console.WriteLine("15. Recargar CSVs (desde bin)");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                try
                {
                    switch (opcion)
                    {
                        case 1: RegistrarCliente(); break;
                        case 2: RegistrarCajero(); break;
                        case 3: RegistrarServicio(); break;
                        case 4: RegistrarAtencionManual(); break;
                        case 5: RegistrarVentanilla(); break;
                        case 6: ListarClientes(); break;
                        case 7: ListarCajeros(); break;
                        case 8: ListarServicios(); break;
                        case 9: ListarAtenciones(); break;
                        case 10: ListarVentanillas(); break;
                        case 11: ConfigurarVentanillas(); break;
                        case 12: ProcesarAtencionesUnaVez(); break;
                        case 13: ExportarTransacciones(); break;
                        case 14: ExportarVentanillas(); break;
                        case 15: CargarCsvInicial(); break;
                        case 0: break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }

            } while (opcion != 0);
        }

        #region Registrar
        static void RegistrarCliente()
        {
            var c = new Cliente();
            c.Leer();
            sistema.Clientes.Agregar(c);
            Console.WriteLine("Cliente agregado.");
        }

        static void RegistrarCajero()
        {
            var caj = new Cajero();
            caj.Leer();
            sistema.Cajeros.Agregar(caj);
            Console.WriteLine("Cajero agregado.");
        }

        static void RegistrarServicio()
        {
            var s = new Servicio();
            s.Leer();
            sistema.Servicios.Agregar(s);
            Console.WriteLine("Servicio agregado.");
        }

        static void RegistrarAtencionManual()
        {
            var a = new Atencion();
            a.Leer();
            sistema.Atenciones.Agregar(a);
            Console.WriteLine("Atención manual agregada.");
        }

        static void RegistrarVentanilla()
        {
            var v = new Ventanilla();
            v.Leer();
            sistema.Ventanillas.Add(v);
            Console.WriteLine("Ventanilla agregada.");
        }
        #endregion

        #region Listados
        static void ListarClientes()
        {
            Console.WriteLine("\n=== CLIENTES ===");
            Console.WriteLine("DNI\tNombres\tFecha Nacimiento\tDiscapacidad\tNiños\tEmail\tTeléfono\tMonto");
            var todos = sistema.Clientes.ObtenerTodos();
            foreach (var c in todos) c.Escribir();
        }

        static void ListarCajeros()
        {
            Console.WriteLine("\n=== CAJEROS ===");
            Console.WriteLine("DNI\tNombres\tDirección\tEmail\tTeléfono");
            var todos = sistema.Cajeros.ObtenerTodos();
            foreach (var c in todos) c.Escribir();
        }

        static void ListarServicios()
        {
            Console.WriteLine("\n=== SERVICIOS ===");
            Console.WriteLine("ID\tDescripción");
            var todos = sistema.Servicios.ObtenerTodos();
            foreach (var s in todos) s.Escribir();
        }

        static void ListarAtenciones()
        {
            Console.WriteLine("\n=== ATENCIONES ===");
            Console.WriteLine("Ticket\tFechaHora\tCliente\tCajero\tServicio\tMonto\tSegundos");
            var todos = sistema.Atenciones.ObtenerTodos();
            foreach (var a in todos) a.Escribir();
        }

        static void ListarVentanillas()
        {
            Console.WriteLine("\n=== VENTANILLAS ===");
            Console.WriteLine("Nro\tCajero\tCliente\tTicket\tPreferencial\tAtendido\tTiempoRestante");
            foreach (var v in sistema.Ventanillas) v.Escribir();
        }
        #endregion


        #region Otras acciones
        static void ConfigurarVentanillas()
        {
            Console.Write("Número de ventanillas normales: ");
            int normales = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Número de ventanillas preferenciales: ");
            int preferenciales = int.Parse(Console.ReadLine() ?? "0");

            sistema.ConfigurarVentanillas(normales, preferenciales);
            Console.WriteLine("Ventanillas configuradas.");
        }

        static void ProcesarAtencionesUnaVez()
        {
            sistema.ProcesarAtenciones();
            Console.WriteLine("Procesamiento de atenciones ejecutado (una iteración).");
        }

        static void ExportarTransacciones()
        {
            Console.Write("Ruta archivo de salida (ej: transacciones.csv): ");
            var ruta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ruta)) ruta = "transacciones.csv";
            sistema.ExportarReporteTransacciones(ruta);
            Console.WriteLine("Reporte exportado a: " + Path.GetFullPath(ruta));
        }

        static void ExportarVentanillas()
        {
            Console.Write("Ruta archivo de salida (ej: ventanillas.csv): ");
            var ruta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ruta)) ruta = "ventanillas.csv";
            sistema.ExportarReporteVentanillas(ruta);
            Console.WriteLine("Reporte exportado a: " + Path.GetFullPath(ruta));
        }
        #endregion
    }
}
