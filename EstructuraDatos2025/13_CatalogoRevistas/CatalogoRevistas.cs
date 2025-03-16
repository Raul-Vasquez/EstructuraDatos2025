public static class GestorRevistas
{
    public static void run()
    {
        // Crear una instancia de la clase CatalogoRevistas.
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Agregamos 10 títulos al catálogo.
        catalogo.AgregarRevista("National Geographic");
        catalogo.AgregarRevista("Time");
        catalogo.AgregarRevista("Forbes");
        catalogo.AgregarRevista("Vogue");
        catalogo.AgregarRevista("Science");
        catalogo.AgregarRevista("Nature");
        catalogo.AgregarRevista("PC Magazine");
        catalogo.AgregarRevista("Sports Illustrated");
        catalogo.AgregarRevista("The Economist");
        catalogo.AgregarRevista("Rolling Stone");

        // Variable para controlar el bucle.
        string opcion = "";

        // Bucle principal del programa.
        while (opcion != "2")
        {
            // Mostramos el menú de búsqueda.
            Console.WriteLine("\nCatálogo de Revistas");
            Console.WriteLine("1. Buscar Revista");
            Console.WriteLine("2. Salir");

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
                    if (catalogo.BuscarRevista(tituloBuscado))
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

    public class CatalogoRevistas
    {
        // Lista para almacenar los títulos de las revistas.
        private List<string> revistas = new List<string>();

        // Método para agregar títulos al catálogo.
        public void AgregarRevista(string titulo)
        {
            revistas.Add(titulo);
        }

        // Método para buscar un título en el catálogo.
        public bool BuscarRevista(string tituloBuscado)
        {
            // Convertimos el título buscado a minúsculas para hacer la búsqueda insensible a mayúsculas y minúsculas.
            tituloBuscado = tituloBuscado.ToLower();

            // Recorremos la lista de revistas.
            foreach (string revista in revistas)
            {
                // Convertimos el título de la revista a minúsculas para comparar.
                if (revista.ToLower() == tituloBuscado)
                {
                    // Si encontramos el título, devolvemos true.
                    return true;
                }
            }

            // Si no encontramos el título, devolvemos false.
            return false;
        }
    }
}