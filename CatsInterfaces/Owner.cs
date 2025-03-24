using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Owner : IOwner
    {
        private readonly int _fillMealsAmount;
        public Owner(string name, int fillMealsAmount)
        {
            Name = name;
            this._fillMealsAmount = fillMealsAmount;
        }

        #region Subscription
        public void SubscribeEmpty(Bowl bowl)
        {
            bowl.Empty += OnEmptyBowl;
        }
        public void UnsubscribeEmpty(Bowl bowl)
        {
            bowl.Empty -= OnEmptyBowl;
        }
        #endregion
        public string Name { get; set; }
        public event Action<IBowl, int>? Refilled;
        public void OnEmptyBowl(IBowl bowl)
        {
            Console.WriteLine($"{bowl.Name} is empty. Filling it with {_fillMealsAmount} meals by {Name}.");
            Refilled?.Invoke(bowl, _fillMealsAmount);
        }
    }
}
