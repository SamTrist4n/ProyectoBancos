public class ColaPrioridad<T>
{
    private List<(T item, int prioridad)> elementos;

    public ColaPrioridad(int capacidad = -1)
    {
        elementos = new List<(T, int)>();
        // ... resto de la inicialización
    }

    public void Encolar(T item, int prioridad)
    {
        elementos.Add((item, prioridad));
        elementos = elementos.OrderBy(e => e.prioridad).ToList();
    }

    public T Desencolar()
    {
        if (elementos.Count == 0) return default(T);
        var item = elementos[0].item;
        elementos.RemoveAt(0);
        return item;
    }

    public bool EstaVacia()
    {
        return elementos.Count == 0;
    }

    // --- SOLUCIÓN: método para obtener todos los elementos en espera ---
    public List<T> ObtenerTodos()
    {
        return elementos.Select(e => e.item).ToList();
    }
}