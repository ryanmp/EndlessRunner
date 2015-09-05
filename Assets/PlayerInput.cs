using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	
	public Player Player;

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

		if (Input.GetKey (KeyCode.Space)) {
			Player.Jump ();
		}

		
	}
}