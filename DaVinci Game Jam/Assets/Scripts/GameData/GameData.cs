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

	public string userName = "Martelletti";

	List<Question> _questions;

	public void SortQuestions()
	{
		_questions = new List<Question> ();
		_questions.Add(	new Question(	"Bienvenido/a " + userName + ", usted es el nuevo presidente de la Nación",
										new Answer("LIDER SUPREMO querras decir...", 1, -1, 1, -1, -1),
										new Answer("Y lo seré siempre que los compañeros me apoyen.", 2, -1, -1, 1, 1),
										new Answer("Em... supongo.", 1, -1, 1, 0, 0)));

		_questions.Add(	new Question(	"Un fiscal encuentró información que podría vincularte a algo ilegal.",
										new Answer("Hacer que se tropiece con una bala.", -2, -2, 0, 1, -3),
										new Answer("Filtrar video porno del fiscal.", 2, 0, 0, 0, 3),
										new Answer("Meh, no pienso darle bola.", 0, 0, 0, 0, 1)));

		_questions.Add(	new Question(	"Varias protestas se están generando cerca de la casa del gobierno por los últimos despidos. ¿Deberíamos detenerlos?",
										new Answer("Que se note lo mucho que me quiere el pueblo. Plomo para todos!", -3, 1, 2, -1, -1),
										new Answer("Recuperen ya mismo esos puestos de trabajo.", 3, -2, -3, 1, 1),
										new Answer("Dejen que protesten, me voy de vacaciones.", -1, 0, -1, -1, 0)));

		_questions.Add(	new Question(	"Transnacionales se ofrecen a invertir un buen monto de millones para usted y sus allegados, siempre en cuanto apruebe algunos despidos...",
										new Answer("Hoy invito yo!", -2, 2, 1, -2, -1),
										new Answer("Muestren al mundo el pedido infame de esta transnacional imperialista.", 2, -3, -1, 0, 3),
										new Answer("A mi no me metan en esto", -1, -1, -1, 0, 0)));

		_questions.Add(	new Question(	"Los chinos nos traen estas maravillas de afuera. Es mi quinta adquisición del mismo ya que los últimos 4 se rompieron...",
										new Answer("¡Que buena es la globalización, liberen las importaciones!", -2, 0, -2, 3, 0),
										new Answer("Que no pase un producto más. Debemos proteger nuestra industria.", 1, -2, 0, -2, 0),
										new Answer("Que pasen solo si pagan impuestos razonables", -1, -1, 1, 1, 0)));
	}

	public Question getNextQuestion()
	{
		if (_questions.Count == 0) 
		{
			UnityEngine.Debug.Log ("REFILL!!!");
			return null;
		}

		var q = _questions [0];
		_questions.RemoveAt (0);
		return q;
	}

	public void UpdateStats(Answer answer)
	{
		poorPeopleHappiness 	= UnityEngine.Mathf.Clamp (poorPeopleHappiness + answer.poorPeopleInfluence, 0, 10);
		richPeopleHappiness 	= UnityEngine.Mathf.Clamp (richPeopleHappiness + answer.richPeopleInfluence, 0, 10);
		economy 				= UnityEngine.Mathf.Clamp (economy + answer.economyInfluence, 0, 10);
		internationalAffairs 	= UnityEngine.Mathf.Clamp (internationalAffairs + answer.internationalInfluence, 0, 10);
		mediaHappiness 			= UnityEngine.Mathf.Clamp (mediaHappiness + answer.mediaInfluence, 0, 10);
	}
}
