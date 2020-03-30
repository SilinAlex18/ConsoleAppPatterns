using System;

namespace ConsoleAppPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CreationalPatterns.CreationalPatternsMain.Menu();
            StructuralPatterns.StructuralPatternsMain.Menu();
            BehavioralPatterns.BehavioralPatternsMain.Menu();

            Console.ReadKey();
        }
    }
}
