using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void YesClick()
    {
        GameManager.Instance.LoadLevelScene("Game");
    }

    public void NoClick()
    {
        GameManager.Instance.LoadMenuScene();
    }
}
