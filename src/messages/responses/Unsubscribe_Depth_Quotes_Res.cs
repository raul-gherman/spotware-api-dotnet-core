using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Depth_Quotes_Res()
        {
            ProtoOAUnsubscribeDepthQuotesRes args = Serializer.Deserialize<ProtoOAUnsubscribeDepthQuotesRes>(_processorMemoryStream);

            _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                      $"Unsubscribe_Depth_Quotes_Res");
            OnUnsubscribeDepthQuotesRes_Received?.Invoke(args);
        }

        public event UnsubscribeDepthQuotesResReceived OnUnsubscribeDepthQuotesRes_Received;

        public delegate void UnsubscribeDepthQuotesResReceived(ProtoOAUnsubscribeDepthQuotesRes args);
    }
}