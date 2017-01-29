using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShitMsg : MonoBehaviour 
{
	public Image portrait;
	public Text userName;
	public Text shit;

	public Sprite[] portraitsSrc;

	public void Fill(string msg)
	{
		var parsedMsg = msg.Split ('|');
		if (parsedMsg [0] == "e")
			portrait.sprite = portraitsSrc [0];
		else if (parsedMsg [0] == "i")
			portrait.sprite = portraitsSrc [1];
		else if (parsedMsg [0] == "n")
			portrait.sprite = portraitsSrc [2];
		else if (parsedMsg [0] == "p")
			portrait.sprite = portraitsSrc [3];
		else 
			portrait.sprite = portraitsSrc [4];

		userName.text = "@" + GetUserName (parsedMsg [0]);
		shit.text = parsedMsg [1];
	}

	public string GetUserName(string usrType)
	{
		int rnd = Random.Range (0, 3);
		if (usrType == "e") 
		{
			switch (rnd) 
			{
			case 0:
				return "Forbis";
				break;
			case 1:
				return "TheGarconomist";
				break;
			default:
				return "AmbitoFalopero";
				break;
			}
		} else if (usrType == "i") {
			switch (rnd) 
			{
			case 0:
				return "CNNNNNN";
				break;
			case 1:
				return "RussiaYesterday";
				break;
			default:
				return "TheMoon";
				break;
			}
		} else if (usrType == "n") {
			switch (rnd) 
			{
			case 0:
				return "Garquin";
				break;
			case 1:
				return "ElBajon";
				break;
			default:
				return "Primicia";
				break;
			}
		} else if (usrType == "p") {
			switch (rnd) 
			{
			case 0:
				return "3lBrayan";
				break;
			case 1:
				return "El$honyRePeola";
				break;
			default:
				return "LaaYooliii";
				break;
			}
		} else {
			switch (rnd) 
			{
			case 0:
				return "AnotherCoolDude";
				break;
			case 1:
				return "DaddysLittleSlut";
				break;
			default:
				return "ElPibeLacteo";
				break;
			}
		}
		return "User";
	}
}
