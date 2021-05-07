using System;

namespace BatteryCheckWindowsService
{
    public struct Battery
    {

        public static BatteryInfo GetInfo()
        {
            System.Windows.Forms.PowerStatus status = System.Windows.Forms.SystemInformation.PowerStatus;

            return new BatteryInfo
            {
                ChargePercent = (UInt16)(status.BatteryLifePercent * 100),
                Status = (BatteryStatus)status.PowerLineStatus

            };
        }

    }
    public struct BatteryInfo
    {
        public UInt16 ChargePercent;
        public BatteryStatus Status;

    }
    public enum BatteryStatus : UInt16
    {
        FulliCharged = 255,
        Charging = 1,
        Uncharging = 0,
    }
}
