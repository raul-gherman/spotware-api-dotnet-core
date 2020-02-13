using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Application_Auth_Res()
        {
            ProtoOAApplicationAuthRes args = Serializer.Deserialize<ProtoOAApplicationAuthRes>(_processorMemoryStream);

            _log.Info($"ProtoOAApplicationAuthRes");
            _log.Info($"Get_Accounts_By_Access_Token_Req({AccessToken})");

            _log.Info($"Send(Get_Accounts_By_Access_Token_Req({AccessToken}))");
            Send(Get_Accounts_By_Access_Token_Req(AccessToken));

            OnApplicationAuthResReceived?.Invoke(args);
        }

        public event ApplicationAuthResReceived OnApplicationAuthResReceived;

        public delegate void ApplicationAuthResReceived(ProtoOAApplicationAuthRes args);
    }
}