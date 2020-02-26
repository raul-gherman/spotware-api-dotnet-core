using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Subscribe_Spots_Res()
        {
            ProtoOASubscribeSpotsRes args = Serializer.Deserialize<ProtoOASubscribeSpotsRes>(_processorMemoryStream);

            Persist(args);

            OnSubscribeSpotsResReceived?.Invoke(args);
        }

        public event SubscribeSpotsResReceived OnSubscribeSpotsResReceived;

        public delegate void SubscribeSpotsResReceived(ProtoOASubscribeSpotsRes args);
    }
}