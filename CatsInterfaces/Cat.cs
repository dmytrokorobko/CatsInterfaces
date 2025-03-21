using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Cat
    {
        string name;
        public event Action<Cat, Bowl>? WannaEat;
        public Cat(string name) { this.name = name; } 
        public string Name { get { return name; } }
        public void Feed(Bowl bowl) {
            
            WannaEat?.Invoke(this, bowl);

        }
    }
}
