using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Depth_Event()
        {
            ProtoOADepthEvent args = Serializer.Deserialize<ProtoOADepthEvent>(_processorMemoryStream);

            string newQuotes = string.Empty;
            foreach (ProtoOADepthQuote newQuote in args.newQuotes)
            {
                newQuotes += $"Id: {newQuote.Id}; " +
                             $"Ask: {newQuote.Ask}; " +
                             $"Bid: {newQuote.Bid}; " +
                             $"Size: {newQuote.Size} | ";
            }

            Log.Info("ProtoOADepthEvent: "                                          +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}; "           +
                     $"symbolId: {args.symbolId}; "                                 +
                     $"deletedQuotes: [{string.Join("; ", args.deletedQuotes)}]; " +
                     $"newQuotes: [{newQuotes}]");

            OnDepthEventReceived?.Invoke(args);
        }

        public event DepthEventReceived OnDepthEventReceived;

        public delegate void DepthEventReceived(ProtoOADepthEvent args);
    }
}