using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            string Margins = String.Empty;
            foreach (ProtoOAExpectedMargin margin in args.Margins)
            {
                Margins += $"Volume: {margin.Volume} | "       +
                           $"buyMargin: {margin.buyMargin} | " +
                           $"sellMargin: {margin.sellMargin}";
            }

            Log.Info($"ProtoOAExpectedMarginRes | "                        +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Margins: {Margins}");

            OnExpectedMarginResReceived?.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginResReceived;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}