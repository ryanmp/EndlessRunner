using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	//public Transform floor;

	public Color slow_color;
	public Color fast_color;

	public GameObject Camera;

	// Use this for initialization
	void Start ()
	{
	


	}
	
	// Update is called once per frame
	void Update ()
	{
	
		float raw_vx = gameObject.GetComponent<Rigidbody2D> ().velocity.x;

		float scale_factor = 1f / 8f;

		float vx = Mathf.Clamp ((raw_vx * scale_factor), 0f, 1f);






		gameObject.GetComponent<SpriteRenderer> ().color = Color.Lerp (slow_color, fast_color, vx);

	}


	public void Jump ()
	{
		//float height = gameObject.transform.position.y - (gameObject.transform.localScale.y / 2f) - floor.position.y;
		//if (height < 0.2f) {
		Vector2 v = gameObject.GetComponent<Rigidbody2D> ().velocity;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (v.x, 5f);
		//}
	}



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
	}

}
