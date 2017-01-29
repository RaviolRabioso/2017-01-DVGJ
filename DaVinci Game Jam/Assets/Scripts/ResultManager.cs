using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    public Text resultText;
    public GameObject background;

    public GameObject panel;
    public GameObject rightVictory;
    public GameObject leftVictory;
    public GameObject neutralVictory;

	public void ShowResult(GameData gD)
    {
        Activate();
        var value = gD.leftLevel - gD.rightLevel;
        if (value < -3)
        {
            resultText.text = "Victoria, el imperio es suyo mi líder!";
            Instantiate(rightVictory);
        }
        else if (value > 3)
        {
            resultText.text = "Victoria, querido kamarrada!";
            Instantiate(leftVictory);
        }
        else
        {
            Instantiate(neutralVictory);
            resultText.text = "Victoria... acá tenés un par de huevos Sr. Neutral...";
        }
    }

    public void ShowDefeat(GameData gD)
    {
        Activate();
        if (gD.economy <= 0)
            resultText.text = "Derrota, no hay ni un lecop en el país";
        else if (gD.poorPeopleHappiness <= 0)
            resultText.text = "Derrota, feliz viaje en helicoptero te desea el populacho";
        else if (gD.richPeopleHappiness <= 0)
            resultText.text = "Derrota, nunca tuviste el poder, siempre fue de los ricos";
        else if (gD.mediaHappiness <= 0)
            resultText.text = "Derrota, los medios no te favorecieron lo suficiente";
        else if (gD.internationalAffairs <= 0)
            resultText.text = "Derrota, no te quieren ni los de afuera";
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Activate()
    {
        panel.SetActive(false);
        resultText.gameObject.SetActive(true);
        background.SetActive(true);
        Invoke("ReturnMenu", 5);
    }
}
