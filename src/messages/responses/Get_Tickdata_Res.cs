using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Tickdata_Res()
        {
            ProtoOAGetTickDataRes args = Serializer.Deserialize<ProtoOAGetTickDataRes>(_processorMemoryStream);

            foreach (ProtoOATickData tickData in args.tickDatas)
            {
                _log.Info($"ProtoOAGetTickDataRes | "                           +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"Tick: {tickData.Tick} | "                           +
                          $"Timestamp: {tickData.Timestamp}");
            }

            OnGetTickDataResReceived?.Invoke(args);
        }

        public event GetTickDataResReceived OnGetTickDataResReceived;

        public delegate void GetTickDataResReceived(ProtoOAGetTickDataRes args);
    }
}