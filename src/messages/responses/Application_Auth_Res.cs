using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Application_Auth_Res()
        {
            ProtoOAApplicationAuthRes args = Serializer.Deserialize<ProtoOAApplicationAuthRes>(_processorMemoryStream);

            Persist(args);

            Send(Get_Accounts_By_Access_Token_Req(_accessToken));

            OnApplicationAuthResReceived?.Invoke(args);
        }

        public event ApplicationAuthResReceived OnApplicationAuthResReceived;

        public delegate void ApplicationAuthResReceived(ProtoOAApplicationAuthRes args);
    }
}