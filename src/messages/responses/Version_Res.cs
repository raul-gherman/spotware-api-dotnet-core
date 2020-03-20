using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Version_Res()
        {
            ProtoOAVersionRes args = Serializer.Deserialize<ProtoOAVersionRes>(_processorMemoryStream);

            Log.Info($"ProtoOAVersionRes:: " +
                     $"Version: {args.Version}");

            Send(Application_Auth_Req(_clientId, _clientSecret));

            OnVersionResReceived?.Invoke(args);
        }

        public event VersionResReceived OnVersionResReceived;

        public delegate void VersionResReceived(ProtoOAVersionRes args);
    }
}