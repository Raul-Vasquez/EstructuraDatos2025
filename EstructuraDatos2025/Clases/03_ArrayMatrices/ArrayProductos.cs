using System;

public class Producto{
    public int Id{ get;set;}   // ID del producto
    public string Nombre{get;set;} // Nombre del Producto
    public string Unidad{get;set;} // Unidad de Medida Kg
    public double []Precios{get;set;} // Arreglo de tres precios para el producto
    
    //Contructor para inicializar el producto con valores
    public Producto(int id, string nombre, string unidad, double precio1, double precio2, double precio3)
    {
        Id=id;
        Nombre=nombre;
        Unidad=unidad;
        Precios= new double []{precio1, precio2, precio3};
    }
    // Metodo para mostar la informacion del Producto
    public void mostarInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Unidad: {Unidad}");
        Console.WriteLine($"Precio1: {Precios[0]}");
        Console.WriteLine($"Precio2: {Precios[1]}");
        Console.WriteLine($"Precio2: {Precios[2]}");
    }

}