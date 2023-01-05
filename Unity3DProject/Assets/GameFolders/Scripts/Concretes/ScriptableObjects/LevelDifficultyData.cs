using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty", order = 1)]
public class LevelDifficultyData : ScriptableObject
{
    [SerializeField] FloorController floorController;
    [SerializeField] GameObject spawnerController;
    [SerializeField] Material skyBoxMaterial;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float delayTime = 50f;


    public FloorController FloorController => floorController;
    public GameObject SpawnerController => spawnerController;
    public Material SkyBoxMaterial => skyBoxMaterial;
    public float MoveSpeed => moveSpeed;
    public float DelayTime => delayTime;



}
