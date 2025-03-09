// Definimos una clase estática llamada TorneoBarrialChanchalo.
public static class TorneoBarrialChanchalo
{
    // Definimos el método principal 'run' que contiene la lógica del programa.
    public static void run()
    {
        // Creamos una instancia de la clase CampeonatoIntercomunal.
        // Esta clase maneja la lógica del campeonato de fútbol.
        CampeonatoIntercomunal campeonato = new CampeonatoIntercomunal();

        // Agregamos equipos al campeonato.
        campeonato.AgregarEquipo("Real Madrid");
        campeonato.AgregarEquipo("Atletico Madrid");
        campeonato.AgregarEquipo("Chelsea");
        campeonato.AgregarEquipo("Juventus");
        campeonato.AgregarEquipo("San Jose");
        campeonato.AgregarEquipo("Liverpool");

        // Agregamos jugadores a los equipos.
        campeonato.AgregarJugador("Real Madrid", "Paul Ortiz");
        campeonato.AgregarJugador("Real Madrid", "Raul Vasquez");
        campeonato.AgregarJugador("Atletico Madrid", "Cristhian Jimenez");
        campeonato.AgregarJugador("Chelsea", "Danilo Lascano");
        campeonato.AgregarJugador("Juventus", "Ruben Ortiz");
        campeonato.AgregarJugador("San Jose", "Javier Haro");
        campeonato.AgregarJugador("Liverpool", "Nelson Carvajal");

        // Mostramos la lista de equipos y sus jugadores.
        campeonato.MostrarEquipos();

        // Mostrar jugadores de un equipo específico.
        Console.WriteLine("\nIngrese el nombre del equipo para ver sus jugadores:");
        string nombreEquipo = Console.ReadLine()!; // Le decimos al compilador que sabemos que no será nulo.
        HashSet<string> jugadoresEquipo = campeonato.ObtenerJugadoresEquipo(nombreEquipo);
        if (jugadoresEquipo.Count > 0)
        {
            Console.WriteLine($"Jugadores de {nombreEquipo}: {string.Join(", ", jugadoresEquipo)}");
        }
        else
        {
            Console.WriteLine($"El equipo {nombreEquipo} no existe o no tiene jugadores.");
        }

        // Mostrar equipos con un jugador específico.
        Console.WriteLine("\nIngrese el nombre del jugador para ver a qué equipos pertenece:");
        string nombreJugador = Console.ReadLine()!; // Le decimos al compilador que sabemos que no será nulo.
        List<string> equiposJugador = campeonato.ObtenerEquiposJugador(nombreJugador);
        if (equiposJugador.Count > 0)
        {
            Console.WriteLine($"Equipos de {nombreJugador}: {string.Join(", ", equiposJugador)}");
        }
        else
        {
            Console.WriteLine($"El jugador {nombreJugador} no pertenece a ningún equipo.");
        }

        // Buscar jugadores por nombre o parte del nombre.
        Console.WriteLine("\nIngrese el nombre o parte del nombre del jugador a buscar:");
        string nombreBuscar = Console.ReadLine()!; // Le decimos al compilador que sabemos que no será nulo.
        List<string> jugadoresEncontrados = campeonato.BuscarJugadores(nombreBuscar);
        if (jugadoresEncontrados.Count > 0)
        {
            Console.WriteLine($"Jugadores encontrados: {string.Join(", ", jugadoresEncontrados)}");
        }
        else
        {
            Console.WriteLine($"No se encontraron jugadores con el nombre o parte del nombre '{nombreBuscar}'.");
        }

        // Mostrar estadísticas del torneo.
        campeonato.MostrarEstadisticas();
    }

    // Definimos una clase interna llamada CampeonatoIntercomunal.
    // Esta clase contiene la lógica para manejar los equipos y jugadores del campeonato.
    public class CampeonatoIntercomunal
    {
        // Definimos un diccionario para almacenar los equipos y sus jugadores.
        // La clave es el nombre del equipo y el valor es un conjunto de nombres de jugadores.
        private Dictionary<string, HashSet<string>> equipos;

