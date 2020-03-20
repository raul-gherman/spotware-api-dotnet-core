using System;
using System.IO;

namespace spotware
{
    public partial class Client
    {
        public void Connect()
        {
            Prepare_Dispatcher();

            _connection = new Connection(_gateway, _port)
                          {
                              KeepAliveMessage = Heartbeat()
                          };

            _connection.OnConnectionEstablished += Start_Message_Flow;
            _connection.OnMessageReceived       += MessageReceived;
            _connection.Connect();
        }

        private void Start_Message_Flow(object sender, EventArgs args)
        {
            Send(Version_Req());
        }

        private void MessageReceived(ProtoMessage args)
        {
            _processorMemoryStream = new MemoryStream(args.Payload);
            _dispatcher[args.payloadType]();
        }
    }
}