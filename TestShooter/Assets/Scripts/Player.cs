using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float Speed;
	public GameObject ProjectilePreFab;
	
	public static int Score = 0;
	public static int Lives = 3;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(-6, 5, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 amountToMove = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0) * Speed * Time.deltaTime;
		transform.Translate(amountToMove);
		
		//wrap
		if(transform.position.x <= -7.5f)
		{
			transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
		}
		if(transform.position.x >= 7.5f)
		{
			transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
		}
		
		if(Input.GetKeyDown("space"))
		{
			//fire
			Instantiate(ProjectilePreFab, transform.position, Quaternion.identity);
		}
	}
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,60,20), "Score: " + Player.Score.ToString());
		GUI.Label(new Rect(10,30,60,20), "Lives: " + Player.Lives.ToString());
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		Debug.Log ("Player hit: " + otherObject.name);
		if(otherObject.tag == "enemy")
		{
			Player.Lives -= 1;
			
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			enemy.Reset();
			
			StartCoroutine(DestroyShip());
		}
	}
	
	IEnumerator DestroyShip()
	{
		gameObject.renderer.enabled = false;
		transform.position = new Vector3(0,0,0);
		yield return new WaitForSeconds(1.5f);
		if(Player.Lives > 0)
		{
			gameObject.renderer.enabled = true;	
		}
		else
		{
			Application.LoadLevel(2);
		}
	}
}
