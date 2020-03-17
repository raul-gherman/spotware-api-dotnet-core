using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Changed_Event()
        {
            ProtoOAMarginChangedEvent args = Serializer.Deserialize<ProtoOAMarginChangedEvent>(_processorMemoryStream);

            Log.Info("ProtoOAMarginChangedEvent | "      +
                     $"positionId: {args.positionId} | " +
                     $"usedMargin: {args.usedMargin} | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnMarginChangedEventReceived?.Invoke(args);
        }

        public event MarginChangedEventReceived OnMarginChangedEventReceived;

        public delegate void MarginChangedEventReceived(ProtoOAMarginChangedEvent args);
    }
}