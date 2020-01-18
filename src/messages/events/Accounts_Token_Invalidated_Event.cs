using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Accounts_Token_Invalidated_Event()
        {
            ProtoOAAccountsTokenInvalidatedEvent args = Serializer.Deserialize<ProtoOAAccountsTokenInvalidatedEvent>(_processorMemoryStream);

            foreach (long account in args.ctidTraderAccountIds)
            {
                _log.Info($"{args.ctidTraderAccountIds} token invalidated: {args.Reason}");
            }

            OnAccountsTokenInvalidatedEvent_Received?.Invoke(args);
        }

        public event AccountsTokenInvalidatedEventReceived OnAccountsTokenInvalidatedEvent_Received;

        public delegate void AccountsTokenInvalidatedEventReceived(ProtoOAAccountsTokenInvalidatedEvent args);
    }
}