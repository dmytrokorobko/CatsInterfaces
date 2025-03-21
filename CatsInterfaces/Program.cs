using CatsFeedingApp;

List<Cat> cats = new List<Cat> { 
    new Cat("Tom"), 
    new Cat("Jerry"),
    new Cat("Garfield"),
    new Cat("Sylvester")
};

Owner owner = new Owner(3);

List<Bowl> bowls = new List<Bowl> {
    new Bowl("Bowl1", 2),
    new Bowl("Bowl2", 1),
    new Bowl("Bowl3", 3)
};

foreach (var cat in cats)
{
    foreach (var bowl in bowls)
    {
        bowl.SubscribeWannaEat(cat);
    }
}

foreach (var bowl in bowls)
{
    bowl.SubscribeFilledBowl(owner);
    owner.SubscribeEmpty(bowl);
}

for(int i = 0; i < 5; i++)
{
    foreach (var cat in cats)
    {
        int rnd = new Random().Next(0, bowls.Count);
        cat.Feed(bowls[rnd]);
    }
}
