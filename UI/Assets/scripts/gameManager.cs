using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager instance;
	public string playerName;
	public int playerTankN;
	public int badguysN = 0;

	void Awake()
	{
		if(instance)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);

			playerName = PlayerPrefs.GetString("playerName","");
			playerTankN = PlayerPrefs.GetInt("playerTankN",0);
		}
	}

	public void setPreferences()
	{
		PlayerPrefs.SetString("playerName",playerName);
		PlayerPrefs.SetInt("playerTankN",playerTankN);
	}
}


