using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.StructuralPatterns.Bridge
{
    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the C ++ compiler, compile the program into binary code");
        }

        public void Execute()
        {
            Console.WriteLine("Run the program executable");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the Roslyn compiler, compile the source code into an exe file");
        }

        public void Execute()
        {
            Console.WriteLine("JIT compiles a binary code program");
            Console.WriteLine("CLR executes compiled binary code");
        }
    }

    abstract class Programmers
    {
        protected ILanguage language;

        public ILanguage Language
        {
            set { language = value; }
        }

        public Programmers(ILanguage lang)
        {
            language = lang;
        }

        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }

        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmers
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }

        public override void EarnMoney()
        {
            Console.WriteLine("We receive payment for the completed order");
        }
    }

    class CorporateProgrammer : Programmers
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }

        public override void EarnMoney()
        {
            Console.WriteLine("We receive a salary at the end of the month");
        }
    }
}
