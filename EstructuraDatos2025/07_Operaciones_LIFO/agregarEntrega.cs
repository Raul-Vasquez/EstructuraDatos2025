public static class semana7
{
    public static void run()
    {
        System.Console.WriteLine("1. Verificar paréntesis balanceados");
        System.Console.WriteLine("Ingresa una fórmula matemática:");
        string formula = System.Console.ReadLine() ?? string.Empty; // Maneja posibles valores nulos
        System.Console.WriteLine(EsBalanceada(formula) ? "La fórmula está balanceada." : "La fórmula no está balanceada.");

        System.Console.WriteLine("\n2. Resolver Torres de Hanói");
        System.Console.Write("Ingresa el número de discos: ");
        string input = System.Console.ReadLine() ?? string.Empty; // Maneja posibles valores nulos
        if (int.TryParse(input, out int numDiscos) && numDiscos > 0) ResolverTorresDeHanoi(numDiscos);
        else System.Console.WriteLine("Número de discos inválido. Por favor, ingresa un número entero positivo.");
    }

    static bool EsBalanceada(string formula)
    {
        if (string.IsNullOrEmpty(formula)) return false;
        var pila = new System.Collections.Generic.Stack<char>();
        foreach (char c in formula)
        {
            if (c == '(' || c == '{' || c == '[') pila.Push(c);
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0 || (c == ')' && pila.Pop() != '(') || (c == '}' && pila.Pop() != '{') || (c == ']' && pila.Pop() != '[')) return false;
            }
        }
        return pila.Count == 0;
    }

    static System.Collections.Generic.Stack<int> torreOrigen = new System.Collections.Generic.Stack<int>();
    static System.Collections.Generic.Stack<int> torreAuxiliar = new System.Collections.Generic.Stack<int>();
    static System.Collections.Generic.Stack<int> torreDestino = new System.Collections.Generic.Stack<int>();

    static void ResolverTorresDeHanoi(int n)
    {
        for (int i = n; i >= 1; i--) torreOrigen.Push(i);
        System.Console.WriteLine("Estado inicial:"); MostrarTorres();
        TorresDeHanoi(n, torreOrigen, torreAuxiliar, torreDestino);
        System.Console.WriteLine("Estado final:"); MostrarTorres();
    }

    static void TorresDeHanoi(int n, System.Collections.Generic.Stack<int> origen, System.Collections.Generic.Stack<int> auxiliar, System.Collections.Generic.Stack<int> destino)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            System.Console.WriteLine($"Mover disco {disco} de {NombreDePila(origen)} a {NombreDePila(destino)}");
        }
        else
        {
            TorresDeHanoi(n - 1, origen, destino, auxiliar);
            TorresDeHanoi(1, origen, auxiliar, destino);
            TorresDeHanoi(n - 1, auxiliar, origen, destino);
        }
    }

    static void MostrarTorres()
    {
        System.Console.WriteLine($"Origen: {string.Join(", ", torreOrigen)}");
        System.Console.WriteLine($"Auxiliar: {string.Join(", ", torreAuxiliar)}");
        System.Console.WriteLine($"Destino: {string.Join(", ", torreDestino)}");
    }

    static string NombreDePila(System.Collections.Generic.Stack<int> pila)
    {
        if (pila == torreOrigen) return "Origen";
        if (pila == torreAuxiliar) return "Auxiliar";
        if (pila == torreDestino) return "Destino";
        return "Desconocido";
    }
}