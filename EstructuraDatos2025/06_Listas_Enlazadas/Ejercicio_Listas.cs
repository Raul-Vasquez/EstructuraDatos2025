using System.Threading.Tasks.Dataflow;

public static class InvertirLista{
    public static void run (){
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Ejericio 1 de Listas Enlazadas");
    Console.WriteLine("---------------------------------");
      // Crear la lista enlazada
    ListaEnlazada lista = new ListaEnlazada();

    // Agregar elementos a la lista
    lista.Agregar(4);
    lista.Agregar(5);
    lista.Agregar(6);
    lista.Agregar(3);
    lista.Agregar(8);

    // Mostrar la lista original
    System.Console.WriteLine("Lista original:");
    lista.Mostrar();

    // Invertir la lista
    lista.Invertir();

    // Mostrar la lista invertida
    System.Console.WriteLine("Lista invertida:");
    lista.Mostrar();
   } 
}

class Nodo
{
    public int Valor;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null!;
    }
}

class ListaEnlazada
{
    private Nodo cabeza;

    // Método para agregar un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null!)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo anterior = null!;
        Nodo actual = cabeza;
        Nodo siguiente = null!;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }

        cabeza = anterior;
    }

    // Método para mostrar los elementos de la lista
    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            System.Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        System.Console.WriteLine();
    }
}


