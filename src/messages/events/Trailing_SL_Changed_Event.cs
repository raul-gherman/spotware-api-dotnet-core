using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trailing_SL_Changed_Event()
        {
            ProtoOATrailingSLChangedEvent args = Serializer.Deserialize<ProtoOATrailingSLChangedEvent>(_processorMemoryStream);

            // log

            OnTrailingSlChangedEvent_Received.Invoke(args);
        }

        public event TrailingSlChangedEventReceived OnTrailingSlChangedEvent_Received;

        public delegate void TrailingSlChangedEventReceived(ProtoOATrailingSLChangedEvent args);
    }
}