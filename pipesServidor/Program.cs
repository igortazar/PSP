using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace pipesServidor
{
    class Program
    {
        static void Main(string[] args)
        {
           
                var server = new NamedPipeServerStream("PipesOfPiece");
                server.WaitForConnection();
                Console.WriteLine("Servidor esperando datos");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (true)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    Console.WriteLine("Servidor procesando datos");
                    writer.WriteLine(String.Join("", line.ToUpper()));
                    writer.Flush();
                }
           
        }
    }
}
