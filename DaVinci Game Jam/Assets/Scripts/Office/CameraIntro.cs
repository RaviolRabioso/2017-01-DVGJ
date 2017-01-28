using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntro : MonoBehaviour 
{
	public Transform start;
	public Transform end;
	public float duration;
	void Start () 
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "onupdate", "Lerp", "time", duration, "easetype", iTween.EaseType.easeOutExpo));
	}

	void Lerp(float f)
	{
		transform.position = Vector3.Lerp (start.position, end.position, f);
		var q = transform.rotation;
		q.eulerAngles = Vector3.Lerp (start.rotation.eulerAngles, end.rotation.eulerAngles, f);
		transform.rotation = q;
	}
}
