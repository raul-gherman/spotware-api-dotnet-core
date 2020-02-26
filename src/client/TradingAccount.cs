using System;
using System.Collections.Generic;

namespace spotware
{
    public class TradingAccount
    {
        public readonly long          CtidTraderAccount;
        public          ProtoOATrader Trader { get; set; }

        public readonly Dictionary<long, TradingSymbol>   TradingSymbols = new Dictionary<long, TradingSymbol>();
        public readonly Dictionary<long, ProtoOAPosition> Positions      = new Dictionary<long, ProtoOAPosition>();
        public readonly Dictionary<long, ProtoOAOrder>    Orders         = new Dictionary<long, ProtoOAOrder>();

        public TradingAccount(Client client, long ctid)
        {
            CtidTraderAccount               =  ctid;
            client.OnExecutionEventReceived += ExecutionEventReceived;
        }

        private void ExecutionEventReceived(ProtoOAExecutionEvent args)
        {
            if (args.ctidTraderAccountId != CtidTraderAccount)
                return;
            switch (args.executionType)
            {
                case ProtoOAExecutionType.OrderAccepted:
                {
                    if (args.Order.closingOrder)
                    {
                        if (Positions.ContainsKey(args.Position.positionId))
                            Positions.Remove(args.Position.positionId);
                    }
                    else
                    {
                        switch (args.Order.orderType)
                        {
                            case ProtoOAOrderType.Limit:
                            case ProtoOAOrderType.Stop:
                            case ProtoOAOrderType.StopLimit:
                                Orders[args.Order.orderId] = args.Order;
                                break;
                            case ProtoOAOrderType.Market:
                            case ProtoOAOrderType.MarketRange:
                            case ProtoOAOrderType.StopLossTakeProfit:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    break;
                }

                case ProtoOAExecutionType.OrderFilled:
                {
                    if (Orders.ContainsKey(args.Order.orderId))
                        Orders.Remove(args.Order.orderId);

                    switch (args.Position.positionStatus)
                    {
                        case ProtoOAPositionStatus.PositionStatusOpen:
                        {
                            Positions[args.Position.positionId] = args.Position;
                            break;
                        }

                        case ProtoOAPositionStatus.PositionStatusClosed:
                        {
                            if (Positions.ContainsKey(args.Position.positionId))
                                Positions.Remove(args.Position.positionId);

                            break;
                        }

                        case ProtoOAPositionStatus.PositionStatusCreated:
                        {
                            Positions[args.Position.positionId] = args.Position;
                            break;
                        }

                        case ProtoOAPositionStatus.PositionStatusError:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                }

                case ProtoOAExecutionType.OrderReplaced:
                {
                    Orders[args.Order.orderId] = args.Order;
                    break;
                }

                case ProtoOAExecutionType.OrderCancelled:
                case ProtoOAExecutionType.OrderExpired:
                {
                    if (Orders.ContainsKey(args.Order.orderId))
                        Orders.Remove(args.Order.orderId);

                    break;
                }

                case ProtoOAExecutionType.OrderPartialFill:
                case ProtoOAExecutionType.OrderCancelRejected:
                {
                    Orders[args.Order.orderId]          = args.Order;
                    Positions[args.Position.positionId] = args.Position;
                    break;
                }

                case ProtoOAExecutionType.OrderRejected:
                case ProtoOAExecutionType.BonusDepositWithdraw:
                case ProtoOAExecutionType.DepositWithdraw:
                case ProtoOAExecutionType.Swap:
                {
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}