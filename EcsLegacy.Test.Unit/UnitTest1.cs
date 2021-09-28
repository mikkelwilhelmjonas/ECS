using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using System.ComponentModel;
using ECS.Legacy;
using NSubstitute;
using ECS = ECS.Legacy.ECS;


namespace EcsLegacy.Test.Unit
{
    [TestFixture]
    public class ECSTests
    {
        private global::ECS.Legacy.ECS uut;
        private ITempSensor _fakeTempSensor;
        private IHeater _fakeHeater;

        [SetUp]
        public void Setup()
        {
            _fakeHeater = Substitute.For<IHeater>();
            _fakeTempSensor = Substitute.For<ITempSensor>();

            uut = new global::ECS.Legacy.ECS(10, _fakeTempSensor, _fakeHeater);
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void RunSelfTest_ECS(bool first, bool second, bool result)
        {
            _fakeTempSensor.RunSelfTest().Returns(first);
            _fakeHeater.RunSelfTest().Returns(second);

            Assert.That(uut.RunSelfTest().Equals(result));
        }

        [Test]
        public void ECSRegulateTest_fakeHeater_turnOnCalled()
        {
            _fakeTempSensor.GetTemp().Returns(5);
            uut.Regulate();
            _fakeHeater.Received(1).TurnOn();
        }

        [Test]
        public void ECSRegulateTest_fakeHeater_turnOffCalled()
        {
            _fakeTempSensor.GetTemp().Returns(15);
            uut.Regulate();
            _fakeHeater.Received(1).TurnOff();
        }


        [TestCase(5, 5)]
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

        [Test]
        public void Test_GetCurlTemp_TempSensor_GetTempCalled()
        {
            _fakeTempSensor.GetTemp().Returns(15);
            uut.GetCurTemp();
            _fakeTempSensor.Received(1).GetTemp();
        }


    }
}