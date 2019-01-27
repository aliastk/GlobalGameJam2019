using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Brain : MonoBehaviour {
    public Transform goal;
    private NavMeshAgent ai;
    public BallLaunchTest Launch;
	// Use this for initialization
	void Start () {
        ai = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpeedUp()
    {
        while (ai.speed < 1)
        {
            yield return new WaitForSeconds(2f);
            ai.speed *= 1.05f;
        }
    }
}
