using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Order_Error_Event()
        {
            ProtoOAOrderErrorEvent args = Serializer.Deserialize<ProtoOAOrderErrorEvent>(_processorMemoryStream);

            _log.Info($"ProtoOAOrderErrorEvent | "                          +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                      $"positionId: {args.positionId} | "                   +
                      $"orderId: {args.orderId} | "                         +
                      $"errorCode: {args.errorCode} | "                     +
                      $"Description: {args.Description}");

            OnOrderErrorEventReceived?.Invoke(args);
        }

        public event OrderErrorEventReceived OnOrderErrorEventReceived;

        public delegate void OrderErrorEventReceived(ProtoOAOrderErrorEvent args);
    }
}