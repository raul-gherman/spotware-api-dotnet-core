﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Heartbeat_Event()
        {
            ProtoHeartbeatEvent args = Serializer.Deserialize<ProtoHeartbeatEvent>(_processorMemoryStream);

            Log.Info("ProtoHeartbeatEvent");
            
            Send(Heartbeat());

            OnHeartbeatEventReceived?.Invoke(args);
        }

        public event HeartbeatEventReceived OnHeartbeatEventReceived;

        public delegate void HeartbeatEventReceived(ProtoHeartbeatEvent args);
    }
}