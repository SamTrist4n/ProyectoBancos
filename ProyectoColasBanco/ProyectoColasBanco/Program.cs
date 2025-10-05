// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        static void CargarCsvInicial()
        {
            Console.WriteLine("Buscando CSV en carpeta de ejecución: " + AppDomain.CurrentDomain.BaseDirectory);

            try
            {
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
                Console.WriteLine("16. Simulación gráfica (con cola y ventanillas)");
                Console.WriteLine("17. Descargar archivos CSV necesarios"); // Nueva opción
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
                        case 16: Simulacion.Run(sistema); break;
                        case 17: DescargarCsvs(); break; 
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

        // Nuevo método para descargar los CSVs necesarios
        static void DescargarCsvs()
        {
            var archivos = new Dictionary<string, string>
            {
                { "clientes.csv", "https://raw.githubusercontent.com/SamTrist4n/ProyectoBancos/main/Clientes.csv" },
                { "cajeros.csv", "https://raw.githubusercontent.com/SamTrist4n/ProyectoBancos/main/Cajeros.csv" },
                { "servicios.csv", "https://raw.githubusercontent.com/SamTrist4n/ProyectoBancos/main/Servicios.csv" },
                { "ventanillas.csv", "https://raw.githubusercontent.com/SamTrist4n/ProyectoBancos/main/Ventanillas.csv" },
                { "atenciones.csv", "https://raw.githubusercontent.com/SamTrist4n/ProyectoBancos/main/Atenciones.csv" }
            };

            string carpetaBin = AppDomain.CurrentDomain.BaseDirectory;
            using (var http = new HttpClient())
            {
                foreach (var kvp in archivos)
                {
                    string destino = Path.Combine(carpetaBin, kvp.Key);
                    try
                    {
                        Console.WriteLine($"Descargando {kvp.Key}...");
                        var contenido = http.GetByteArrayAsync(kvp.Value).GetAwaiter().GetResult();
                        File.WriteAllBytes(destino, contenido);
                        Console.WriteLine($"Archivo {kvp.Key} guardado en {destino}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al descargar {kvp.Key}: {ex.Message}");
                    }
                }
            }
            Console.WriteLine("Descarga de archivos CSV completada.");
            Console.WriteLine("Presiona una tecla para volver al menú...");
            Console.ReadKey(true);
            Console.Clear(); // Limpia la pantalla antes de mostrar el menú de nuevo
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
            Console.WriteLine("DNI".PadRight(12) + "Nombres".PadRight(25) + "F.Nac".PadRight(12) + "Disc".PadRight(6) + "Niños".PadRight(6) + "Email".PadRight(25) + "Tel".PadRight(15) + "Monto".PadLeft(10));
            var todos = sistema.Clientes.ObtenerTodos();
            foreach (var c in todos) c.Escribir();
        }

        static void ListarCajeros()
        {
            Console.WriteLine("\n=== CAJEROS ===");
            Console.WriteLine("DNI".PadRight(12) + "Nombres".PadRight(25) + "Dirección".PadRight(30) + "Email".PadRight(25) + "Tel".PadRight(15));
            var todos = sistema.Cajeros.ObtenerTodos();
            foreach (var c in todos) c.Escribir();
        }

        static void ListarServicios()
        {
            Console.WriteLine("\n=== SERVICIOS ===");
            Console.WriteLine("IdServicio".PadRight(12) + "Descripción".PadRight(50));
            var todos = sistema.Servicios.ObtenerTodos();
            foreach (var s in todos) s.Escribir();
        }

        static void ListarAtenciones()
        {
            Console.WriteLine("\n=== ATENCIONES ===");
            Console.WriteLine("Ticket".PadRight(12) + "FechaHora".PadRight(20) + "Cliente".PadRight(12) + "Cajero".PadRight(12) + "Servicio".PadRight(12) + "Monto".PadLeft(10) + "Segs".PadLeft(8));
            var todos = sistema.Atenciones.ObtenerTodos();
            foreach (var a in todos) a.Escribir();
        }

        static void ListarVentanillas()
        {
            Console.WriteLine("\n=== VENTANILLAS ===");
            Console.WriteLine("Nro".PadRight(6) + "DNI Cajero".PadRight(12) + "DNI Cliente".PadRight(12) + "Ticket".PadRight(12) + "Pref".PadRight(6) + "Atendido".PadRight(8) + "TiempoRest");
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

        public static class Simulacion
        {
            public static int TickMs = 800;      // ms por tick
            public static double ProbLlegada = 1.0;

            public static void Run(SistemaBanco sistema)
            {
                if (sistema == null) throw new ArgumentNullException(nameof(sistema));

                var rnd = new Random();
                bool running = true;
                bool paused = false;

                Console.Clear();
                Console.WriteLine("SIMULACIÓN SIMPLE (ultra) - Presiona Esc para volver al menú");
                Console.WriteLine("Controles: P = Pausa/Resume   A = Llegada forzada");
                Thread.Sleep(800);

                while (running)
                {
                    while (Console.KeyAvailable)
                    {
                        var k = Console.ReadKey(true).Key;
                        if (k == ConsoleKey.Escape) { running = false; break; }
                        if (k == ConsoleKey.P) { paused = !paused; }
                        if (k == ConsoleKey.A) { GenerarLlegada(sistema, rnd, true); }
                    }
                    if (!running) break;

                    if (!paused)
                    {
                        if (rnd.NextDouble() < ProbLlegada) GenerarLlegada(sistema, rnd, false);

                        // Lógica robusta de procesamiento de atenciones
                        ProcesarAtencionesRobusto(sistema);
                    }

                    Console.Clear();
                    Console.WriteLine("SIMULACIÓN SIMPLE (ultra)");
                    Console.WriteLine("Controles: P = Pausa/Resume   A = Llegada forzada   Esc = Salir");
                    Console.WriteLine(paused ? "*** PAUSADO ***" : "*** EN EJECUCIÓN ***");
                    Console.WriteLine();

                    Console.WriteLine("Ventanillas:");
                    if (sistema.Ventanillas.Count == 0)
                    {
                        Console.WriteLine("  (No hay ventanillas configuradas)");
                    }
                    else
                    {
                        foreach (var v in sistema.Ventanillas)
                        {
                            string caj = string.IsNullOrWhiteSpace(v.DNICajero) ? "-" : v.DNICajero;
                            string cli = string.IsNullOrWhiteSpace(v.DNICliente) ? "-" : v.DNICliente;
                            string tck = string.IsNullOrWhiteSpace(v.NroTicket) ? "-" : v.NroTicket;
                            Console.WriteLine($"  V{v.NroVentanilla} | Cajero: {caj} | Cliente: {cli} | Ticket: {tck} | Pref: {(v.Preferencial ? "S" : "N")} | TR: {v.TiempoRestante}s");
                        }
                    }

                    Console.WriteLine();
                    
                    var totalAt = sistema.Atenciones.ObtenerTodos()?.Count() ?? 0;
                    Console.WriteLine($"Atenciones registradas: {totalAt}");

                    Console.WriteLine();
                    Console.WriteLine($"Hora: {DateTime.Now:HH:mm:ss}");
                    Thread.Sleep(TickMs);
                }

                Console.WriteLine("\nSaliendo de la simulación. Presiona una tecla para continuar...");
                Console.ReadKey(true);
            }

            // Lógica robusta de procesamiento de atenciones
            private static void ProcesarAtencionesRobusto(SistemaBanco sistema)
            {
                // 1. Actualizar tiempos y liberar ventanillas si corresponde
                foreach (var ventanilla in sistema.Ventanillas)
                {
                    if (ventanilla.Atendido && !string.IsNullOrEmpty(ventanilla.DNICliente))
                    {
                        ventanilla.TiempoRestante--;
                        if (ventanilla.TiempoRestante <= 0)
                        {
                            ventanilla.Liberar();
                        }
                    }
                }

                // 2. Asignar clientes a ventanillas libres
                foreach (var ventanilla in sistema.Ventanillas)
                {
                    if (!ventanilla.Atendido || string.IsNullOrEmpty(ventanilla.DNICliente))
                    {
                        Cliente cliente = null;
                        int prioridad = 0;
                        // Preferencial primero si la ventanilla es preferencial
                        if (ventanilla.Preferencial && !sistema.ColaPreferencial.EstaVacia())
                        {
                            cliente = sistema.ColaPreferencial.Desencolar();
                            prioridad = 1;
                        }
                        // Si no, normal
                        else if (!sistema.ColaNormal.EstaVacia())
                        {
                            cliente = sistema.ColaNormal.Desencolar();
                            prioridad = 3;
                        }
                        // Si la ventanilla es normal y la preferencial tiene clientes, también puede atenderlos
                        else if (!ventanilla.Preferencial && !sistema.ColaPreferencial.EstaVacia())
                        {
                            cliente = sistema.ColaPreferencial.Desencolar();
                            prioridad = 2;
                        }

                        if (cliente != null)
                        {
                            string nroTicket = "TKT-" + DateTime.Now.Ticks.ToString().Substring(8); // Genera un ticket único
                            int tiempoAtencion = cliente.CalcularTiempoAtencion();
                            ventanilla.AsignarCliente(cliente.DNI, nroTicket, tiempoAtencion);

                            // Registrar la atención
                            var servicio = sistema.Servicios.ObtenerTodos().FirstOrDefault() ?? new Servicio { IdServicio = "RET", Descripcion = "Retiro" };
                            var atencion = new Atencion
                            {
                                NroTicket = nroTicket,
                                FechaHora = DateTime.Now,
                                IdCliente = cliente.DNI,
                                IdCajero = ventanilla.DNICajero,
                                IdServicio = servicio.IdServicio,
                                Monto = cliente.Monto,
                                Segundos = tiempoAtencion
                            };
                            sistema.Atenciones.Agregar(atencion);
                        }
                    }
                }
            }

            static void GenerarLlegada(SistemaBanco sistema, Random rnd, bool forzar)
            {
                try
                {
                    var todos = sistema.Clientes.ObtenerTodos().ToList();
                    Cliente cliente = null;
                    if (todos.Count > 0 && (forzar || rnd.NextDouble() < 0.85))
                    {
                        cliente = todos[rnd.Next(todos.Count)];
                    }
                    else
                    {
                        cliente = new Cliente
                        {
                            DNI = "X" + rnd.Next(1000, 9999),
                            Nombres = "Auto" + rnd.Next(1, 999),
                            FechaNacimiento = DateTime.Today.AddYears(-rnd.Next(18, 80)),
                            Discapacidad = rnd.NextDouble() < 0.08,
                            Niños = rnd.NextDouble() < 0.15 ? rnd.Next(1, 4) : 0,
                            Email = "auto@demo",
                            Telefono = "000",
                            Monto = rnd.Next(0, 5000)
                        };
                    }

                    sistema.AgregarClienteACola(cliente);
                }
                catch
                {
                    // no fallar la simulación por una llegada
                }
            }
        }
    }
}
