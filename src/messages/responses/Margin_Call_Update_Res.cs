using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Margin_Call_Update_Res()
        {
            ProtoOAMarginCallUpdateRes args = Serializer.Deserialize<ProtoOAMarginCallUpdateRes>(_processorMemoryStream);

            _log.Info("MarginCallUpdate");

            OnMarginCallUpdateRes_Received?.Invoke(this, args);
        }

        public event On_MarginCallUpdateRes_Received OnMarginCallUpdateRes_Received;

        public delegate void On_MarginCallUpdateRes_Received(object sender, ProtoOAMarginCallUpdateRes args);
    }
}