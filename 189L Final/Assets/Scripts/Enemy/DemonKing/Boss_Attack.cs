using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;

public class Boss_Attack : StateMachineBehaviour
{
    BossController bossController;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //TODO: might need to use GetComponentInParent
        bossController = animator.GetComponent<BossController>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int AbilityChoice = Random.Range(1, 7);
        animator.SetInteger("AbilityChoice", AbilityChoice);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AbilityChoice", 0);
    }
}
