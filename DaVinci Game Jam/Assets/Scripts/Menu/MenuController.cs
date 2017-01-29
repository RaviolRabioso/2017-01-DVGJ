using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject namePanel;

	public void Play()
    {
        namePanel.SetActive(true);
		/*SceneManager.LoadScene("Office");
		SceneManager.LoadScene("UI", LoadSceneMode.Additive);*/
    }

    public void LoadLegacy()
    {
    }
}
