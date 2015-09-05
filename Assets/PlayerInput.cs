using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	
	public Player Player;
	private bool is_jumping = false;
	private float jump_start_time;

	private float max_jump_duration = 1.1f;

	// Update is called once per frame
	void Update ()
	{
		
		if (Input.touchCount > 0) {
			
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began:

					Debug.Log ("Began");
					Player.Jump ();

					break;
						
				case TouchPhase.Canceled:

					Debug.Log ("Canceled");

					break;
						
				case TouchPhase.Ended:
						
					Debug.Log ("Ended");
						
					break;
				}
			}
		}



		if (Input.GetKeyDown (KeyCode.Space)) {
			is_jumping = true;
			jump_start_time = Time.time;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			is_jumping = false;
		}





		if 
			(((Time.time - jump_start_time) < max_jump_duration) && is_jumping) {
			Player.Jump ();

		} else {

		}

		
	}






}