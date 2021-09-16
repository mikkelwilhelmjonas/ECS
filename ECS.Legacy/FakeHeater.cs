﻿namespace ECS.Legacy
{
    public class FakeHeater : IHeater
    {
        public bool TurnOnCalled { get; set; }

        public void TurnOn()
        {
            TurnOnCalled = true;
        }

        public void TurnOff()
        {
            TurnOnCalled = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }

    }
}