using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Order_Error_Event()
        {
            ProtoOAOrderErrorEvent args = Serializer.Deserialize<ProtoOAOrderErrorEvent>(_processorMemoryStream);

            Log.Info("ProtoOAOrderErrorEvent: "                           +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"orderId: {args.orderId}; "                         +
                     $"positionId: {args.positionId}; "                   +
                     $"errorCode: {args.errorCode}; "                     +
                     $"Description: {args.Description}");

            OnOrderErrorEventReceived?.Invoke(args);
        }

        public event OrderErrorEventReceived OnOrderErrorEventReceived;

        public delegate void OrderErrorEventReceived(ProtoOAOrderErrorEvent args);
    }
}