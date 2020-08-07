using System;
using System.Collections;
using System.IO;

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
        public static readonly XLogger Instance = new XLogger();
        private Queue _que;

        private XLogger()
        {
        }

        private string _logFileName;

        public void Init(string filename)
        {
            _que = new Queue();
            _logFileName = filename;
            System.Timers.Timer saveTimer = new System.Timers.Timer(10)
            {
                Enabled = true,
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


        private static string FormatLog(string log, string msg)
        {
            return $"{(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff"))} {log} {msg}{Environment.NewLine}";
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