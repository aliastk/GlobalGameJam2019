using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BallLaunchTest : MonoBehaviour {
    public float maxForce = 60f;
    public GameObject Cam;
    public GameObject Dog;
    public CloseDoor Door;
    public Text Info;
    public bool BallFetched = false;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void OnEnable()
    {

    }
    // Update is called once per frame
    void Update () {
        if (BallFetched)
        {
            Vector3 Dir =  player.transform.position - Camera.main.transform.position;
            float Angle = Vector3.Angle(Camera.main.transform.forward, Dir);
            print(Angle);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,Dir, out hit, 15f))
            {
                if (hit.collider.gameObject.tag == "Player" && Angle<70)
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("VisibleToDog");
                    gameObject.transform.SetParent(null);
                    gameObject.GetComponent<Collider>().enabled = true;
                    gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
                    gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
                    Door.enabled = true;
                    
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PauseMenuScript.GlobalTime = 1f;
        if (collision.gameObject.name == "Dog" && !BallFetched)
        {
            gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
            gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.transform.SetParent(collision.gameObject.transform);
            BallFetched = true;
            Door.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);

        }
    }

    public IEnumerator Throw()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        Dog.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        Dog.transform.LookAt(gameObject.transform);
        Cam.transform.LookAt(gameObject.transform);
        PauseMenuScript.GlobalTime = .25f;
        Info.text = "Fetch";
        yield return new WaitForSeconds(1f);
        Info.text = "";
        gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
        gameObject.GetComponent<Collider>().attachedRigidbody.AddForce(new Vector3(.25f,.15f,1) * maxForce, ForceMode.Impulse);
        gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
        gameObject.transform.SetParent(null);
        for(int i = 0; i < 50; i++)
        {
            Dog.transform.LookAt(gameObject.transform);
            Cam.transform.LookAt(gameObject.transform);
            yield return new WaitForSecondsRealtime(.005f);
        }
        Dog.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
    }

}
