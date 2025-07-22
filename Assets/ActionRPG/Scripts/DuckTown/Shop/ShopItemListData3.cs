using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shop Item List", menuName = "DuckTown3/Shop/ShopItemList")]
public class ShopItemListData3 : ScriptableObject
{
    public List<ShopItemData> shopItemDataList;
}