using System;
using System.Collections.Generic;

namespace ProyectoColasBanco
{
    // Lista recursiva sin nodos, usando CLista
    public class CLista
    {
        private object aElemento;
        private CLista aSubLista;

        public CLista()
        {
            aElemento = null;
            aSubLista = null;
        }

        public CLista(object pElemento, CLista pSubLista)
        {
            aElemento = pElemento;
            aSubLista = pSubLista;
        }

        public object Elemento { get => aElemento; set => aElemento = value; }
        public CLista SubLista { get => aSubLista; set => aSubLista = value; }

        public bool EstaVacia()
        {
            return aElemento == null && aSubLista == null;
        }

        public int Longitud()
        {
            if (EstaVacia())
                return 0;
            else
                return 1 + aSubLista.Longitud();
        }

        public void Agregar(object pElemento)
        {
            if (EstaVacia())
            {
                Elemento = pElemento;
                SubLista = new CLista();
            }
            else
            {
                SubLista.Agregar(pElemento);
            }
        }

        public void Eliminar(int posicion)
        {
            if (EstaVacia()) return;
            if (posicion == 1)
            {
                Elemento = SubLista?.Elemento;
                SubLista = SubLista?.SubLista;
            }
            else
            {
                SubLista?.Eliminar(posicion - 1);
            }
        }

        public object Iesimo(int posicion)
        {
            if (EstaVacia()) return null;
            if (posicion == 1)
                return Elemento;
            else
                return SubLista.Iesimo(posicion - 1);
        }

        public List<T> ObtenerTodos<T>()
        {
            var lista = new List<T>();
            ObtenerTodosRecursivo(this, lista);
            return lista;
        }

        private void ObtenerTodosRecursivo<T>(CLista lista, List<T> resultado)
        {
            if (lista == null || lista.EstaVacia()) return;
            resultado.Add((T)lista.Elemento);
            ObtenerTodosRecursivo(lista.SubLista, resultado);
        }
    }

    // Cola de prioridad basada en CLista
    public class ColaPrioridad<T>
    {
        private CLista lista;
        private int capacidad;
        private int tamaño;

        public ColaPrioridad(int capacidad = -1)
        {
            lista = new CLista();
            this.capacidad = capacidad;
            tamaño = 0;
        }               

        public bool EstaVacia()
        {
            return tamaño == 0;
        }

        public bool EstaLlena()
        {
            return capacidad != -1 && tamaño >= capacidad;
        }

        // Encolar según prioridad (menor número = mayor prioridad)
        public bool Encolar(T dato, int prioridad)
        {
            if (EstaLlena()) return false;

            var nuevo = new NodoPrioridad<T>(dato, prioridad);

            if (lista.EstaVacia())
            {
                lista.Agregar(nuevo);
            }
            else
            {
                // Insertar en la posición correcta según prioridad
                int pos = 1;
                int len = lista.Longitud();
                for (; pos <= len; pos++)
                {
                    var actual = (NodoPrioridad<T>)lista.Iesimo(pos);
                    if (prioridad < actual.Prioridad)
                        break;
                }
                InsertarEn(pos, nuevo);
            }
            tamaño++;
            return true;
        }

        // Desencolar el de mayor prioridad
        public T Desencolar()
        {
            if (EstaVacia()) return default(T);
            var primero = (NodoPrioridad<T>)lista.Iesimo(1);
            lista.Eliminar(1);
            tamaño--;
            return primero.Dato;
        }

        public int Tamaño()
        {
            return tamaño;
        }

        // Insertar en posición (1-based)
        private void InsertarEn(int posicion, NodoPrioridad<T> nodo)
        {
            if (posicion <= 1)
            {
                var nueva = new CLista(lista.Elemento, lista.SubLista);
                lista.Elemento = nodo;
                lista.SubLista = nueva;
            }
            else
            {
                CLista actual = lista;
                for (int i = 1; i < posicion - 1 && actual.SubLista != null; i++)
                    actual = actual.SubLista;
                var nueva = new CLista(actual.SubLista?.Elemento, actual.SubLista?.SubLista);
                actual.SubLista = new CLista(nodo, nueva);
            }
        }
    }

    // Nodo para cola de prioridad
    public class NodoPrioridad<T>
    {
        public T Dato { get; set; }
        public int Prioridad { get; set; }

        public NodoPrioridad(T dato, int prioridad)
        {
            Dato = dato;
            Prioridad = prioridad;
        }
    }
}
