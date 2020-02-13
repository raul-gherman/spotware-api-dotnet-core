using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Accounts_Token_Invalidated_Event()
        {
            ProtoOAAccountsTokenInvalidatedEvent args = Serializer.Deserialize<ProtoOAAccountsTokenInvalidatedEvent>(_processorMemoryStream);

            foreach (long ctidTraderAccountId in args.ctidTraderAccountIds)
            {
                _log.Info($"ProtoOAAccountsTokenInvalidatedEvent | "       +
                          $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                          $"Reason: {args.Reason}");
            }

            _log.Info($"Send(Refresh_Token_Req({RefreshToken})");
            Send(Refresh_Token_Req(RefreshToken));

            OnAccountsTokenInvalidatedEventReceived?.Invoke(args);
        }

        public event AccountsTokenInvalidatedEventReceived OnAccountsTokenInvalidatedEventReceived;

        public delegate void AccountsTokenInvalidatedEventReceived(ProtoOAAccountsTokenInvalidatedEvent args);
    }
}