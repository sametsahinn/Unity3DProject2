using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 0f;

        OnGameOver?.Invoke();
    }

    public void MissionSucced()
    {
        OnMissionSucced?.Invoke();
    }

    public void LoadLevelScene(string screenName)
    {
        StartCoroutine(LoadLevelSceneAsync(screenName));
    }

    private IEnumerator LoadLevelSceneAsync(string screenName)
    {
        //SoundManager.Instance.StopSound(1);
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(screenName);
        //SoundManager.Instance.PlaySound(2);
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }

    private IEnumerator LoadMenuSceneAsync()
    {
        //SoundManager.Instance.StopSound(2);
        yield return SceneManager.LoadSceneAsync("Menu");
        //SoundManager.Instance.PlaySound(1);
    }

    public void Exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
