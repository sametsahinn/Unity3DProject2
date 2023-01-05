using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializerController : MonoBehaviour
{
    LevelDifficultyData levelDifficultyData;

    private void Awake()
    {
        levelDifficultyData = GameManager.Instance.LevelDifficultyData;
    }

    private void Start()
    {
        RenderSettings.skybox = levelDifficultyData.SkyBoxMaterial;
        Instantiate(levelDifficultyData.FloorController);
        Instantiate(levelDifficultyData.SpawnerController);
        EnemyManager.Instance.SetMoveSpeed(levelDifficultyData.MoveSpeed);
        EnemyManager.Instance.SetDelayTime(levelDifficultyData.DelayTime);
    }
}
