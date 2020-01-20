using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Spots_Res()
        {
            ProtoOASubscribeSpotsRes args = Serializer.Deserialize<ProtoOASubscribeSpotsRes>(_processorMemoryStream);

            _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                      $"Subscribe_Spots_Res");
            OnSubscribeSpotsRes_Received?.Invoke(args);
        }

        public event SubscribeSpotsResReceived OnSubscribeSpotsRes_Received;

        public delegate void SubscribeSpotsResReceived(ProtoOASubscribeSpotsRes args);
    }
}