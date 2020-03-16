using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Cash_Flow_History_List_Res()
        {
            ProtoOACashFlowHistoryListRes args = Serializer.Deserialize<ProtoOACashFlowHistoryListRes>(_processorMemoryStream);

            string depositWithdraws = String.Empty;
            foreach (ProtoOADepositWithdraw depositWithdraw in args.depositWithdraws)
            {
                depositWithdraws += $"Balance: {depositWithdraw.Balance} | "                   +
                                    $"balanceVersion: {depositWithdraw.balanceVersion} | "     +
                                    $"Delta: {depositWithdraw.Delta} | "                       +
                                    $"Equity: {depositWithdraw.Equity} | "                     +
                                    $"externalNote: {depositWithdraw.externalNote} | "         +
                                    $"operationType: {depositWithdraw.operationType} | "       +
                                    $"balanceHistoryId: {depositWithdraw.balanceHistoryId} | " +
                                    $"changeBalanceTimestamp: {depositWithdraw.changeBalanceTimestamp}";
            }

            Log.Info($"ProtoOACashFlowHistoryListRes | "                   +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"depositWithdraws: {depositWithdraws}");

            OnCashFlowHistoryListResReceived?.Invoke(args);
        }

        public event CashFlowHistoryListResReceived OnCashFlowHistoryListResReceived;

        public delegate void CashFlowHistoryListResReceived(ProtoOACashFlowHistoryListRes args);
    }
}