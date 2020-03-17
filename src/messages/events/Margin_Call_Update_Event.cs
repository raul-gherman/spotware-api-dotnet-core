using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Event()
        {
            ProtoOAMarginCallUpdateEvent args = Serializer.Deserialize<ProtoOAMarginCallUpdateEvent>(_processorMemoryStream);

            Log.Info("ProtoOAMarginCallUpdateEvent | "   +
                     $"marginCall: {args.marginCall} | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnMarginCallUpdateEventReceived?.Invoke(this, args);
        }

        public event MarginCallUpdateEventReceived OnMarginCallUpdateEventReceived;

        public delegate void MarginCallUpdateEventReceived(object sender, ProtoOAMarginCallUpdateEvent args);
    }
}