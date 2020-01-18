using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Event()
        {
            ProtoOAMarginCallUpdateEvent args = Serializer.Deserialize<ProtoOAMarginCallUpdateEvent>(_processorMemoryStream);

            // log

            OnMarginCallUpdateEvent_Received?.Invoke(this, args);
        }

        public event MarginCallUpdateEvent_Received OnMarginCallUpdateEvent_Received;

        public delegate void MarginCallUpdateEvent_Received(object sender, ProtoOAMarginCallUpdateEvent args);
    }
}