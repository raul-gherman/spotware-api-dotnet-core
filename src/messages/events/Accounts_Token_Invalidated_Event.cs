using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Accounts_Token_Invalidated_Event()
        {
            ProtoOAAccountsTokenInvalidatedEvent args = Serializer.Deserialize<ProtoOAAccountsTokenInvalidatedEvent>(_processorMemoryStream);

            string ctidTraderAccountIds = string.Empty;
            foreach (long ctid in args.ctidTraderAccountIds)
            {
                ctidTraderAccountIds += ctid + " | ";
            }

            Log.Info($"ProtoOAAccountsTokenInvalidatedEvent | "      +
                     $"ctidTraderAccountIds: {ctidTraderAccountIds}" +
                     $"Reason: {args.Reason}");

            Send(Refresh_Token_Req(_refreshToken));

            OnAccountsTokenInvalidatedEventReceived?.Invoke(args);
        }

        public event AccountsTokenInvalidatedEventReceived OnAccountsTokenInvalidatedEventReceived;

        public delegate void AccountsTokenInvalidatedEventReceived(ProtoOAAccountsTokenInvalidatedEvent args);
    }
}