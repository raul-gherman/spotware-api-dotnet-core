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
        private const    int                 Heartbeatinterval = 25;
        private          Thread              _senderThread;
        private          DateTime            _nextTimeGate        = DateTime.UtcNow;
        public readonly  Queue<ProtoMessage> ProtoMessagesQueue   = new Queue<ProtoMessage>();
        private readonly MemoryStream        _encoderMemoryStream = new MemoryStream();

        private void Start_Sender_Thread()
        {
            _senderThread = new Thread(() =>
                                       {
                                           Thread.CurrentThread.IsBackground = true;
                                           try
                                           {
                                               while (Thread.CurrentThread.IsAlive)
                                               {
                                                   Thread.Sleep(1);
                                                   if (ProtoMessagesQueue.Count > 0)
                                                   {
                                                       Send(ProtoMessagesQueue.Dequeue());
                                                   }
                                               }
                                           }
                                           catch (Exception ex)
                                           {
                                               _log.Error("Start_Sender_Thread :: " + ex);
                                           }
                                       });
            _senderThread.Start();
        }

        private void Send(ProtoMessage protoMessage)
        {
            _nextTimeGate = DateTime.UtcNow.AddSeconds(Heartbeatinterval);

            _encoderMemoryStream.SetLength(0);
            Serializer.Serialize(_encoderMemoryStream, protoMessage);

            _sslStream.Write(BitConverter.GetBytes(_encoderMemoryStream.ToArray().Length).Reverse().ToArray());
            _sslStream.Write(_encoderMemoryStream.ToArray());

            _sslStream.Flush();
        }
    }
}