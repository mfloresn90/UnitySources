using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleCanvas : MonoBehaviour {

	public InputField playerNameInput;
	public Button[] tankBtns;

	void Start()
	{
		tankBtns[gameManager.instance.playerTankN].onClick.Invoke();
		tankBtns[gameManager.instance.playerTankN].Select();

		playerNameInput.text = gameManager.instance.playerName;
	}

	public void pressQuit()
	{
		Application.Quit();
	}

	public void pressPlay()
	{
		//player has entered a name//
		if(playerNameInput.text.Length > 0)
		{
			//set name//
			gameManager.instance.playerName = playerNameInput.text;

			//load level//
			SceneManager.LoadScene(1);

			gameManager.instance.setPreferences();
		}
	}

	public void pressTank(int _number)
	{
		gameManager.instance.playerTankN = _number;
	}
}
