using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Res()
        {
            ProtoOAMarginCallUpdateRes args = Serializer.Deserialize<ProtoOAMarginCallUpdateRes>(_processorMemoryStream);

            Log.Info($"ProtoOAMarginCallUpdateRes");

            OnMarginCallUpdateResReceived?.Invoke(this, args);
        }

        public event MarginCallUpdateResReceived OnMarginCallUpdateResReceived;

        public delegate void MarginCallUpdateResReceived(object sender, ProtoOAMarginCallUpdateRes args);
    }
}