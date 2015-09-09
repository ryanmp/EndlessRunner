using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	
	public Player Player;
	private bool is_jumping = false;
	private float jump_start_time;

	private float max_jump_duration = 0.8f;

	private bool jump_reset = true;

	public JumpTrigger jump_trigger;

	// Update is called once per frame
	void Update ()
	{

		bool jt = jump_trigger.GetComponent<JumpTrigger> ().can_jump;


		/// touch input logic
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began:

					is_jumping = true;
					if (jump_reset && jt) {
						jump_start_time = Time.time;
						jump_reset = false;
					}

					break;
						
				case TouchPhase.Canceled:

					is_jumping = false;
					jump_reset = true;
					jump_start_time = Time.time - max_jump_duration;

					break;
						
				case TouchPhase.Ended:
						
					is_jumping = false;
					jump_reset = true;
					jump_start_time = Time.time - max_jump_duration;
						
					break;
				}
			}
		}

		/// keyboard in put logic
		if (Input.GetKeyDown (KeyCode.Space)) {
			is_jumping = true;
			if (jump_reset && jt) {
				jump_start_time = Time.time;
				jump_reset = false;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			is_jumping = false;
			jump_reset = true;
			jump_start_time = Time.time - max_jump_duration;
		}



		// apply jump!
		if (((Time.time - jump_start_time) < max_jump_duration) && is_jumping) {
			Player.Jump ();

		}

		
	}






}