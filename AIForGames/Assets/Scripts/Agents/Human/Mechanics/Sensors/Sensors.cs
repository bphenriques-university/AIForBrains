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
    HumanTouch touch;

    void Awake()
    {
        hunger = GetComponentInChildren<HumanHunger>();
        health = GetComponentInChildren<HumanHealth>();
        shooting = GetComponentInChildren<HumanShooting>();
        movement = GetComponentInChildren<HumanMovement>();
        speech = GetComponentInChildren<HumanSpeak>();
        sight = GetComponentInChildren<HumanSight>();
        touch = GetComponentInChildren<HumanTouch>();
    }


    
}
