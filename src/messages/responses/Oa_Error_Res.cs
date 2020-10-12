namespace spotware
{
    public partial class Client
    {
        private void Process_Oa_Error_Res()
        {
            ProtoOAErrorRes args = ProtoBuf.Serializer.Deserialize<ProtoOAErrorRes>(_processorMemoryStream);

            Log.Info("ProtoOAErrorRes:: "                                 +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"errorCode: {args.errorCode}; "                     +
                     $"Description: {args.Description}; "                 +
                     $"maintenanceEndTimestamp: {args.maintenanceEndTimestamp} ({EpochToString(args.maintenanceEndTimestamp)})");

            OnOaErrorResReceived?.Invoke(args);
        }

        public event OaErrorResReceived OnOaErrorResReceived;

        public delegate void OaErrorResReceived(ProtoOAErrorRes args);
    }
}