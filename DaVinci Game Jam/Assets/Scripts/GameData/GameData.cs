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

	public int poorPeopleHappiness 	= 10;
    public int richPeopleHappiness  = 10;
	public int economy 				= 10;
	public int internationalAffairs = 10;
	public int mediaHappiness 		= 10;

	public int leftLevel 			= 0;
	public int rightLevel 			= 0;
	public int pussyLevel 			= 0;
    

	List<Question> _questions;

    private bool hasTakenFirst = false;
	public static string username = "Batman" ;

    public GameData()
    {
    }

	public void SortQuestions()
	{
		_questions = new List<Question> ();
		_questions.Add(	new Question(	"Bienvenido/a " + username + ", usted es el nuevo presidente de la Nación",
			new Answer("LIDER SUPREMO querras decir...", 1, -1, 1, -1, -1, "n|" + GetUserNameForShit()+ " es el nuevo Lider de la Nacion."),
			new Answer("Y lo seré siempre que los compañeros me apoyen.", 2, -1, -1, 1, 1, "p|Vamo' ameo, "+GetUserNameForShit()+" es re peola."),
			new Answer("Em... supongo.", 1, -1, 1, 0, 0, "r|"+GetUserNameForShit()+" pecho frio.")));

		_questions.Add(	new Question(	"Un fiscal encontró información que podría vincularte a algo ilegal.",
										new Answer("Hacer que se tropiece con una bala.", -2, -2, 0, 1, -3, "n|El fiscal #Prisman habria sido picado por una bala. Ampliaremos."),
										new Answer("Filtrar video porno del fiscal.", 2, 0, 0, 0, 3,"r|Al final la gran evidencia del fiscal #Prisman esta entre sus piernas. #socotroco"),
										new Answer("Meh, no pienso darle bola.", 0, 0, 0, 0, 1, "n|El fiscal #Prisman amenaza con denunciar al Presidente. #KB")));

        _questions.Add(new Question(	"La multinacional Morfato te quiere dejar 1.000.000.000 dolares a cambio de seguir 'cuidando' los campos", 
							            new Answer("Que se cague el campo!", -3, 3, 2, 1, 0, "p|El wacho de la @Ashelenn salio con 4 vrasos, debe ser por dog chau."), 
			new Answer("Para nada, voy a denunciarlos!", 3, 1, -4, -1, 2, "i|Escandalo internacional: " + GetUserNameForShit() + " denuncia a #Morfato por coimeros."), 
							            new Answer("Paso y me hago el boludo", 0, 0, -2, 0, -1, "e|Nada importante paso hoy.")));

        _questions.Add(new Question("El Gremio reclama una mejora salarial para los trabajadores",
			new Answer("Laburen vagos!", -3, 3, 1, 0, 2, "r|Los negritos se creen importantes. No son como uno. Viva " + GetUserNameForShit()),
			new Answer("Tomen todo lo que quieran", 5, -3, -5, 0, 5, "r|"+GetUserNameForShit()+" quiere mantener a los vagos. Si sigo pagando asi voy a tener que vacacionar en Gessell #PUAJ."),
			new Answer("Que lo defina el congreso", -1, -1, 0, 0, -3, "n|Se solicita informacion respecto a las pelotas de " + GetUserNameForShit())));

        _questions.Add(new Question("La economía esta por el piso y hay que elevar los impuestos",
            new Answer("Que lo pague el pueblo, es su economía", -3, 1, 5, 0, 1, "n|Hoy te damos las 10 mejores recetas para comer carton. #YUMMI #Rico"),
            new Answer("Que lo pague la clase alta, ellos se beneficiaron con la actual crisis", 3, -4, 5, 0, -3, "p|Los chetitos se sienten re zarpado', la villa esta de fiesta eaea"),
            new Answer("Que lo paguen todos, menos yo obviamente", -2, -2, 5, 0, -1, "e|PROMO: 20% extra DE REGALO en cada envase de #vaselina.")));

        _questions.Add(new Question("Muchos innmigrantes les pareció buena idea entrar a nuestro país",
            new Answer("Sólo queremos atletas, que aprendan a saltar muros", 2, 3, 1, -3, 1, "r|Alguien sabe porque quedaron tan pocos albaniles?"),
            new Answer("Son todos bienvenidos!", -2, -3, -1, 3, 1, "r|Que bueno que el Country tiene paredones electricos. #Horror"),
            new Answer("Mirá vo...", -3, -3, -2, 0, -3, "n|ULTIMO MOMENTO: Eeeeeeeehhhhhhhhhhhh.... #Ampliaremos")));

        _questions.Add(new Question("Nuestro pequeño país vecino está por entrar en guerra con una potencia mundial",
			new Answer("Que la coman, apoyamos a la potencia", -2, -1, -1, +2, +2, "i|"+GetUserNameForShit()+" decide entrar en la guerra y apoyar a #USA."),
			new Answer("Son nuestros hermanos, los apoyaremos", -1, -2, -3, 3, 2, "i|"+GetUserNameForShit()+ "decide entrar en la guerra y apoyar a #Zukistan."),
			new Answer("Mándele a ambos buena suerte", 0, 0, 1, -3, -1, "i|"+GetUserNameForShit()+ " acerca de la guerra: Me preocupan mas las #Piranas")));

		_questions.Add(	new Question(	"Varias protestas se están generando cerca de la casa del gobierno por los últimos despidos. ¿Deberíamos detenerlos?",
										new Answer("Que se note lo mucho que me quiere el pueblo. Plomo para todos!", -3, 1, 2, -1, -1, "n|ALERTA METEOROLOGICO: Se esperan lluvias de plomo en el microcentro."),
										new Answer("Recuperen ya mismo esos puestos de trabajo.", 3, -2, -3, 1, 1, "e|"+GetUserNameForShit()+" vs #empresarios. La gente gana una prorroga e indemnizaciones."),
										new Answer("Dejen que protesten, me voy de vacaciones.", -1, 0, -1, -1, 0, "n|"+GetUserNameForShit()+" se fractura un tobillo al saltar la soga en sus vacaciones. #Ampliaremos")));

		_questions.Add(	new Question(	"Transnacionales se ofrecen a invertir un buen monto de millones para usted y sus allegados, siempre en cuanto apruebe algunos despidos...",
										new Answer("Hoy invito yo!", -2, 2, 1, -2, -1),
										new Answer("Muestren al mundo el pedido infame de esta transnacional imperialista.", 2, -3, -1, 0, 3),
										new Answer("A mi no me metan en esto", -1, -1, -1, 0, 0)));

		_questions.Add(	new Question(	"Los chinos nos traen estas maravillas de afuera. Es mi quinta adquisición del mismo ya que los últimos 4 se rompieron...",
										new Answer("¡Que buena es la globalización, liberen las importaciones!", -2, 0, -2, 3, 0),
										new Answer("Que no pase un producto más. Debemos proteger nuestra industria.", 1, -2, 0, -2, 0),
										new Answer("Que pasen solo si pagan impuestos razonables", -1, -1, 1, 1, 0)));

        _questions.Add(new Question("Una radio local está difamando injúrias sobre varios líderes de nuestro partido",
            new Answer("Esperemos que puedan seguir expresándose desde la cárcel", 1, 1, 0, -3, -3),
            new Answer("Tienen derecho a expresarse si lo desean", -2, -2, 0, 0, 1),
            new Answer("Bueno, podemos publicar un par de tweets desmintiendo, no?", -1, -1, 0, -1, 0)));

        _questions.Add(new Question("Nuestros jóvenes de clase baja exigen una educación de calidad y gratuita",
            new Answer("Pueden aprender manualidades en los talleres de la cárcel", -3, 1, 1, -1, -1),
            new Answer("Que se abran las universidades necesarias para resolver este problema", 2, -2, -3, 1, 1),
            new Answer("Supongo que podemos dar un par de becas para privadas", -1, -1, -1, 0, 0)));

        _questions.Add(new Question("Podemos ser los representates del próximo mundial! Tan sólo debemos aceptar un par de restricciones y pagar una suma",
            new Answer("Siempre quise ver a mi equipo subcampeón como local. Que se haga lo necesario", 2, 1, -3, 2, 3),
            new Answer("Ninguna asociación mundial nos va a decir que debemos hacer", -2, -1, 0, 0, -2),
            new Answer("De acuerdo, pero intentemos que sus restricciones no sean graves ni destruyan la economía", 1, 0, -1, -2, -1)));

        _questions.Add(new Question("Una cadena prestigiosa de comida rápida se ofrece a pagarnos un dineral si les permitimos explotar al máximo a nuestra población más precaria",
            new Answer("Dinero y comida deliciosamente rápida para la gente importante. Que no se diga más!", -2, 1, 2, 1, 0),
            new Answer("Comida chatarra y gente precarizada? Sobre mi cadáver marxista", 1, -1, 0, -1, 0),
            new Answer("Podemos aceptarlo, pero asegurémonos de pagar la diferencia para que el trabajo sea aceptable", -1, 1, 0, 1, 0)));

        _questions.Add(new Question("Ayer murieron 2 personas a causa del hambre. Deberíamos hacer algo?",
            new Answer("El hambre es para la gente que no puede costearse vivir", -3, 1, 0, -2, -1),
            new Answer("Preparen los camiones. Saldremos a repartir pan al pueblo!", 3, -1, -2, 0, 1),
            new Answer("Y si probamos dando cupones de descuento?, Podrían venir con un corte de pelo también", -1, 0, -1, 0, -1)));

        _questions.Add(new Question("Una empresa altamente prestigiosa acaba de quebrar",
            new Answer("El pobre eempresario no tiene la culpa. Que no se indemnice a nadie!", -2, 1, 1, 0, -1),
            new Answer("Que los trabajadores formen una cooperativa y se hagan cargo de la empresa", 1, -2, 0, 0, 0),
            new Answer("No importa la cantidad de despidos mientras se los indemnice como pide la ley", -1, -2, -1, 0, 0)));

        _questions.Add(new Question("Estados Unidos nos ofrece un progrma nuclear en el país. La paga sería alta pero probablemente la población no disfrute comprar medias de a tres",
            new Answer("La gente puede acostumbrarse a los buzos de cuatro mangas", -3, -3, 3, 1, -2),
            new Answer("Acá dibujamos la línea. Cortaremos lazos con Estados Unidos", 0, -2, -2, -2, -2),
            new Answer("Aceptaremos pero invertiremos suficiente en propaganda y en la seguridad de nuestros habitantes", -1, -1, -1, 1, 2)));

        _questions.Add(new Question("Algunos piden vacaciones pagas mientras otros dicen que cada uno se pague sus vacaciones",
            new Answer("Cada uno debe pagarse sus vacaciones. Ya tienen suficiente con sus sueldos", -2, 1, 1, -1, -1),
            new Answer("Que no solamente se paguen sueldos, que se paguen pasajes!", 3, -1, -3, 1, 1),
            new Answer("Que tengan vacaciones pagadas a mitad del sueldo", -1, -1, 0, 0, 0)));

        _questions.Add(new Question("A nuestros habitantes les gusta hacer mucho chaca chaca... pero luego exigen permisos por paternidad!",
            new Answer("Fue su elección así como su problema controlar a sus plagas", -3, -3, 3, 0, 0),
            new Answer("Asignaremos dinero a cada familia por cada uno de sus hijos, además de unas merecidas vacaciones pagas", 2, -1, -3, 0, 0),
            new Answer("Con un mes de vacaciones pagas para la madre debe de ser suficiente", 0, 0, -1, 0, 0)));

        _questions.Add(new Question("Cada vez se anotan más y más niños a los colegios. Deberíamos ofrecerles alimento?",
            new Answer("Podríamos cobrarles el alimento dentro del colegio", -2, 0, 2, 0, 0),
            new Answer("El alimento debería ser un derecho. Comidas diarias para todos los alumnos", 2, -1, -3, 0, 0),
            new Answer("Demasiado trabajo, que cada uno se lleve su vianda", -2, -1, 0, 0, -1)));

        _questions.Add(new Question("El populacho exige mejores condiciones en las fábricas",
            new Answer("Que no exageren. Inhalar carbón solamente durante 14 horas laborales no debería ser problema", -3, 0, 2, -1, 0),
            new Answer("Las fábricas deberían ser del pueblo. Que los obreros tomen el poder y decidan lo que es justo!", 3, -3, -2, -1, 1),
            new Answer("Podríamos pedir condiciones mínimas para la jornada de 8 horas", -1, -1, -1, 0, 0)));

        _questions.Add(new Question("Se acerca el día del trabajador, cómo deberíamos celebrarlo?",
            new Answer("Pues trabajando, obviamente!", -2, 1, 2, -1, -2),
            new Answer("Saldremos a las calles a festejar durante toda la semana", 3, -2, -3, 0, 3),
            new Answer("Tendrán el día libre", 1, -1, -1, 0, 0)));
	}

	public string GetUserNameForShit()
	{
		return "<color='blue'>#" + username + "</color>";
	}

	public Question getNextQuestion()
	{
		if (_questions.Count == 0) 
		{
			UnityEngine.Debug.Log ("REFILL!!!");
			return null;
		}

        Question q;
        if (!hasTakenFirst)
        {
            q = _questions[0];
            _questions.RemoveAt(0);
            hasTakenFirst = true;
        }
        else
        {
            int r = UnityEngine.Random.Range(0, _questions.Count -1);
            q = _questions[r];
            _questions.RemoveAt(r);
        }
		return q;
	}

	public void UpdateStats(Answer answer)
	{
		poorPeopleHappiness 	= UnityEngine.Mathf.Clamp (poorPeopleHappiness + answer.poorPeopleInfluence, 0, 20);
		richPeopleHappiness 	= UnityEngine.Mathf.Clamp (richPeopleHappiness + answer.richPeopleInfluence, 0, 20);
		economy 				= UnityEngine.Mathf.Clamp (economy + answer.economyInfluence, 0, 20);
		internationalAffairs 	= UnityEngine.Mathf.Clamp (internationalAffairs + answer.internationalInfluence, 0, 20);
		mediaHappiness 			= UnityEngine.Mathf.Clamp (mediaHappiness + answer.mediaInfluence, 0, 20);
	}
}
