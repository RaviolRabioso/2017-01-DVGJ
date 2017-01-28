using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public Light light;
    public AudioSource turnOn;
    public AudioSource turnOff;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Turn(bool value)
    {
        light.gameObject.SetActive(value);
        if (value)
            turnOn.Play();
        else
            turnOff.Play();
    }
}
