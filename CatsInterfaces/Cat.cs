using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Cat : IEater
    {
        public Cat(string name) { Name = name; }
        public string Name { get; set; }

        public event Action<IEater, IBowl>? WannaEat;
        public void Eat(IBowl bowl)
        {
            WannaEat?.Invoke(this, bowl);
        }
    }
}
