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

            string Symbols = String.Empty;

            foreach (ProtoOASymbol symbol in args.Symbols)
            {
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[symbol.symbolId].Symbol = symbol;
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[symbol.symbolId].Pip    = Math.Pow(10, -symbol.pipPosition);

                string Schedules = String.Empty;
                foreach (ProtoOAInterval interval in symbol.Schedules)
                {
                    Schedules += $"startSecond: {interval.startSecond} | " +
                                 $"endSecond: {interval.endSecond} | ";
                }

                Symbols += $"Commission: {symbol.Commission} | "                           +
                           $"commissionType: {symbol.commissionType} | "                   +
                           $"Digits: {symbol.Digits} | "                                   +
                           $"gslCharge: {symbol.gslCharge} | "                             +
                           $"gslDistance: {symbol.gslDistance} | "                         +
                           $"maxExposure: {symbol.maxExposure} | "                         +
                           $"maxVolume: {symbol.maxVolume} | "                             +
                           $"minCommission: {symbol.minCommission} | "                     +
                           $"minVolume: {symbol.minVolume} | "                             +
                           $"pipPosition: {symbol.pipPosition} | "                         +
                           $"rolloverCommission: {symbol.rolloverCommission} | "           +
                           $"Schedules: [{Schedules}] | "                                  +
                           $"slDistance: {symbol.slDistance} | "                           +
                           $"stepVolume: {symbol.stepVolume} | "                           +
                           $"swapLong: {symbol.swapLong} | "                               +
                           $"swapShort: {symbol.swapShort} | "                             +
                           $"symbolId: {symbol.symbolId} | "                               +
                           $"tpDistance: {symbol.tpDistance} | "                           +
                           $"tradingMode: {symbol.tradingMode} | "                         +
                           $"distanceSetIn: {symbol.distanceSetIn} | "                     +
                           $"enableShortSelling: {symbol.enableShortSelling} | "           +
                           $"guaranteedStopLoss: {symbol.guaranteedStopLoss} | "           +
                           $"minCommissionAsset: {symbol.minCommissionAsset} | "           +
                           $"minCommissionType: {symbol.minCommissionType} | "             +
                           $"rolloverCommission3Days: {symbol.rolloverCommission3Days} | " +
                           $"scheduleTimeZone: {symbol.scheduleTimeZone} | "               +
                           $"skipRolloverDays: {symbol.skipRolloverDays} | "               +
                           $"swapCalculationType: {symbol.swapCalculationType} | "         +
                           $"swapRollover3Days: {symbol.swapRollover3Days}";
            }

            Log.Info("ProtoOASymbolByIdRes | "                             +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Symbols: {Symbols}");

            if (_subscribeAllSymbols)
            {
                Send(Subscribe_Spots_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));
            }

            OnSymbolByIdResReceived?.Invoke(args);
        }

        public event SymbolByIdResReceived OnSymbolByIdResReceived;

        public delegate void SymbolByIdResReceived(ProtoOASymbolByIdRes args);
    }
}