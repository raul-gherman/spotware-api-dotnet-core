using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Disconnect_Event()
        {
            ProtoOAAccountDisconnectEvent args = Serializer.Deserialize<ProtoOAAccountDisconnectEvent>(_processorMemoryStream);

            _log.Info($"{args.ctidTraderAccountId} disconnected");

            OnAccountDisconnectEvent_Received?.Invoke(args);
        }

        public event AccountDisconnectEventReceived OnAccountDisconnectEvent_Received;

        public delegate void AccountDisconnectEventReceived(ProtoOAAccountDisconnectEvent args);
    }
}