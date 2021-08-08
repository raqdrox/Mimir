using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThemeScript : MonoBehaviour
{
    public GameObject pnlObj;
    public GameObject[] gobjlist;
    public bool LoadScript = false;
    public void Awake()
    {
        if(LoadScript)
        {
            Load();
        }
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/prefs.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/prefs.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            pnlObj.GetComponent<Image>().color = saveObject.dm_PanelCol;
            foreach(GameObject txtObj in gobjlist)
            {
                txtObj.GetComponent<Text>().color = saveObject.dm_Txt;
            }

        }
        else
        {
            Debug.Log("No File");
        }

    }
    public void Save(bool theme)
    {
        if (File.Exists(Application.persistentDataPath + "/prefs.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/prefs.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            if(theme)
            {
                saveObject.dm_PanelCol = Color.black;
                saveObject.dm_Txt = Color.white;

            }
            else
            {
                saveObject.dm_PanelCol = Color.white;
                saveObject.dm_Txt = Color.black;

            }
            string json = JsonUtility.ToJson(saveObject);
            File.WriteAllText(Application.persistentDataPath + "/prefs.txt", json);
        }
        else
        {
            SaveObject saveObject = new SaveObject
            {
                dm_PanelCol = Color.white,
                dm_Txt = Color.black,
            };
            string json = JsonUtility.ToJson(saveObject);
            File.WriteAllText(Application.persistentDataPath + "/prefs.txt", json);
        }

    }

}

public class SaveObject
{
    public Color dm_PanelCol;
    public Color dm_Txt;

}