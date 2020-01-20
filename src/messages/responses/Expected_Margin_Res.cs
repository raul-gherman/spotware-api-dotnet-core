using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            foreach (ProtoOAExpectedMargin expected_margin in args.Margins)
            {
                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                          $"buyMargin: {expected_margin.buyMargin} | "     +
                          $"sellMargin: {expected_margin.sellMargin} | "   +
                          $"Volume: {expected_margin.Volume}");
            }

            OnExpectedMarginRes_Received.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginRes_Received;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}