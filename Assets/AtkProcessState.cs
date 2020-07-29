using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkProcessState : StateMachineBehaviour
{
    Enemy enemy;
    Transform enemyTransform;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) < 50)
        {
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, enemy.player.position, Time.deltaTime * enemy.atkspeed);

            if (Vector2.Distance(enemyTransform.position, enemy.player.position) < 10)
            {
                animator.SetBool("isAttack", false);
            }
        }else
        {
            animator.SetBool("isAttack", false);
        }        
        enemy.DirectionEnemy(enemy.player.position.x, enemyTransform.position.x);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
