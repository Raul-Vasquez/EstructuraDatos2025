public static class Operaciones_Conjutos{
    public static void run (){
        // Crear conjunto de 500 ecuatorianos
        HashSet<string> ecuatorianos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ecuatorianos.Add($"ecuatoriano {i}");
        }

        // Crear conjunto de ecuatorianos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"ecuatoriano {i}");
        }

        // Crear conjunto de ecuatorianos vacunados con Astrazeneca
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        for (int i = 50; i <= 125; i++)
        {
            vacunadosAstrazeneca.Add($"ecuatoriano {i}");
        }

        // Ecuatorianos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ecuatorianos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Ecuatorianos vacunados con ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);

        // Ecuatorianos vacunados solo con Pfizer
        HashSet<string> vacunadosSoloPfizer = new HashSet<string>(vacunadosPfizer);
        vacunadosSoloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Ecuatorianos vacunados solo con Astrazeneca
        HashSet<string> vacunadosSoloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        vacunadosSoloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Mostrar los resultados
        Console.WriteLine("Ecuatorianos no vacunados:");
        Console.WriteLine(string.Join(", ", noVacunados));

        Console.WriteLine("\nEcuatorianos vacunados con ambas vacunas:");
        Console.WriteLine(string.Join(", ", vacunadosAmbas));

        Console.WriteLine("\nEcuatorianos vacunados solo con Pfizer:");
        Console.WriteLine(string.Join(", ", vacunadosSoloPfizer));

        Console.WriteLine("\nEcuatorianos vacunados solo con Astrazeneca:");
        Console.WriteLine(string.Join(", ", vacunadosSoloAstrazeneca));
    }
}