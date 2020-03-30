using ConsoleAppPatterns.BehavioralPatterns.ChainOfResponsibility;
using ConsoleAppPatterns.BehavioralPatterns.Command;
using ConsoleAppPatterns.BehavioralPatterns.Iterator;
using ConsoleAppPatterns.BehavioralPatterns.Mediator;
using ConsoleAppPatterns.BehavioralPatterns.Memento;
using ConsoleAppPatterns.BehavioralPatterns.Observer;
using ConsoleAppPatterns.BehavioralPatterns.State;
using ConsoleAppPatterns.BehavioralPatterns.Strategy;
using ConsoleAppPatterns.BehavioralPatterns.TemplateMethod;
using ConsoleAppPatterns.BehavioralPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Text;
using Bank = ConsoleAppPatterns.BehavioralPatterns.Observer.Bank;

namespace ConsoleAppPatterns.BehavioralPatterns
{
    class BehavioralPatternsMain
    {
        public static void Menu()
        {
            //ChainOfResponsibility
            Console.WriteLine("--- ChainOfResponsibility ---");
            Receiver receiver = new Receiver(false, true, true);
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHadler;
            bankPaymentHandler.Handle(receiver);

            //Command
            Console.WriteLine("--- Command ---");
            TV tv = new TV();
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv));
            mPult.SetCommand(1, new VolumeCommand(volume));
            mPult.PressButton(0);
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();

            //Iterator
            Console.WriteLine("--- Iterator ---");
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

            //Mediator
            Console.WriteLine("--- Mediator ---");
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("There is an order, you need to make a program");
            programmer.Send("The program is ready, it is necessary to test");
            tester.Send("The program is tested and ready for sale.");

            //Memento
            Console.WriteLine("--- Memento ---");
            Hero hero = new Hero();
            hero.Shoot();
            GameHistory game = new GameHistory();
            game.History.Push(hero.SaveState());
            hero.Shoot();
            hero.RestoreState(game.History.Pop());
            hero.Shoot();

            //Observer
            Console.WriteLine("--- Observer ---");
            Stock stock = new Stock();
            Bank bank = new Bank("Unitbank", stock);
            Broker broker = new Broker("Ivan Ivanovich", stock);
            stock.Market();
            broker.StopTrade();
            stock.Market();

            //State
            Console.WriteLine("--- State ---");
            Water water = new Water(WaterState.LIQUID);
            water.Heat();
            water.Frost();
            water.Frost();

            //Strategy
            Console.WriteLine("--- Strategy ---");
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            //TemplateMethod
            Console.WriteLine("--- TemplateMethod ---");
            School school = new School();
            University university = new University();
            school.Learn();
            university.Learn();

            //Visitor
            Console.WriteLine("--- Visitor ---");
            var structure = new Visitor.Bank();
            structure.Add(new Person { Name = "Ivan Alekseev", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());
        }
    }
}
