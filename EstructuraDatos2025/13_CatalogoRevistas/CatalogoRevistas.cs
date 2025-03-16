public static class BusquedaCatalogoRevista
{
    public static void run()
    {
        // Crear una instancia de la clase CatalogoRevistasBST.
        CatalogoRevistasBST catalogo = new CatalogoRevistasBST(); // BST son las siglas en inglés de "Binary Search Tree"

        // Agregamos 10 títulos al catálogo.
        catalogo.Insertar("Ecuador debate");
        catalogo.Insertar("Revista amazónica: Ciencia y tecnología");
        catalogo.Insertar("Dominio de las Ciencias");
        catalogo.Insertar("CienciAmérica");
        catalogo.Insertar("Yachana");
        catalogo.Insertar("Revista ESPAMCiencia");
        catalogo.Insertar("Cumbres");
        catalogo.Insertar("ReHuSo");
        catalogo.Insertar("Chakiñan");
        catalogo.Insertar("Enfoque UTE");

        // Variable para controlar el bucle.
        string opcion = "";

        // Bucle principal del programa.
        while (opcion != "2")
        {
            // Mostramos el menú de búsqueda.
            Console.WriteLine("\nCatálogo de Revistas");
            Console.WriteLine("1. Buscar Revista");
            Console.WriteLine("2. Salir");
            Console.WriteLine("3. Mostrar Catalogo");

            // Obtenemos la opción del usuario.
            opcion = Console.ReadLine()!;

            // Si la opción es 1, buscamos una revista.
            if (opcion == "1")
            {
                Console.WriteLine("Ingrese el título de la revista que desea buscar:");
                string tituloBuscado = Console.ReadLine()!;

                // Verificamos si el título ingresado es nulo o vacío.
                if (!string.IsNullOrEmpty(tituloBuscado))
                {
                    // Buscamos la revista en el catálogo.
                    if (catalogo.Buscar(tituloBuscado))
                    {
                        Console.WriteLine("Encontrado");
                    }
                    else
                    {
                        Console.WriteLine("No encontrado");
                    }
                }
                else
                {
                    Console.WriteLine("Título de revista no válido.");
                }
            }
            //Si la opcion es 3, muestra el catalogo
            else if (opcion == "3")
            {
                catalogo.MostrarCatalogo();
            }
            // Si la opción es 2, salimos del bucle.
            else if (opcion == "2")
            {
                Console.WriteLine("Saliendo del programa...");
            }
            // Si la opción no es válida, mostramos un mensaje de error.
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }

    public class Nodo
    {
        public string Titulo { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(string titulo)
        {
            Titulo = titulo;
            Izquierdo = null!;
            Derecho = null!;
        }
    }

    public class CatalogoRevistasBST
    {
        private Nodo raiz;

        public CatalogoRevistasBST()
        {
            raiz = null!;
        }

        public void Insertar(string titulo)
        {
            raiz = InsertarRecursivo(raiz, titulo);
        }

        private Nodo InsertarRecursivo(Nodo nodo, string titulo)
        {
            if (nodo == null)
            {
                return new Nodo(titulo);
            }

            if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
            }
            else if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
            }

            return nodo;
        }

        public bool Buscar(string titulo)
        {
            return BuscarRecursivo(raiz, titulo);
        }

        private bool BuscarRecursivo(Nodo nodo, string titulo)
        {
            if (nodo == null)
            {
                return false;
            }

            if (string.Equals(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return BuscarRecursivo(nodo.Izquierdo, titulo);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecho, titulo);
            }
        }

        public void MostrarCatalogo()
        {
            MostrarCatalogoRecursivo(raiz);
        }

        private void MostrarCatalogoRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                MostrarCatalogoRecursivo(nodo.Izquierdo);
                Console.WriteLine(nodo.Titulo);
                MostrarCatalogoRecursivo(nodo.Derecho);
            }
        }
    }
}