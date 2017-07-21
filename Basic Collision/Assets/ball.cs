using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	public float moveSpeed = 10f;

	private Rigidbody rbody;
	private Renderer rend;
	private Light myLight;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");

		float moveX = inputX*moveSpeed*Time.deltaTime;
		float moveZ = inputZ*moveSpeed*Time.deltaTime;

		//transform.Translate(moveX,0f,moveZ);
		rbody.AddForce(moveX,0f,moveZ);
	}

	void OnCollisionEnter(Collision col)
	{
		//print (col.collider.name);
		if(col.collider.name == "wall1")
		{
			rend.material.color = Color.blue;
			myLight.color = Color.blue;
		}
		else if(col.collider.name == "wall2")
		{
			rend.material.color = Color.red;
			myLight.color = Color.red;
		}
		else if(col.collider.name == "wall3")
		{
			rend.material.color = Color.green;
			myLight.color = Color.green;
		}
		else if(col.collider.name == "wall4")
		{
			rend.material.color = Color.yellow;
			myLight.color = Color.yellow;
		}
	}
}






