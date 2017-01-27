using System.Collections;
using System.Collections.Generic;

public class GameData
{
	/*
	- La Prole: gente comun y corriente. Su infelicidad te saca del gobierno.
	- La Oligarquia: gente de mucha plata. Su infelicidad te saca del gobierno.
	- Economia: mejora o empeora la felicidad de todos.
	- Relaciones exteriores: afecta tanto a la economia como a la felicidad de la gente.
	- Medios: Afecta todo. Se los puede mantener contentos pero pueden traicionar.
	*/

	public int poorPeopleHappiness 	= 5;
	public int richPeopleHappiness 	= 5;
	public int economy 				= 5;
	public int internationalAffairs = 5;
	public int mediaHappiness 		= 5;

	public int leftLevel 			= 0;
	public int rightLevel 			= 0;
	public int pussyLevel 			= 0;

	List<Question> _questions;

	public void SortQuestions()
	{
		_questions = new List<Question> ();
		_questions.Add(	new Question(	"Bienvenido/a, usted es el nuevo presidente de la Nacion", 					
										new Answer("LIDER SUPREMO querras decir...", +1, -1, +1, -1, -3),							
										new Answer("Y lo sere siempre que el pueblo me apoye", +3, -2, -1, +1, +3),
										new Answer("Em... supongo", +1, -1, +1, 0, 0)));
										

	}

	public Question getNextQuestion()
	{
		var q = _questions [0];
		_questions.RemoveAt (0);

		if (_questions.Count == 0)
			UnityEngine.Debug.Log ("REFILL!!!");

		return q;
	}

	public void UpdateStats(Answer answer)
	{
		poorPeopleHappiness 	+= answer.poorPeopleInfluence;
		richPeopleHappiness 	+= answer.richPeopleInfluence;
		economy					+= answer.economyInfluence;
		internationalAffairs	+= answer.internationalInfluence;
		mediaHappiness 			+= answer.mediaInfluence;
	}
}