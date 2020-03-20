using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trailing_SL_Changed_Event()
        {
            ProtoOATrailingSLChangedEvent args = Serializer.Deserialize<ProtoOATrailingSLChangedEvent>(_processorMemoryStream);

            Log.Info("ProtoOATrailingSLChangedEvent:: "                   +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"orderId: {args.orderId}; "                         +
                     $"positionId: {args.positionId}; "                   +
                     $"stopPrice: {args.stopPrice}; "                     +
                     $"utcLastUpdateTimestamp: {args.utcLastUpdateTimestamp}");

            OnTrailingSlChangedEventReceived?.Invoke(args);
        }

        public event TrailingSlChangedEventReceived OnTrailingSlChangedEventReceived;

        public delegate void TrailingSlChangedEventReceived(ProtoOATrailingSLChangedEvent args);
    }
}