using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Changed_Event()
        {
            ProtoOAMarginChangedEvent args = Serializer.Deserialize<ProtoOAMarginChangedEvent>(_processorMemoryStream);

            Log.Info("ProtoOAMarginChangedEvent:: "                       +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"positionId: {args.positionId}; "                   +
                     $"usedMargin: {args.usedMargin}");

            OnMarginChangedEventReceived?.Invoke(args);
        }

        public event MarginChangedEventReceived OnMarginChangedEventReceived;

        public delegate void MarginChangedEventReceived(ProtoOAMarginChangedEvent args);
    }
}