using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	//public Transform floor;

	public Color slow_color;
	public Color fast_color;

	public GameObject Camera;

	public GameObject jump_trigger;

	private float jump_vel = 5f;

	// Use this for initialization
	void Start ()
	{
	


	}
	
	// Update is called once per frame
	void Update ()
	{
	
		// color based on speed
		float raw_vx = gameObject.GetComponent<Rigidbody2D> ().velocity.x;
		float scale_factor = 1f / 5f;
		float vx = Mathf.Clamp ((raw_vx * scale_factor), 0f, 1f);
		gameObject.GetComponent<SpriteRenderer> ().color = Color.Lerp (slow_color, fast_color, vx);

		// restart if dead
		if (transform.position.y <= -20f) {
			Application.LoadLevel (0);
		}



	}


	public void Jump ()
	{
		//Debug.Log (jump_trigger.GetComponent<JumpTrigger> ().can_jump);


		//float height = gameObject.transform.position.y - (gameObject.transform.localScale.y / 2f) - floor.position.y;
		//if (height < 0.2f) {

		//if (jump_trigger.GetComponent<JumpTrigger> ().can_jump) {
		Vector2 v = gameObject.GetComponent<Rigidbody2D> ().velocity;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (v.x, jump_vel);
		//}

	}





	/*
	public void OnCollisionEnter2D (Collision2D c)
	{
		Camera.GetComponent<Camera> ().UpdatePosition (transform.position);
	}


	public void OnCollisionStay2D (Collision2D c)
	{
		Camera.GetComponent<Camera> ().UpdatePosition (transform.position);
	}

	public void OnCollisionExit2D (Collision2D c)
	{
		Camera.GetComponent<Camera> ().UpdatePosition (transform.position);
	} */

}
