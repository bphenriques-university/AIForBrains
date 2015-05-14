using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{

    public Transform CurrentPosition()
    {
        return transform.root;
    }

    public bool IsMoving()
    {
        return movement.isMoving();
    }


    public bool IsRunning()
    {
        return IsMoving() && movement.isRunning();
    }

    public float GetSpeed()
    {
        return movement.getSpeed();
    }
}
