using System;
using System.Collections;
using System.IO;
using System.Text;

namespace spotware
{
    public interface ILog
    {
        void Error(string msg);

        void Info(string msg);
    }

    public static class LogManager
    {
        public static void Configure(string filename)
        {
            XLogger.Instance.Init(filename);
        }

        public static ILog GetLogger()
        {
            return new Logger();
        }
    }

    internal class Logger : ILog
    {
        public void Error(string msg)
        {
            Log(" ERR ", msg);
        }

        public void Info(string msg)
        {
            Log(" INF ", msg);
        }

        private static void Log(string logtype, string msg)
        {
            XLogger.Instance.Log(logtype, msg);
        }
    }

    internal class XLogger
    {
        public static readonly XLogger       Instance = new XLogger();
        private                Queue         _que;
        private readonly       StringBuilder _sb = new StringBuilder();

        private XLogger()
        {
        }

        private string _logFileName;

        public void Init(string filename)
        {
            _que         = new Queue();
            _logFileName = filename;
            System.Timers.Timer saveTimer = new System.Timers.Timer(1000)
                                            {
                                                Enabled   = true,
                                                AutoReset = true
                                            };
            saveTimer.Elapsed += _saveTimer_Elapsed;
        }

        private void _saveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            WriteData();
        }

        public void Log(string logType, string msg)
        {
            _que.Enqueue(FormatLog(logType, msg));
        }


        private string FormatLog(string log, string msg)
        {
            _sb.Clear();
            _sb.Append(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
            _sb.Append(log);
            _sb.AppendLine(msg);
            return _sb.ToString();
        }

        private void WriteData()
        {
            using StreamWriter output = new StreamWriter(_logFileName, true);
            while (_que.Count > 0)
            {
                object o = _que.Dequeue();

                if (o == null)
                    continue;
                Console.Write(o);
                output.Write(o);
            }

            output.Flush();
        }
    }
}