using System.IO;
using UnityEngine;
namespace CodeBase
{
    public class SaveLoadDataService : MonoBehaviour
    {
        public PlayerData LoadData()
        {
            var json = File.ReadAllText(Application.persistentDataPath + "/playerData.json");
            return JsonUtility.FromJson<PlayerData>(json);
        }
        public void SaveData(Vector3 playerPosition,int playerHp)
        {
            var playerData = new PlayerData(playerPosition,playerHp);
            var json = JsonUtility.ToJson(playerData,true);
            File.WriteAllText(Application.persistentDataPath + "/playerData.json",json);
        }
    }
}