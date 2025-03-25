using CatsFeedingApp;

List<IEater> animals = new List<IEater> { 
    new Cat("Cat Tom"), 
    new Cat("Cat Jerry"),
    new Cat("Cat Garfield"),
    new Cat("Cat Sylvester"),
    new Dog("Dog Luke"),
    new Dog("Dog Gektor")
};

Owner owner = new Owner("Bob", 3);

List<IBowl> bowls = new List<IBowl> {
    new Bowl("Bowl1", 2),
    new Bowl("Bowl2", 1),
    new Bowl("Bowl3", 3)
};

foreach (IEater animal in animals)
{
    foreach (IBowl bowl in bowls)
    {
        bowl.SubscribeWannaEat(animal);
    }
}

foreach (var bowl in bowls)
{
    bowl.SubscribeFilledBowl(owner);
    owner.SubscribeEmpty(bowl);
}

TimerCallback callback = ShowCat;
Timer timer = new Timer(callback, null, 0, 1000);
Console.ReadLine();

void ShowCat(object? state)
{
    int rndCat = new Random().Next(0, animals.Count);
    int rndBolw = new Random().Next(0, bowls.Count);
    animals[rndCat].Eat(bowls[rndBolw]);
}
