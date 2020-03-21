using System;
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
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[symbol.symbolId].Pip    = Math.Pow(10, -symbol.pipPosition);

                string Schedules = string.Empty;
                foreach (ProtoOAInterval interval in symbol.Schedules)
                {
                    Schedules += $"startSecond: {interval.startSecond}; " +
                                 $"endSecond: {interval.endSecond} | ";
                }

                string Symbols = string.Empty;
                Symbols += $"symbolId: {symbol.symbolId}; "                               +
                           $"Digits: {symbol.Digits}; "                                   +
                           $"pipPosition: {symbol.pipPosition}; "                         +
                           $"tradingMode: {symbol.tradingMode}; "                         +
                           $"Commission: {symbol.Commission}; "                           +
                           $"commissionType: {symbol.commissionType}; "                   +
                           $"minCommission: {symbol.minCommission}; "                     +
                           $"minCommissionType: {symbol.minCommissionType}; "             +
                           $"minCommissionAsset: {symbol.minCommissionAsset}; "           +
                           $"gslCharge: {symbol.gslCharge}; "                             +
                           $"gslDistance: {symbol.gslDistance}; "                         +
                           $"maxExposure: {symbol.maxExposure}; "                         +
                           $"maxVolume: {symbol.maxVolume}; "                             +
                           $"minVolume: {symbol.minVolume}; "                             +
                           $"rolloverCommission: {symbol.rolloverCommission}; "           +
                           $"distanceSetIn: {symbol.distanceSetIn}; "                     +
                           $"slDistance: {symbol.slDistance}; "                           +
                           $"tpDistance: {symbol.tpDistance}; "                           +
                           $"stepVolume: {symbol.stepVolume}; "                           +
                           $"swapLong: {symbol.swapLong}; "                               +
                           $"swapShort: {symbol.swapShort}; "                             +
                           $"enableShortSelling: {symbol.enableShortSelling}; "           +
                           $"guaranteedStopLoss: {symbol.guaranteedStopLoss}; "           +
                           $"rolloverCommission3Days: {symbol.rolloverCommission3Days}; " +
                           $"skipRolloverDays: {symbol.skipRolloverDays}; "               +
                           $"scheduleTimeZone: {symbol.scheduleTimeZone}; "               +
                           $"Schedules: [{Schedules}]; "                                  +
                           $"swapCalculationType: {symbol.swapCalculationType}; "         +
                           $"swapRollover3Days: {symbol.swapRollover3Days}";

                Log.Info("ProtoOASymbolByIdRes:: "                            +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Symbol: {Symbols}");
            }
            
            Send(Reconcile_Req(args.ctidTraderAccountId));

            OnSymbolByIdResReceived?.Invoke(args);
        }

        public event SymbolByIdResReceived OnSymbolByIdResReceived;

        public delegate void SymbolByIdResReceived(ProtoOASymbolByIdRes args);
    }
}