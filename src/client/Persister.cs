using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace spotware
{
    public partial class Client
    {
        private Thread _persisterThread;

        private static Queue<object> PersisterQueue = new Queue<object>();

        private static void Persist(object message)
        {
            PersisterQueue.Enqueue(message);
        }

        private void Start_Persister_Thread()
        {
            _persisterThread = new Thread(() =>
                                          {
                                              Thread.CurrentThread.IsBackground = true;
                                              WriteToPersistenceLayer();
                                          });
            _persisterThread.Start();
        }

        private static void WriteToPersistenceLayer()
        {
            try
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    Thread.Sleep(1);

                    if (PersisterQueue.Count <= 0)
                        continue;
                    Log.Info(GetObjectDetails(PersisterQueue.Dequeue()));
                }
            }
            catch (Exception ex)
            {
                Log.Error($"WriteToPersistenceLayer :: {ex}");
            }
        }

        private static string GetObjectDetails(object o)
        {
            string logMessage = "";
            try
            {
                PropertyInfo[] properties = o.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string name      = property.Name;
                    object value     = property.GetValue(o);
                    Type   valueType = value.GetType();

                    if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        List<object> myList = ((IEnumerable<object>) value).ToList();
                        if (myList.Count <= 0)
                        {
                            logMessage += $"{name}=[] ";
                            continue;
                        }

                        logMessage += $"{name}={Environment.NewLine}[";

                        for (int i = myList.Count; i-- > 0;)
                        {
                            logMessage += Environment.NewLine;
                            logMessage += $"  {GetObjectDetails(myList[i])}";
                        }

                        logMessage += Environment.NewLine;
                        logMessage += "] ";
                    }
                    else if (valueType.IsArray)
                    {
                        string arrayObjects = "[";

                        foreach (object obj in (Array) value)
                        {
                            arrayObjects += $"{obj} ";
                        }

                        arrayObjects += "]";
                        logMessage   += $"{name}={arrayObjects} ";
                    }
                    else if (name != "payloadType")
                    {
                        if (valueType.IsClass && !valueType.Namespace.Equals("System"))
                            logMessage += $"{name}=[{GetObjectDetails(value)}] ";
                        else
                            logMessage += $"{name}={value} ";
                    }
                    else logMessage += $"{name}={value} ";
                }
            }
            catch
            {
                // ignored
            }

            return logMessage;
        }
    }
}