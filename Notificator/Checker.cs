using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Threading;
using WFNotificator.Helpers;

namespace BatteryCheckWindowsService
{
    public static class Checker
    {
        public static void Start()
        {
            while (true)
            {
                
                var info = Battery.GetInfo();

                if (info.Status != BatteryStatus.Uncharging
                    && info.ChargePercent >= 88)
                {
                    CreateToast(info.ChargePercent);
                    
                    
                }

                var interval = GetCheckInterval(info.ChargePercent);
                Thread.Sleep(interval);
                ToastNotificationManagerCompat.History.Clear();
            }
        }
        public static void CreateToast(UInt32 percent)
        {
                new ToastContentBuilder()
                .AddText($"Задряд аккумулятора {percent}", hintMaxLines: 1)
                .AddText("Рекомендуем отключить кабель питания.")
                .SetToastScenario(ToastScenario.Alarm)
                .Show();
        }
        private static Int32 GetCheckInterval(UInt32 percent)
        {

            if (percent >= 98) return Timers.TenSeconds;
            if (percent >= 95) return Timers.ThirtySeconds;
            if (percent >= 90) return Timers.OneMinute;

            return Timers.FiveMinutes;
        }
    }
}
