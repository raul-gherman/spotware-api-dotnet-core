using System;

namespace spotware
{
    public partial class Client
    {
        private static ProtoMessage Encode(uint payloadType, byte[] payload)
        {
            return new ProtoMessage
                   {
                       clientMsgId = DateTime.UtcNow.ToString("yyyyMMddHHmmssffffff"),
                       payloadType = payloadType,
                       Payload     = payload
                   };
        }

        public void Send(ProtoMessage protoMessage)
        {
            _connection.ProtoMessagesQueue.Enqueue(protoMessage);
        }
    }
}