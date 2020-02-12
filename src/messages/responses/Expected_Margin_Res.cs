using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            foreach (ProtoOAExpectedMargin expectedMargin in args.Margins)
            {
                _log.Info($"ProtoOAExpectedMarginRes | "                        +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"buyMargin: {expectedMargin.buyMargin} | "           +
                          $"sellMargin: {expectedMargin.sellMargin} | "         +
                          $"Volume: {expectedMargin.Volume}");
            }

            OnExpectedMarginResReceived?.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginResReceived;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}