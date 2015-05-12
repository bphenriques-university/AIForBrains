using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DesiresManager : MonoBehaviour {

    private Desire[] desires;


    public void Start()
    {
        desires = new Desire[] {  };
    }


    public IList<Desire> Options(BeliefsManager beliefs, IList<Intention> intentions)
    {
        IList<Desire> desired = new List<Desire>();
        foreach (Desire desire in desires)
        {
            desire.Deliberate(beliefs, intentions);
            desired.Add(desire);
        }   
        return desired;
    }

}