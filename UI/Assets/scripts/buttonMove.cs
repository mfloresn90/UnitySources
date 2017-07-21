using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonMove : Button {

	public tankScript tank;
	public float pushX;
	
	// Update is called once per frame
	void Update () 
	{
		if(IsPressed())
		{
			tank.move(pushX);
		}
	}
}
