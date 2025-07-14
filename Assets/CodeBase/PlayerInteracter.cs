using UnityEngine;
public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            var item = other.gameObject.GetComponent<InteractableItem>().GetItem();
            _inventorySystem.AddItem(item);
            Destroy(other.gameObject);
        }
    }
}