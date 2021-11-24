using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Load : MonoBehaviour
{
    public List<Player> players = new List<Player>();

    void Awake()
    {
        string dir = Application.dataPath + "/Resources/data1.json";

        if(!File.Exists(dir))
        {
            print("No Data File!");
            return;
        }

        string json = File.ReadAllText(dir);

        JsonUtility.FromJsonOverwrite(json, this);
    }

    /*
    public static List<Player> LoadFromJson()
    {
        string dir = Application.dataPath + "/Resources/data1.json";

        if(!File.Exists(dir))
        {
            print("No Data File!");
            return null;
        }

        string json = File.ReadAllText(dir);

        print("Data Loaded!");
        return JsonUtility.FromJson<List<Player>>(json);
    }
    */
}
