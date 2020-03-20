﻿using ProtoBuf;

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
                Trendbars += $"Period: {trendBar.Period}; "         +
                             $"Volume: {trendBar.Volume}; "         +
                             $"Low: {trendBar.Low}; "               +
                             $"deltaOpen: {trendBar.deltaOpen}; "   +
                             $"deltaHigh: {trendBar.deltaHigh}; "   +
                             $"deltaClose: {trendBar.deltaClose}; " +
                             $"utcTimestampInMinutes: {trendBar.utcTimestampInMinutes} | ";
            }

            Log.Info("ProtoOAGetAccountListByAccessTokenRes: "            +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"symbolId: {args.symbolId}; "                       +
                     $"Timestamp: {args.Timestamp}; "                     +
                     $"Trendbars: [{Trendbars}]");

            OnGetTrendbarsResReceived?.Invoke(args);
        }

        public event GetTrendbarsResReceived OnGetTrendbarsResReceived;

        public delegate void GetTrendbarsResReceived(ProtoOAGetTrendbarsRes args);
    }
}