using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

        savePath = Application.persistentDataPath;
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        OnStateChange?.Invoke(state);
    }

    public void SaveData(string saveName)
    {
        string path = savePath + "saveData.json";

        SaveFile newFile = new SaveFile(saveName);
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

    public SaveFile(string saveName)
    {
        nama = saveName;
    }
}
