using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void SelectAndStartButton(int index)
    {
        GameManager.Instance.DiffcultyIndex = index;
        GameManager.Instance.LoadLevelScene("Game");
    }

    public void ExitClick()
    {
        GameManager.Instance.Exit();
    }
}
