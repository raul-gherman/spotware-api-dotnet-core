using ProtoBuf;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace spotware
{
    public partial class Connection
    {
        private          Thread       _listenerThread;
        private readonly byte[]       _incomingHeader = new byte[4];
        private          int          _readBytes;
        private          int          _calculatedIncomingRawDataSize;
        private          byte[]       _rawData;
        private          MemoryStream _decoderMemoryStream;
        private          ProtoMessage _incomingMessage = new ProtoMessage();

        private void Start_Listening_Thread()
        {
            _listenerThread = new Thread(() =>
                                         {
                                             Thread.CurrentThread.IsBackground = true;
                                             try
                                             {
                                                 Listen();
                                             }
                                             catch (Exception ex)
                                             {
                                                 _log.Error($"Listen :: {ex}");
                                             }
                                         });
            _listenerThread.Start();
        }

        private void Listen()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                _readBytes = 0;
                do
                {
                    _readBytes += _sslStream.Read(_incomingHeader, _readBytes, _incomingHeader.Length - _readBytes);
                } while (_readBytes < _incomingHeader.Length);

                _calculatedIncomingRawDataSize = BitConverter.ToInt32(_incomingHeader.Reverse().ToArray(), 0);

                if (_calculatedIncomingRawDataSize <= 0)
                {
                    continue;
                }

                _rawData   = new byte[_calculatedIncomingRawDataSize];
                _readBytes = 0;
                do
                {
                    _readBytes += _sslStream.Read(_rawData, _readBytes, _rawData.Length - _readBytes);
                } while (_readBytes < _calculatedIncomingRawDataSize);

                _decoderMemoryStream = new MemoryStream(_rawData);
                _incomingMessage     = Serializer.Deserialize<ProtoMessage>(_decoderMemoryStream);

                OnMessageReceived?.Invoke(_incomingMessage);
            }
        }

        public event MessageReceived OnMessageReceived;

        public delegate void MessageReceived(ProtoMessage args);
    }
}