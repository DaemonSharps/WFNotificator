using System;
using System.Collections.Generic;
using System.Text;

namespace WFNotificator.Helpers
{
    public static class Timers
    {
        public static Int32 TenSeconds => (Int32)Spans.TenSeconds.TotalMilliseconds;

        public static Int32 OneMinute => (Int32)Spans.OneMinute.TotalMilliseconds;

        public static Int32 ThirtySeconds => (Int32)Spans.ThirtySeconds.TotalMilliseconds;

        public static Int32 FiveMinutes => (Int32)Spans.FiveMinutes.TotalMilliseconds;

        internal static class Spans
        {
            internal static TimeSpan TenSeconds => TimeSpan.FromSeconds(10);

            internal static TimeSpan ThirtySeconds => TimeSpan.FromSeconds(30);

            internal static TimeSpan OneMinute => TimeSpan.FromMinutes(1);

            internal static TimeSpan FiveMinutes => TimeSpan.FromMinutes(5);
        }
    }
}
