using System;
using System.Linq;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_By_Id_Res()
        {
            ProtoOASymbolByIdRes args = Serializer.Deserialize<ProtoOASymbolByIdRes>(_processorMemoryStream);

            foreach (ProtoOASymbol symbol in args.Symbols)
            {
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[symbol.symbolId].Symbol = symbol;
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[symbol.symbolId].Pip = Math.Pow(10, -symbol.pipPosition);
            }

            _log.Info($"Trading account {args.ctidTraderAccountId} symbols ready, subscribing...");

            Send(Subscribe_Spots_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));

            OnSymbolByIdRes_Received?.Invoke(args);
        }

        public event SymbolByIdResReceived OnSymbolByIdRes_Received;

        public delegate void SymbolByIdResReceived(ProtoOASymbolByIdRes args);
    }
}