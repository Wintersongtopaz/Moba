using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTarget : MonoBehaviour, ITask
{
    NavMover navMover;
    public GameObject target;
    public float searchRadius = 10f;
    public float attackRange = 2f;

    public bool autoFindTarget = true;

    void Awake() => navMover = GetComponent<NavMover>();
    //Attempt to find and chase an enemy target.
    public bool Evaluate()
    {
        //if no target found return false
        if (!target) target = autoFindTarget ? FindTarget() : null;
        if (!target) return false;
        //if target found and out of range, move to target
        //if target found and in range, stop moving
        if (TargetInRange())
        {
            if (navMover) navMover.StopMove();
            target.GetComponent<IDamageble>().TakeDamage(1);
        }
        else
        {
            if (navMover) navMover.Destination = target.transform.position;
        }
        return true;
    }
    //returns true if the units current attck target is in range
    //Use a raycast to determine whether the target enemy is close enough to deal damage to
    public bool TargetInRange()
    {
        if (!target) return false;

        Vector3 start = transform.position;
        Vector3 end = target.transform.position;
        Vector3 direction = (end - start).normalized;
        RaycastHit[] hits = Physics.RaycastAll(start, direction, attackRange);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject == target) return true;
        }
        return false;
    }
    //Use Layers to search for only Game Obhects belonging to the opposite team.
    GameObject FindTarget()
    {
        int layerMask;
        if (LayerMask.LayerToName(gameObject.layer) == "Team 1") layerMask = LayerMask.GetMask("Team 2");
        else layerMask = LayerMask.GetMask("Team 1");

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, searchRadius, Vector3.up, 1f, layerMask);
        float minDistance = 100f;
        GameObject newTarget = null;
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.GetComponent<IDamageble>() == null) continue;
            float distance = (hit.point - transform.position).magnitude;
            if (distance <= minDistance)
            {
                minDistance = distance;
                newTarget = hit.collider.gameObject;
            }
        }
        return newTarget;
    }
    
}
