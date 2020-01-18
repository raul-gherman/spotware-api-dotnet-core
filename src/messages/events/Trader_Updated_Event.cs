using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Update_Event()
        {
            ProtoOATraderUpdatedEvent args = Serializer.Deserialize<ProtoOATraderUpdatedEvent>(_processorMemoryStream);

            // log

            OnTraderUpdatedEvent_Received.Invoke(args);
        }

        public event TraderUpdatedEventReceived OnTraderUpdatedEvent_Received;

        public delegate void TraderUpdatedEventReceived(ProtoOATraderUpdatedEvent args);
    }
}