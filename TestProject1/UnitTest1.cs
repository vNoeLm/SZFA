using NUnit.Framework;
using ZHGyak;

namespace TestProject1
{
    [TestFixture]
    public class DeliverableTests
    {

        [Test]
        public void Envelope_CalculatePrice()
        {
            var env = new Envelope(100, "Leírás", "Címzett");

            Assert.AreEqual(400, env.CalculatePrice(false));
            Assert.AreEqual(400, env.CalculatePrice(true));
        }

        [Test]
        public void Envelope_Overweight_ThrowsException()
        {
            var heavyEnv = new Envelope(2500, "Leírás", "Címzett");

            Assert.Throws<OverweightException>(() => heavyEnv.CalculatePrice(false));
        }


        [Test]
        public void FragileParcel_LockerDelivery_ThrowsException()
        {
            var fragile = new FragileParcel(100, Orientation.Horizontal, "Címzett");

            Assert.Throws<DeliveryException>(() => fragile.CalculatePrice(true));
        }

        [Test]
        public void FragileParcel_Arbitrary_ThrowsException()
        {
            Assert.Throws<IncorrectOrientationException>(() =>
                new FragileParcel(100, Orientation.Arbitrary, "Címzett"));
        }


        [Test]
        public void Courier_PickUpItem()
        {
            var courier = new Courier(5);
            var env = new Envelope(100, "Leírás", "A");
            var parcel = new NormalParcel(500, "B");

            courier.PickUpItem(env);
            courier.PickUpItem(parcel);

            Assert.AreEqual(600, courier.TotalWeight);
        }

        [Test]
        public void Courier_FragilesSorted()
        {
            var courier = new Courier(5);
            var f1 = new FragileParcel(1000, Orientation.Vertical, "Nehéz");
            var f2 = new FragileParcel(200, Orientation.Horizontal, "Könnyű");
            var n1 = new NormalParcel(500, "Normál");

            courier.PickUpItem(f1);
            courier.PickUpItem(n1);
            courier.PickUpItem(f2);

            var sortedFragiles = courier.FragilesSorted();

            Assert.AreEqual(2, sortedFragiles.Length); 
            Assert.AreEqual(200, sortedFragiles[0].Weight); 
            Assert.AreEqual(1000, sortedFragiles[1].Weight); 
        }
    }
}