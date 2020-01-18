using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Trigger_Event()
        {
            ProtoOAMarginCallTriggerEvent args = Serializer.Deserialize<ProtoOAMarginCallTriggerEvent>(_processorMemoryStream);

            // log

            OnMarginCallTriggerEvent_Received?.Invoke(this, args);
        }

        public event MarginCallTriggerEvent_Received OnMarginCallTriggerEvent_Received;

        public delegate void MarginCallTriggerEvent_Received(object sender, ProtoOAMarginCallTriggerEvent args);
    }
}