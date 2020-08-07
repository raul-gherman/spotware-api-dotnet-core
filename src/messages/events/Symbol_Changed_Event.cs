using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_Changed_Event()
        {
            ProtoOASymbolChangedEvent args = Serializer.Deserialize<ProtoOASymbolChangedEvent>(_processorMemoryStream);

            Log.Info("ProtoOASymbolChangedEvent:: " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"symbolIds: [{string.Join("; ", args.symbolIds)}]");

            Send(Symbol_By_Id_Req(args.ctidTraderAccountId, args.symbolIds));

            OnSymbolChangedEventReceived?.Invoke(args);
        }

        public event SymbolChangedEventReceived OnSymbolChangedEventReceived;

        public delegate void SymbolChangedEventReceived(ProtoOASymbolChangedEvent args);
    }
}