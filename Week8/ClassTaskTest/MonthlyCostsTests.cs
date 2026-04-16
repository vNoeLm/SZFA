using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassTask;

namespace ClassTaskTest
{
    [TestFixture]
    internal class MonthlyCostsTests
    {
        [Test]
        public void LoadFromNonExisting()
        {
            Assert.Throws<FileNotFoundException>(() => MonthlyCosts.LoadFrom("non_existing.csv"));
        }

        [Test]
        public void LoadFromEmpty()
        {
            MonthlyCosts februaryCosts = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_02.csv");
            Assert.That(februaryCosts.TrainingCosts.Length, Is.EqualTo(0));
        }

        [Test]
        public void LoadFromSuccessful()
        {
            MonthlyCosts januaryCosts = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");
            Assert.That(januaryCosts.TrainingCosts.Length, Is.EqualTo(6));
        }
    }
}
