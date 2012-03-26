using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float MinSpeed;
	public float MaxSpeed;
	private float currentSpeed;
	
	// Use this for initialization
	void Start () {
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 amountToMove = currentSpeed * Time.deltaTime * Vector3.down;
		transform.Translate(amountToMove);
		
		if(transform.position.y < -7.0f)
		{
			Reset ();
		}
	}
	
	public void Reset()
	{
		currentSpeed = Random.Range(MinSpeed,MaxSpeed);
		transform.position = new Vector3(Random.Range(-6.0f,6.0f),7.0f,0);
	}
}
