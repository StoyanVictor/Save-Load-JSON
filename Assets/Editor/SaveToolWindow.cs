using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveToolWindow : EditorWindow
{
private PlayerData _playerData = new PlayerData(Vector3.zero, 100, 50);
private InventoryData _inventoryData = new InventoryData(new List<string>());

[MenuItem("Sigma/Save Tool")]
public static void Open()
{
    GetWindow<SaveToolWindow>("Save Tool");
}
private void OnGUI()
{
    GUILayout.Label("🧍 Player Data", EditorStyles.boldLabel);
    _playerData.Position = EditorGUILayout.Vector3Field("Position", _playerData.Position);
    _playerData.Health = EditorGUILayout.IntField("Health", _playerData.Health);
    _playerData.Money = EditorGUILayout.IntField("Money", _playerData.Money);

    if (GUILayout.Button("💾 Save PlayerData"))
    {
        Save(_playerData);
    }

    if (GUILayout.Button("📂 Load PlayerData"))
    {
        var loaded = Load<PlayerData>();
        if (loaded != null)
            _playerData = loaded;
    }

    EditorGUILayout.Space(20);
    GUILayout.Label("🎒 Inventory Data", EditorStyles.boldLabel);

    if (_inventoryData.ItemsId == null)
        _inventoryData.ItemsId = new List<string>();

    for (int i = 0; i < _inventoryData.ItemsId.Count; i++)
    {
        _inventoryData.ItemsId[i] = EditorGUILayout.TextField($"Item {i + 1}", _inventoryData.ItemsId[i]);
    }

    if (GUILayout.Button("+ Add Item"))
    {
        _inventoryData.ItemsId.Add("");
    }

    if (GUILayout.Button("💾 Save InventoryData"))
    {
        Save(_inventoryData);
    }

    if (GUILayout.Button("📂 Load InventoryData"))
    {
        var loaded = Load<InventoryData>();
        if (loaded != null)
            _inventoryData = loaded;
    }
}
private void Save<T>(T data) where T : class, IData
{
    var json = JsonUtility.ToJson(data, true);
    var path = Path.Combine(Application.persistentDataPath, typeof(T).Name + ".json");
    File.WriteAllText(path, json);
    Debug.Log($"[Save] {typeof(T).Name} сохранён в {path}");
}
private T Load<T>() where T : class, IData
{
    var path = Path.Combine(Application.persistentDataPath, typeof(T).Name + ".json");
    if (!File.Exists(path))
    {
        Debug.LogWarning($"[Load] Файл не найден: {path}");
        return null;
    }

    var json = File.ReadAllText(path);
    return JsonUtility.FromJson<T>(json);
}
}