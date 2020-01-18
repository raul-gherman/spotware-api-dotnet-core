using System;
using System.Collections.Generic;
using System.IO;
using Logger;

namespace spotware
{
    public partial class Client
    {
        private readonly ILog _log = LogManager.GetLogger();

        public string Gateway;
        public int    Port;

        public string ClientId;
        public string ClientSecret;

        public string AccessToken;

        private                 Connection   _connection;
        private                 MemoryStream _processorMemoryStream = new MemoryStream();
        private static readonly MemoryStream InnerMemoryStream      = new MemoryStream();

        public readonly Dictionary<long, TradingAccount> TradingAccounts = new Dictionary<long, TradingAccount>();

        public void Connect()
        {
            LogManager.Configure($"spotware-api-{DateTime.Now:yyyy-MM-dd}.log");

            Prepare_Dispatcher();

            _connection = new Connection(Gateway, Port)
                          {
                              KeepAliveMessage = Heartbeat()
                          };

            _connection.OnConnectionEstablished += Authorize;
            _connection.OnMessageReceived       += MessageReceived;
            _connection.Connect();
        }

        private void Authorize(object sender, EventArgs args)
        {
            _log.Info($"Authorizing: ClientId: {ClientId} ClientSecret: {ClientSecret}");
            Send(Application_Auth_Req(ClientId, ClientSecret));
        }

        private void MessageReceived(ProtoMessage args)
        {
            _processorMemoryStream = new MemoryStream(args.Payload);
            _dispatcher[args.payloadType]();
        }
    }
}