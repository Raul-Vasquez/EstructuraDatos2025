public static class EjericioDosListas{
    public static void run (){

    Console.WriteLine("--------------------------------");
    Console.WriteLine("Ejericio 2 de Listas Enlazadas");
    Console.WriteLine("---------------------------------");
     // Crear la lista enlazada personalizada
    ListaEnlazadaPersonalizada listaDeNumeros = new ListaEnlazadaPersonalizada();

    // Generar 50 números aleatorios entre 1 y 999 y agregarlos a la lista
    Random generadorDeNumeros = new Random();
    for (int i = 0; i < 50; i++)
    {
        int numeroGenerado = generadorDeNumeros.Next(1, 1000); // Genera un número entre 1 y 999
        listaDeNumeros.AgregarNumero(numeroGenerado);
    }

    // Mostrar la lista original
    System.Console.WriteLine("Lista original:");
    listaDeNumeros.MostrarLista();

    // Pedir al usuario el rango de valores
    System.Console.WriteLine("Introduce el valor mínimo del rango:");
    int minimoRango = int.Parse(System.Console.ReadLine());

    System.Console.WriteLine("Introduce el valor máximo del rango:");
    int maximoRango = int.Parse(System.Console.ReadLine());

    // Eliminar los nodos fuera del rango
    listaDeNumeros.EliminarNumerosFueraDeRango(minimoRango, maximoRango);

    // Mostrar la lista después de eliminar los nodos fuera de rango
    System.Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
    listaDeNumeros.MostrarLista();

    }
}

class ListaEnlazadaPersonalizada
{
    private NodoDeLista cabeza;

    // Método para agregar un número a la lista
    public void AgregarNumero(int valor)
    {
        NodoDeLista nuevoNodo = new NodoDeLista(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoDeLista nodoActual = cabeza;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    // Método para mostrar los números de la lista
    public void MostrarLista()
    {
        NodoDeLista nodoActual = cabeza;
        while (nodoActual != null)
        {
            System.Console.Write(nodoActual.Valor + " ");
            nodoActual = nodoActual.Siguiente;
        }
        System.Console.WriteLine();
    }

    // Método para eliminar los números fuera del rango
    public void EliminarNumerosFueraDeRango(int rangoMinimo, int rangoMaximo)
    {
        NodoDeLista nodoActual = cabeza;
        NodoDeLista nodoAnterior = null;

        while (nodoActual != null)
        {
            if (nodoActual.Valor < rangoMinimo || nodoActual.Valor > rangoMaximo)
            {
                // Eliminar el nodo actual
                if (nodoAnterior == null)  // Caso en el que el nodo a eliminar es la cabeza
                {
                    cabeza = nodoActual.Siguiente;
                }
                else
                {
                    nodoAnterior.Siguiente = nodoActual.Siguiente;
                }
            }
            else
            {
                nodoAnterior = nodoActual;
            }
            nodoActual = nodoActual.Siguiente;
        }
    }
}

class NodoDeLista
{
    public int Valor;
    public NodoDeLista Siguiente;

    public NodoDeLista(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}