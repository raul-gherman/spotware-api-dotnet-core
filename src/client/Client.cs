﻿using System;
using System.Collections.Generic;
using System.IO;

namespace spotware
{
    public partial class Client
    {
        public static readonly ILog Log = LogManager.GetLogger();

        private Connection _connection;
        private string     _gateway;
        private int        _port;

        private string _clientId;
        private string _clientSecret;

        private string _accessToken;
        private string _refreshToken;

        private                 MemoryStream _processorMemoryStream = new MemoryStream();
        private static readonly MemoryStream InnerMemoryStream      = new MemoryStream();

        public readonly Dictionary<long, TradingAccount> TradingAccounts = new Dictionary<long, TradingAccount>();

        private bool _subscribeAllSymbols = false;

        public Client()
        {
            ReadVariablesFromEnvironment();
        }

        private void ReadVariablesFromEnvironment()
        {
            LogManager.Configure($"spotware-api-{DateTime.UtcNow:yyyy-MM-dd}.log");

            _gateway = Environment.GetEnvironmentVariable("SPOTWARE_API_GATEWAY")
                       ?? throw new Exception("SPOTWARE_API_GATEWAY not set");
            _port = int.Parse(Environment.GetEnvironmentVariable("SPOTWARE_API_PORT")
                              ?? throw new Exception("SPOTWARE_API_PORT not set"));

            _clientId = Environment.GetEnvironmentVariable("SPOTWARE_API_CLIENT_ID")
                        ?? throw new Exception("SPOTWARE_API_CLIENT_ID not set");
            _clientSecret = Environment.GetEnvironmentVariable("SPOTWARE_API_CLIENT_SECRET")
                            ?? throw new Exception("SPOTWARE_API_CLIENT_SECRET not set");

            _accessToken = Environment.GetEnvironmentVariable("SPOTWARE_API_ACCESS_TOKEN")
                           ?? throw new Exception("SPOTWARE_API_ACCESS_TOKEN not set");
            _refreshToken = Environment.GetEnvironmentVariable("SPOTWARE_API_REFRESH_TOKEN")
                            ?? throw new Exception("SPOTWARE_API_REFRESH_TOKEN not set");

            _subscribeAllSymbols = bool.Parse(Environment.GetEnvironmentVariable("SPOTWARE_SUBSCRIBE_ALL_SYMBOLS")
                                              ?? throw new Exception("SPOTWARE_SUBSCRIBE_ALL_SYMBOLS not set"));
        }
    }
}