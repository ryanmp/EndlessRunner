using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour
{

	public bool can_jump = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log ("OnTriggerEnter2D");
		can_jump = true;
	}

	public void OnTriggerStay2D (Collider2D other)
	{
		//Debug.Log ("OnTriggerStay2D");
		can_jump = true;
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		//Debug.Log ("OnTriggerExit2D");
		can_jump = false;
	}
}
