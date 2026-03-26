using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class Envelope : IDeliverable
    {
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }

        public Envelope(int weight, string address, string description, string recipient)
        {
            Weight = weight;
            Address = address;
            Description = description;
            Recipient = recipient;
        }

        public double CalculatePrice(bool fromLocker)
        {
            double price = 0.0;
            switch (Weight)
            {
                case > 2000:
                    throw new OverweightException();
                case <= 50:
                    price = 200;
                    return price;
                case <= 500:
                    price = 400;
                    return price;
                case <= 2000:
                    price = 1000;
                    return price;
            }
        }

        public override string ToString()
        {
            return $"Cimzet: {Recipient} / Leiras: {Description} / Tomeg: {Weight} g";
        }
    }
}
