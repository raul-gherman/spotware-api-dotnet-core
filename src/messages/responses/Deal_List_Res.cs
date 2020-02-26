using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Deal_List_Res()
        {
            ProtoOADealListRes args = Serializer.Deserialize<ProtoOADealListRes>(_processorMemoryStream);

            Persist(args);

            OnDealListResReceived?.Invoke(args);
        }

        public event DealListResReceived OnDealListResReceived;

        public delegate void DealListResReceived(ProtoOADealListRes args);
    }
}