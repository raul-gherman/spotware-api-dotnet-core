using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Accounts_By_Access_Token_Res()
        {
            ProtoOAGetAccountListByAccessTokenRes args = Serializer.Deserialize<ProtoOAGetAccountListByAccessTokenRes>(_processorMemoryStream);

            string ctidTraderAccounts = string.Empty;

            foreach (ProtoOACtidTraderAccount account in args.ctidTraderAccounts)
            {
                TradingAccounts[(long) account.ctidTraderAccountId] = new TradingAccount(this, (long) account.ctidTraderAccountId);

                ctidTraderAccounts += $"isLive: {account.isLive} | "           +
                                      $"traderLogin: {account.traderLogin} | " +
                                      $"ctidTraderAccountId: {account.ctidTraderAccountId}";

                Send(Account_Auth_Req((long) account.ctidTraderAccountId, _accessToken));
            }

            Log.Info("ProtoOAGetAccountListByAccessTokenRes | "    +
                     $"accessToken: {args.accessToken} | "         +
                     $"permissionScope: {args.permissionScope} | " +
                     $"ctidTraderAccounts: [{ctidTraderAccounts}]");

            OnGetAccountListByAccessTokenResReceived?.Invoke(args);
        }

        public event GetAccountListByAccessTokenResReceived OnGetAccountListByAccessTokenResReceived;

        public delegate void GetAccountListByAccessTokenResReceived(ProtoOAGetAccountListByAccessTokenRes args);
    }
}