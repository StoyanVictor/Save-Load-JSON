using System.Collections.Generic;
using CodeBase;
using UnityEngine;
public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int _inventorySpace;
    [SerializeField] private GameObject _emptyInventoryCell;
    [SerializeField] private Transform _horizontalLayoutGroupe;
    [SerializeField] private ItemDataBase _itemDataBase;
    private SaveLoadDataService<InventoryData> _saveLoadDataService;
    private InventoryData inventoryData;
    public List<IItem> _items = new List<IItem>();
    public List<InventorySlotDisplay> _itemsView = new List<InventorySlotDisplay>();
    private void InitializeInventory()
    {
        CreateInventoryField();
    }
    public void AddItem(IItem item)
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
           var itemDisplay = cell.GetComponent<InventorySlotDisplay>();
           _itemsView.Add(itemDisplay);
        }
        RefreshInventoryInfo();
    }
    private void RefreshInventoryInfo()
    {
        for (int i = 0; i < inventoryData.ItemsId.Count; i++)
        {
            var currentItem = Resources.Load<Item>($"Data/{inventoryData.ItemsId[i]}");
            _itemsView[i].SetItemData(currentItem);
        }
    }
    private void Awake()
    {
        _saveLoadDataService = new SaveLoadDataService<InventoryData>();
        InitializeInventory();
    }
    
}
