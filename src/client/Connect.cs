using System;
using System.IO;

namespace spotware
{
    public partial class Client
    {
        public void Connect()
        {
            LogManager.Configure($"spotware-api-{DateTime.UtcNow:yyyy-MM-dd}.log");

            Prepare_Dispatcher();

            _connection = new Connection(Gateway, Port)
                          {
                              KeepAliveMessage = Heartbeat()
                          };

            _connection.OnConnectionEstablished += Start_Spotware_Message_Flow;
            _connection.OnMessageReceived       += MessageReceived;
            _connection.Connect();
        }

        private void Start_Spotware_Message_Flow(object sender, EventArgs args)
        {
            _log.Info("Send(Version_Req())");
            Send(Version_Req());
        }

        private void MessageReceived(ProtoMessage args)
        {
            _processorMemoryStream = new MemoryStream(args.Payload);
            _dispatcher[args.payloadType]();
        }
    }
}