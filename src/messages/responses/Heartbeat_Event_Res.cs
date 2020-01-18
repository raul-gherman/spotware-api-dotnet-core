using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Heartbeat_Event()
        {
            ProtoHeartbeatEvent args = Serializer.Deserialize<ProtoHeartbeatEvent>(_processorMemoryStream);

            // log

            OnHeartbeatEvent_Received?.Invoke(args);
        }

        public event HeartbeatEventReceived OnHeartbeatEvent_Received;

        public delegate void HeartbeatEventReceived(ProtoHeartbeatEvent args);
    }
}