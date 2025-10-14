using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{

    public interface ISpread // interface bana rahe hain
    {
        void Spread();
        // yahan per koi method define kar sakte hain agar zarurat ho to
    }

    public class PeanutButter : ISpread {
        public void Spread() {
            Console.WriteLine("Spreading peanut butter...");
        }
    }
    public class Jelly : ISpread {
        public void Spread() {
            Console.WriteLine("Spreading jelly...");
        }
    }


    // Ohne Dependency Injection ka example,,, 

    class RobotChef
    {
        public void MakeSandwich()
        {
            var peanutButter = new PeanutButter(); // robot decides which spread, koupled mit PeanutButter
            var jelly = new Jelly();               // robot decides sweet spread, koupled mit Jelly
            Console.WriteLine("Sandwich made!");
        }
    }

   //------------------------------------------------------------------------------
    // mit Dependency Injection ka example,,,
    class RobotChefDI
    {
        private readonly ISpread _spread; // robot is not coupled mit any specific spread
        public RobotChefDI(ISpread spread) // spread wird injected
        {
            _spread = spread;
        }
        public void MakeSandwich()
        {
            _spread.Spread(); // use the injected spread
            Console.WriteLine("Sandwich made with " + _spread.GetType().Name + "!");
        }
    }
}
