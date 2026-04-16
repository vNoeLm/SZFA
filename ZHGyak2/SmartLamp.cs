using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak2
{
    internal class SmartLamp : ISmartDevice
    {
        public int Wattage { get; set; }
        public string RoomName { get; set; }

        int LightIntensity;

        public SmartLamp(int wattage, string RoamName, int lightIntensity)
        {
            this.Wattage = wattage;
            this.RoomName = RoamName;
            this.LightIntensity = lightIntensity;
            if (LightIntensity < 0 || LightIntensity > 100)
            {
                throw new InvalidSettingException();
            }
        }

        public double CalculateMothlyCost(double pricePerKwh)
        {
            double dailyKwhUsage = Wattage * 24 / 1000;
            double monthlyCost = dailyKwhUsage * pricePerKwh;
            return monthlyCost;
        }

        override public string ToString()
        {
            return $"Helyiseg: {RoomName} / Tipus: {this.GetType} / Fogyasztas: {Wattage} W";
        }
    }
}
