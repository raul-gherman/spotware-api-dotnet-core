using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Client_Disconnect_Event()
        {
            ProtoOAClientDisconnectEvent args = Serializer.Deserialize<ProtoOAClientDisconnectEvent>(_processorMemoryStream);

            //_log.Info($"{args.ctidTraderAccountId} assetClass: {asset_class.Id} {asset_class.Name}");

            OnClientDisconnectEvent_Received?.Invoke(args);
        }

        public event ClientDisconnectEventReceived OnClientDisconnectEvent_Received;

        public delegate void ClientDisconnectEventReceived(ProtoOAClientDisconnectEvent args);
    }
}