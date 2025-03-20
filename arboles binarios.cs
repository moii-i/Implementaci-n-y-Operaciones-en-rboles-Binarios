using System;

// Clase para representar un nodo del árbol
class Nodo
{
    public int valor;
    public Nodo izquierda, derecha;

    public Nodo(int valor)
    {
        this.valor = valor;
        izquierda = derecha = null;
    }
}

// Clase para manejar el Árbol Binario de Búsqueda
class ArbolBinarioBusqueda
{
    public Nodo raiz;

    // Método para insertar un nuevo valor
    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.valor)
            nodo.izquierda = InsertarRecursivo(nodo.izquierda, valor);
        else if (valor > nodo.valor)
            nodo.derecha = InsertarRecursivo(nodo.derecha, valor);

        return nodo;
    }

    // Método para buscar un valor
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;
        if (valor == nodo.valor)
            return true;
        if (valor < nodo.valor)
            return BuscarRecursivo(nodo.izquierda, valor);
        return BuscarRecursivo(nodo.derecha, valor);
    }

    // Métodos para los recorridos
    public void Inorden() => InordenRecursivo(raiz);
    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.izquierda);
            Console.Write(nodo.valor + " ");
            InordenRecursivo(nodo.derecha);
        }
    }

    public void Preorden() => PreordenRecursivo(raiz);
    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.valor + " ");
            PreordenRecursivo(nodo.izquierda);
            PreordenRecursivo(nodo.derecha);
        }
    }

    public void Postorden() => PostordenRecursivo(raiz);
    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.izquierda);
            PostordenRecursivo(nodo.derecha);
            Console.Write(nodo.valor + " ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú del Árbol Binario de Búsqueda ---");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Buscar un valor");
            Console.WriteLine("3. Mostrar recorrido en inorden");
            Console.WriteLine("4. Mostrar recorrido en preorden");
            Console.WriteLine("5. Mostrar recorrido en postorden");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Introduce el valor a insertar: ");
                    int valorInsertar = int.Parse(Console.ReadLine());
                    arbol.Insertar(valorInsertar);
                    Console.WriteLine("Valor insertado correctamente.");
                    break;
                case 2:
                    Console.Write("Introduce el valor a buscar: ");
                    int valorBuscar = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valorBuscar) ? "Valor encontrado." : "Valor no encontrado.");
                    break;
                case 3:
                    Console.Write("Recorrido inorden: ");
                    arbol.Inorden();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("Recorrido preorden: ");
                    arbol.Preorden();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Recorrido postorden: ");
                    arbol.Postorden();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intenta de nuevo.");
                    break;
            }
        } while (opcion != 6);
    }
}
