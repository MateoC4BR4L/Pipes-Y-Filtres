using System.Collections.Generic;
using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using CognitiveCoreUCU;

namespace CompAndDel
{
    public class Ejercicio4 // Ejercicio 4: Nuevo Pipe de filtro condicional
    {
        CognitiveFace Detector = new();
        PictureProvider provider = new();
        IPicture img;
        PipeNull nullpipe = new();
        FilterNegative filtro1 = new();
        FilterGreyscale filtro2 = new();

        public void PipeCondicional(string path)
        {
            img = provider.GetPicture(path);

            Detector.Recognize(path);

            if(Detector.FaceFound) // Si la imagen contiene una cara se aplica un filtro
            {
                PipeSerial pipe1 = new PipeSerial(filtro1, nullpipe);
                img = pipe1.Send(img);
                provider.SavePicture(img, @"FiltroConCara.jpg");
            }
            else
            {
                PipeSerial pipe2 = new PipeSerial(filtro2, nullpipe);
                img = pipe2.Send(img);
                provider.SavePicture(img, @"FiltroSinCara.jpg");
            }
        }
    }
}