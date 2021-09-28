using System;

namespace ECS.Legacy
{
#if false
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
#endif
}