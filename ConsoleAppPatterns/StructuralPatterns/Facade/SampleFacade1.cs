using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.StructuralPatterns.Facade
{
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Code writing");
        }

        public void Save()
        {
            Console.WriteLine("Code saving");
        }
    }

    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Compiling an application");
        }
    }

    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Application execution");
        }

        public void Finish()
        {
            Console.WriteLine("Application shutdown");
        }
    }

    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;

        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }

        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }

        public void Stop()
        {
            clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
