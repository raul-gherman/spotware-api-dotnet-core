using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_List_Res()
        {
            ProtoOAMarginCallListRes args = Serializer.Deserialize<ProtoOAMarginCallListRes>(_processorMemoryStream);

            Persist(args);

            OnMarginCallListResReceived?.Invoke(this, args);
        }

        public event MarginCallListResReceived OnMarginCallListResReceived;

        public delegate void MarginCallListResReceived(object sender, ProtoOAMarginCallListRes args);
    }
}