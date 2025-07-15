using System.Collections.Generic;
using CodeBase;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int _inventorySpace;
    [SerializeField] private GameObject _emptyInventoryCell;
    [SerializeField] private Transform _horizontalLayoutGroupe;
    [SerializeField] private ItemDataBase _itemDataBase;
    private SaveLoadDataService<InventoryData> _saveLoadDataService;
    private InventoryData inventoryData;
    public List<InventorySlot> _inventorySlots = new List<InventorySlot>();
    private void InitializeInventory()
    {
        CreateInventoryField();
    }
    public void ClearAllInventory()
    {
        for (int i = inventoryData.ItemsId.Count - 1; i >= 0; i--)
        {
            inventoryData.ItemsId.RemoveAt(i);
        }
        foreach (var itemView in _inventorySlots)
        {
            itemView.SetItemData(_itemDataBase.GetItemById("Empty"));
        }
        _saveLoadDataService.SaveData(inventoryData);
        RefreshInventoryInfo();
    }
    public void DropItem(Vector3 placeToSpawn,Vector3 wayOfDropping,float powerOfDropping)
    {
        var currentInventorySlotData = GetCurrentNotEmptySlot();
        if(currentInventorySlotData!= null)
        {
            var itemModel =Instantiate(currentInventorySlotData.GetPrefab(),placeToSpawn,quaternion.identity);
            itemModel.GetComponent<Rigidbody>().AddForce(wayOfDropping * powerOfDropping,ForceMode.Impulse);
            inventoryData.ItemsId.Remove(currentInventorySlotData.Id());
            _saveLoadDataService.SaveData(inventoryData);
        }
        else print($"You dont have any items!");
    }

    private Item GetCurrentNotEmptySlot()
    {
        Item item = null;
        foreach (var inventorySlot in _inventorySlots)
        {
            if (inventorySlot.GetItem() == null) continue;
            else
            {
                item = inventorySlot.GetItem();
                inventorySlot.DeleteCurrentItemData();
                break;
            }
        }
        return item;
    }

    public void AddItem(ItemBase item)
    {
        inventoryData.ItemsId.Add(item.Id());
        _saveLoadDataService.SaveData(inventoryData);
        RefreshInventoryInfo();
    }
    private void CreateInventoryField()
    {
         inventoryData = (InventoryData)_saveLoadDataService.LoadData();
        for (int i = 0; i < _inventorySpace; i++)
        { 
           var cell= Instantiate(_emptyInventoryCell, _horizontalLayoutGroupe);
           var itemDisplay = cell.GetComponent<InventorySlot>();
           _inventorySlots.Add(itemDisplay);
        }
        RefreshInventoryInfo();
    }
    private void RefreshInventoryInfo()
    {
        for (int i = 0; i < inventoryData.ItemsId.Count; i++)
        {
            var currentItem = _itemDataBase.GetItemById(inventoryData.ItemsId[i]);
            _inventorySlots[i].SetItemData(currentItem);
        }
    }
    private void Awake()
    {
        _saveLoadDataService = new SaveLoadDataService<InventoryData>();
        _itemDataBase.InitializeItemDataBase();
        InitializeInventory();
    }
    
}
