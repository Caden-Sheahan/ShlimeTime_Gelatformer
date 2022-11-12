using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager : MonoBehaviour
{
    public static JsonManager instance;
    public GameSaveData GSD;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
        DontDestroyOnLoad(gameObject);
    }

    public void savePos(Vector2 tempPos)
    {
        GSD.resetPos = tempPos;
        saveText();
    }

    public void saveText()
    {
        var convertedJson = JsonConvert.SerializeObject(GSD, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(Application.persistentDataPath + "/SaveData/Data.json", convertedJson);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/SaveDate/Data.json"))
        {
            var json = File.ReadAllText(Application.persistentDataPath + "/SaveData/Data.json");
            GSD = JsonConvert.DeserializeObject<GameSaveData>(json);
        }
        else
        {
            saveText();
            /*
            var newGSD = new GameSaveData();
            var convertedJson = JsonConvert.SerializeObject(newGSD);
            //File.WriteAllText(Application.persistentDataPath + "/SaveData/Data.json", convertedJson);
            //GSD = newGSD;
            */
        }
    }
}

[System.Serializable]
public class GameSaveData 
{
    public Vector2 resetPos;
    public bool hasPush;
    public bool hasSlow;
    public bool hasJetPack;
    public bool hasSwing;
}
