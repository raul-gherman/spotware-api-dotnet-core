using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Trigger_Event()
        {
            ProtoOAMarginCallTriggerEvent args = Serializer.Deserialize<ProtoOAMarginCallTriggerEvent>(_processorMemoryStream);

            Log.Info("ProtoOAMarginCallTriggerEvent | "  +
                     $"marginCall: {args.marginCall} | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnMarginCallTriggerEventReceived?.Invoke(this, args);
        }

        public event MarginCallTriggerEventReceived OnMarginCallTriggerEventReceived;

        public delegate void MarginCallTriggerEventReceived(object sender, ProtoOAMarginCallTriggerEvent args);
    }
}