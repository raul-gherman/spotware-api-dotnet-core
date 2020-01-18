using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Execution_Event()
        {
            ProtoOAExecutionEvent args = Serializer.Deserialize<ProtoOAExecutionEvent>(_processorMemoryStream);

            OnExecutionEvent_Received?.Invoke(args);
        }

        public event ExecutionEventReceived OnExecutionEvent_Received;

        public delegate void ExecutionEventReceived(ProtoOAExecutionEvent args);
    }
}