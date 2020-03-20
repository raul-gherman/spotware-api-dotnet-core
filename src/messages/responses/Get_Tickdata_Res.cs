using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Tickdata_Res()
        {
            ProtoOAGetTickDataRes args = Serializer.Deserialize<ProtoOAGetTickDataRes>(_processorMemoryStream);

            string tickDatas = string.Empty;
            foreach (ProtoOATickData tickData in args.tickDatas)
            {
                tickDatas += $"Tick: {tickData.Tick} | " +
                             $"Timestamp: {tickData.Timestamp}";
            }

            Log.Info("ProtoOAGetTickDataRes | "                        +
                     $"accessToken: {args.hasMore} | "                 +
                     $"permissionScope: {args.ctidTraderAccountId} | " +
                     $"tickDatas: [{tickDatas}]");

            OnGetTickDataResReceived?.Invoke(args);
        }

        public event GetTickDataResReceived OnGetTickDataResReceived;

        public delegate void GetTickDataResReceived(ProtoOAGetTickDataRes args);
    }
}