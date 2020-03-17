using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trailing_SL_Changed_Event()
        {
            ProtoOATrailingSLChangedEvent args = Serializer.Deserialize<ProtoOATrailingSLChangedEvent>(_processorMemoryStream);

            Log.Info("ProtoOATrailingSLChangedEvent | "                    +
                     $"orderId: {args.orderId} | "                         +
                     $"positionId: {args.positionId} | "                   +
                     $"stopPrice: {args.stopPrice} | "                     +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"utcLastUpdateTimestamp: {args.utcLastUpdateTimestamp}");

            OnTrailingSlChangedEventReceived?.Invoke(args);
        }

        public event TrailingSlChangedEventReceived OnTrailingSlChangedEventReceived;

        public delegate void TrailingSlChangedEventReceived(ProtoOATrailingSLChangedEvent args);
    }
}