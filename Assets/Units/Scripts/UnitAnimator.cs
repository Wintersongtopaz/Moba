using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unit Animator: retrieves data from relevant scripts and updates parameters in an Animator Controller
public class UnitAnimator : MonoBehaviour
{
    Animator animator;
    AIController aIController;
    NavMover navMover;

    void Awake()
    {
        aIController = GetComponent<AIController>();
        navMover = GetComponent<NavMover>();
        animator = GetComponentInChildren<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", navMover.Speed);
        bool attacking = false;
        if(aIController.activeTask is AttackTarget)
        {
            if ((aIController.activeTask as AttackTarget).TargetInRange()) attacking = true;
        }
        animator.SetBool("Attacking", attacking);
    }
}
