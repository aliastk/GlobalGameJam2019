using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CloseDoor : MonoBehaviour {
    public float DoorSpeed = 5f;
    public UnityStandardAssets.ImageEffects.Grayscale Grayscale;
    public Transform Leave;
    public WhimperGame whimper;
    //public AudioClip HappyMusic;
    public AudioSource MainCameraMusic;
    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        StartCoroutine("Close");
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
       // GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().SetDestination(Leave.position);
    }
    // Update is called once per frame
    void Update () {
        
        if(gameObject.transform.localRotation.eulerAngles.y < 1f)
        {
            StopAllCoroutines();
            if (MainCameraMusic.isPlaying)
            {
                MainCameraMusic.Stop();
            }
            
            Grayscale.enabled = true;
            whimper.enabled = true;
            this.enabled = false;
        }
    }

    public IEnumerator Close()
    {
        yield return new WaitForSeconds(1.2f);
        while (true)
        {
            gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * DoorSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name == "Dog")
        {

        }
    }
}
