using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Trigger_Event()
        {
            ProtoOAMarginCallTriggerEvent args = Serializer.Deserialize<ProtoOAMarginCallTriggerEvent>(_processorMemoryStream);

            Persist(args);

            OnMarginCallTriggerEventReceived?.Invoke(this, args);
        }

        public event MarginCallTriggerEventReceived OnMarginCallTriggerEventReceived;

        public delegate void MarginCallTriggerEventReceived(object sender, ProtoOAMarginCallTriggerEvent args);
    }
}