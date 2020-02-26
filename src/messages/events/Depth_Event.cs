using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Depth_Event()
        {
            ProtoOADepthEvent args = Serializer.Deserialize<ProtoOADepthEvent>(_processorMemoryStream);

            Persist(args); // TODO

            OnDepthEventReceived?.Invoke(args);
        }

        public event DepthEventReceived OnDepthEventReceived;

        public delegate void DepthEventReceived(ProtoOADepthEvent args);
    }
}