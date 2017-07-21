using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonShoot : Button {

	public tankScript tank;
	public RectTransform barBack;
	public RectTransform barFill;

	private float power = 0f;
	private float n = 0f;
	
	// Update is called once per frame
	void Update () 
	{
		if(IsPressed())
		{
			n += Time.deltaTime;
			power = Mathf.PingPong(n,1f);
			barFill.sizeDelta = new Vector2(barBack.sizeDelta.x*power,barBack.sizeDelta.y);
		}
		else if(n > 0f)
		{
			tank.shoot(power*2000f);
			n = 0f;
			power = 0f;

		}
	}
}
