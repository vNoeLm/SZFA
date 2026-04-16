using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak2
{
    public enum DeviceStatus
    {
        On,
        Off,
        Standby
    }
    internal abstract class Appliance : ISmartDevice, IComparable<Appliance>
    {
        public int Wattage { get; set; }
        public string RoomName { get; set; }

        DeviceStatus Status;
        public DeviceStatus _Status { get { return Status; } }

        public static Random rnd = new Random();
        public Appliance(int wattage, string roomName)
        {
            Wattage = wattage;
            RoomName = roomName;
        }

        public Appliance(DeviceStatus status)
        {
            this.Status = status;
        }

        public abstract double CalculateMothlyCost(double pricePerKwh);

        public int CompareTo(Appliance? other)
        {
            if (other is Appliance obj)
            {
                return this.Wattage.CompareTo(obj.Wattage);

            }
            else
            {
                throw new ArgumentException("Object is not an Appliance");
            }
        }
    }
}
