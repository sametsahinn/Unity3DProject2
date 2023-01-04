using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [Range(0.5f, 2)]
    [SerializeField] float moveSpeed = 0.5f;
    Material material;

    private void Awake()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Update()
    {
        material.mainTextureOffset += Vector2.down * Time.deltaTime * moveSpeed;
    }
}
