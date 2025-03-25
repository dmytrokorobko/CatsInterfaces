using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Bowl : IBowl
    {
        public string Name { get; set; }
        public int Meals { get; set; }

        public Bowl(string name, int meals)
        {
            Name = name;
            Meals = meals;
        }

        public event Action<IBowl>? Empty;

        public void OnConsumeFood(IEater eater, IBowl bowl)
        {
            if (bowl != this) return;

            if (Meals == 0)
            {
                Empty?.Invoke(this);
            }
            
            if (Meals > 0)
            {
                Console.WriteLine($"{eater.Name} is eating from {bowl.Name}. {--Meals} are in this bowl");
            } else
            {
                Console.WriteLine($"{bowl.Name} is empty");
            }
        }

        public void OnRefill(IBowl bowl, int amount)
        {
            if (bowl != this) return;

            Meals += amount;
            Console.WriteLine($"{bowl.Name} was filled with {amount} meals");
        }

        #region Subscription
        public void SubscribeWannaEat(IEater cat)
        {
            cat.WannaEat += OnConsumeFood;
        }
        public void SubscribeFilledBowl(IOwner owner)
        {
            owner.Refilled += OnRefill;
        }
        #endregion
    }
}
