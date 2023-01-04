using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SinglationThisObject<GameManager>
{
    public event System.Action OnGameOver;

    public event System.Action OnMissionSucced;

    private void Awake()
    {
        SingletonThisGameObject(this);
    }

    public void GameOver()
    {
        //OnGameOver?.Invoke();

        Time.timeScale = 0f;
    }

    public void MissionSucced()
    {
        OnMissionSucced?.Invoke();
    }
}
