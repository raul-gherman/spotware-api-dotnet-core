using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Trigger_Event()
        {
            ProtoOAMarginCallTriggerEvent args = Serializer.Deserialize<ProtoOAMarginCallTriggerEvent>(_processorMemoryStream);

            _log.Info($"ProtoOAMarginCallTriggerEvent | "                                +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId} | "              +
                      $"marginCallType: {args.marginCall.marginCallType} | "             +
                      $"marginLevelThreshold: {args.marginCall.marginLevelThreshold} | " +
                      $"utcLastUpdateTimestamp: {args.marginCall.utcLastUpdateTimestamp}");

            OnMarginCallTriggerEventReceived?.Invoke(this, args);
        }

        public event MarginCallTriggerEventReceived OnMarginCallTriggerEventReceived;

        public delegate void MarginCallTriggerEventReceived(object sender, ProtoOAMarginCallTriggerEvent args);
    }
}