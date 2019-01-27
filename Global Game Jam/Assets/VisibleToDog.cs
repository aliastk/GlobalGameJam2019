using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleToDog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Camera.main.transform.forward,out hit, 6f))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("VisibleToDog"); 
            }
        }
	}
}
