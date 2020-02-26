namespace spotware
{
    public partial class Client
    {
        private void Process_Oa_Error_Res()
        {
            ProtoOAErrorRes args = ProtoBuf.Serializer.Deserialize<ProtoOAErrorRes>(_processorMemoryStream);

            Persist(args);

            OnOaErrorResReceived?.Invoke(args);
        }

        public event OaErrorResReceived OnOaErrorResReceived;

        public delegate void OaErrorResReceived(ProtoOAErrorRes args);
    }
}