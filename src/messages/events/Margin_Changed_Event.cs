using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Changed_Event()
        {
            ProtoOAMarginChangedEvent args = Serializer.Deserialize<ProtoOAMarginChangedEvent>(_processorMemoryStream);

            // log

            OnMarginChangedEvent_Received?.Invoke(args);
        }

        public event MarginChangedEventReceived OnMarginChangedEvent_Received;

        public delegate void MarginChangedEventReceived(ProtoOAMarginChangedEvent args);
    }
}