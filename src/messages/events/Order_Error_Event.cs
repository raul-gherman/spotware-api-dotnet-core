using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Order_Error_Event()
        {
            ProtoOAOrderErrorEvent args = Serializer.Deserialize<ProtoOAOrderErrorEvent>(_processorMemoryStream);

            // log

            OnOrderErrorEvent_Received?.Invoke(args);
        }

        public event OrderErrorEventReceived OnOrderErrorEvent_Received;

        public delegate void OrderErrorEventReceived(ProtoOAOrderErrorEvent args);
    }
}