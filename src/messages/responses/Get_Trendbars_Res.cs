using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Trendbars_Res()
        {
            ProtoOAGetTrendbarsRes args = Serializer.Deserialize<ProtoOAGetTrendbarsRes>(_processorMemoryStream);

            string Trendbars = string.Empty;
            foreach (ProtoOATrendbar trendBar in args.Trendbars)
            {
                Trendbars += $"deltaClose: {trendBar.deltaClose} | "                       +
                             $"deltaHigh: {trendBar.deltaHigh} | "                         +
                             $"Low: {trendBar.Low} | "                                     +
                             $"Period: {trendBar.Period} | "                               +
                             $"Volume: {trendBar.Volume} | "                               +
                             $"utcTimestampInMinutes: {trendBar.utcTimestampInMinutes} | " +
                             $"deltaOpen: {trendBar.deltaOpen}";
            }

            Log.Info("ProtoOAGetAccountListByAccessTokenRes | "            +
                     $"symbolId: {args.symbolId} | "                       +
                     $"Timestamp: {args.Timestamp} | "                     +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Trendbars: [{Trendbars}]");

            OnGetTrendbarsResReceived?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsResReceived;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}