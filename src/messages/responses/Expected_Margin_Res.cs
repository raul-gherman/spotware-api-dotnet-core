using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Expected_Margin_Res()
        {
            ProtoOAExpectedMarginRes args = Serializer.Deserialize<ProtoOAExpectedMarginRes>(_processorMemoryStream);

            Persist(args);

            OnExpectedMarginResReceived?.Invoke(args);
        }

        public event ExpectedMarginResReceived OnExpectedMarginResReceived;

        public delegate void ExpectedMarginResReceived(ProtoOAExpectedMarginRes args);
    }
}