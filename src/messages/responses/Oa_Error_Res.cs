namespace spotware
{
    public partial class Client
    {
        private void Process_Oa_Error_Res()
        {
            ProtoOAErrorRes args = ProtoBuf.Serializer.Deserialize<ProtoOAErrorRes>(_processorMemoryStream);

            _log.Error($"Oa_Error_Res: {args.errorCode} :: {args.Description}");

            OnOaErrorRes_Received?.Invoke(args);
        }

        public event OaErrorResReceived OnOaErrorRes_Received;

        public delegate void OaErrorResReceived(ProtoOAErrorRes args);
    }
}