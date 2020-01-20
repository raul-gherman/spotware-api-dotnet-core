using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Tickdata_Res()
        {
            ProtoOAGetTickDataRes args = Serializer.Deserialize<ProtoOAGetTickDataRes>(_processorMemoryStream);

            foreach (ProtoOATickData tick_data in args.tickDatas)
            {
                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                          $"Tick: {tick_data.Tick} | "                     +
                          $"Timestamp: {tick_data.Timestamp}");
            }

            OnGetTickDataRes_Received?.Invoke(args);
        }

        public event GetTickDataResReceived OnGetTickDataRes_Received;

        public delegate void GetTickDataResReceived(ProtoOAGetTickDataRes args);
    }
}