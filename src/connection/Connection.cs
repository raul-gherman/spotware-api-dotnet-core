using System;
using System.Net.Security;
using System.Net.Sockets;

namespace spotware
{
    public partial class Connection
    {
        private readonly ILog _log = LogManager.GetLogger();

        private readonly string    _gateway;
        private readonly int       _port;
        private          TcpClient _tcpClient;
        private          SslStream _sslStream;

        public event ConnectionEstablished OnConnectionEstablished;

        public delegate void ConnectionEstablished(object sender, EventArgs args);

        public Connection(string gateway, int port)
        {
            _gateway = gateway;
            _port    = port;
        }
    }
}