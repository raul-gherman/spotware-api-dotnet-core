using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Auth_Res()
        {
            ProtoOAAccountAuthRes args = Serializer.Deserialize<ProtoOAAccountAuthRes>(_processorMemoryStream);

            _log.Info($"TradingAccount {args.ctidTraderAccountId} authorized");

            Send(Trader_Req(args.ctidTraderAccountId));

            OnAccountAuthRes_Received?.Invoke(args);
        }

        public event AccountAuthResReceived OnAccountAuthRes_Received;

        public delegate void AccountAuthResReceived(ProtoOAAccountAuthRes args);
    }
}