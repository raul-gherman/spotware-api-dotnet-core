using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Version_Res()
        {
            ProtoOAVersionRes args = Serializer.Deserialize<ProtoOAVersionRes>(_processorMemoryStream);

            _log.Info($"ProtoOAVersionRes | " +
                      $"Version: {args.Version}");

            _log.Info($"Send(Application_Auth_Req({ClientId}, {ClientSecret})");

            Send(Application_Auth_Req(ClientId, ClientSecret));

            OnVersionResReceived?.Invoke(args);
        }

        public event VersionResReceived OnVersionResReceived;

        public delegate void VersionResReceived(ProtoOAVersionRes args);
    }
}