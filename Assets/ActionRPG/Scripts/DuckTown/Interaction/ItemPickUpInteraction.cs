using UnityEngine;

public class ItemPickUpInteraction : MonoBehaviour
{
    [SerializeField] private ItemData3 itemData;
    private IReceiver receiver;
    
    public void Init(IReceiver receiver)
    {
        this.receiver = receiver;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && receiver != null)
        {
            receiver.ReceiverItem(itemData);
            Destroy(gameObject);
        }
    }
}