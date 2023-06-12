using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameState currentState;

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
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        Debug.Log("CURRENT STATE : " + state);
        OnStateChange?.Invoke(state);
    }
}



public enum GameState
{
    Menu,
    Help,
    Load,
    Level
}
