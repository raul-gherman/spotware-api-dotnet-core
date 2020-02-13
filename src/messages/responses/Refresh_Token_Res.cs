using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Refresh_Token_Res()
        {
            ProtoOARefreshTokenRes args = Serializer.Deserialize<ProtoOARefreshTokenRes>(_processorMemoryStream);

            _log.Info($"ProtoOARefreshTokenRes | "            +
                      $"tokenType: {args.tokenType} | "       +
                      $"accessToken: {args.accessToken} | "   +
                      $"refreshToken: {args.refreshToken} | " +
                      $"expiresIn: {args.expiresIn}");

            AccessToken  = args.accessToken;
            RefreshToken = args.refreshToken;

            TradingAccounts.Clear();

            _log.Info($"Send(Get_Accounts_By_Access_Token_Req({AccessToken}))");
            Send(Get_Accounts_By_Access_Token_Req(AccessToken));

            OnRefreshTokenResReceived?.Invoke(args);
        }

        public event RefreshTokenResReceived OnRefreshTokenResReceived;

        public delegate void RefreshTokenResReceived(ProtoOARefreshTokenRes args);
    }
}