using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AdsManager adsManager;

    [SerializeField] private GameState currentState;
    [SerializeField] private PlaneType levelType = PlaneType.Grass;

    private string savePath;
    [SerializeField] private SaveData saveDataFiles;

    public delegate void GameStateDelegate(GameState newState);
    public event GameStateDelegate OnStateChange;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        adsManager = GetComponent<AdsManager>();

        savePath = Application.persistentDataPath;

        if(File.Exists(savePath + "saveData.json"))
        {
            LoadData();
        }
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        OnStateChange?.Invoke(state);
    }

    public void SaveData(string saveName)
    {
        string path = savePath + "saveData.json";
        int n = 0;
        switch (GameManager.Instance.GetLevelPlane())
        {
            case PlaneType.Grass:
                n = 0;
                break;
            case PlaneType.Sand:
                n = 1;
                break;
            case PlaneType.Stone:
                n = 2;
                break;
            default:
                break;
        }
        SaveFile newFile = new SaveFile(saveName , n);
        saveDataFiles.allSaveData.Add(newFile);

        string json = JsonUtility.ToJson(saveDataFiles);
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = savePath + "saveData.json";

        string json = File.ReadAllText(path);
        saveDataFiles = JsonUtility.FromJson<SaveData>(json);
    }

    public void SetLevelPlane(PlaneType newType)
    {
        levelType = newType;
    }

    public PlaneType GetLevelPlane()
    {
        return levelType;
    }

    public SaveData GetSaveData()
    {
        return saveDataFiles;
    }
}



public enum GameState
{
    Menu,
    Help,
    Load,
    Level,
    Game,
    Pause,
    Setting,
    Save,
    EditMode,
    Vehicle
}


[System.Serializable]
public class SaveData
{
    public List<SaveFile> allSaveData = new List<SaveFile>();
}


[System.Serializable]
public class SaveFile
{
    public string nama;
    public int nomorPlane;

    public SaveFile(string saveName , int level)
    {
        nama = saveName;
        nomorPlane = level;
    }
}
