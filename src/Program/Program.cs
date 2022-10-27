using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            Picture newPicture = new Picture(30, 40);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"PathToImageToLoad.jpg");

            provider.SavePicture(newPicture, @"PathToImageToSave.jpg");

            PipeNull nullpipe = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, nullpipe);
            
            FilterGreyscale filtroGris = new FilterGreyscale();
            PipeSerial piepserial1 = new PipeSerial(filtroGris, pipeSerial2);

            piepserial1.Send(newPicture);
        }
    }
}
