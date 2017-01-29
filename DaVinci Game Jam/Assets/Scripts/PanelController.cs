using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
    
    public Text namee;

	public void LoadGameScene()
    {
        GameData.username = namee.text;
        SceneManager.LoadScene("Office");
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
}
