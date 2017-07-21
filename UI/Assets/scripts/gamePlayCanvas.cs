using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gamePlayCanvas : MonoBehaviour {

	public void pressExit()
	{
		SceneManager.LoadScene(0);
	}


}
