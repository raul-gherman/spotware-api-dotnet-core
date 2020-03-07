using System.Collections.Generic;
using System.IO;

namespace spotware
{
    public partial class Client
    {
        private static readonly ILog Log = LogManager.GetLogger();

        private string _gateway;
        private int    _port;

        private string _clientId;
        private string _clientSecret;

        private string _accessToken;
        private string _refreshToken;

        private                 Connection   _connection;
        private                 MemoryStream _processorMemoryStream = new MemoryStream();
        private static readonly MemoryStream InnerMemoryStream      = new MemoryStream();

        public readonly Dictionary<long, TradingAccount> TradingAccounts = new Dictionary<long, TradingAccount>();

        private bool SubscribeAllSymbols = true;

        public Client()
        {
            Initialize();
        }

        public Client(bool subscribeAllSymbols = true)
        {
            SubscribeAllSymbols = subscribeAllSymbols;
            Initialize();
        }

        private void Initialize()
        {
            LogManager.Configure($"spotware-api-{System.DateTime.UtcNow:yyyy-MM-dd}.log");

            _gateway = GetEnvironmentVariable("SPOTWARE_API_GATEWAY");
            _port    = int.Parse(GetEnvironmentVariable("SPOTWARE_API_PORT"));

            _clientId     = GetEnvironmentVariable("SPOTWARE_API_CLIENT_ID");
            _clientSecret = GetEnvironmentVariable("SPOTWARE_API_CLIENT_SECRET");

            _accessToken  = GetEnvironmentVariable("SPOTWARE_API_ACCESS_TOKEN");
            _refreshToken = GetEnvironmentVariable("SPOTWARE_API_REFRESH_TOKEN");
        }

        private static string GetEnvironmentVariable(string key)
        {
            return System.Environment.GetEnvironmentVariable(key);
        }
    }
}