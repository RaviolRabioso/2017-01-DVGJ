using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public LayerMask layerMaskBase;
    public LayerMask layerMaskSeal;
    public GameObject seal;

    private Vector3 _mousePosition;
    private bool _movingSeal;

	void Start () {
		
	}
	
	void Update () {
        // Updates the position of the mouse on the desk
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, layerMaskBase))
        {
            _mousePosition = hit.point;
        }

        //Check input
        if(Input.GetMouseButtonDown(0))
            PressClick();

        //If needed, moves the seal
        if(_movingSeal)
        {
            seal.transform.position = _mousePosition + Vector3.up * 0.7f;
            seal.transform.forward = Vector3.up;
        }
	}

    /// <summary>
    /// Called when user makes left click.
    /// </summary>
    private void PressClick()
    {
        if(_movingSeal)
        {
            ActivateSeal(false);
        }
        else
        {
            var col = Physics.OverlapSphere(_mousePosition, 0.5f, layerMaskSeal);
            for (int i = col.Length - 1; i >= 0; i--)
            {
                if (col[i] == seal.GetComponent<Collider>())
                {
                    ActivateSeal(true);
                    
                }
            }
        }
    }

    /// <summary>
    /// Activates or desactivates the dragging of the seal.
    /// </summary>
    /// <param name="value">If you want to activate or desactivate</param>
    private void ActivateSeal(bool value)
    {
        _movingSeal = value;
        if (value)
        {
            
        }
        else
        {

        }
    }

    void OnDrawGizmos()
    {
        if (_mousePosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_mousePosition, 0.5f);
        }
    }
}
