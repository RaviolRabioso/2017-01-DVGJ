using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void Play()
    {
		SceneManager.LoadScene("Office");
		SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public void LoadLegacy()
    {

    }
}
