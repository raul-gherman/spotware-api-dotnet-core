using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Depth_Quotes_Res()
        {
            ProtoOASubscribeDepthQuotesRes args = Serializer.Deserialize<ProtoOASubscribeDepthQuotesRes>(_processorMemoryStream);

            _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                      $"Subscribe_Depth_Quotes_Res");

            OnSubscribeDepthQuotesRes_Received?.Invoke(args);
        }

        public event SubscribeDepthQuotesResReceived OnSubscribeDepthQuotesRes_Received;

        public delegate void SubscribeDepthQuotesResReceived(ProtoOASubscribeDepthQuotesRes args);
    }
}