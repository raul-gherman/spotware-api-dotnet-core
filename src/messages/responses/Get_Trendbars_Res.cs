using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Trendbars_Res()
        {
            ProtoOAGetTrendbarsRes args = Serializer.Deserialize<ProtoOAGetTrendbarsRes>(_processorMemoryStream);

            Persist(args);

            OnGetTrendbarsResReceived?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsResReceived;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}