﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Auth_Res()
        {
            ProtoOAAccountAuthRes args = Serializer.Deserialize<ProtoOAAccountAuthRes>(_processorMemoryStream);

            _log.Info($"ProtoOAAccountAuthRes | " +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            _log.Info($"Send(Trader_Req({args.ctidTraderAccountId}))");
            Send(Trader_Req(args.ctidTraderAccountId));

            OnAccountAuthResReceived?.Invoke(args);
        }

        public event AccountAuthResReceived OnAccountAuthResReceived;

        public delegate void AccountAuthResReceived(ProtoOAAccountAuthRes args);
    }
}