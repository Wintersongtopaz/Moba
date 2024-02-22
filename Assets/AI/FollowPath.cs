using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Follow Path: Update the Destination of the NavMover script with the next path point from the NavPath script.
[RequireComponent(typeof(NavMover))]
public class FollowPath : MonoBehaviour, ITask
{
    NavMover navMover;
    public NavPath path;
    public int pathIndex;
    public bool followInReverse = false;

    void Awake() => navMover = GetComponent<NavMover>();

 //Upon reaching the destination, increment or decrement the path index.
 //if looping, loop path index to the beginning or end of the path.
 //if not looping, clamp path index between 0 and the number of path points -1.
    // Attempt to perform task. Return whether successful
    public bool Evaluate()
    {
        if (!path) return false;

        if (navMover.DestinationReached(path.pathPoints[pathIndex]))
        {
            pathIndex = followInReverse ? pathIndex - 1 : pathIndex + 1;

            if (path.loop)
            {
                if (pathIndex < 0) pathIndex = path.pathPoints.Count - 1;
                if (pathIndex >= path.pathPoints.Count) pathIndex = 0;
            }
            else
            {
                pathIndex = Mathf.Clamp(pathIndex, 0, path.pathPoints.Count - 1);
            }
        }
        navMover.Destination = path.pathPoints[pathIndex];
        return true;
    }
}
