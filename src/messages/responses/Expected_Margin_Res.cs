using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            //_log.Info($"{args.ctidTraderAccountId} assetClass: {asset_class.Id} {asset_class.Name}");

            OnExpectedMarginRes_Received.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginRes_Received;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}