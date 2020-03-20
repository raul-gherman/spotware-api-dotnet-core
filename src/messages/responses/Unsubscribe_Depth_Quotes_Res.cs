using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Depth_Quotes_Res()
        {
            ProtoOAUnsubscribeDepthQuotesRes args = Serializer.Deserialize<ProtoOAUnsubscribeDepthQuotesRes>(_processorMemoryStream);

            Log.Info("ProtoOAUnsubscribeDepthQuotesRes: " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnUnsubscribeDepthQuotesResReceived?.Invoke(args);
        }

        public event UnsubscribeDepthQuotesResReceived OnUnsubscribeDepthQuotesResReceived;

        public delegate void UnsubscribeDepthQuotesResReceived(ProtoOAUnsubscribeDepthQuotesRes args);
    }
}