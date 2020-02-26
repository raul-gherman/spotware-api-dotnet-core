using System.Collections.Generic;
using System.IO;

namespace spotware
{
    public partial class Client
    {
        private static readonly ILog Log = LogManager.GetLogger();

        public string Gateway;
        public int    Port;

        public string ClientId;
        public string ClientSecret;

        public string AccessToken;
        public string RefreshToken;

        private                 Connection   _connection;
        private                 MemoryStream _processorMemoryStream = new MemoryStream();
        private static readonly MemoryStream InnerMemoryStream      = new MemoryStream();

        public readonly Dictionary<long, TradingAccount> TradingAccounts = new Dictionary<long, TradingAccount>();
    }
}