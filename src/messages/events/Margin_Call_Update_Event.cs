using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Event()
        {
            ProtoOAMarginCallUpdateEvent args = Serializer.Deserialize<ProtoOAMarginCallUpdateEvent>(_processorMemoryStream);

            _log.Info($"ProtoOAMarginCallUpdateEvent | "                                 +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId} | "              +
                      $"marginCallType: {args.marginCall.marginCallType} | "             +
                      $"marginLevelThreshold: {args.marginCall.marginLevelThreshold} | " +
                      $"utcLastUpdateTimestamp: {args.marginCall.utcLastUpdateTimestamp}");

            OnMarginCallUpdateEventReceived?.Invoke(this, args);
        }

        public event MarginCallUpdateEventReceived OnMarginCallUpdateEventReceived;

        public delegate void MarginCallUpdateEventReceived(object sender, ProtoOAMarginCallUpdateEvent args);
    }
}