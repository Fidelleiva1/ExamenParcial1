using System;
using System.Collections.Generic;

class Pelicula
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracion { get; set; } // Duración en minutos
    public string Estilo { get; set; }

    public Pelicula(string titulo, string genero, int duracion, string estilo)
    {
        Titulo = titulo;
        Genero = genero;
        Duracion = duracion;
        Estilo = estilo;
    }
}

class SistemaExperto
{
    private List<Pelicula> peliculas = new List<Pelicula>();

    public SistemaExperto()
    {
        // Se añaden algunas películas a la base de datos del sistema experto
        peliculas.Add(new Pelicula("Inception", "accion", 148, "intenso"));
        peliculas.Add(new Pelicula("Titanic", "Drama", 195, "romantico"));
        peliculas.Add(new Pelicula("Mad Max: Fury Road", "accion", 120, "apocaliptico"));
        peliculas.Add(new Pelicula("The Notebook", "drama", 124, "romantico"));
        peliculas.Add(new Pelicula("John Wick", "accion", 101, "violento"));
    }

    public Pelicula RecomendarPelicula(string genero, string duracion, string estilo)
    {
        int duracionMinima = 0;
        int duracionMaxima = int.MaxValue;

        // Establecer los criterios de duración basados en la preferencia del usuario
        switch (duracion.ToLower())
        {
            case "corta":
                duracionMaxima = 100;
                break;
            case "larga":
                duracionMinima = 100;
                break;
        }

        // Buscar una película que cumpla con los criterios del usuario
        foreach (var pelicula in peliculas)
        {
            if (pelicula.Genero.ToLower() == genero.ToLower() &&
                pelicula.Duracion >= duracionMinima && pelicula.Duracion <= duracionMaxima &&
                pelicula.Estilo.ToLower().Contains(estilo.ToLower()))
            {
                return pelicula;
            }
        }

        return null; // No se encontró una película que cumpla con los criterios
    }
}

class Program
{
    static void Main(string[] args)
    {
        SistemaExperto sistema = new SistemaExperto();

        // Preguntar al usuario por sus preferencias
        Console.WriteLine("¿Qué género de película prefieres? (accion, drama, etc.)");
        string genero = Console.ReadLine();

        Console.WriteLine("¿Prefieres una película corta o larga?");
        string duracion = Console.ReadLine();

        Console.WriteLine("¿Qué estilo de película prefieres? (romantico, intenso, violento, etc.)");
        string estilo = Console.ReadLine();

        // Obtener la recomendación
        Pelicula recomendacion = sistema.RecomendarPelicula(genero, duracion, estilo);

        if (recomendacion != null)
        {
            Console.WriteLine($"Te recomendamos ver: {recomendacion.Titulo}, una película de {recomendacion.Genero} con estilo {recomendacion.Estilo} y una duración de {recomendacion.Duracion} minutos.");
        }
        else
        {
            Console.WriteLine("No hemos encontrado una película que coincida con tus preferencias.");
        }
    }
}
