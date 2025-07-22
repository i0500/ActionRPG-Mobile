using System.Collections.Generic;

public class ShopSystem : IShopSystem3
{
    private IShopItemReceiver shopItemReceiver;
    private IGoldSystem goldSystem;
    public List<ShopItemData> shopItemDataList { get; }

    public ShopSystem(IShopItemReceiver shopItemReceiver, IGoldSystem goldSystem, List<ShopItemData> shopItemDataList)
    {
        this.shopItemReceiver = shopItemReceiver;
        this.goldSystem = goldSystem;
        this.shopItemDataList = shopItemDataList;
    }

    public void BuyItem(ShopItemData shopItemData)
    {
        if (goldSystem.TrySpendGold(shopItemData.price))
        {
            shopItemReceiver.OnShopItemBought(shopItemData.itemData);
        }
    }
}