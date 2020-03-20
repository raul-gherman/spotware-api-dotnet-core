using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Depth_Quotes_Res()
        {
            ProtoOASubscribeDepthQuotesRes args = Serializer.Deserialize<ProtoOASubscribeDepthQuotesRes>(_processorMemoryStream);

            Log.Info("ProtoOASubscribeDepthQuotesRes: " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnSubscribeDepthQuotesResReceived?.Invoke(args);
        }

        public event SubscribeDepthQuotesResReceived OnSubscribeDepthQuotesResReceived;

        public delegate void SubscribeDepthQuotesResReceived(ProtoOASubscribeDepthQuotesRes args);
    }
}