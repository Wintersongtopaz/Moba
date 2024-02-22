using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveToPostion: A MonoBehavior script that orders a NavMover to move to a specific location
[RequireComponent(typeof(NavMover))]
public class MoveToPosition : MonoBehaviour, ITask
{
    NavMover navMover;
    public Vector3 destination;
    public bool destinationSet;

    void Awake() => navMover = GetComponent<NavMover>();
    //When the NavMover arrives, clear destination
   public bool Evaluate()
    {
        if (!destinationSet) return false;

        navMover.Destination = destination;
        if (navMover.DestinationReached(destination)) destinationSet = false;

        return true;
    }
}
