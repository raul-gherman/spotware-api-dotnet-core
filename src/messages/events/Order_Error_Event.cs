using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Order_Error_Event()
        {
            ProtoOAOrderErrorEvent args = Serializer.Deserialize<ProtoOAOrderErrorEvent>(_processorMemoryStream);

            Log.Info("ProtoOAOrderErrorEvent | "           +
                     $"Description: {args.Description} | " +
                     $"errorCode: {args.errorCode} | "     +
                     $"orderId: {args.orderId} | "         +
                     $"positionId: {args.positionId} | "   +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnOrderErrorEventReceived?.Invoke(args);
        }

        public event OrderErrorEventReceived OnOrderErrorEventReceived;

        public delegate void OrderErrorEventReceived(ProtoOAOrderErrorEvent args);
    }
}