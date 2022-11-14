using System.Collections.Generic;
using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    public class Ejercicio3
    {
        public void publicarTwitter(int secuencia) // Número de secuencia (1, 2 o 3)
        {
            if((secuencia >= 1) && (secuencia <= 3))
            {
                var twitter = new TwitterImage();
                Console.WriteLine(twitter.PublishToTwitter($"Secuencia {secuencia}", $@"Secuencia{secuencia}.jpg"));
            }
            else
            {
                Console.WriteLine("Número de secuencia incorrecto.");
            }
        }
    }
}