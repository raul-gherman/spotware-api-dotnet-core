using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Depth_Event()
        {
            ProtoOADepthEvent args = Serializer.Deserialize<ProtoOADepthEvent>(_processorMemoryStream);

            //_log.Info($"{args.ctidTraderAccountId} assetClass: {asset_class.Id} {asset_class.Name}");

            OnDepthEvent_Received?.Invoke(args);
        }

        public event DepthEventReceived OnDepthEvent_Received;

        public delegate void DepthEventReceived(ProtoOADepthEvent args);
    }
}