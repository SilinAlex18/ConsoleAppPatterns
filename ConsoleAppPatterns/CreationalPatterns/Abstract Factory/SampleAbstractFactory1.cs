using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPatterns.CreationalPatterns.Abstract_Factory
{
    abstract class Weapon
    {
        public abstract void Hit();
    }
    
    abstract class Movement
    {
        public abstract void Move();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("We shoot from a crossbow");
        }
    }
    
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Beat with a sword");
        }
    }
    
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Flying");
        }
    }
    
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    
    class Hero
    {
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Hit()
        {
            weapon.Hit();
        }
    }
}
