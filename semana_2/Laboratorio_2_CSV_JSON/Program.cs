using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string rutaCsv = "estudiantes.csv";
        string rutaJson = "estudiantes.json";

        // Leer el archivo CSV
        string[] lineas = File.ReadAllLines(rutaCsv);

        // Crear la lista de estudiantes
        List<Estudiante> estudiantes = new List<Estudiante>();

        // Omitir la primera línea (encabezado) y procesar el resto
        for (int i = 1; i < lineas.Length; i++)
        {
            string linea = lineas[i];

            if (string.IsNullOrWhiteSpace(linea))
                continue;

            string[] campos = linea.Split(',');

            Estudiante estudiante = new Estudiante
            {
                Id = int.Parse(campos[0]),
                Nombre = campos[1],
                Carrera = campos[2]
            };

            estudiantes.Add(estudiante);
        }

        // Mostrar todos los estudiantes en consola
        foreach (var est in estudiantes)
        {
            Console.WriteLine($"{est.Id} - {est.Nombre} - {est.Carrera}");
        }

        // Convertir la lista a formato JSON
        JsonSerializerOptions opciones = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(estudiantes, opciones);

        // Guardar el resultado en estudiantes.json
        File.WriteAllText(rutaJson, json);

        Console.WriteLine();
        Console.WriteLine("Archivo estudiantes.json creado correctamente.");
    }
}