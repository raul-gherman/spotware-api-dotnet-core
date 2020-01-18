using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_Changed_Event()
        {
            ProtoOASymbolChangedEvent args = Serializer.Deserialize<ProtoOASymbolChangedEvent>(_processorMemoryStream);

            // log

            OnSymbolChangedEvent_Received?.Invoke(args);
        }

        public event SymbolChangedEventReceived OnSymbolChangedEvent_Received;

        public delegate void SymbolChangedEventReceived(ProtoOASymbolChangedEvent args);
    }
}