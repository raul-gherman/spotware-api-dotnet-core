using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Unsubscribe_Spots_Res()
        {
            ProtoOAUnsubscribeSpotsRes args = Serializer.Deserialize<ProtoOAUnsubscribeSpotsRes>(_processorMemoryStream);

            _log.Info($"ProtoOAUnsubscribeSpotsRes | " +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnUnsubscribeSpotsResReceived?.Invoke(args);
        }

        public event UnsubscribeSpotsResReceived OnUnsubscribeSpotsResReceived;

        public delegate void UnsubscribeSpotsResReceived(ProtoOAUnsubscribeSpotsRes args);
    }
}