using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityController
{
    Transform transform { get; }
    float MoveSpeed { get; }
    float MoveBoundary { get; }

}
