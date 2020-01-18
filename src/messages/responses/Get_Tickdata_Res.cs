using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Tickdata_Res()
        {
            ProtoOAGetTickDataRes args = Serializer.Deserialize<ProtoOAGetTickDataRes>(_processorMemoryStream);

            // log

            OnGetTickDataRes_Received?.Invoke(args);
        }

        public event GetTickDataResReceived OnGetTickDataRes_Received;

        public delegate void GetTickDataResReceived(ProtoOAGetTickDataRes args);
    }
}