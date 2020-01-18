using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_List_Res()
        {
            ProtoOAMarginCallListRes args = Serializer.Deserialize<ProtoOAMarginCallListRes>(_processorMemoryStream);

            // log

            OnMarginCallListRes_Received?.Invoke(this, args);
        }

        public event MarginCallListRes_Received OnMarginCallListRes_Received;

        public delegate void MarginCallListRes_Received(object sender, ProtoOAMarginCallListRes args);
    }
}