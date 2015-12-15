using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketCSharp.socket
{
    class SocketCliente
    {
        private Socket clientSocket;
        private IPEndPoint serverAddress;

        private String host;
        private int puerto;

        public SocketCliente(String host, int puerto)
        {
            this.host = host;
            this.puerto = puerto;
            //this.conectar();
        }

        public void conectar()
        {
            serverAddress = new IPEndPoint(IPAddress.Parse(host), puerto);

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);
        }

        public String leer()
        {
            byte[] sizeBuffer = new byte[1024];
            int tamanio = clientSocket.Receive(sizeBuffer);
            String myString = Encoding.UTF8.GetString(sizeBuffer, 0, tamanio);
            return myString;
        }

        public Boolean salida(String texto)
        {
            byte[] msg = Encoding.UTF8.GetBytes(texto);
            clientSocket.Send(msg);
            return true;
        }

        public void desconectar()
        {
            clientSocket.Close();
        }
    }
}
