using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Spot_Event()
        {
            ProtoOASpotEvent args = Serializer.Deserialize<ProtoOASpotEvent>(_processorMemoryStream);

            // not logging ProtoOASpotEvent
            
            OnSpotEventReceived?.Invoke(args);
        }

        public event SpotEventReceived OnSpotEventReceived;

        public delegate void SpotEventReceived(ProtoOASpotEvent args);
    }
}