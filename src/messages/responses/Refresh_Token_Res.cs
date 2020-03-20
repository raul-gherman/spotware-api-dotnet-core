using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Refresh_Token_Res()
        {
            ProtoOARefreshTokenRes args = Serializer.Deserialize<ProtoOARefreshTokenRes>(_processorMemoryStream);

            _accessToken = args.accessToken;
            System.Environment.SetEnvironmentVariable("SPOTWARE_API_ACCESS_TOKEN", _accessToken);

            _refreshToken = args.refreshToken;
            System.Environment.SetEnvironmentVariable("SPOTWARE_API_REFRESH_TOKEN", _refreshToken);

            TradingAccounts.Clear();

            Log.Info("ProtoOARefreshTokenRes: "             +
                     $"tokenType: {args.tokenType}; "       +
                     $"accessToken: {args.accessToken}; "   +
                     $"refreshToken: {args.refreshToken}; " +
                     $"expiresIn: {args.expiresIn}");

            Send(Get_Accounts_By_Access_Token_Req(_accessToken));

            OnRefreshTokenResReceived?.Invoke(args);
        }

        public event RefreshTokenResReceived OnRefreshTokenResReceived;

        public delegate void RefreshTokenResReceived(ProtoOARefreshTokenRes args);
    }
}