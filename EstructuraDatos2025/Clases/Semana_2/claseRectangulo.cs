public class Rectangulo{
    // area de las propiedades y sus atrubutos
    private double largo;
    private double ancho;
/// <summary>
/// Constructor de un Rectangulo
/// </summary>
/// <param name="largoRectangulo">Medidas decimales del largo del Rectangulo</param>
/// <param name="anchoRectangulo">Medidas decimales del ancho del Rectangulo</param>
    public Rectangulo (double largoRectangulo, double anchoRectangulo){
        largo = largoRectangulo;
        ancho = anchoRectangulo;
    } 
/// <summary>
/// Funcion para calcular el area del rectangulo
/// </summary>
/// <returns>Devuelve un valor decimal</returns>
    public double Area (){
        return largo * ancho;
    }   

}

// Calcular el perimetro y area de un pentágono, es decir de una figura que tiene cinco lados iguales
// y cinco vertices

public class Pentagono{
    // propiedades de un pentago que tiene tiene perimetro, area y apotema
    private double perimetro;
    private double apotema;
/// <summary>
/// Constructos de un Pentágono
/// </summary>
/// <param name="perimetro1">Medidades decimales del perimetro del pentagono</param>
/// <param name="apotemaDistancia">Medidas decimales del apotema del pentagono</param>
    public Pentagono (double perimetro1 , double apotemaDistancia){
        perimetro = perimetro1;
        apotema = apotemaDistancia;
    }
/// <summary>
/// funcion para calcular el permitro del pentágono
/// </summary>
/// <returns>devuelve valores decimales</returns>
    public double Perimetro2 (){
        return  perimetro * 5;

    }
/// <summary>
/// Funcion para calcular el area del pentágono
/// </summary>
/// <returns></returns>
    public double Area2 (){
        return Perimetro2() * apotema /2;
    }



}

