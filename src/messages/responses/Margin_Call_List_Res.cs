using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_List_Res()
        {
            ProtoOAMarginCallListRes args = Serializer.Deserialize<ProtoOAMarginCallListRes>(_processorMemoryStream);

            string marginCalls = String.Empty;
            foreach (ProtoOAMarginCall marginCall in args.marginCalls)
            {
                marginCalls += $"marginCallType: {marginCall.marginCallType} | "             +
                               $"marginLevelThreshold: {marginCall.marginLevelThreshold} | " +
                               $"utcLastUpdateTimestamp: {marginCall.utcLastUpdateTimestamp}";
            }

            Log.Info("ProtoOAMarginCallListRes | " +
                     $"marginCalls: [{marginCalls}]");

            OnMarginCallListResReceived?.Invoke(this, args);
        }

        public event MarginCallListResReceived OnMarginCallListResReceived;

        public delegate void MarginCallListResReceived(object sender, ProtoOAMarginCallListRes args);
    }
}