using System;

namespace ECS.Legacy
{
    public class FakeTempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return 5;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}