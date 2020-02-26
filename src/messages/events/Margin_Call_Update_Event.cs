using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Event()
        {
            ProtoOAMarginCallUpdateEvent args = Serializer.Deserialize<ProtoOAMarginCallUpdateEvent>(_processorMemoryStream);

            Persist(args);

            OnMarginCallUpdateEventReceived?.Invoke(this, args);
        }

        public event MarginCallUpdateEventReceived OnMarginCallUpdateEventReceived;

        public delegate void MarginCallUpdateEventReceived(object sender, ProtoOAMarginCallUpdateEvent args);
    }
}