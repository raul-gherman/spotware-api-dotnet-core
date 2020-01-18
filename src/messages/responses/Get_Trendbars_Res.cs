using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Trendbars_Res()
        {
            ProtoOAGetTrendbarsRes args = Serializer.Deserialize<ProtoOAGetTrendbarsRes>(_processorMemoryStream);

            // log

            OnGetTrendbarsRes_Received?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsRes_Received;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}