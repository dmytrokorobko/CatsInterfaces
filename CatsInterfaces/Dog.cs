namespace CatsFeedingApp;

public class Dog : IEater
{
    public string Name { get; set; }

    public Dog(string name)
    {
        Name = name;
    }

    public event Action<IEater, IBowl>? WannaEat;
    public void Eat(IBowl bowl)
    {
        WannaEat?.Invoke(this, bowl);
    }
}