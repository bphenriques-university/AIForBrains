using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{
    private HumanHunger hunger;
    private HumanHealth health;
    private HumanShooting shooting;
    private HumanMovement movement;
    private HumanSight sight;
    private HumanTouch touch;
	private HumanTrade trade;
	private HumanSpeak speech;
	private HumanHear hearing;


    private int lastSeenHealth;
    private int shootableMask;

    void Awake()
    {
        hunger = GetComponentInChildren<HumanHunger>();
        health = GetComponentInChildren<HumanHealth>();
        shooting = GetComponentInChildren<HumanShooting>();
        movement = GetComponentInChildren<HumanMovement>();
        sight = GetComponentInChildren<HumanSight>();
        touch = GetComponentInChildren<HumanTouch>();
		trade = GetComponentInChildren<HumanTrade> ();
        speech = GetComponentInChildren<HumanSpeak>();
        hearing = GetComponentInChildren<HumanHear>();

        lastSeenHealth = health.startingHealth;
        shootableMask = LayerMask.GetMask("Shootable");
    }


    
}
