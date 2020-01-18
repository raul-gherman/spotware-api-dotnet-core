using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Reconcile_Res()
        {
            ProtoOAReconcileRes args = Serializer.Deserialize<ProtoOAReconcileRes>(_processorMemoryStream);

            foreach (ProtoOAPosition position in args.Positions)
            {
                TradingAccounts[args.ctidTraderAccountId].Positions[position.positionId] = position;

                // log

            }

            foreach (ProtoOAOrder order in args.Orders)
            {
                TradingAccounts[args.ctidTraderAccountId].Orders[order.orderId] = order;

                // log

            }

            Send(Symbols_List_Req(args.ctidTraderAccountId));

            OnReconcileRes_Received?.Invoke(args);
        }

        public event ReconcileResReceived OnReconcileRes_Received;

        public delegate void ReconcileResReceived(ProtoOAReconcileRes args);
    }
}