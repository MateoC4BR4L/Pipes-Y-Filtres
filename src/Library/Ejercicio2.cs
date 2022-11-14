using System.Collections.Generic;
using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    public class Ejercicio2
    {
        List<IPicture> secuencias = new();
        IPicture img{get; set;}

        
        public Ejercicio2(IPicture imagen)
        {
            img = imagen;
        }

        public void GuardarSecuencias() // Se guardan las secuencias de filtros
        {
            PipeNull nullpipe = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, nullpipe);
            IPicture imgFiltrada = pipeSerial2.Send(this.img);  // Se aplica el primer filtro solamente
            secuencias.Add(imgFiltrada); // Se guarda esa primera secuencia de filtro

            
            FilterGreyscale filtroGris = new FilterGreyscale();
            PipeSerial piepserial1 = new PipeSerial(filtroGris, nullpipe);
            imgFiltrada = piepserial1.Send(this.img); // Se aplica el segundo filtro solamente
            secuencias.Add(imgFiltrada); // Se guarda la segunda secuencia de filtro


            PipeSerial pipeserial = new PipeSerial(filtroGris, pipeSerial2);
            imgFiltrada = pipeserial.Send(this.img); // Se aplican ambos filtros a la imagen
            secuencias.Add(imgFiltrada); // Se guarda esta ultima secuencia con ambos filtros aplicados.
        }

        public void VerSecuencias() // Se habilitan para ver las imagenes filtradas por secuencia
        {
            PictureProvider provider = new();
            int num = 1;
            foreach(IPicture i in this.secuencias)
            {
                provider.SavePicture(i, $@"Secuencia{num}.jpg");
                if(num != secuencias.Count)
                    num += 1;
            }
        }
    }
}

