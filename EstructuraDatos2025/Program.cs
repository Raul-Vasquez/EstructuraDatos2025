// Se realiza las funciones para mejorar la presentacion del codigo
// Programa Principal y llamadas al mismo 
Encabezado ();

while (true)
{
    opciones();
    string? opcion = Console.ReadLine(); //Readline -- Lee desde teclado
    
    switch (opcion)
    {
        case "0":
            return;
        case "1":
            Console.WriteLine("At work - Tipos de datos básicos");
            break;
        case "2":
            Console.WriteLine("At work - POO encapsulamiento");
            break;
        case "3":
            Console.WriteLine("At work - Array y matrices");
            break;
        // case "4":
        //     Console.WriteLine("Men at work - .....");
        //     break;
        default:
            Console.WriteLine("Opción no válida, pulse una tecla para continuar");
            break;
    } 
    piePagina ();
} 


// 3 Funciones Basica como el Encabezado, Cuerpo/Desarrollo y el Pie de Pagina
static void Encabezado(){
    Console.WriteLine("____________________________________");
    Console.WriteLine("UNIVERSIDAD ESTATAL AMANZONICA");
    Console.WriteLine("CARRERA DE TECNOLOGIAS DE LA INFORMACION");
    Console.WriteLine("Modalidad de estudios En Línea");
    Console.WriteLine("____________________________________\n");
}

static void opciones(){
    Console.WriteLine("Eliga la opcion que quiera mostar");
    Console.WriteLine("1. Tipos de Datos Basicos");
    Console.WriteLine("2. POO");
    Console.WriteLine("3. Arreglos y Matrices");
    Console.WriteLine("Presione 0 para salir\n");

}

static void piePagina(){
    Console.WriteLine("*******************************************************");
    Console.WriteLine("Elaborado por: "+"Raul Vasquez Lascano");
    Console.WriteLine("Tutor: "+ "DR. DELFÍN BERNABÉ ORTEGA TENEZACA, PHD");
    Console.WriteLine("*******************************************************");
}
