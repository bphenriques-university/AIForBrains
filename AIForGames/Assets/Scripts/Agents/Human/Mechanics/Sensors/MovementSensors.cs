using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{

    public bool IsMoving()
    {
        return movement.isMoving();
    }



    public bool IsRunning()
    {
        return IsMoving() && movement.isRunning();
    }
}
