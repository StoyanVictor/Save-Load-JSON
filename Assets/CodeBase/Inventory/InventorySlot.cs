using System;
using CodeBase;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _iconSlot;
    [SerializeField] private Item _item;
    private InventorySlotView _inventorySlotView;
    public void SetItemData(Item item)
    {
        _item = item;
        _inventorySlotView.SwitchCurrentIcon(_item,_iconSlot);
    }

    public void DeleteCurrentItemData() => _item = null;
    public Item GetItem() => _item;
    private void Awake()
    {
        _inventorySlotView = new InventorySlotView();
    }
}
public class InventorySlotView
{
    public void SwitchCurrentIcon(Item item,Image icon)
    {
        icon.sprite = item.Icon();
    }
}