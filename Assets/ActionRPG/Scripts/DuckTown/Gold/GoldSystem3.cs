using System;

public class GoldSystem3 : IGoldSystem
{
    private int currentGold = 1000; // Starting gold
    
    public int CurrentGold => currentGold;
    public event Action<int> OnGoldChanged;
    
    public bool TrySpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            OnGoldChanged?.Invoke(currentGold);
            return true;
        }
        return false;
    }
    
    public void AddGold(int amount)
    {
        currentGold += amount;
        OnGoldChanged?.Invoke(currentGold);
    }
}