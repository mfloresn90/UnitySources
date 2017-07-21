using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tankScript : MonoBehaviour {

	public SpriteRenderer bodyArt;
	public SpriteRenderer cannonArt;
	public Sprite[] tankBodies;
	public Sprite[] tankCannons;
	public Text txtName;
	public bool isPlayer = false;
	public float moveSpeed = 400f;
	public Rigidbody2D rbody;
	public GameObject cannon;
	public GameObject bullet;
	public Transform bulletSpawnPoint;
	public RectTransform hpBar;
	public RectTransform hpFill;
	public float hp = 100f;


	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D>();

		if(isPlayer)
		{
			//set name//
			txtName.text = gameManager.instance.playerName;

			//set art//
			bodyArt.sprite = tankBodies[gameManager.instance.playerTankN];
			cannonArt.sprite = tankCannons[gameManager.instance.playerTankN];
		}
		else
		{
			gameManager.instance.badguysN++;

			//set name//
			txtName.text = "badguy"+gameManager.instance.badguysN;

			//set art//
			bodyArt.sprite = tankBodies[1];
			cannonArt.sprite = tankCannons[1];
		}

	
	}
	
	//move//
	public void move(float _pushX)
	{
		rbody.AddForce(new Vector2(_pushX*moveSpeed*Time.deltaTime,0f));
	}

	//aim//
	public void aim(float _value)
	{
		cannon.transform.rotation = Quaternion.Euler(0f,0f,_value);
	}

	//shoot//
	public void shoot(float _power)
	{
		GameObject newBullet = Instantiate(bullet,bulletSpawnPoint.position,Quaternion.identity) as GameObject;
		newBullet.GetComponent<Rigidbody2D>().AddForce(cannon.transform.right*_power);
	}

	//update health//
	public void updateHp()
	{
		hpFill.sizeDelta = new Vector2(hpBar.sizeDelta.x*(hp*0.01f),hpBar.sizeDelta.y);
	}

	//collision//
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "bullet")
		{
			hp-=10f;
			if(hp < 0f)
			{
				hp = 0f;
				print(txtName.text+" is dead");
			}
			updateHp();
		}
	}

}
