// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using Momntz.Common.Monitoring;
//
// namespace Clean.Common.Monitoring
// {
//     public class Instrumentation : IInstrumentation
//     {
//         private readonly TelemetryClient _telemetryClient;
//
//         public Instrumentation(TelemetryClient telemetryClient)
//         {
//             _telemetryClient = telemetryClient;
//         }
//
//         public void Activity(string name, params KeyValuePair<string, string>[] properties)
//         {
//             _telemetryClient.TrackEvent(name, new Dictionary<string, string>(properties));
//         }
//
//         public void Activity(string name)
//         {
//             _telemetryClient.TrackEvent(name);
//         }
//
//         public void Activity(string name, params KeyValuePair<string, double>[] metrics)
//         {
//             _telemetryClient.TrackEvent(name, metrics: new Dictionary<string, double>(metrics));
//         }
//
//         public void TimedActivity(string name, Action action)
//         {
//             var watch = Stopwatch.StartNew();
//             action();
//             watch.Stop();
//
//             var metric = _telemetryClient.GetMetric(new MetricIdentifier(name));
//             metric.TrackValue(watch.ElapsedMilliseconds);
//         }
//
//         public void CaptureException(string message, string description, Exception exception)
//         {
//             _telemetryClient.TrackException(exception, new Dictionary<string, string> {{nameof(message), message}, {nameof(description), description}});
//         }
//     }
// }