using System.IO;
using UnityEngine;
namespace CodeBase
{
    public class SaveLoadDataService<T> where T : IData
    {
        public IData LoadData()
        {
            var json = File.ReadAllText(Application.persistentDataPath + $"/{typeof(T)}.json");
            return JsonUtility.FromJson<T>(json);
        }
        public void SaveData(T data)
        {
            var json = JsonUtility.ToJson(data,true);
            File.WriteAllText(Application.persistentDataPath + $"/{typeof(T).Name}.json",json);
        }
    }
}