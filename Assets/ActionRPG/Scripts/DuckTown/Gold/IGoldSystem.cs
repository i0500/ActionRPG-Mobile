using System;

public interface IGoldSystem
{
    int CurrentGold { get; }
    event Action<int> OnGoldChanged;
    
    bool TrySpendGold(int amount);
    void AddGold(int amount);
}