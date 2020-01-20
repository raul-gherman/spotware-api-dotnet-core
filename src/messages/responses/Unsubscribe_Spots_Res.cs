using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Spots_Res()
        {
            ProtoOAUnsubscribeSpotsRes args = Serializer.Deserialize<ProtoOAUnsubscribeSpotsRes>(_processorMemoryStream);

            _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                      $"Unsubscribe_Spots_Res");

            OnUnsubscribeSpotsRes_Received?.Invoke(args);
        }

        public event UnsubscribeSpotsResReceived OnUnsubscribeSpotsRes_Received;

        public delegate void UnsubscribeSpotsResReceived(ProtoOAUnsubscribeSpotsRes args);
    }
}