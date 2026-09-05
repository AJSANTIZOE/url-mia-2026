using System;
using System.IO;

Console.Write("Ingrese su nombre completo: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese la ruta del archivo de texto: ");
string ruta = Console.ReadLine();

if (File.Exists(ruta))
{
    string[] lineas = File.ReadAllLines(ruta);
    string texto = File.ReadAllText(ruta);

    int numeroLineas = lineas.Length;
    int numeroCaracteres = texto.Length;
    int numeroVocales = 0;

    for (int i = 0; i < texto.Length; i++)
    {
        char letra = Char.ToLower(texto[i]);

        if (letra == 'a' ||
            letra == 'e' ||
            letra == 'i' ||
            letra == 'o' ||
            letra == 'u')
        {
            numeroVocales++;
        }
    }

    Console.WriteLine();
    Console.WriteLine("===== RESULTADOS =====");
    Console.WriteLine("Líneas: " + numeroLineas);
    Console.WriteLine("Vocales: " + numeroVocales);
    Console.WriteLine("Caracteres: " + numeroCaracteres);

    string carpeta = @"C:\MIA_Parcial_1";

    string nombreArchivo = nombre.Replace(" ", "_");

    string rutaCSV = carpeta + @"\resultados_" + nombreArchivo + ".csv";

    StreamWriter archivo = new StreamWriter(rutaCSV);

    archivo.WriteLine("Nombre,Lineas,Vocales,Caracteres");
    archivo.WriteLine(nombreArchivo + "," +
                      numeroLineas + "," +
                      numeroVocales + "," +
                      numeroCaracteres);

    archivo.Close();

    Console.WriteLine();
    Console.WriteLine("Archivo CSV creado correctamente.");
    Console.WriteLine("Ruta: " + rutaCSV);
}
else
{
    Console.WriteLine("El archivo no existe.");
}

Console.WriteLine();
Console.WriteLine("Presione una tecla para finalizar...");
Console.ReadKey();
