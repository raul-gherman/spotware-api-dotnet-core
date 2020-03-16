using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Account_Logout_Res()
        {
            ProtoOAAccountLogoutRes args = Serializer.Deserialize<ProtoOAAccountLogoutRes>(_processorMemoryStream);

            Log.Info($"ProtoOAAccountLogoutRes | " +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnAccountLogoutReceived?.Invoke(args);
        }

        public event AccountLogoutReceived OnAccountLogoutReceived;

        public delegate void AccountLogoutReceived(ProtoOAAccountLogoutRes args);
    }
}