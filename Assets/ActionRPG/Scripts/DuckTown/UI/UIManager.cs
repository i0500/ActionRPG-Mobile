using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    public GameObject goldPanel;
    
    // System references
    private IGoldSystem goldSystem;
    private IShopSystem3 shopSystem;
    private IInventorySystemV2 inventorySystem;
    
    public void InitializeWithSystems(IShopSystem3 shop, IGoldSystem gold, IInventorySystemV2 inventory)
    {
        shopSystem = shop;
        goldSystem = gold;
        inventorySystem = inventory;
        
        // Initialize UI components
        InitializeShopUI();
        InitializeGoldUI();
        InitializeInventoryUI();
    }
    
    private void InitializeShopUI()
    {
        if (shopPanel != null && shopSystem != null)
        {
            var shopUI = shopPanel.GetComponent<UI_ShopPanel>();
            if (shopUI != null)
            {
                // shopUI.Initialize(shopSystem);
            }
        }
    }
    
    private void InitializeGoldUI()
    {
        if (goldPanel != null && goldSystem != null)
        {
            var goldUI = goldPanel.GetComponent<UI_GoldPanel3>();
            if (goldUI != null)
            {
                // goldUI.Initialize(goldSystem);
            }
        }
    }
    
    private void InitializeInventoryUI()
    {
        if (inventoryPanel != null && inventorySystem != null)
        {
            var inventoryUI = inventoryPanel.GetComponent<UI_InventoryPanelV2>();
            if (inventoryUI != null)
            {
                // inventoryUI.Initialize(inventorySystem);
            }
        }
    }
    
    public void ToggleShopPanel()
    {
        if (shopPanel != null)
            shopPanel.SetActive(!shopPanel.activeSelf);
    }
    
    public void ToggleInventoryPanel()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}