using System;
using System.Collections.Generic;

namespace BancoApp
{
    // Nodo para lista enlazada
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Lista enlazada recursiva
    public class ListaRecursiva<T>
    {
        private Nodo<T> primero;
        private Nodo<T> ultimo;
        private int tamaño;

        public ListaRecursiva()
        {
            primero = null;
            ultimo = null;
            tamaño = 0;
        }

        public bool EstaVacia()
        {
            return primero == null;
        }

        public void Agregar(T dato)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(dato);
            if (EstaVacia())
            {
                primero = nuevoNodo;
                ultimo = nuevoNodo;
            }
            else
            {
                ultimo.Siguiente = nuevoNodo;
                ultimo = nuevoNodo;
            }
            tamaño++;
        }

        public bool Eliminar(T dato)
        {
            Nodo<T> actual = primero;
            Nodo<T> anterior = null;

            while (actual != null)
            {
                if (actual.Dato.Equals(dato))
                {
                    if (anterior == null)
                    {
                        primero = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }

                    if (actual == ultimo)
                    {
                        ultimo = anterior;
                    }

                    tamaño--;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        public T Buscar(Func<T, bool> criterio)
        {
            return BuscarRecursivo(primero, criterio);
        }

        private T BuscarRecursivo(Nodo<T> nodo, Func<T, bool> criterio)
        {
            if (nodo == null) return default(T);
            if (criterio(nodo.Dato)) return nodo.Dato;
            return BuscarRecursivo(nodo.Siguiente, criterio);
        }

        public List<T> ObtenerTodos()
        {
            List<T> elementos = new List<T>();
            ObtenerTodosRecursivo(primero, elementos);
            return elementos;
        }

        private void ObtenerTodosRecursivo(Nodo<T> nodo, List<T> elementos)
        {
            if (nodo == null) return;
            elementos.Add(nodo.Dato);
            ObtenerTodosRecursivo(nodo.Siguiente, elementos);
        }

        public int Contar()
        {
            return ContarRecursivo(primero);
        }

        private int ContarRecursivo(Nodo<T> nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarRecursivo(nodo.Siguiente);
        }
    }

    // Nodo para cola de prioridad
    public class NodoPrioridad<T>
    {
        public T Dato { get; set; }
        public int Prioridad { get; set; }
        public NodoPrioridad<T> Siguiente { get; set; }

        public NodoPrioridad(T dato, int prioridad)
        {
            Dato = dato;
            Prioridad = prioridad;
            Siguiente = null;
        }
    }

    // Cola de prioridad
    public class ColaPrioridad<T>
    {
        private NodoPrioridad<T> primero;
        private NodoPrioridad<T> ultimo;
        private int capacidad;
        private int tamaño;

        public ColaPrioridad(int capacidad = -1)
        {
            primero = null;
            ultimo = null;
            this.capacidad = capacidad;
            tamaño = 0;
        }

        public bool EstaVacia()
        {
            return primero == null;
        }

        public bool EstaLlena()
        {
            return capacidad != -1 && tamaño >= capacidad;
        }

        public bool Encolar(T dato, int prioridad)
        {
            if (EstaLlena()) return false;

            NodoPrioridad<T> nuevoNodo = new NodoPrioridad<T>(dato, prioridad);

            if (EstaVacia())
            {
                primero = nuevoNodo;
                ultimo = nuevoNodo;
            }
            else
            {
                // Insertar según prioridad (menor número = mayor prioridad)
                if (prioridad < primero.Prioridad)
                {
                    nuevoNodo.Siguiente = primero;
                    primero = nuevoNodo;
                }
                else
                {
                    NodoPrioridad<T> actual = primero;
                    while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                    {
                        actual = actual.Siguiente;
                    }
                    nuevoNodo.Siguiente = actual.Siguiente;
                    actual.Siguiente = nuevoNodo;
                    if (actual == ultimo)
                    {
                        ultimo = nuevoNodo;
                    }
                }
            }

            tamaño++;
            return true;
        }

        public T Desencolar()
        {
            if (EstaVacia()) return default(T);

            T dato = primero.Dato;
            primero = primero.Siguiente;

            if (primero == null)
            {
                ultimo = null;
            }

            tamaño--;
            return dato;
        }

        public T VerPrimero()
        {
            if (EstaVacia()) return default(T);
            return primero.Dato;
        }

        public int Tamaño()
        {
            return tamaño;
        }
    }
}
