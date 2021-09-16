using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using System.ComponentModel;
using ECS.Legacy;
using ECS = ECS.Legacy.ECS;


namespace Ecs.Legacy.Test.Unit
{
    
    [TestFixture]
    public class ECSTests
    {
        private global::ECS.Legacy.ECS uut;
        private FakeHeater fakeHeater_ = new FakeHeater();
        private FakeTempSensor FakeTempSensor_ = new FakeTempSensor();

        [SetUp]
        public void Setup()
        {
            uut = new global::ECS.Legacy.ECS(23, FakeTempSensor_, fakeHeater_);
        }


        //Tests for ECS.cs
        [TestCase(5,5)]
        [TestCase(10, 10)]
        [TestCase(20, 20)]
        public void SetThresholdTest(int input, int output)
        {
            uut.SetThreshold(input);
            Assert.That(uut.GetThreshold().Equals(output));
        }

        [TestCase(5, 5)]
        [TestCase(10, 10)]
        [TestCase(20, 20)]
        public void GetThresholdTest(int input, int output)
        {
            uut.SetThreshold(input);
            Assert.That(uut.GetThreshold().Equals(output));
        }

        [TestCase(10)]
        public void TestRegulateBelowThreshold(int input)
        {
            uut.SetThreshold(input);
            uut.Regulate();

            Assert.AreEqual(true, fakeHeater_.TurnOnCalled);

        }

        [TestCase(1)]
        public void TestRegulateAboveThreshold(int input)
        {
            uut.SetThreshold(input);
            uut.Regulate();

            Assert.AreEqual(false, fakeHeater_.TurnOnCalled);

        }

        [Test]
        public void GetCurTemp()
        {
            int temp = uut.GetCurTemp();
            Assert.That(temp.Equals(5));
        }
    }
}