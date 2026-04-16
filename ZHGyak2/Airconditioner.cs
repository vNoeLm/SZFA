using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak2
{
    internal class Airconditioner : Appliance
    {
        public Airconditioner(int wattage, string roomName) : base(wattage, roomName)
        {
        }
        public Airconditioner(DeviceStatus status) : base(status)
        {
            status = (DeviceStatus)rnd.Next(0, 3);
        }

        public override double CalculateMothlyCost(double pricePerKwh)
        {
            int basePrice = 2000;
            double price = basePrice + (Wattage * 1.5 * pricePerKwh);
            if (_Status == DeviceStatus.Standby)
            {
                price *= 0.1;
            }
            return price;
        }
    }
}
