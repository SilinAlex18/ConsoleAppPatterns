using ConsoleAppPatterns.CreationalPatterns.Abstract_Factory;
using ConsoleAppPatterns.CreationalPatterns.Builder;
using ConsoleAppPatterns.CreationalPatterns.FactoryMethod;
using ConsoleAppPatterns.CreationalPatterns.Prototype;
using ConsoleAppPatterns.CreationalPatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.CreationalPatterns
{
    class CreationalPatternsMain
    {
        public static void Menu()
        {
            //FactoryMethod
            Console.WriteLine("--- FactoryMethod ---");
            Developer developer = new PanelDeveloper("Company 1");
            House house = developer.Create();

            //AbstractFactory
            Console.WriteLine("--- AbstractFactory ---");
            Hero hero = new Hero(new ElfFactory());
            hero.Hit();
            hero.Run();

            //Builder
            Console.WriteLine("--- Builder ---");
            Baker baker = new Baker();
            BreadBuilder builder = new RyeBreadBuilder();
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            //Prototype
            Console.WriteLine("--- Prototype ---");
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            //Singleton
            Console.WriteLine("--- Singleton ---");
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);
        }
    }
}
