using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;

public class Skeleton_Idle : StateMachineBehaviour
{
    SkeletonController skeletonController;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //TODO: might need to use GetComponentInParent
        skeletonController = animator.GetComponent<SkeletonController>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeletonController.SeekPlayerLogic();
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
