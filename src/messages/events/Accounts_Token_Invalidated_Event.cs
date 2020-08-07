using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Accounts_Token_Invalidated_Event()
        {
            ProtoOAAccountsTokenInvalidatedEvent args = Serializer.Deserialize<ProtoOAAccountsTokenInvalidatedEvent>(_processorMemoryStream);

            Log.Info("ProtoOAAccountsTokenInvalidatedEvent:: " +
                     $"ctidTraderAccountIds: [{string.Join("; ", args.ctidTraderAccountIds)}]" +
                     $"Reason: {args.Reason}");

            Send(Refresh_Token_Req(_refreshToken));

            OnAccountsTokenInvalidatedEventReceived?.Invoke(args);
        }

        public event AccountsTokenInvalidatedEventReceived OnAccountsTokenInvalidatedEventReceived;

        public delegate void AccountsTokenInvalidatedEventReceived(ProtoOAAccountsTokenInvalidatedEvent args);
    }
}