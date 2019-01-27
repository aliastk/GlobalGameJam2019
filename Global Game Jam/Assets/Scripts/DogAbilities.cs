using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAbilities : MonoBehaviour {
    AudioSource Sound;
    public AudioClip BarkBark;
    public AudioClip GrowlGrowl;
    public AudioClip WhimperWhimper;
    // Use this for initialization
    void Start () {
        Sound = GetComponent<AudioSource>();
       
	}
	
	// Update is called once per frame
	void Update () {
        Bark();
        Growl();
        Whimper();
	}
    public void Bark()
    {
        if (Input.GetKeyDown("f"))
        {
            Sound.clip = BarkBark;
            print("bark, bark");
            Sound.Play();
        }
    }
    public void Growl()
    {
        if (Input.GetKeyDown("g"))
        {
            Sound.clip = GrowlGrowl;
            print("growl, growl");
            Sound.Play();
        }
    }
    public void Whimper()
    {
        if (Input.GetKeyDown("r"))
        {
            Sound.clip = WhimperWhimper;
            print("whimper, whimper");
            Sound.Play();
        }
    }
}
