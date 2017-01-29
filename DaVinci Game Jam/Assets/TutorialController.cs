using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject add;
    public GameObject select;
    public GameObject grab;
    
    private int _state;

	// Use this for initialization
	void Start () {
        _state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grabs()
    {
        if(_state == 0)
        {
            _state++;
            grab.SetActive(false);
            add.SetActive(true);
        }
    }

    public void Adds()
    {
        if(_state == 1)
        {
            _state++;
            add.SetActive(false);
            select.SetActive(true);
        }
    }

    public void Selects()
    {
        if(_state == 2)
        {
            _state++;
            select.SetActive(false);
        }
    }
}
