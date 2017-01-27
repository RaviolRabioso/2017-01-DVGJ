using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFire : MonoBehaviour {

    public GameObject objetive;

    private float _timeLeft = 4f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
            Destroy(objetive);
	}
}
