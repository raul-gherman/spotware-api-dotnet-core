﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Error_Res()
        {
            ProtoErrorRes args = Serializer.Deserialize<ProtoErrorRes>(_processorMemoryStream);

            _log.Error($"ProtoErrorRes: | "                  +
                       $"errorCode: {args.errorCode} |"      +
                       $"Description: {args.Description} | " +
                       $"maintenanceEndTimestamp: {args.maintenanceEndTimestamp}");

            OnErrorResReceived?.Invoke(args);
        }

        public event ErrorResReceived OnErrorResReceived;

        public delegate void ErrorResReceived(ProtoErrorRes args);
    }
}