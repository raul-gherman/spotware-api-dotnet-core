using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Depth_Event()
        {
            ProtoOADepthEvent args = Serializer.Deserialize<ProtoOADepthEvent>(_processorMemoryStream);

            Log.Info($"ProtoOADepthEvent | "                               +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"symbolId: {args.symbolId} | "                       +
                     $"//TODO"); //TODO

            OnDepthEventReceived?.Invoke(args);
        }

        public event DepthEventReceived OnDepthEventReceived;

        public delegate void DepthEventReceived(ProtoOADepthEvent args);
    }
}