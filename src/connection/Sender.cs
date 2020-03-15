using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using ProtoBuf;

namespace spotware
{
    public partial class Connection
    {
        private          Thread              _senderThread;
        private const    int                 HeartbeatIntervalInSeconds = 25;
        private          DateTime            _nextTimeGate              = DateTime.UtcNow;
        public readonly  Queue<ProtoMessage> ProtoMessagesQueue         = new Queue<ProtoMessage>();
        private readonly MemoryStream        _encoderMemoryStream       = new MemoryStream();

        private       int      _outgoingMessageCountPerTimeWindow;
        private const int      MaxOutgoingMessageCountPerTimeWindow = 50;
        private       DateTime _nextOutgoingWindow;
        private const int      OutgoingTimeWindowInMillis = 950;

        private void Start_Sender_Thread()
        {
            _senderThread = new Thread(() =>
                                       {
                                           Thread.CurrentThread.IsBackground = true;

                                           _nextOutgoingWindow = DateTime.UtcNow.AddMilliseconds(OutgoingTimeWindowInMillis);

                                           while (Thread.CurrentThread.IsAlive)
                                           {
                                               Thread.Sleep(1);

                                               if (ProtoMessagesQueue.Count <= 0)
                                                   continue;

                                               if (DateTime.UtcNow >= _nextOutgoingWindow)
                                               {
                                                   _outgoingMessageCountPerTimeWindow = 0;
                                                   _nextOutgoingWindow                = DateTime.UtcNow.AddMilliseconds(OutgoingTimeWindowInMillis);
                                               }

                                               if (_outgoingMessageCountPerTimeWindow >= MaxOutgoingMessageCountPerTimeWindow)
                                               {
                                                   Thread.Sleep((_nextOutgoingWindow - DateTime.UtcNow).Milliseconds);

                                                   _outgoingMessageCountPerTimeWindow = 0;
                                                   _nextOutgoingWindow                = DateTime.UtcNow.AddMilliseconds(OutgoingTimeWindowInMillis);
                                               }

                                               Send(ProtoMessagesQueue.Dequeue());
                                           }
                                       });
            _senderThread.Start();
        }

        private void Send(ProtoMessage protoMessage)
        {
            try
            {
                _encoderMemoryStream.SetLength(0);
                Serializer.Serialize(_encoderMemoryStream, protoMessage);

                _sslStream.Write(BitConverter.GetBytes(_encoderMemoryStream.ToArray().Length).Reverse().ToArray());
                _sslStream.Write(_encoderMemoryStream.ToArray());

                ++_outgoingMessageCountPerTimeWindow;

                _nextTimeGate = DateTime.UtcNow.AddSeconds(HeartbeatIntervalInSeconds);

                _sslStream.Flush();
            }
            catch (Exception ex)
            {
                _log.Error($"Send :: {ex}");
                throw;
            }
        }
    }
}