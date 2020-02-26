using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Live_Trendbar_Res()
        {
            ProtoOASubscribeLiveTrendbarRes args = Serializer.Deserialize<ProtoOASubscribeLiveTrendbarRes>(_processorMemoryStream);

            Persist(args);

            OnSubscribeLiveTrendbarResReceived?.Invoke(args);
        }

        public event SubscribeLiveTrendbarResReceived OnSubscribeLiveTrendbarResReceived;

        public delegate void SubscribeLiveTrendbarResReceived(ProtoOASubscribeLiveTrendbarRes args);
    }
}