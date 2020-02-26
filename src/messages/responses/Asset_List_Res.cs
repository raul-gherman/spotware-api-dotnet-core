using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_List_Res()
        {
            ProtoOAAssetListRes args = Serializer.Deserialize<ProtoOAAssetListRes>(_processorMemoryStream);

            Persist(args);

            OnAssetListResReceived?.Invoke(args);
        }

        public event AssetListResReceived OnAssetListResReceived;

        public delegate void AssetListResReceived(ProtoOAAssetListRes args);
    }
}