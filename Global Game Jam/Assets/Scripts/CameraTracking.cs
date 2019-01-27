using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {
    public Vector3 Offset;
    public GameObject TrackingTarget;
	// Use this for initialization
	void Start () {
        Offset = gameObject.transform.position - TrackingTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = TrackingTarget.transform.position + Offset;


    }
}
