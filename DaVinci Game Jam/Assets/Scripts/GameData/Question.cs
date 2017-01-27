using System.Collections;
using System.Collections.Generic;

public class Question
{
	public string question;
	public Answer leftAnswer;
	public Answer rightAnswer;
	public Answer pussyAnswer;

	public Question(string question,  Answer rightAnswer, Answer leftAnswer, Answer pussyAnswer)
	{
		this.question = question;
		this.leftAnswer = leftAnswer;
		this.rightAnswer = rightAnswer;
		this.pussyAnswer = pussyAnswer;
	}
}