using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealPlacedController : MonoBehaviour {

    private float _timeToLower;
    private Material _material;
    private bool _sobrePapel;

	// Use this for initialization
	void Start () {
        _sobrePapel = false;
        _material = GetComponent<Renderer>().material;
        _timeToLower = 10;
	}
	
	// Update is called once per frame
	void Update () {
        _timeToLower -= Time.deltaTime;
        if(_timeToLower < 0)
        {
            var color = _material.color;
            color.a -= Time.deltaTime / 10;
            if (color.a < 0) Destroy(gameObject);
            else _material.color = color;
        }
	}
    

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 12)
            _sobrePapel = true;
    }

    public void DefuseIfPaper()
    {
        if (_sobrePapel)
            Destroy(gameObject);
    }
}
