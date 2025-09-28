using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BancoApp
{
    public class SistemaBanco
    {
        public ListaRecursiva<Cliente> Clientes { get; set; }
        public ListaRecursiva<Cajero> Cajeros { get; set; }
        public ListaRecursiva<Servicio> Servicios { get; set; }
        public ListaRecursiva<Atencion> Atenciones { get; set; }
        public List<Ventanilla> Ventanillas { get; set; }
        public ColaPrioridad<Cliente> ColaPreferencial { get; set; }
        public ColaPrioridad<Cliente> ColaNormal { get; set; }

        private int contadorTickets = 1;

        public SistemaBanco()
        {
            Clientes = new ListaRecursiva<Cliente>();
            Cajeros = new ListaRecursiva<Cajero>();
            Servicios = new ListaRecursiva<Servicio>();
            Atenciones = new ListaRecursiva<Atencion>();
            Ventanillas = new List<Ventanilla>();
            ColaPreferencial = new ColaPrioridad<Cliente>(-1); // Capacidad ilimitada
            ColaNormal = new ColaPrioridad<Cliente>(10); // Capacidad limitada
        }

        public void ConfigurarVentanillas(int normales, int preferenciales)
        {
            Ventanillas.Clear();
            int nroVentanilla = 1;

            // Crear ventanillas preferenciales
            for (int i = 0; i < preferenciales; i++)
            {
                Ventanillas.Add(new Ventanilla
                {
                    NroVentanilla = nroVentanilla++,
                    Preferencial = true,
                    Atendido = false
                });
            }

            // Crear ventanillas normales
            for (int i = 0; i < normales; i++)
            {
                Ventanillas.Add(new Ventanilla
                {
                    NroVentanilla = nroVentanilla++,
                    Preferencial = false,
                    Atendido = false
                });
            }
        }

        public void AsignarCajeroAVentanilla(int nroVentanilla, string dniCajero)
        {
            var ventanilla = Ventanillas.FirstOrDefault(v => v.NroVentanilla == nroVentanilla);
            if (ventanilla != null)
            {
                ventanilla.DNICajero = dniCajero;
            }
        }

        public string AgregarClienteACola(Cliente cliente)
        {
            string nroTicket = GenerarNumeroTicket();
            int prioridad = cliente.CalcularPrioridad();

            if (prioridad == 1 || prioridad == 2)
            {
                ColaPreferencial.Encolar(cliente, prioridad);
            }
            else
            {
                ColaNormal.Encolar(cliente, prioridad);
            }

            return nroTicket;
        }

        private string GenerarNumeroTicket()
        {
            return "TKT-" + contadorTickets++.ToString("D6");
        }

        public void ProcesarAtenciones()
        {
            // Primero, procesar clientes en ventanillas que ya están siendo atendidos
            ActualizarTiempos();

            // Luego, asignar nuevos clientes a ventanillas libres
            AsignarNuevosClientes();
        }

        private void AsignarNuevosClientes()
        {
            // Primero intentar asignar a ventanillas preferenciales
            foreach (var ventanilla in Ventanillas.Where(v => v.Preferencial && !v.Atendido))
            {
                if (!ColaPreferencial.EstaVacia())
                {
                    Cliente cliente = ColaPreferencial.Desencolar();
                    if (cliente != null)
                    {
                        string nroTicket = GenerarNumeroTicket();
                        int tiempoAtencion = cliente.CalcularTiempoAtencion();
                        ventanilla.AsignarCliente(cliente.DNI, nroTicket, tiempoAtencion);
                        RegistrarAtencion(cliente, ventanilla, tiempoAtencion);
                    }
                }
            }

            // Luego asignar a ventanillas normales
            foreach (var ventanilla in Ventanillas.Where(v => !v.Preferencial && !v.Atendido))
            {
                if (!ColaNormal.EstaVacia())
                {
                    Cliente cliente = ColaNormal.Desencolar();
                    if (cliente != null)
                    {
                        string nroTicket = GenerarNumeroTicket();
                        int tiempoAtencion = cliente.CalcularTiempoAtencion();
                        ventanilla.AsignarCliente(cliente.DNI, nroTicket, tiempoAtencion);
                        RegistrarAtencion(cliente, ventanilla, tiempoAtencion);
                    }
                }
            }
        }

        public void ActualizarTiempos()
        {
            foreach (var ventanilla in Ventanillas.Where(v => v.Atendido))
            {
                ventanilla.TiempoRestante--;

                if (ventanilla.TiempoRestante <= 0)
                {
                    ventanilla.Liberar();
                }
            }
        }

        private void RegistrarAtencion(Cliente cliente, Ventanilla ventanilla, int segundos)
        {
            var servicio = Servicios.ObtenerTodos().FirstOrDefault() ?? new Servicio { IdServicio = "RET", Descripcion = "Retiro" };

            var atencion = new Atencion
            {
                NroTicket = ventanilla.NroTicket,
                FechaHora = DateTime.Now,
                IdCliente = cliente.DNI,
                IdCajero = ventanilla.DNICajero,
                IdServicio = servicio.IdServicio,
                Monto = cliente.Monto,
                Segundos = segundos
            };

            Atenciones.Agregar(atencion);
        }

        public void ExportarReporteTransacciones(string rutaArchivo)
        {
            DateTime dosMesesAtras = DateTime.Now.AddMonths(-2);
            var transacciones = Atenciones.ObtenerTodos()
                .Where(a => a.FechaHora >= dosMesesAtras)
                .ToList();

            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                writer.WriteLine("NroTicket,FechaHora,IdCliente,IdCajero,IdServicio,Monto,Segundos");
                foreach (var transaccion in transacciones)
                {
                    writer.WriteLine($"{transaccion.NroTicket},{transaccion.FechaHora},{transaccion.IdCliente}," +
                                     $"{transaccion.IdCajero},{transaccion.IdServicio},{transaccion.Monto},{transaccion.Segundos}");
                }
            }
        }

        public void ExportarReporteVentanillas(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                writer.WriteLine("NroVentanilla,DNICajero,DNICliente,NroTicket,Preferencial,Atendido,TiempoRestante");
                foreach (var ventanilla in Ventanillas)
                {
                    writer.WriteLine($"{ventanilla.NroVentanilla},{ventanilla.DNICajero},{ventanilla.DNICliente}," +
                                     $"{ventanilla.NroTicket},{ventanilla.Preferencial},{ventanilla.Atendido},{ventanilla.TiempoRestante}");
                }
            }
        }
    }
}
