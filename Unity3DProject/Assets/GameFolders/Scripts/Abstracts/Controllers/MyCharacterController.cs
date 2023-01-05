using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyCharacterController : MonoBehaviour
{
    [SerializeField] float moveBoundary = 4.5f;
    [SerializeField] float moveSpeed = 10f;

    public float MoveSpeed => moveSpeed;
    public float MoveBoundary => moveBoundary;
}
