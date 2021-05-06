using System;
using System.Linq;
using System.Management;

namespace BatteryCheckWindowsService
{
    public struct Battery
    {
        public static BatteryInfo GetInfo()
        {
            UInt16 charge = 0;
            UInt16 status = 0;

            using (var searcher = new ManagementObjectSearcher("select * from Win32_Battery"))
            {
                foreach (ManagementObject wmiObj in searcher.Get())
                {
                    foreach (var property in wmiObj.Properties.OfType<PropertyData>().Select(p => new { p.Name, p.Value }))
                    {
                        if (property.Name == "BatteryStatus") status = (UInt16)property.Value;
                        
                        if (property.Name == "EstimatedChargeRemaining") charge = (UInt16)property.Value;

                    }
                }
            }

            return new BatteryInfo
            {
                ChargePercent = charge,
                Status = (BatteryStatus)status

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
        FulliCharged = 3,
        Charging = 2,
        Uncharging = 1,
    }
}
