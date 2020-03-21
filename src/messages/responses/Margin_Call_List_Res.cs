using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_List_Res()
        {
            ProtoOAMarginCallListRes args = Serializer.Deserialize<ProtoOAMarginCallListRes>(_processorMemoryStream);

            foreach (ProtoOAMarginCall marginCall in args.marginCalls)
            {
                string marginCalls = string.Empty;
                marginCalls += $"marginCallType: {marginCall.marginCallType}; "             +
                               $"marginLevelThreshold: {marginCall.marginLevelThreshold}; " +
                               $"utcLastUpdateTimestamp: {marginCall.utcLastUpdateTimestamp} ({EpochToString(marginCall.utcLastUpdateTimestamp)}";

                Log.Info("ProtoOAMarginCallListRes:: " +
                         $"marginCall: {marginCalls}");
            }

            OnMarginCallListResReceived?.Invoke(this, args);
        }

        public event MarginCallListResReceived OnMarginCallListResReceived;

        public delegate void MarginCallListResReceived(object sender, ProtoOAMarginCallListRes args);
    }
}