public static class ArbolBinarioBST
{
    public static void run()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        // Insertar aerolíneas de ejemplo.
        arbol.Insertar(new Aerolinea(5, "Iberia", "Ecuador-España", 9500));
        arbol.Insertar(new Aerolinea(3, "Latam", "Perú-México", 4500));
        arbol.Insertar(new Aerolinea(7, "Air Europa", "Colombia-Italia", 8800));
        arbol.Insertar(new Aerolinea(2, "Avianca", "Argentina-EEUU", 8000));
        arbol.Insertar(new Aerolinea(4, "Copa Airlines", "Panamá-Brasil", 3500));
        arbol.Insertar(new Aerolinea(9, "Aeroméxico", "Chile-Canadá", 9000));
        // Variable para almacenar la opción del usuario.
        string opcion = "";
        // Bucle principal del programa, que se ejecuta hasta que el usuario elige salir.
        while (opcion != "6")
        {
            Console.WriteLine("\nMenú de Operaciones en Árbol Binario de Búsqueda");
            Console.WriteLine("1. Insertar Aerolínea");
            Console.WriteLine("2. Buscar Aerolínea");
            Console.WriteLine("3. Recorrido Preorden");
            Console.WriteLine("4. Recorrido Inorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Salir");

            opcion = Console.ReadLine()!;
        // Realiza la operación correspondiente según la opción del usuario.
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la claveContenedor de la aerolínea: ");
                    int claveContenedor = int.Parse(Console.ReadLine()!);
                    Console.Write("Ingrese el nombre de la aerolínea: ");
                    string nombre = Console.ReadLine()!;
                    Console.Write("Ingrese el destino: ");
                    string destino = Console.ReadLine()!;
                    Console.Write("Ingrese los kilómetros recorridos: ");
                    int kmRecorridos = int.Parse(Console.ReadLine()!);
                    Aerolinea aerolinea = new Aerolinea(claveContenedor, nombre, destino, kmRecorridos);
                    arbol.Insertar(aerolinea);
                    break;
                case "2":
                    Console.Write("Ingrese la claveContenedor a buscar: ");
                    int claveContenedorBuscar = int.Parse(Console.ReadLine()!);
                    Aerolinea aerolineaEncontrada = arbol.Buscar(claveContenedorBuscar);
                    if (aerolineaEncontrada != null)
                    {
                        Console.WriteLine($"Aerolínea encontrada: {aerolineaEncontrada}");
                    }
                    else
                    {
                        Console.WriteLine("claveContenedor no encontrado.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.RecorridoPreorden();
                    break;
                case "4":
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.RecorridoInorden();
                    break;
                case "5":
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.RecorridoPostorden();
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
// Clase que representa una aerolínea.
    public class Aerolinea
    {
        public int claveContenedor { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public int KmRecorridos { get; set; }

        // Constructor de la clase Aerolinea.
        public Aerolinea(int claveContenedor, string nombre, string destino, int kmRecorridos)
        {
            this.claveContenedor = claveContenedor;
            Nombre = nombre;
            Destino = destino;
            KmRecorridos = kmRecorridos;
        }
// Método que devuelve una representación en cadena de la aerolínea.
        public override string ToString()
        {
            return $"claveContenedor: {claveContenedor}, Nombre: {Nombre}, Destino: {Destino}, KmRecorridos: {KmRecorridos}";
        }
    }
// Clase que representa un nodo del árbol BST.
       public class Nodo
    {
        public Aerolinea Datos { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(Aerolinea datos)
        {
            Datos = datos;
            Izquierdo = null!;
            Derecho = null!;
        }
    }
// Clase que implementa la lógica del árbol BST.
    public class ArbolBinarioBusqueda
    {
        private Nodo raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null!;
        }

        public void Insertar(Aerolinea aerolinea)
        {
            raiz = InsertarRecursivo(raiz, aerolinea);
        }

        private Nodo InsertarRecursivo(Nodo nodo, Aerolinea aerolinea)
        {
            if (nodo == null)
            {
                return new Nodo(aerolinea);
            }

            if (aerolinea.claveContenedor < nodo.Datos.claveContenedor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, aerolinea);
            }
            else if (aerolinea.claveContenedor > nodo.Datos.claveContenedor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, aerolinea);
            }

            return nodo;
        }
        // Método que busca una aerolínea.

        public Aerolinea Buscar(int claveContenedor)
        {
            return BuscarRecursivo(raiz, claveContenedor);
        }
        
        // Método recursivo que inserta una aerolínea en el árbol.
        private Aerolinea BuscarRecursivo(Nodo nodo, int claveContenedor)
        {
            if (nodo == null)
            {
                return null!;
            }

            if (claveContenedor == nodo.Datos.claveContenedor)
            {
                return nodo.Datos;
            }

            if (claveContenedor < nodo.Datos.claveContenedor)
            {
                return BuscarRecursivo(nodo.Izquierdo, claveContenedor);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecho, claveContenedor);
            }
        }
// Método que realiza el recorrido preorden del árbol.
        public void RecorridoPreorden()
        {
            RecorridoPreordenRecursivo(raiz);
        }

      
        private void RecorridoPreordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.WriteLine(nodo.Datos);
                RecorridoPreordenRecursivo(nodo.Izquierdo);
                RecorridoPreordenRecursivo(nodo.Derecho);
            }
        }
// Método que realiza el recorrido inorden del árbol.
        public void RecorridoInorden()
        {
            RecorridoInordenRecursivo(raiz);
        }

        private void RecorridoInordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoInordenRecursivo(nodo.Izquierdo);
                Console.WriteLine(nodo.Datos);
                RecorridoInordenRecursivo(nodo.Derecho);
            }
        }
// Método que realiza el recorrido postorden del árbol.
        public void RecorridoPostorden()
        {
            RecorridoPostordenRecursivo(raiz);
        }
// Método recursivo que realiza el recorrido postorden del árbol.
        private void RecorridoPostordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoPostordenRecursivo(nodo.Izquierdo);
                RecorridoPostordenRecursivo(nodo.Derecho);
                Console.WriteLine(nodo.Datos);
            }
        }
    }
}