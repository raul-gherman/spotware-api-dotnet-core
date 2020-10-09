using ProtoBuf;

namespace spotware
{
    public partial class
        Client
    {
        public static ProtoMessage Symbols_For_Conversion_Req(long ctidTraderAccountId, long firstAssetId, long lastAssetId)
        {
            ProtoOASymbolsForConversionReq message = new ProtoOASymbolsForConversionReq
            {
                payloadType         = ProtoOAPayloadType.ProtoOaSymbolsForConversionReq,
                ctidTraderAccountId = ctidTraderAccountId,
                firstAssetId        = firstAssetId,
                lastAssetId         = lastAssetId
            };

            Log.Info("ProtoOASymbolsForConversionReq:: "             +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"firstAssetId: {firstAssetId}; "               +
                     $"lastAssetId: {lastAssetId}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}