using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float Speed;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 amountToMove = Vector3.up * Speed * Time.deltaTime;
		transform.Translate(amountToMove);
		
		if(transform.position.y > 6.4f)
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		Debug.Log ("Projectile hit: " + otherObject.name);
		if(otherObject.tag == "enemy")
		{
			Player.Score += 1;
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			enemy.Reset();
			Destroy(gameObject);
			
			if(Player.Score > 3)
			{
				Application.LoadLevel(3);
			}
		}
	}
}

