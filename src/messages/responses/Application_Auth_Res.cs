using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Application_Auth_Res()
        {
            ProtoOAApplicationAuthRes args = Serializer.Deserialize<ProtoOAApplicationAuthRes>(_processorMemoryStream);

            _log.Info($"Authorized; retrieve accounts for AccessToken {AccessToken}");

            Send(Get_Accounts_By_Access_Token_Req(AccessToken));

            OnApplicationAuthRes_Received?.Invoke(args);
        }

        public event ApplicationAuthResReceived OnApplicationAuthRes_Received;

        public delegate void ApplicationAuthResReceived(ProtoOAApplicationAuthRes args);
    }
}