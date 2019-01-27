using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BarkingMinigame : MonoBehaviour {

    public GameObject KittyTask;
    public Text ChangeDialogue;
    public Transform CatObj;
    private bool Waiting;
	// Use this for initialization
	void Start () {
        KittyTask.SetActive(true);
        Waiting = true;
        ChangeDialogue.text = "Is that a cat?" + "\n" +  "Protect your territory by pressing G or F.";
        CatObj.gameObject.SetActive(true);
        
        StartCoroutine("wait");
    }
	
    public IEnumerator wait()
    {
        Waiting = true;
        yield return new WaitForSeconds(6f);
        Waiting = false;
    }
	// Update is called once per frame
	void Update () {
        
        if(CatObj == null)
        {
            this.enabled = false;
            return;
           
        }
        float CatDistance = Vector3.Distance(CatObj.position, gameObject.transform.position);
        if(CatDistance < 20 && !Waiting)
        {
            ChangeDialogue.text = "Maybe you can somehow make" +"\n" + "a stairway to get closer?";
        }
        else if (CatDistance > 20 && !Waiting)
        {
            ChangeDialogue.text = "The cat can't see you." + "\n" + "Find a way to get closer.";
        }
        
           
        
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cat")
        {
            print("I'm a cat");
            ChangeDialogue.text = "Almost there! You need to get even closer.";
        }
        if (other.gameObject.tag == "Cat" && (Input.GetKeyDown("f") || Input.GetKeyDown("g")))
        {
            ChangeDialogue.text = "Begone, foul beast!";
            Destroy(other.gameObject);
            WakeUp.blurriness += .25f;
            WakeUp.JumpForce -= 2f;
            WakeUp.MoveSpeed *= .75f;
            SceneManager.LoadScene("House");
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            print("I'm a cat");
            ChangeDialogue.text = "Almost there! You need to get even closer.";
        }
        if (other.gameObject.tag == "Cat" && (Input.GetKeyDown("f") || Input.GetKeyDown("g")))
        {
            ChangeDialogue.text = "Begone, foul beast!";
            Destroy(other.gameObject);
            WakeUp.blurriness += .25f;
            WakeUp.JumpForce -= 4f;
            WakeUp.MoveSpeed *= .75f;
            SceneManager.LoadScene("House");
        }
        else if (other.gameObject.tag != "Cat" && (Input.GetKeyDown("f") || Input.GetKeyDown("g")))
        {
            ChangeDialogue.text = "The cat isn't scared of something it's taller than.";
        }
    }
}
