using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.BehavioralPatterns.Memento
{
    class Hero
    {
        private int patrons = 10;
        private int lives = 5;

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Firing a shot. Left {0} patrons", patrons);
            }
            else
                Console.WriteLine("There are no more cartridges");
        }
        
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save game. Options: {0} patrons, {1} lives", patrons, lives);
            return new HeroMemento(patrons, lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Game recovery. Options: {0} patron, {1} lives", patrons, lives);
        }
    }
    
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }

        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
