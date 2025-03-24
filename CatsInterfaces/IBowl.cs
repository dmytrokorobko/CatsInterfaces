namespace CatsFeedingApp;

public interface IBowl
{
    string Name { get; set; }
    int Meals { get; set; }
    event Action<IBowl>? Empty;
    void OnConsumeFood(IEater eater, IBowl bowl);
    void OnRefill(IBowl bowl, int amount);
}