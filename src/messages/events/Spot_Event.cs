﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Spot_Event()
        {
            ProtoOASpotEvent args = Serializer.Deserialize<ProtoOASpotEvent>(_processorMemoryStream);
            
            // not logging spot events, they are way too many...

            OnSpotEventReceived?.Invoke(args);
        }

        public event SpotEventReceived OnSpotEventReceived;

        public delegate void SpotEventReceived(ProtoOASpotEvent args);
    }
}