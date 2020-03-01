using System;
using System.Collections.Generic;

namespace Clean.Common.Monitoring
{
    public interface IInstrumentation
    {
        void Activity(string name);

        void Activity(string name, params KeyValuePair<string, string>[] properties);

        void Activity(string name, params KeyValuePair<string, double>[] metrics);

        void TimedActivity(string name, Action action);

        void CaptureException(string message, string description, Exception exception);
    }
}