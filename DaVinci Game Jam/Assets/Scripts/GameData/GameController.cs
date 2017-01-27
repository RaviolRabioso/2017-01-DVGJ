using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
	GameData _gameData;

	public Text question;
	public Text rightAnswer;
	public Text leftAnswer;
	public Text pussyAnswer;

	public Image poorPeopleBar;
	public Image richPeopleBar;
	public Image economyBar;
	public Image internationalBar;
	public Image mediaBar;

	public Gradient gradient;

	Question _currentQuestion;

	void Start () 
	{
		StartGame ();	
	}

	public void StartGame()
	{
		_gameData = new GameData ();
		_gameData.SortQuestions ();

		UpdateBars ();
		ShowQuestion (_gameData.getNextQuestion ());
	}

	public void ShowQuestion(Question q)
	{
		_currentQuestion = q;
		question.text = q.question;
		rightAnswer.text = q.rightAnswer.text;
		leftAnswer.text = q.leftAnswer.text;
		pussyAnswer.text = q.pussyAnswer.text;
	}

	public void SelectRightAnswer()
	{
		_gameData.rightLevel++;
		_gameData.UpdateStats (_currentQuestion.rightAnswer);
		UpdateBars ();
	}

	public void SelectLeftAnswer()
	{
		_gameData.leftLevel++;
		_gameData.UpdateStats (_currentQuestion.leftAnswer);
		UpdateBars ();
	}

	public void SelectPussyAnswer()
	{
		_gameData.pussyLevel++;
		_gameData.UpdateStats (_currentQuestion.pussyAnswer);
		UpdateBars ();
	}

	void UpdateBars()
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", poorPeopleBar.fillAmount,"to", _gameData.poorPeopleHappiness / 10f, "time", 0.3f, "onupdate", "UpdatePoorPeopleBar"));
		iTween.ValueTo(gameObject, iTween.Hash("from", richPeopleBar.fillAmount,"to", _gameData.richPeopleHappiness / 10f, "time", 0.3f, "onupdate", "UpdateRichPeopleBar"));
		iTween.ValueTo(gameObject, iTween.Hash("from", economyBar.fillAmount,"to", _gameData.economy / 10f, "time", 0.3f, "onupdate", "UpdateEconomyBar"));
		iTween.ValueTo(gameObject, iTween.Hash("from", internationalBar.fillAmount,"to", _gameData.internationalAffairs / 10f, "time", 0.3f, "onupdate", "UpdateInternationalBar"));
		iTween.ValueTo(gameObject, iTween.Hash("from", mediaBar.fillAmount,"to", _gameData.mediaHappiness / 10f, "time", 0.3f, "onupdate", "UpdateMediaBar"));
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1))
			SelectRightAnswer ();
		if (Input.GetKeyDown (KeyCode.Alpha2))
			SelectLeftAnswer ();
		if (Input.GetKeyDown (KeyCode.Alpha3))
			SelectPussyAnswer ();
		if (Input.GetKeyDown (KeyCode.R)) 
			StartGame ();
	}

	void UpdatePoorPeopleBar(float f)
	{
		poorPeopleBar.fillAmount = f;
		poorPeopleBar.color = gradient.Evaluate (f);
	}

	void UpdateRichPeopleBar(float f)
	{
		richPeopleBar.fillAmount = f;
		richPeopleBar.color = gradient.Evaluate (f);
	}

	void UpdateEconomyBar(float f)
	{
		economyBar.fillAmount = f;
		economyBar.color = gradient.Evaluate (f);
	}

	void UpdateInternationalBar(float f)
	{
		internationalBar.fillAmount = f;
		internationalBar.color = gradient.Evaluate (f);
	}

	void UpdateMediaBar(float f)
	{
		mediaBar.fillAmount = f;
		mediaBar.color = gradient.Evaluate (f);
	}
}
