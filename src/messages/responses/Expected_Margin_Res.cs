using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            foreach (ProtoOAExpectedMargin margin in args.Margins)
            {
                string Margins = string.Empty;
                Margins += $"Volume: {margin.Volume}; "       +
                           $"buyMargin: {margin.buyMargin}; " +
                           $"sellMargin: {margin.sellMargin}";

                Log.Info("ProtoOAExpectedMarginRes:: "                        +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Margin: {Margins}");
            }

            OnExpectedMarginResReceived?.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginResReceived;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}