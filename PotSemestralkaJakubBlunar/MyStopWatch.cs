using System;
using System.Diagnostics;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    ///     Stopwatch which can start at specified time.
    /// </summary>
    public class MyStopwatch : Stopwatch
    {
        public MyStopwatch(TimeSpan startOffset)
        {
            StartOffset = startOffset;
        }

        private TimeSpan StartOffset { get; }

        public new TimeSpan Elapsed => base.Elapsed.Add(StartOffset);
    }
}