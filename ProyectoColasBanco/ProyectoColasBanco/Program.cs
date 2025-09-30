// Program.cs
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                        case 16: IniciarSimulacionGrafica(); break;
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

        static void IniciarSimulacionGrafica()
        {
            Console.WriteLine("Iniciando simulación gráfica... (P pausa/resume, A llegada forzada, C limpiar, Esc salir)");
            SimulacionConsola.Run(sistema);
        }
    }

    public static class SimulacionConsola
    {
        public static int TickMs = 700;           // duración de cada tick (ms)
        public static double ProbabilidadLlegada = 0.5; // probabilidad de llegada por tick
        public static int MaxMostrarCola = 8;

        public static void Run(SistemaBanco sistema)
        {
            if (sistema == null) throw new ArgumentNullException(nameof(sistema));

            var rnd = new Random();
            bool running = true;
            bool paused = false;

            Console.Clear();
            Console.CursorVisible = false;

            PrintControls();

            while (running)
            {
                if (!paused)
                {
                    // generar llegada aleatoria
                    if (rnd.NextDouble() <= ProbabilidadLlegada)
                    {
                        GenerarLlegadaAleatoria(sistema, rnd);
                    }

                    // procesar atenciones (actualiza tiempos y asignaciones)
                    sistema.ProcesarAtenciones();
                }

                RenderEstado(sistema);

                // manejo de teclas
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape) { running = false; break; }
                    if (key == ConsoleKey.P) { paused = !paused; PrintPauseStatus(paused); }
                    if (key == ConsoleKey.A) { GenerarLlegadaAleatoria(sistema, rnd, true); RenderEstado(sistema); }
                    if (key == ConsoleKey.C) { ClearQueuesAndVentanillas(sistema); }
                }

                Thread.Sleep(TickMs);
            }

            Console.CursorVisible = true;
            Console.WriteLine("\nSimulación finalizada. Presiona una tecla...");
            Console.ReadKey(true);
        }

        static void PrintControls()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("SIMULACIÓN - BANCO (Esc sale)");
            Console.WriteLine("[P] Pausa/Resume   [A] Forzar llegada   [C] Limpiar colas");
            Console.WriteLine();
        }

        static void PrintPauseStatus(bool paused)
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(paused ? "PAUSADO".PadRight(80) : "EN EJECUCIÓN".PadRight(80));
        }

        static void RenderEstado(SistemaBanco sistema)
        {
            int top = 4;
            int colWidth = 36;
            var ventanillas = sistema.Ventanillas;
            int perRow = Math.Max(1, Console.WindowWidth / (colWidth + 2));
            int row = 0;
            for (int i = 0; i < ventanillas.Count; i++)
            {
                int colIndex = i % perRow;
                row = i / perRow;
                int x = colIndex * (colWidth + 2);
                int y = top + row * 7;
                DrawVentanillaBox(ventanillas[i], x, y, colWidth);
            }

            int afterVentasRows = (ventanillas.Count + perRow - 1) / perRow;
            int colaTop = top + Math.Max(1, afterVentasRows) * 7 + 1;

            DrawCola("COLA PREFERENCIAL", sistema.ColaPreferencial, colaTop, 0, Console.WindowWidth / 2 - 1);
            DrawCola("COLA NORMAL      ", sistema.ColaNormal, colaTop, Console.WindowWidth / 2 + 1, Console.WindowWidth / 2 - 2);

            int statsTop = colaTop + 8;
            DrawStats(sistema, statsTop, 0);
        }

        static void DrawVentanillaBox(Ventanilla v, int x, int y, int width)
        {
            for (int i = 0; i < 6; i++) SafeWriteAt(new string(' ', width), x, y + i);

            SafeWriteAt("+" + new string('-', width - 2) + "+", x, y);
            SafeWriteAt("|" + CenterText($"Ventanilla {v.NroVentanilla}", width - 2) + "|", x, y + 1);

            string cajero = string.IsNullOrWhiteSpace(v.DNICajero) ? "(sin cajero)" : v.DNICajero;
            SafeWriteAt("| Cajero: " + Truncate(cajero, width - 11).PadRight(width - 11) + "|", x, y + 2);

            string cliente = string.IsNullOrWhiteSpace(v.DNICliente) ? "(libre)" : v.DNICliente;
            string ticket = string.IsNullOrWhiteSpace(v.NroTicket) ? "" : v.NroTicket;
            SafeWriteAt("| Cliente: " + Truncate(cliente + " " + ticket, width - 11).PadRight(width - 11) + "|", x, y + 3);

            string pref = v.Preferencial ? "S" : "N";
            SafeWriteAt("| Pref: " + pref.PadRight(4) + " Tiempo: " + v.TiempoRestante.ToString().PadLeft(3) + "s" + new string(' ', Math.Max(0, width - 28)) + "|", x, y + 4);

            SafeWriteAt("+" + new string('-', width - 2) + "+", x, y + 5);
        }

        static void DrawCola(string titulo, object colaObj, int top, int left, int width)
        {
            SafeWriteAt(titulo.PadRight(width), left, top);
            SafeWriteAt("[" + " ".PadRight(width - 2) + "]", left, top + 1);

            // intentar snapshot
            var snapshot = TryGetColaSnapshot(colaObj);
            if (snapshot != null)
            {
                var list = snapshot.Take(MaxMostrarCola).ToList();
                for (int i = 0; i < MaxMostrarCola; i++)
                {
                    string text = i < list.Count ? $"{i + 1}. {Truncate(list[i].DNI + " " + list[i].Nombres, width - 4)}" : "";
                    SafeWriteAt(text.PadRight(width), left, top + 2 + i);
                }
                SafeWriteAt($"Total: {snapshot.Count()}".PadRight(width), left, top + 2 + MaxMostrarCola);
            }
            else
            {
                int count = TryGetColaCount(colaObj);
                for (int i = 0; i < MaxMostrarCola; i++) SafeWriteAt("".PadRight(width), left, top + 2 + i);
                SafeWriteAt($"Total: {count}".PadRight(width), left, top + 2 + MaxMostrarCola);
            }
        }

        // intenta varios métodos/properties para obtener snapshot (ObtenerTodos, ToArray, ToList, internal)
        static IEnumerable<Cliente> TryGetColaSnapshot(object cola)
        {
            try
            {
                if (cola == null) return null;
                if (cola is IEnumerable<Cliente> en) return en.ToList();

                var miObtener = cola.GetType().GetMethod("ObtenerTodos");
                if (miObtener != null)
                {
                    var res = miObtener.Invoke(cola, null) as IEnumerable<Cliente>;
                    return res?.ToList();
                }

                var miToArray = cola.GetType().GetMethod("ToArray");
                if (miToArray != null)
                {
                    var arr = miToArray.Invoke(cola, null) as Cliente[];
                    return arr?.ToList();
                }

                // Try method that returns array via reflection "ToList" or "ToArray" elsewhere
                return null;
            }
            catch { return null; }
        }

        static int TryGetColaCount(object cola)
        {
            try
            {
                var miTamaño = cola.GetType().GetMethod("Tamaño");
                if (miTamaño != null) return (int)miTamaño.Invoke(cola, null);

                var propCount = cola.GetType().GetProperty("Count");
                if (propCount != null) return (int)propCount.GetValue(cola);

                var miCount = cola.GetType().GetMethod("Count");
                if (miCount != null) return (int)miCount.Invoke(cola, null);

                return -1;
            }
            catch { return -1; }
        }

        static void DrawStats(SistemaBanco sistema, int top, int left)
        {
            SafeWriteAt("=== ESTADÍSTICAS ===", left, top);
            SafeWriteAt($"Clientes totales: {sistema.Clientes.ObtenerTodos().Count()}", left, top + 1);
            SafeWriteAt($"Atenciones en memoria: {sistema.Atenciones.ObtenerTodos().Count()}", left, top + 2);
            SafeWriteAt($"Cola preferencial (intento): {TryGetColaCount(sistema.ColaPreferencial)}", left, top + 3);
            SafeWriteAt($"Cola normal (intento): {TryGetColaCount(sistema.ColaNormal)}", left, top + 4);
            SafeWriteAt($"Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", left, top + 6);
        }

        static void SafeWriteAt(string text, int x, int y)
        {
            try
            {
                if (y < 0) return;
                if (x < 0) x = 0;
                Console.SetCursorPosition(x, y);
                Console.Write(text);
            }
            catch { }
        }

        static string CenterText(string text, int width)
        {
            if (text.Length >= width) return text.Substring(0, width);
            int left = (width - text.Length) / 2;
            return new string(' ', left) + text + new string(' ', width - text.Length - left);
        }

        static string Truncate(string s, int width)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length <= width) return s;
            return s.Substring(0, width - 3) + "...";
        }

        static void GenerarLlegadaAleatoria(SistemaBanco sistema, Random rnd, bool forzar = false)
        {
            var todos = sistema.Clientes.ObtenerTodos().ToList();
            Cliente cliente = null;
            if (todos.Count > 0 && (forzar || rnd.NextDouble() < 0.8))
            {
                cliente = todos[rnd.Next(todos.Count)];
            }

            if (cliente == null)
            {
                cliente = new Cliente
                {
                    DNI = "X" + rnd.Next(1000, 9999),
                    Nombres = "Genérico" + rnd.Next(1, 99),
                    FechaNacimiento = DateTime.Today.AddYears(-rnd.Next(18, 80)),
                    Discapacidad = rnd.NextDouble() < 0.08,
                    Niños = rnd.NextDouble() < 0.15 ? rnd.Next(1, 4) : 0,
                    Email = "auto@demo",
                    Telefono = "000",
                    Monto = rnd.Next(0, 5000)
                };
            }

            // Encolar con la lógica del sistema (generará ticket y encolará en las colas internas)
            sistema.AgregarClienteACola(cliente);
        }

        static void ClearQueuesAndVentanillas(SistemaBanco sistema)
        {
            try
            {
                var miPref = sistema.ColaPreferencial.GetType().GetMethod("Clear");
                miPref?.Invoke(sistema.ColaPreferencial, null);
            }
            catch { }
            try
            {
                var miNorm = sistema.ColaNormal.GetType().GetMethod("Clear");
                miNorm?.Invoke(sistema.ColaNormal, null);
            }
            catch { }

            foreach (var v in sistema.Ventanillas) v.Liberar();
        }
    }
}
