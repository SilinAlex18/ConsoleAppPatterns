using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.BehavioralPatterns.TemplateMethod
{
    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }

        public abstract void Enter();
        public abstract void Study();

        public virtual void PassExams()
        {
            Console.WriteLine("We pass final exams");
        }

        public abstract void GetDocument();
    }

    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Go to first grade");
        }

        public override void Study()
        {
            Console.WriteLine("We attend classes, do homework");
        }

        public override void GetDocument()
        {
            Console.WriteLine("We get a certificate of secondary education");
        }
    }

    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("We pass entrance exams and enter the university");
        }

        public override void Study()
        {
            Console.WriteLine("We attend lectures");
            Console.WriteLine("Go through practice");
        }

        public override void PassExams()
        {
            Console.WriteLine("We pass an exam in the specialty");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Getting a higher education diploma");
        }
    }
}
