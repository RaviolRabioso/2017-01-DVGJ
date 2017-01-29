using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
	GameData _gameData;

	public ShitterController shitter;
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

    private int _totalQuestions = 12;
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
		if (q == null) 
		{
			print ("GAME OVER");
			return;
		}

		_currentQuestion = q;

        _totalQuestions--;


		question.text = "";//q.question;
		rightAnswer.text = "<color='red'>A </color>- " ;//+ q.rightAnswer.text;
		leftAnswer.text = "<color='blue'>B </color>- ";// + q.leftAnswer.text;
		pussyAnswer.text = "<color='green'>C </color>- ";// + q.pussyAnswer.text;

		StartCoroutine (DisplayTexts());
	}

	IEnumerator	DisplayTexts()
	{
		int i = 0;
		while (i < _currentQuestion.question.Length) 
		{
			question.text += _currentQuestion.question[i];
			i++;
			yield return new WaitForSeconds (0.02f);
		}

		StartCoroutine (DisplayAnswer(rightAnswer, _currentQuestion.rightAnswer.text));
		StartCoroutine (DisplayAnswer(leftAnswer, _currentQuestion.leftAnswer.text));
		StartCoroutine (DisplayAnswer(pussyAnswer, _currentQuestion.pussyAnswer.text));
	}

	IEnumerator	DisplayAnswer(Text container, string finalText)
	{
		int i = 0;
		while (i < finalText.Length) 
		{
			container.text += finalText[i];
			i++;
			yield return new WaitForSeconds (0.02f);
		}
	}

    private bool CheckEnd()
    {
        Debug.Log("Economy " + _gameData.economy + "International "+_gameData.internationalAffairs+" Poor "+_gameData.poorPeopleHappiness+" Rich "+_gameData.richPeopleHappiness+" Media "+_gameData.mediaHappiness);
        if (_gameData.economy <= 0 || _gameData.internationalAffairs <= 0 || _gameData.poorPeopleHappiness <= 0 || _gameData.richPeopleHappiness <= 0 || _gameData.mediaHappiness <= 0)
        {
            FindObjectOfType<ResultManager>().ShowDefeat(_gameData);
            return true;
        }
        else if (_totalQuestions == 0)
        {
            FindObjectOfType<ResultManager>().ShowResult(_gameData);
            return true;
        }
        return false;
    }

	public void SelectRightAnswer()
	{
		_gameData.rightLevel++;
		_gameData.UpdateStats (_currentQuestion.rightAnswer);
		UpdateBars ();
		shitter.Push (_currentQuestion.rightAnswer.customMsg);
        if (!CheckEnd()) ShowQuestion(_gameData.getNextQuestion());
	}

	public void SelectLeftAnswer()
	{
		_gameData.leftLevel++;
		_gameData.UpdateStats (_currentQuestion.leftAnswer);
		UpdateBars ();
		shitter.Push (_currentQuestion.leftAnswer.customMsg);
        if (!CheckEnd()) ShowQuestion(_gameData.getNextQuestion ());
	}

	public void SelectPussyAnswer()
	{
		_gameData.pussyLevel++;
		_gameData.UpdateStats (_currentQuestion.pussyAnswer);
		UpdateBars ();
		shitter.Push (_currentQuestion.pussyAnswer.customMsg);
        if (!CheckEnd()) ShowQuestion(_gameData.getNextQuestion ());
	}

    private void CleanTexts()
    {

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
		/*if (Input.GetKeyDown (KeyCode.Alpha1))
			SelectRightAnswer ();
		if (Input.GetKeyDown (KeyCode.Alpha2))
			SelectLeftAnswer ();
		if (Input.GetKeyDown (KeyCode.Alpha3))
			SelectPussyAnswer ();*/
		/*if (Input.GetKeyDown (KeyCode.R)) 
			StartGame ();*/
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


	static GameController _instance;
	public static GameController Instance	{	get{ return _instance;	}	}
	void Awake()	{	_instance = this;	}
}
