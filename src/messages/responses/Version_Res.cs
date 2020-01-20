using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Version_Res()
        {
            ProtoOAVersionRes args = Serializer.Deserialize<ProtoOAVersionRes>(_processorMemoryStream);

            _log.Info($"Version: {args.Version}");
            
            OnVersionRes_Received?.Invoke(args);
        }

        public event VersionResReceived OnVersionRes_Received;

        public delegate void VersionResReceived(ProtoOAVersionRes args);
    }
}