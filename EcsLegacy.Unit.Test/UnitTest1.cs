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

        [SetUp]
        public void Setup()
        {
            uut = new global::ECS.Legacy.ECS(23, new FakeTempSensor(), new FakeHeater());
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

    }
}