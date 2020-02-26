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
            }

            foreach (ProtoOAOrder order in args.Orders)
            {
                TradingAccounts[args.ctidTraderAccountId].Orders[order.orderId] = order;
            }

            Persist(args);

            OnReconcileResReceived?.Invoke(args);

            Send(Symbols_List_Req(args.ctidTraderAccountId));
        }

        public event ReconcileResReceived OnReconcileResReceived;

        public delegate void ReconcileResReceived(ProtoOAReconcileRes args);
    }
}