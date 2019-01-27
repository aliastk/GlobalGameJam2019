using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToGoal : StateMachineBehaviour {
    public GameObject npc;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        npc = animator.gameObject;
        npc.GetComponent<Brain>().StartCoroutine("SpeedUp");

        npc.GetComponent<NavMeshAgent>().SetDestination(npc.GetComponent<Brain>().goal.position);
        //Debug.Log(npc.GetComponent<NavMeshAgent>().destination);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       animator.SetFloat("RemainingDistance",Vector3.Distance(npc.transform.position, npc.GetComponent<NavMeshAgent>().destination));
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        npc.GetComponent<Brain>().StopCoroutine("SpeedUp");
        npc.GetComponent<NavMeshAgent>().ResetPath();
        npc.transform.localRotation = Quaternion.Euler(Vector3.zero);
        //  npc.GetComponent<NavMeshAgent>().enabled = false;

    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
