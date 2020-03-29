using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.StructuralPatterns.Flyweight
{
    abstract class House
    {
        protected int stages;

        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Prefabricated house of 16 floors; coordinates: {0} latitude and {1} longitude",
                latitude, longitude);
        }
    }
    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Built brick house of 5 floors; coordinates: {0} latitude and {1} longitude",
                latitude, longitude);
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }
}
