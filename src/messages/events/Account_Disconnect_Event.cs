using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Disconnect_Event()
        {
            ProtoOAAccountDisconnectEvent args = Serializer.Deserialize<ProtoOAAccountDisconnectEvent>(_processorMemoryStream);

            Log.Info("ProtoOAAccountDisconnectEvent | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnAccountDisconnectEventReceived?.Invoke(args);
        }

        public event AccountDisconnectEventReceived OnAccountDisconnectEventReceived;

        public delegate void AccountDisconnectEventReceived(ProtoOAAccountDisconnectEvent args);
    }
}