using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject namePanel;
	public UnityEngine.UI.Button legacyBtn;


	void Start()
	{
		legacyBtn.interactable = (Directory.Exists("Save/") && File.Exists("Save/legacy.tuvieja"));
	}

	public void Play()
    {
		GameController.loadLegacy = false;
        namePanel.SetActive(true);
		/*SceneManager.LoadScene("Office");
		SceneManager.LoadScene("UI", LoadSceneMode.Additive);*/
    }

    public void LoadLegacy()
    {
		GameController.loadLegacy = true;
		namePanel.SetActive(true);
    }
}
