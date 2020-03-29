using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.StructuralPatterns.Adapter
{
    interface ITransport
    {
        void Drive();
    }
    
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car rides on the road");
        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    
    interface IAnimal
    {
        void Move();
    }
    
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel walks through the sands of the desert");
        }
    }
    
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;

        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
