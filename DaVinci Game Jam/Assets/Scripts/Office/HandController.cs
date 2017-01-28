using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public LayerMask layerMaskBase;
    public LayerMask layerMaskSeal;
    public GameObject seal;
    public GameObject tintParticleSystem;
    public GameObject sealPlaced;
    public GameObject hojaVoladora;

    private bool _turnOnLight;
    private int _hasTint;
    private Vector3 _mousePosition;
    private bool _movingSeal;
    private bool _removeWhenUp;
    private float _timeSealOut;

	void Start () {
        _hasTint = 0;
        _turnOnLight = false;
        _removeWhenUp = false;
	}
	
	void Update () {
        // Updates the position of the mouse on the desk
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMaskBase))
        {
            _mousePosition = hit.point;
        }
       
        //Check input
        if(Input.GetMouseButtonDown(0))
            PressClick();

        _timeSealOut -= Time.deltaTime;

        //If needed, moves the seal
        if (_timeSealOut > 0)
        {
            seal.transform.position = Vector3.Lerp(seal.transform.position, new Vector3(1f + 0.67f, 0.82f - 0.89f, -4.52f + 3.76f), 3 * Time.deltaTime);
        }
        else if (_movingSeal)
        {
            seal.transform.position = Vector3.Lerp(seal.transform.position, _mousePosition + Vector3.up * 0.7f, 10 * Time.deltaTime);
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
                else if(col[i].GetComponent<LightController>() != null)
                {
                    col[i].GetComponent<LightController>().Turn(_turnOnLight);
                    _turnOnLight = !_turnOnLight;
                }
            }
            if (_removeWhenUp)
            {
                _removeWhenUp = false;
                _timeSealOut = 3;
                Invoke("RemoveAfterTimeSeals", 1);
            }
        }
    }

    private void RemoveAfterTimeSeals()
    {
        Instantiate(hojaVoladora);
        var tints = FindObjectsOfType<SealPlacedController>();
        for (int i = tints.Length - 1; i >= 0; i--)
        {
            tints[i].DefuseIfPaper();
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
            seal.GetComponent<Rigidbody>().isKinematic = true;
        else
            seal.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void ChargeTint()
    {
        _hasTint = 3;
        Instantiate(tintParticleSystem).transform.position = _mousePosition;
    }

    public void UseTint()
    {
        if (_hasTint > 0)
        {
            _hasTint--;
            Instantiate(tintParticleSystem).transform.position = _mousePosition + Vector3.up * 0.05f;
            Instantiate(sealPlaced).transform.position = new Vector3(seal.transform.position.x, sealPlaced.transform.position.y + 0.1f, seal.transform.position.z);
        }
    }

    public void TryAnswer(AnswerQuestion.Answer answer)
    {
        if (_hasTint > 0)
        {
            switch (answer)
            {
                case AnswerQuestion.Answer.Left:
                    FindObjectOfType<GameController>().SelectLeftAnswer();
                    break;
                case AnswerQuestion.Answer.Right:
                    FindObjectOfType<GameController>().SelectRightAnswer();
                    break;
                case AnswerQuestion.Answer.Neutral:
                    FindObjectOfType<GameController>().SelectPussyAnswer();
                    break;
            }
            _removeWhenUp = true;
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
