using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Refresh_Token_Res()
        {
            ProtoOARefreshTokenRes args = Serializer.Deserialize<ProtoOARefreshTokenRes>(_processorMemoryStream);

            AccessToken  = args.accessToken;
            RefreshToken = args.refreshToken;

            TradingAccounts.Clear();

            Persist(args);

            Send(Get_Accounts_By_Access_Token_Req(AccessToken));

            OnRefreshTokenResReceived?.Invoke(args);
        }

        public event RefreshTokenResReceived OnRefreshTokenResReceived;

        public delegate void RefreshTokenResReceived(ProtoOARefreshTokenRes args);
    }
}