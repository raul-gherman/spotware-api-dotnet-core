using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Error_Res()
        {
            ProtoErrorRes args = Serializer.Deserialize<ProtoErrorRes>(_processorMemoryStream);

            _log.Error($"Error_Res: {args.errorCode} :: {args.Description}");

            OnErrorRes_Received?.Invoke(args);
        }

        public event ErrorResReceived OnErrorRes_Received;

        public delegate void ErrorResReceived(ProtoErrorRes args);
    }
}