        // Constructor de la clase CampeonatoIntercomunal.
        // Inicializa el diccionario de equipos.
        public CampeonatoIntercomunal()
        {
            equipos = new Dictionary<string, HashSet<string>>();
        }

        // Método para agregar un nuevo equipo al campeonato.
        public void AgregarEquipo(string nombreEquipo)
        {
            if (!equipos.ContainsKey(nombreEquipo))
            {
                equipos[nombreEquipo] = new HashSet<string>();
                Console.WriteLine($"Equipo '{nombreEquipo}' agregado.");
            }
            else
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' ya existe.");
            }
        }

        // Método para agregar un jugador a un equipo existente.
        public void AgregarJugador(string nombreEquipo, string nombreJugador)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                equipos[nombreEquipo].Add(nombreJugador);
                Console.WriteLine($"Jugador '{nombreJugador}' agregado a '{nombreEquipo}'.");
            }
            else
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no existe.");
            }
        }

        // Método para eliminar un jugador de un equipo existente.
        public void EliminarJugador(string nombreEquipo, string nombreJugador)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                if (equipos[nombreEquipo].Contains(nombreJugador))
                {
                    equipos[nombreEquipo].Remove(nombreJugador);
                    Console.WriteLine($"Jugador '{nombreJugador}' eliminado de '{nombreEquipo}'.");
                }
                else
                {
                    Console.WriteLine($"El jugador '{nombreJugador}' no pertenece a '{nombreEquipo}'.");
                }
            }
            else
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no existe.");
            }
        }

        // Método para obtener la lista de jugadores de un equipo.
        public HashSet<string> ObtenerJugadoresEquipo(string nombreEquipo)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                return equipos[nombreEquipo];
            }
            else
            {
                return new HashSet<string>();
            }
        }

        // Método para obtener los jugadores que juegan en ambos equipos.
        public HashSet<string> ObtenerJugadoresComunes(string equipo1, string equipo2)
        {
            if (equipos.ContainsKey(equipo1) && equipos.ContainsKey(equipo2))
            {
                return new HashSet<string>(equipos[equipo1].Intersect(equipos[equipo2]));
            }
            else
            {
                return new HashSet<string>();
            }
        }

        // Método para mostrar la lista de equipos y sus jugadores.
        public void MostrarEquipos()
        {
            foreach (var equipo in equipos)
            {
                Console.WriteLine($"Equipo: {equipo.Key}, Jugadores: {string.Join(", ", equipo.Value)}");
            }
        }

        // Método para obtener los equipos a los que pertenece un jugador.
        public List<string> ObtenerEquiposJugador(string nombreJugador)
        {
            List<string> equiposJugador = new List<string>();
            foreach (var equipo in equipos)
            {
                if (equipo.Value.Contains(nombreJugador))
                {
                    equiposJugador.Add(equipo.Key);
                }
            }
            return equiposJugador;
        }

        // Método para buscar jugadores por nombre o parte del nombre.
        public List<string> BuscarJugadores(string nombreBuscar)
        {
            List<string> jugadoresEncontrados = new List<string>();
            foreach (var equipo in equipos)
            {
                foreach (var jugador in equipo.Value)
                {
                    if (jugador.Contains(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                    {
                        jugadoresEncontrados.Add(jugador);
                    }
                }
            }
            return jugadoresEncontrados;
        }

        // Método para mostrar estadísticas del torneo.
        public void MostrarEstadisticas()
        {
            int totalEquipos = equipos.Count;
            int totalJugadores = 0;

            foreach (var equipo in equipos)
            {
                totalJugadores += equipo.Value.Count;
            }

            Console.WriteLine($"\nEstadísticas del torneo:");
            Console.WriteLine($"Total de equipos: {totalEquipos}");
            Console.WriteLine($"Total de jugadores: {totalJugadores}");
        }
    }
}