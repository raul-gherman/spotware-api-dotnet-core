using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Spot_Event()
        {
            ProtoOASpotEvent args = Serializer.Deserialize<ProtoOASpotEvent>(_processorMemoryStream);

            OnSpotEvent_Received?.Invoke(args);
        }

        public event SpotEventReceived OnSpotEvent_Received;

        public delegate void SpotEventReceived(ProtoOASpotEvent args);
    }
}