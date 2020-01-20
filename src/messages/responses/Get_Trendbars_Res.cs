using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Trendbars_Res()
        {
            ProtoOAGetTrendbarsRes args = Serializer.Deserialize<ProtoOAGetTrendbarsRes>(_processorMemoryStream);

            foreach (ProtoOATrendbar trend_bar in args.Trendbars)
            {
                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                          $"symbolId: {args.symbolId} | "                  +
                          $"Period: {args.Period} | "                      +
                          $"Timestamp: {args.Timestamp} | "                +
                          $"Low: {trend_bar.Low} | "                       +
                          $"deltaOpen: {trend_bar.deltaOpen} | "           +
                          $"deltaHigh: {trend_bar.deltaHigh} | "           +
                          $"deltaClose: {trend_bar.deltaClose} | "         +
                          $"Volume: {trend_bar.Volume} | "                 +
                          $"Period: {trend_bar.Period}");
            }

            OnGetTrendbarsRes_Received?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsRes_Received;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}