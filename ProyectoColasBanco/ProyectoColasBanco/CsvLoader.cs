using System;
using System.Globalization;
using System.IO;
using System.Linq;


namespace ProyectoColasBanco
{
    public class CsvLoader
    {
        private SistemaBanco sistema;

        public CsvLoader(SistemaBanco sistema)
        {
            this.sistema = sistema;
        }

        public void CargarClientes(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                var campos = linea.Split(',');

                var cliente = new Cliente
                {
                    DNI = campos[0],
                    Nombres = campos[1],
                    FechaNacimiento = DateTime.ParseExact(campos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Discapacidad = bool.Parse(campos[3]),
                    Niños = int.Parse(campos[4]),
                    Email = campos[5],
                    Telefono = campos[6],
                    Monto = decimal.Parse(campos[7])
                };

                sistema.Clientes.Agregar(cliente);
            }
        }

        public void CargarCajeros(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                var campos = linea.Split(',');

                var cajero = new Cajero
                {
                    DNI = campos[0],
                    Nombres = campos[1],
                    Direccion = campos[2],
                    Email = campos[3],
                    Telefono = campos[4]
                };

                sistema.Cajeros.Agregar(cajero);
            }
        }

        public void CargarServicios(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                var campos = linea.Split(',');

                var servicio = new Servicio
                {
                    IdServicio = campos[0],
                    Descripcion = campos[1]
                };

                sistema.Servicios.Agregar(servicio);
            }
        }

        public void CargarVentanillas(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                var campos = linea.Split(',');

                var ventanilla = new Ventanilla
                {
                    NroVentanilla = int.Parse(campos[0]),
                    DNICajero = campos[1],
                    DNICliente = string.IsNullOrWhiteSpace(campos[2]) ? null : campos[2],
                    NroTicket = string.IsNullOrWhiteSpace(campos[3]) ? null : campos[3],
                    Preferencial = bool.Parse(campos[4]),
                    Atendido = bool.Parse(campos[5]),
                    TiempoRestante = int.Parse(campos[6])
                };

                sistema.Ventanillas.Add(ventanilla);
            }
        }

        public void CargarAtenciones(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                var campos = linea.Split(',');

                var atencion = new Atencion
                {
                    NroTicket = campos[0],
                    FechaHora = DateTime.Parse(campos[1]),
                    IdCliente = campos[2],
                    IdCajero = campos[3],
                    IdServicio = campos[4],
                    Monto = decimal.Parse(campos[5]),
                    Segundos = int.Parse(campos[6])
                };

                sistema.Atenciones.Agregar(atencion);
            }
        }

        // Método general para cargar todo
        public void CargarTodo()
        {
            CargarClientes("Clientes.csv");
            CargarCajeros("Cajeros.csv");
            CargarServicios("Servicios.csv");
            CargarVentanillas("Ventanillas.csv");
            CargarAtenciones("Atenciones.csv");
        }
    }
}

