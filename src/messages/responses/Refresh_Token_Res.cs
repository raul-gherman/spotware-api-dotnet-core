using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Refresh_Token_Res()
        {
            ProtoOARefreshTokenRes args = Serializer.Deserialize<ProtoOARefreshTokenRes>(_processorMemoryStream);

            _log.Info($"RefreshTokenRes: | "                  +
                      $"tokenType: {args.tokenType}| "        +
                      $"expiresIn: {args.expiresIn} | "       +
                      $"accessToken: {args.accessToken} | "   +
                      $"refreshToken: {args.refreshToken} | " +
                      $"expiresIn: {args.expiresIn}");

            // TODO: restart the entire flow, from authorization

            OnRefreshTokenRes_Received?.Invoke(args);
        }

        public event RefreshTokenRessReceived OnRefreshTokenRes_Received;

        public delegate void RefreshTokenRessReceived(ProtoOARefreshTokenRes args);
    }
}