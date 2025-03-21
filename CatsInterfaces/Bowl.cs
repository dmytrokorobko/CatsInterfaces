using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Bowl
    {
        string name;
        int meals;
        public event Action<Bowl>? Empty;
        public Bowl(string name, int meals) { 
            this.name = name; 
            this.meals = meals;
        }
        public string Name { get { return name; } }
        #region Subscription
        public void SubscribeWannaEat(Cat cat)
        {
            cat.WannaEat += OnWannaEat;
        }
        public void SubscribeFilledBowl(Owner owner)
        {
            owner.FilledBowl += OnFilledBowl;
        }
        public void UnsubscribeWannaEat(Cat cat)
        {
            cat.WannaEat -= OnWannaEat;
        }
        public void UnsubscribeFilledBowl(Owner owner)
        {
            owner.FilledBowl -= OnFilledBowl;
        }
        #endregion
        private void OnWannaEat(Cat cat, Bowl bowl)
        {
            if (bowl != this) return;

            if (meals == 0)
            {
                Empty?.Invoke(this);
            }
            
            if (meals > 0)
            {
                Console.WriteLine($"{cat.Name} is eating from {bowl.Name}. {--meals} are in this bowl");
            } else
            {
                Console.WriteLine($"{bowl.Name} is empty");
            }
        }

        private void OnFilledBowl(Bowl bowl, int fillMealsAmount)
        {
            if (bowl != this) return;

            meals += fillMealsAmount;
            Console.WriteLine($"{bowl.Name} was filled with {fillMealsAmount} meals");
        }
    }
}
