using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Client_Disconnect_Event()
        {
            ProtoOAClientDisconnectEvent args = Serializer.Deserialize<ProtoOAClientDisconnectEvent>(_processorMemoryStream);

            Log.Info("ProtoOAClientDisconnectEvent: " +
                     $"Reason: {args.Reason}");

            OnClientDisconnectEventReceived?.Invoke(args);
        }

        public event ClientDisconnectEventReceived OnClientDisconnectEventReceived;

        public delegate void ClientDisconnectEventReceived(ProtoOAClientDisconnectEvent args);
    }
}