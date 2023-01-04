using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void StartClick()
    {
        GameManager.Instance.LoadLevelScene("Game");
    }

    public void ExitClick()
    {
        GameManager.Instance.Exit();
    }
}
