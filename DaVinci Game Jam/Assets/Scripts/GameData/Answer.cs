public struct Answer
{
	public string text;
	public int poorPeopleInfluence;
	public int richPeopleInfluence;
	public int economyInfluence;
	public int internationalInfluence;
	public int mediaInfluence;

	public Answer(string answer, int ppInfluence, int rpInfluence, int eInfluence, int iInfluence, int mInfluence)
	{
		text = answer;
		poorPeopleInfluence = ppInfluence;
		richPeopleInfluence = rpInfluence;
		economyInfluence = eInfluence;
		internationalInfluence = iInfluence;
		mediaInfluence = mInfluence;
	}
}
