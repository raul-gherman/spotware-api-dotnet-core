using System;
using System.Threading;

namespace spotware
{
    public partial class Connection
    {
        private Thread _keepAliveThread;

        public ProtoMessage KeepAliveMessage { private get; set; }

        private void Start_KeepAlive_Thread()
        {
            ProtoMessagesQueue.Enqueue(KeepAliveMessage);
            _keepAliveThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    while (Thread.CurrentThread.IsAlive)
                    {
                        Thread.Sleep(1000);
                        if (DateTime.UtcNow > _nextTimeGate)
                        {
                            ProtoMessagesQueue.Enqueue(KeepAliveMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.Error($"Start_KeepAlive_Thread :: {ex}");
                }
            });
            _keepAliveThread.Start();
        }
    }
}