using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsFeedingApp
{
    internal class Owner
    {
        public event Action<Bowl, int>? FilledBowl;
        int fillMealsAmount;
        public Owner(int fillMealsAmount)
        {
            this.fillMealsAmount = fillMealsAmount;
        }

        #region Subscription
        public void SubscribeEmpty(Bowl bowl)
        {
            bowl.Empty += OnEmpty;
        }
        public void UnsubscribeEmpty(Bowl bowl)
        {
            bowl.Empty -= OnEmpty;
        }
        #endregion
        private void OnEmpty(Bowl bowl)
        {
            Console.WriteLine($"{bowl.Name} is empty. Filling it with {fillMealsAmount} meals");
            FilledBowl?.Invoke(bowl, fillMealsAmount);
        }
    }
}
