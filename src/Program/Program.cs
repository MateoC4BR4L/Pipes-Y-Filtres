using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            
            
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            PipeNull nullpipe = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, nullpipe);

            FilterGreyscale filtroGris = new FilterGreyscale();
            PipeSerial pipeSerial1 = new PipeSerial(filtroGris, pipeSerial2);
            IPicture pictureFiltered = pipeSerial1.Send(picture);

            provider.SavePicture(pictureFiltered, @"Ejercicio1.jpg");

            // Fin Ejercicio 1

            // Ejercicio 2

            PictureProvider provider2 = new PictureProvider();
            IPicture imagen = provider2.GetPicture(@"beer.jpg");

            Ejercicio2 prueba = new Ejercicio2(imagen);
            prueba.GuardarSecuencias();
            prueba.VerSecuencias();

            // Fin Ejercicio 2


        }
    }
}
