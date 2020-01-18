using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Logout_Res()
        {
            ProtoOAAccountLogoutRes args = Serializer.Deserialize<ProtoOAAccountLogoutRes>(_processorMemoryStream);

            _log.Info($"TradingAccount {args.ctidTraderAccountId} logout");

            OnAccountLogout_Received?.Invoke(args);
        }

        public event AccountLogoutReceived OnAccountLogout_Received;

        public delegate void AccountLogoutReceived(ProtoOAAccountLogoutRes args);
    }
}