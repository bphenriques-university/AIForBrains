using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{
    HumanHunger hunger;
    HumanHealth health;
    HumanShooting shooting;
    HumanMovement movement;
    HumanSpeak speech;
    HumanSight sight;

    void Awake()
    {
        hunger = GetComponent<HumanHunger>();
        health = GetComponent<HumanHealth>();
        shooting = GetComponentInChildren<HumanShooting>();
        movement = GetComponentInChildren<HumanMovement>();
        speech = GetComponentInChildren<HumanSpeak>();
        sight = GetComponentInChildren<HumanSight>();
    }



    
}
