using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Logger;

namespace spotware
{
    public partial class Connection
    {
        private readonly ILog _log = LogManager.GetLogger();

        private readonly string _gateway;
        private readonly int _port;
        private TcpClient _tcpClient;
        private SslStream _sslStream;

        public event ConnectionEstablished OnConnectionEstablished;

        public delegate void ConnectionEstablished(object sender, EventArgs args);

        public Connection(string gateway, int port)
        {
            _gateway = gateway;
            _port = port;
        }

        public void Connect()
        {
            try
            {
                _log.Info($"Connecting to {_gateway}:{_port}...");
                _tcpClient = new TcpClient(_gateway, _port) {NoDelay = true};
            }
            catch (Exception ex)
            {
                _log.Error($"Connecting to {_gateway}:{_port} :: {ex.Message}");
                throw;
            }

            _sslStream = new SslStream(_tcpClient.GetStream(), false, ValidateServerCertificate, null);
            try
            {
                _sslStream.AuthenticateAsClient(_gateway);
            }
            catch (Exception ex)
            {
                _log.Error($"_sslStream.AuthenticateAsClient({_gateway}) :: {ex.Message}");
                _tcpClient.Dispose();
                throw;
            }

            if (!_sslStream.IsAuthenticated)
            {
                _log.Error($"Cannot establish secure connection to {_gateway}:{_port}");
                return;
            }

            Start_Listening_Thread();
            Start_Sender_Thread();
            Start_KeepAlive_Thread();
            _log.Info($"Connection established to {_gateway}:{_port}");
            OnConnectionEstablished?.Invoke(this, null);
        }

        private bool ValidateServerCertificate(object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            _log.Error("ValidateServerCertificate :: " + sslPolicyErrors);
            return false;
        }
    }
}