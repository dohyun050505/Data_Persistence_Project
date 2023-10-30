using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance;
    public static string currentUserName;
    public static string recordUserName;
    public static int recordScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highscore;
    }
    public static void SaveRecord()
    {
        SaveData data=new SaveData();
        data.name = recordUserName;
        data.highscore = recordScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public static void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            recordUserName = data.name;
            recordScore = data.highscore;
        }
        else
        {
            recordUserName = null;
            recordScore = 0;
        }
    }
}
