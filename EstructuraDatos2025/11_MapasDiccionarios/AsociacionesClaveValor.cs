public static class DiccionarioTraductor {
    static Dictionary<string, string> diccionario = new Dictionary<string, string>() {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño/a"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
    };

    public static void run() {
        // Convertir todas las claves y valores a minúsculas para evitar errores de búsqueda
        Dictionary<string, string> diccionarioBidireccional = new Dictionary<string, string>();
        foreach (var kvp in diccionario) {
            diccionarioBidireccional[kvp.Key.ToLower()] = kvp.Value.ToLower();
            diccionarioBidireccional[kvp.Value.ToLower()] = kvp.Key.ToLower();
        }
        diccionario = diccionarioBidireccional;

        while (true) {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario Traductor");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine()?.Trim() ?? "";

            if (opcion == "0") break;
            else if (opcion == "1") TraducirFrase();
            else if (opcion == "2") AgregarPalabra();
            else Console.WriteLine("Opción inválida.");
        }
    }

    static void TraducirFrase() {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine()?.Trim() ?? "";
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++) {
            string palabraOriginal = palabras[i].Trim(',', '.', '!', '?'); // Elimina signos de puntuación
            string palabraMinuscula = palabraOriginal.ToLower();

            if (diccionario.ContainsKey(palabraMinuscula)) {
                palabras[i] = palabras[i].Replace(palabraOriginal, diccionario[palabraMinuscula]);
            }
        }

        Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra() {
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine()?.Trim().ToLower() ?? "";
        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (!diccionario.ContainsKey(ingles) && !diccionario.ContainsKey(espanol)) {
            diccionario[ingles] = espanol;
            diccionario[espanol] = ingles;
            Console.WriteLine("Palabra agregada correctamente.");
        } else {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
