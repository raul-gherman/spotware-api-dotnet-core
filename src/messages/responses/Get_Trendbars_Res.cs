using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Trendbars_Res()
        {
            ProtoOAGetTrendbarsRes args = Serializer.Deserialize<ProtoOAGetTrendbarsRes>(_processorMemoryStream);

            foreach (ProtoOATrendbar trendBar in args.Trendbars)
            {
                _log.Info($"ProtoOAGetTrendbarsRes | "                          +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"symbolId: {args.symbolId} | "                       +
                          $"Period: {args.Period} | "                           +
                          $"Timestamp: {args.Timestamp} | "                     +
                          $"Low: {trendBar.Low} | "                             +
                          $"deltaOpen: {trendBar.deltaOpen} | "                 +
                          $"deltaHigh: {trendBar.deltaHigh} | "                 +
                          $"deltaClose: {trendBar.deltaClose} | "               +
                          $"Volume: {trendBar.Volume} | "                       +
                          $"Period: {trendBar.Period}");
            }

            OnGetTrendbarsRes_Received?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsRes_Received;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}