using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhimperGame : MonoBehaviour {
    public Text WhimperMission;
    public GameObject WhimperGameObject;
    public BarkingMinigame Bark;
	// Use this for initialization
	void OnEnable () {
        WhimperGameObject.SetActive(true);
        WhimperMission.text = "Press R at the door to cry.";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            WhimperGameObject.SetActive(false);
            Bark.enabled = true;
            this.enabled = false;
        }
		
	}
    
}
