using CatsFeedingApp;

List<IEater> cats = new List<IEater> { 
    new Cat("Tom"), 
    new Cat("Jerry"),
    new Cat("Garfield"),
    new Cat("Sylvester")
};

Owner owner = new Owner("Bob", 3);

List<IBowl> bowls = new List<IBowl> {
    new Bowl("Bowl1", 2),
    new Bowl("Bowl2", 1),
    new Bowl("Bowl3", 3)
};

foreach (IEater cat in cats)
{
    foreach (IBowl bowl in bowls)
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
