using System.Collections.Generic;

public interface IShopSystem3
{
    List<ShopItemData> shopItemDataList { get; }
    void BuyItem(ShopItemData shopItemData);
}