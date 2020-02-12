using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Accounts_By_Access_Token_Res()
        {
            ProtoOAGetAccountListByAccessTokenRes args = Serializer.Deserialize<ProtoOAGetAccountListByAccessTokenRes>(_processorMemoryStream);

            foreach (ProtoOACtidTraderAccount account in args.ctidTraderAccounts)
            {
                TradingAccounts[(long) account.ctidTraderAccountId] = new TradingAccount(this, (long) account.ctidTraderAccountId);

                _log.Info($"ProtoOAGetAccountListByAccessTokenRes | "              +
                          $"ctidTraderAccountId: {account.ctidTraderAccountId} | " +
                          $"traderLogin: {account.traderLogin} | "                 +
                          $"isLive: {account.isLive} ");

                Send(Account_Auth_Req((long) account.ctidTraderAccountId, AccessToken));
            }

            OnGetAccountListByAccessTokenResReceived?.Invoke(args);
        }

        public event GetAccountListByAccessTokenResReceived OnGetAccountListByAccessTokenResReceived;

        public delegate void GetAccountListByAccessTokenResReceived(ProtoOAGetAccountListByAccessTokenRes args);
    }
}