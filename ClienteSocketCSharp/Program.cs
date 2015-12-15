using ClienteSocketCSharp.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketCliente sc = new SocketCliente("127.0.0.1",9999);
            Console.WriteLine("presione una tecla para iniciar la conexion ...");
            //Console.ReadLine();
            Console.WriteLine("cliente conectado con el servidor...");
            sc.conectar();
            while (true)
            {
                Console.WriteLine("Ingrese el mensaje para enviar: ");
                String msj = Console.ReadLine();
                sc.salida(msj);
                if (msj.Equals("EXIT"))
                    break;
                else
                    Console.WriteLine(sc.leer());
            }
        }
    }
}
