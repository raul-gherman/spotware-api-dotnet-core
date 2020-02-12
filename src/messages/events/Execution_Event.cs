﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Execution_Event()
        {
            ProtoOAExecutionEvent args = Serializer.Deserialize<ProtoOAExecutionEvent>(_processorMemoryStream);

            _log.Info($"ProtoOAExecutionEvent | " +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId}"); // TODO

            OnExecutionEventReceived?.Invoke(args);
        }

        public event ExecutionEventReceived OnExecutionEventReceived;

        public delegate void ExecutionEventReceived(ProtoOAExecutionEvent args);
    }
}