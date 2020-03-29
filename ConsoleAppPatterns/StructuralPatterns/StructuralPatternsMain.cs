using ConsoleAppPatterns.StructuralPatterns.Adapter;
using ConsoleAppPatterns.StructuralPatterns.Bridge;
using ConsoleAppPatterns.StructuralPatterns.Composite;
using ConsoleAppPatterns.StructuralPatterns.Decorator;
using ConsoleAppPatterns.StructuralPatterns.Facade;
using ConsoleAppPatterns.StructuralPatterns.Flyweight;
using ConsoleAppPatterns.StructuralPatterns.Proxy;
using System;
using System.Collections.Generic;
using System.Text;
using Directory = ConsoleAppPatterns.StructuralPatterns.Composite.Directory;
using File = ConsoleAppPatterns.StructuralPatterns.Composite.File;

namespace ConsoleAppPatterns.StructuralPatterns
{
    class StructuralPatternsMain
    {
        public static void Menu()
        {
            //Adapter
            Console.WriteLine("--- Adapter ---");
            Driver driver = new Driver();
            Auto auto = new Auto();
            driver.Travel(auto);
            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);

            //Bridge
            Console.WriteLine("--- Bridge ---");
            Programmers freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();

            //Composite
            Console.WriteLine("--- Composite ---");
            Component fileSystem = new Composite.Directory("File system");
            Component diskC = new Directory("C drive");
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            fileSystem.Add(diskC);
            fileSystem.Print();
            Console.WriteLine();
            diskC.Remove(pngFile);
            Component docsFolder = new Directory("My Documents");
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);
            fileSystem.Print();

            //Decorator
            Console.WriteLine("--- Decorator ---");
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1);
            Console.WriteLine("Title: {0}", pizza1.Name);
            Console.WriteLine("Price: {0}", pizza1.GetCost());
            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);
            Console.WriteLine("Title: {0}", pizza2.Name);
            Console.WriteLine("Price: {0}", pizza2.GetCost());
            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);
            Console.WriteLine("Title: {0}", pizza3.Name);
            Console.WriteLine("Price: {0}", pizza3.GetCost());

            //Facade
            Console.WriteLine("--- Facade ---");
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();
            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);
            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            //Flyweight
            Console.WriteLine("--- Flyweight ---");
            double longitude = 37.61;
            double latitude = 55.74;
            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House panelHouse = houseFactory.GetHouse("Panel");
                if (panelHouse != null)
                    panelHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }
            for (int i = 0; i < 5; i++)
            {
                House brickHouse = houseFactory.GetHouse("Brick");
                if (brickHouse != null)
                    brickHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            //Proxy
            Console.WriteLine("--- Proxy ---");
            using (IBook book = new BookStoreProxy())
            {
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }
        }
    }
}
