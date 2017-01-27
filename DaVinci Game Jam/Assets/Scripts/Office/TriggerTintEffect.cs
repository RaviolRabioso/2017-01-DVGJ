using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTintEffect : MonoBehaviour {

    public enum Effect
    {
        Charge,
        Use
    }

    public Effect effect;

	private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 11) //Hardcoding FTW
        {
            switch(effect)
            {
                case Effect.Charge:
                    GameObject.Find("Main Camera").GetComponent<HandController>().ChargeTint();
                    break;
                case Effect.Use:
                    GameObject.Find("Main Camera").GetComponent<HandController>().UseTint();
                    break;
            }
        }
    }
}
