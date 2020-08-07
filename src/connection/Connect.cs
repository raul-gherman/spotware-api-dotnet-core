using System;
using System.Net.Security;
using System.Net.Sockets;

namespace spotware
{
    public partial class Connection
    {
        public void Connect()
        {
            try
            {
                _log.Info($"Connecting to {_gateway}:{_port}...");
                _tcpClient = new TcpClient(_gateway, _port) { NoDelay = true };
            }
            catch (Exception ex)
            {
                _log.Error($"Connecting to {_gateway}:{_port} :: {ex}");
                throw;
            }

            _sslStream = new SslStream(_tcpClient.GetStream(), false, ValidateServerCertificate, null);
            try
            {
                _sslStream.AuthenticateAsClient(_gateway);
            }
            catch (Exception ex)
            {
                _log.Error($"_sslStream.AuthenticateAsClient({_gateway}) :: {ex}");
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
    }
}