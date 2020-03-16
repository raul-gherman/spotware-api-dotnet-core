using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Live_Trendbar_Res()
        {
            ProtoOAUnsubscribeLiveTrendbarRes args = Serializer.Deserialize<ProtoOAUnsubscribeLiveTrendbarRes>(_processorMemoryStream);

            Log.Info($"ProtoOAUnsubscribeLiveTrendbarRes | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnUnsubscribeLiveTrendbarResReceived?.Invoke(args);
        }

        public event UnsubscribeLiveTrendbarResReceived OnUnsubscribeLiveTrendbarResReceived;

        public delegate void UnsubscribeLiveTrendbarResReceived(ProtoOAUnsubscribeLiveTrendbarRes args);
    }
}