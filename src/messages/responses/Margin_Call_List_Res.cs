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
                _log.Info($"ProtoOAMarginCallListRes | "                                +
                          $"marginCallType: {marginCall.marginCallType} | "             +
                          $"marginLevelThreshold: {marginCall.marginLevelThreshold} | " +
                          $"utcLastUpdateTimestamp: {marginCall.utcLastUpdateTimestamp}");
            }

            OnMarginCallListResReceived?.Invoke(this, args);
        }

        public event MarginCallListResReceived OnMarginCallListResReceived;

        public delegate void MarginCallListResReceived(object sender, ProtoOAMarginCallListRes args);
    }
}