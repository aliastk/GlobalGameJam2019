using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Mouse X");
        rotation.x = -Input.GetAxis("Mouse Y");
        gameObject.transform.localRotation = Quaternion.Euler(gameObject.transform.localRotation.eulerAngles + (rotation * speed));
	}
}
