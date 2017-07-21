using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Animator playerAnim;

	private Rigidbody rbody;
	private float moveSpeed;
	private bool onGround;
	public float jumpStrength;
	
	// Use this for initialization
	void Start () 
	{
		playerAnim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody>();
		moveSpeed = 5000f;
		onGround = false;
		jumpStrength = 10f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float walkInput = Input.GetAxis("Horizontal");
		float jumpInput = Input.GetAxis("Vertical");

		if(onGround)
		{
			if(jumpInput > 0f)
			{
				jump ();
			}


			//walk right//
			if(walkInput > 0f)
			{
				playerAnim.SetBool("walking",true);
				transform.rotation = Quaternion.Euler(0f,walkInput*-90f,0f);
				rbody.AddForce(moveSpeed*walkInput*Time.deltaTime,0f,0f);
				
			}
			//walk left//
			else if(walkInput < 0f)
			{
				playerAnim.SetBool("walking",true);
				transform.rotation = Quaternion.Euler(0f,walkInput*-90f,0f);
				rbody.AddForce(moveSpeed*walkInput*Time.deltaTime,0f,0f);
			}
			else
			{
				playerAnim.SetBool("walking",false);
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0f,0f,0f),10f*Time.deltaTime);

			}
		}
		//in the air
		else
		{
			playerAnim.SetFloat("tuck",transform.rotation.x*-2f);
		}





	}

	void jump()
	{
		rbody.drag = 0f;
		onGround = false;
		//rbody.AddForce(0f,jumpStrength,0f);
		rbody.velocity = new Vector3(rbody.velocity.x,jumpStrength,rbody.velocity.z);
		playerAnim.SetBool("jump",true);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("ground"))
		{
			rbody.drag = 10f;
			onGround = true;
			playerAnim.SetBool("jump",false);
		}
	}

}















