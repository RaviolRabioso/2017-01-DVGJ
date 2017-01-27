using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerQuestion : MonoBehaviour {

    public enum Answer
    {
        Left,
        Right,
        Neutral
    }

    public Answer answer;

	void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 11)
        {
            GameObject.Find("Main Camera").GetComponent<HandController>().TryAnswer(answer);
        }
    }
}
