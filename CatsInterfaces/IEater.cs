namespace CatsFeedingApp;

public interface IEater
{
    string Name { get; set; }
    event Action<IEater, IBowl>? WannaEat;
    void Eat(IBowl bowl);
}