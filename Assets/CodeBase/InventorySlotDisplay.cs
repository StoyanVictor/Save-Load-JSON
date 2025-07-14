using CodeBase;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private Image _iconSlot;
    public void SetItemData(Item item)
    {
        _iconSlot.sprite = item.icon;
    }
}
