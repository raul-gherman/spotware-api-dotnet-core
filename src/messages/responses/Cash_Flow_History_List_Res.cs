using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Cash_Flow_History_List_Res()
        {
            ProtoOACashFlowHistoryListRes args = Serializer.Deserialize<ProtoOACashFlowHistoryListRes>(_processorMemoryStream);

            foreach (ProtoOADepositWithdraw depositWithdraw in args.depositWithdraws)
            {
                string item = $"operationType: {depositWithdraw.operationType}; " +
                              $"Equity: {depositWithdraw.Equity}; " +
                              $"Balance: {depositWithdraw.Balance}; " +
                              $"balanceVersion: {depositWithdraw.balanceVersion}; " +
                              $"balanceHistoryId: {depositWithdraw.balanceHistoryId}; " +
                              $"Delta: {depositWithdraw.Delta}; " +
                              $"externalNote: {depositWithdraw.externalNote}; " +
                              $"changeBalanceTimestamp: {depositWithdraw.changeBalanceTimestamp}";

                Log.Info("ProtoOACashFlowHistoryListRes:: " +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"depositWithdraws: [{item}]");
            }

            OnCashFlowHistoryListResReceived?.Invoke(args);
        }

        public event CashFlowHistoryListResReceived OnCashFlowHistoryListResReceived;

        public delegate void CashFlowHistoryListResReceived(ProtoOACashFlowHistoryListRes args);
    }
}