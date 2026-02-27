using UnityEngine;
using System.IO;

public class GameDataLoader 
{
    public static GameData CargarDatos()
    { 
        string path = Application.streamingAssetsPath + "/GameData.json";

        if (!File.Exists(path))
        {
            Debug.LogError("No se encontró GameData.json");
            return null;    

        }
        string jsonData = File.ReadAllText(path);
        return JsonUtility.FromJson<GameData>(jsonData);
    }
}
