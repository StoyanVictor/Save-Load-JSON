using System;
using UnityEngine;
public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private Transform player;
    [SerializeField] private Transform _offset;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Item"))
        {
            print("Hello");
            var item = hit.gameObject.GetComponent<InteractableItem>().GetItem();
            _inventorySystem.AddItem(item);
            Destroy(hit.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _inventorySystem.ClearAllInventory();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _inventorySystem.DropItem(_offset.position,player.forward,10f);
        }
    }
}