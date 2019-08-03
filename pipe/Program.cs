using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace pipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p;
            StartServer(out p);
            Task.Delay(1000).Wait();


            //Client
            var client = new NamedPipeClientStream("PipesOfPiece");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) break;
                Console.WriteLine(String.Join("","Enviado: ",input));
                writer.WriteLine(input);
                writer.Flush();
                Console.WriteLine(reader.ReadLine());
            }
        }

        static Process StartServer(out Process p1)
        {
            // iniciar un proceso con el servidor y devolver
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\uterc\source\repos\psp\pipesServidor\bin\Release\netcoreapp2.1\publish\pipesServidor.exe");
            // su valor por defecto el false, si se establece a true no se "crea" ventana
            info.CreateNoWindow=false;
            info.WindowStyle = ProcessWindowStyle.Normal;
            // indica si se utiliza el cmd para lanzar el proceso
            info.UseShellExecute = true;
            p1 = Process.Start(info);
            return p1;
        }
    }
}
