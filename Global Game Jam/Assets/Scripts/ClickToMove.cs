using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickToMove : MonoBehaviour {
    private NavMeshAgent AI;
	// Use this for initialization
	void Start () {
        AI = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                AI.SetDestination(hit.point);
            }
            
        }
        
    }

}