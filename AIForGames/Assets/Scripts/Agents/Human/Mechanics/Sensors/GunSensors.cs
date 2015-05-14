using UnityEngine;
using System.Collections;

public partial class Sensors : MonoBehaviour
{
    public bool CanShoot()
    {
        return shooting.CanAttack();
    }
}
