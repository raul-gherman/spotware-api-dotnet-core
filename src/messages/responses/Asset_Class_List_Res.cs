using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_Class_List_Res()
        {
            ProtoOAAssetClassListRes args = Serializer.Deserialize<ProtoOAAssetClassListRes>(_processorMemoryStream);

            Persist(args);

            OnAssetClassListResReceived?.Invoke(args);
        }

        public event AssetClassListResReceived OnAssetClassListResReceived;

        public delegate void AssetClassListResReceived(ProtoOAAssetClassListRes args);
    }
}