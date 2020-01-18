using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Live_Trendbar_Res()
        {
            ProtoOAUnsubscribeLiveTrendbarRes args = Serializer.Deserialize<ProtoOAUnsubscribeLiveTrendbarRes>(_processorMemoryStream);

            // log

            OnSubscribeLiveTrendbarRes_Received?.Invoke(args);
        }

        public event SubscribeLiveTrendbarResReceived OnSubscribeLiveTrendbarRes_Received;

        public delegate void SubscribeLiveTrendbarResReceived(ProtoOAUnsubscribeLiveTrendbarRes args);
    }
}