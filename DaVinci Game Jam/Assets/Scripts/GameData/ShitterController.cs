using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitterController : MonoBehaviour 
{
	public Transform display;
	public ShitMsg[] panels;
	public Transform initialPos;
	public Transform onDisplayPos;
	int _recent = -1;

	public void Push(string msg)
	{
		if (string.IsNullOrEmpty (msg))
			return;
		
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
		panels [_recent].Fill (msg);



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
