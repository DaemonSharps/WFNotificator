using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BatteryCheckWindowsService
{
    public static class Checker
    {
        public static Task Start()
        {
            while (true)
            {
                var info = Battery.GetInfo();

                if (info.Status != BatteryStatus.Uncharging
                    && info.ChargePercent >= 20)
                {
                    CreateToast(info.ChargePercent);
                    Thread.Sleep(60000);
                    ToastNotificationManagerCompat.History.Clear();
                }
            }
        }
        public static void CreateToast(UInt32 percent)
        {
            new ToastContentBuilder()
                .AddText($"Задряд аккумулятора {percent}", hintMaxLines: 1)
                .AddText("Рекомендуем отключить кабель питания.")
                .Show();
        }
    }
}
