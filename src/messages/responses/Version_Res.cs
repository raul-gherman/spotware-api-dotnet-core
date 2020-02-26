using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Version_Res()
        {
            ProtoOAVersionRes args = Serializer.Deserialize<ProtoOAVersionRes>(_processorMemoryStream);

            Persist(args);

            Send(Application_Auth_Req(ClientId, ClientSecret));

            OnVersionResReceived?.Invoke(args);
        }

        public event VersionResReceived OnVersionResReceived;

        public delegate void VersionResReceived(ProtoOAVersionRes args);
    }
}