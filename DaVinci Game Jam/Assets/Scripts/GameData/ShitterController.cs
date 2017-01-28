using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitterController : MonoBehaviour 
{
	public Transform display;
	public GameObject[] panels;
	public Transform initialPos;
	public Transform onDisplayPos;
	int _recent = -1;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
			Push ();
	}

	void Push()
	{
		_recent++;

		if (_recent == panels.Length)
			_recent = 0;


		for (int i = 0; i < panels.Length; i++) 
		{
			if (i == _recent)
				continue;

			StartCoroutine (MoveMsg ((RectTransform)panels [i].transform, panels [i].transform.position, panels [i].transform.position - new Vector3(0, RectTransformUtility.CalculateRelativeRectTransformBounds(panels[i].transform).extents.y, 0)));
		}

		panels [_recent].transform.SetSiblingIndex (display.childCount - 2);
		StartCoroutine (MoveMsg ((RectTransform)panels [_recent].transform, initialPos.position, onDisplayPos.position));



		print ("msg pushed");
	}

	IEnumerator MoveMsg(RectTransform t, Vector3 initialPos,Vector3 finalPos)
	{
		float tick = 0.3f;
		while (tick > 0) 
		{
			tick -= Time.deltaTime;
			t.position = Vector3.Lerp ( finalPos, initialPos, tick / 0.3f);
			yield return new WaitForEndOfFrame();
		}

		yield return null;
	}
}
