using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Tickdata_Res()
        {
            ProtoOAGetTickDataRes args = Serializer.Deserialize<ProtoOAGetTickDataRes>(_processorMemoryStream);

            Persist(args);

            OnGetTickDataResReceived?.Invoke(args);
        }

        public event GetTickDataResReceived OnGetTickDataResReceived;

        public delegate void GetTickDataResReceived(ProtoOAGetTickDataRes args);
    }
}