using Unity.VisualScripting;
using UnityEngine;

// DuckTown's advanced GameManager with Dependency Injection
public class DuckTownGameManager : MonoBehaviour
{
    public static DuckTownGameManager Instance;
    
    [SerializeField] private Transform pickUpItemRoot;
    [SerializeField] private ShopItemListData3 shopItemDataList;
    
    // Systems with Dependency Injection
    public IGoldSystem GoldSystem { get; private set; }
    public IShopSystem3 ShopSystem { get; private set; }
    public IInventorySystemV2 InventorySystem { get; private set; }
    
    // UI Manager
    public UIManager UIManager;
    
    public void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeSystems();
    }

    private void InitializeSystems()
    {
        // Initialize Inventory System
        InventorySystemV2 inventorySystemImpl = new InventorySystemV2();
        InventorySystem = inventorySystemImpl;

        // Initialize Gold System
        GoldSystem = new GoldSystem3();
        
        // Initialize Shop System with dependencies
        ShopSystem = new ShopSystem(inventorySystemImpl, GoldSystem, shopItemDataList.shopItemDataList);

        // Inject dependencies into scene items
        InjectSceneItemDependencies(inventorySystemImpl);

        // Initialize UI with systems
        if (UIManager != null)
        {
            UIManager.InitializeWithSystems(ShopSystem, GoldSystem, InventorySystem);
        }
    }

    private void InjectSceneItemDependencies(IReceiver receiver)
    {
        if (pickUpItemRoot == null) return;
        
        foreach (Transform child in pickUpItemRoot)
        {
            var itemScript = child.GetComponent<ItemPickUpInteraction>();
            if (itemScript != null)
            {
                itemScript.Init(receiver);
            }
        }
    }
}