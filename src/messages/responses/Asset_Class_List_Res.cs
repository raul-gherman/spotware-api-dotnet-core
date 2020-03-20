using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_Class_List_Res()
        {
            ProtoOAAssetClassListRes args = Serializer.Deserialize<ProtoOAAssetClassListRes>(_processorMemoryStream);

            string assetClasses = string.Empty;
            foreach (ProtoOAAssetClass assetClass in args.assetClasses)
            {
                assetClasses += $"Id: {assetClass.Id}; " +
                                $"Name: {assetClass.Name} | ";
            }

            Log.Info("ProtoOAAccountLogoutRes: "                          +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                     $"assetClasses: [{assetClasses}]");

            OnAssetClassListResReceived?.Invoke(args);
        }

        public event AssetClassListResReceived OnAssetClassListResReceived;

        public delegate void AssetClassListResReceived(ProtoOAAssetClassListRes args);
    }
}