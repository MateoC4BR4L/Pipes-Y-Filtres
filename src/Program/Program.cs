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

            // Fin Ejercicio 1 ---------------------------------------------------------------------



            // Ejercicio 2 -------------------------------------------------------------------------

            PictureProvider provider2 = new PictureProvider();
            IPicture imagen = provider2.GetPicture(@"beer.jpg");

            Ejercicio2 ejer2 = new Ejercicio2(imagen);
            ejer2.GuardarSecuencias();
            ejer2.VerSecuencias();

            // Fin Ejercicio 2 ----------------------------------------------------------------------



            // Ejercicio 3 --------------------------------------------------------------------------

            Ejercicio3 ejer3 = new();
            ejer3.publicarTwitter(1); // Publicar la secuencia 1

            // Fin Ejercicio 3 ----------------------------------------------------------------------



            // Ejercicio 4 --------------------------------------------------------------------------

            Ejercicio4 ejer4 = new();
            ejer4.PipeCondicional(@"luke.jpg");

            // Fin Ejercicio 4 ----------------------------------------------------------------------
        }
    }
}
