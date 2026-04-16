using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak2
{
    internal interface ISmartDevice
    {
        int Wattage { get; set; }
        string RoomName { get; set; }

        double CalculateMothlyCost(Double pricePerKwh);
    }
}
