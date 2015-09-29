using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class ClientDemo
    {
        private TcpClient _client;

        private StreamReader _sReader;
        private StreamWriter _sWriter;

        private Boolean _isConnected;

        public ClientDemo(String ipAddress, int portNum)
        {
            _client = new TcpClient();
            _client.Connect(ipAddress, portNum);

            HandleCommunication();
        }

        public void HandleCommunication()
        {
            _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            _isConnected = true;
            String sData = null;
            while (_isConnected)
            {
                Console.Write("&gt; ");
                sData = Console.ReadLine();

                // if I want it to get displayed on my screen - Console.WriteLine(DateTime.Now + ": " + sData);
                _sWriter.WriteLine(DateTime.Now + ": " + sData);
                _sWriter.Flush();
                
                String sDataIncomming = _sReader.ReadLine();
                Console.WriteLine(sDataIncomming);
            }
        }
    }
}
