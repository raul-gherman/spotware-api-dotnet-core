using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Live_Trendbar_Res()
        {
            ProtoOAUnsubscribeLiveTrendbarRes args = Serializer.Deserialize<ProtoOAUnsubscribeLiveTrendbarRes>(_processorMemoryStream);

            // log

            OnUnsubscribeLiveTrendbarRes_Received?.Invoke(args);
        }

        public event UnsubscribeLiveTrendbarResReceived OnUnsubscribeLiveTrendbarRes_Received;

        public delegate void UnsubscribeLiveTrendbarResReceived(ProtoOAUnsubscribeLiveTrendbarRes args);
    }
}