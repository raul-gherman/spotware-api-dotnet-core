using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Cash_Flow_History_List_Res()
        {
            ProtoOACashFlowHistoryListRes args = Serializer.Deserialize<ProtoOACashFlowHistoryListRes>(_processorMemoryStream);

            Persist(args);

            OnCashFlowHistoryListResReceived?.Invoke(args);
        }

        public event CashFlowHistoryListResReceived OnCashFlowHistoryListResReceived;

        public delegate void CashFlowHistoryListResReceived(ProtoOACashFlowHistoryListRes args);
    }
}