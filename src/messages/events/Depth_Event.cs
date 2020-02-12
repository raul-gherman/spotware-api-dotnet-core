using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Depth_Event()
        {
            ProtoOADepthEvent args = Serializer.Deserialize<ProtoOADepthEvent>(_processorMemoryStream);

            _log.Info($"ProtoOADepthEvent | "                               +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                      $"symbolID: {args.symbolId}"); // TODO

            OnDepthEventReceived?.Invoke(args);
        }

        public event DepthEventReceived OnDepthEventReceived;

        public delegate void DepthEventReceived(ProtoOADepthEvent args);
    }
}