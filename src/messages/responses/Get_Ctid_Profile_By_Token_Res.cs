using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Ctid_Profile_By_Token_Res()
        {
            ProtoOAGetCtidProfileByTokenRes args = Serializer.Deserialize<ProtoOAGetCtidProfileByTokenRes>(_processorMemoryStream);

            Log.Info("ProtoOAGetCtidProfileByTokenRes: " +
                     $"Profile.userId: {args.Profile.userId}");

            OnGetCtidProfileByTokenResReceived?.Invoke(args);
        }

        public event GetCtidProfileByTokenResReceived OnGetCtidProfileByTokenResReceived;

        public delegate void GetCtidProfileByTokenResReceived(ProtoOAGetCtidProfileByTokenRes args);
    }
}