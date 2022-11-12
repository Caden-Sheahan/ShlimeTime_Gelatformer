using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager : MonoBehaviour
{
    public static JsonManager instance;
    public GameSaveData GSD;
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        path = Application.isEditor ? Application.dataPath : Application.persistentDataPath; //checks to see if we're in editor, if so use datapath instead of persistent datapath
        path = path + "/SaveData/"; //append /SaveData/ to said path
        if (!Application.isEditor && !Directory.Exists(path)) //check if we're in a build, check if the directory exists, if not
        {
            Directory.CreateDirectory(path); //create it
        }
        Load();
        DontDestroyOnLoad(gameObject);
    }

    public void SavePos(Vector2 tempPos)
    {
        GSD.resetPos = tempPos;
        saveText();
    }

    public void SavePush(bool tempBool)
    {
        GSD.hasPush = tempBool;
        saveText();
    }
    
    public void SaveTime(bool tempBool)
    {
        GSD.hasSlow = tempBool;
        saveText();
    }
    public void SaveJetPack(bool tempBool)
    {
        GSD.hasJetPack = tempBool;
        saveText();
    }
    public void SaveSwing(bool tempBool)
    {
        GSD.hasSwing = tempBool;
        saveText();
    }

    public void saveText()
    {
        var convertedJson = JsonConvert.SerializeObject(GSD, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(path + "Data.json", convertedJson);
    }

    public void Load()
    {
        if (File.Exists(path + "Data.json"))
        {
            var json = File.ReadAllText(path + "Data.json");
            GSD = JsonConvert.DeserializeObject<GameSaveData>(json);
        }
        else
        {
            saveText();

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