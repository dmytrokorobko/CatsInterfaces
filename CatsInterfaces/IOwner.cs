namespace CatsFeedingApp;

public interface IOwner
{
    string Name { get; set; }
    public event Action<IBowl, int>? Refilled;
    void OnEmptyBowl(IBowl bowl);
}