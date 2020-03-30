using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.BehavioralPatterns.State
{
    enum WaterState
    {
        SOLID,
        LIQUID,
        GAS
    }

    class Water
    {
        public WaterState State { get; set; }

        public Water(WaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            if (State == WaterState.SOLID)
            {
                Console.WriteLine("Turn ice into liquid");
                State = WaterState.LIQUID;
            }
            else if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Turn liquid into steam");
                State = WaterState.GAS;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("Raise the temperature of water vapor");
            }
        }

        public void Frost()
        {
            if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Turn liquid into ice");
                State = WaterState.SOLID;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("Turn water vapor into liquid");
                State = WaterState.LIQUID;
            }
        }
    }
}
