using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WakeUp : MonoBehaviour {
    public UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration Vignette;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController FPS;
    public Animator AI;
    public Camera cam;
    public GameObject Follow;
    public static float blurriness = 0;
    public static float JumpForce = 70;
    public static float MoveSpeed = 4;
    public GameObject TaskInstruction;
  
	// Use this for initialization
	void Start () {
        TaskInstruction.SetActive(true);
        cam = Camera.main;
        Camera.main.enabled = false;
        
        StartCoroutine("CloseEyes");
        cam.enabled = true;
       
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vignette.intensity -= .05f;
            
            TaskInstruction.SetActive(false);

        }
        

        if (Vignette.intensity < 0.4f)
        {
            FPS.enabled = true;
            Vignette.intensity = 0;
            Vignette.blur = WakeUp.blurriness;
            FPS.movementSettings.JumpForce = WakeUp.JumpForce;
            FPS.movementSettings.ForwardSpeed = WakeUp.MoveSpeed;
            FPS.movementSettings.BackwardSpeed = WakeUp.MoveSpeed;
            FPS.movementSettings.StrafeSpeed = WakeUp.MoveSpeed;
            StopAllCoroutines();
           // StartCoroutine("GotAchievement");
            AI.SetTrigger("Begin");
            //BarkingGame.enabled = true;
            this.enabled = false;
            TaskInstruction.SetActive(false);
            Follow.SetActive(true);
        }

        else
        {
            TaskInstruction.SetActive(true);
        }
	}

    IEnumerator CloseEyes()
    {
        while (true)
        {
            if (Vignette.intensity > 0.4f && Vignette.intensity < .95f)
            {
                Vignette.intensity += .025f;
                
            }
            yield return new WaitForSeconds(.3f * Vignette.intensity);
        }
    }
    IEnumerator GotAchievement()
    {
        TaskInstruction.SetActive(true);
     
        yield return new WaitForSeconds(2.0f);
        yield return null;
    }
}
