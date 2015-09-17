using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_Server
{
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                TcpClient newClient = _server.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            Boolean bClientConnected = true;
            String sData = null;
            String oData = null;

            while (bClientConnected)
            {
                sData = sReader.ReadLine();
                Console.WriteLine("Client: " + sData);
                //botched fix attempt
                oData = null;
                Console.Write(DateTime.Now + ": " + oData);
                oData = Console.ReadLine();
                //botched fix attempt

                sWriter.WriteLine(DateTime.Now + ": " + oData);
                //Console.WriteLine(DateTime.Now + ": " + oData);
                sWriter.Flush();
            }
        }
    }
}
