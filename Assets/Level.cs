using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour
{


	/// TODO

	// start with an initial medium rotational velocity
	// explore other ideas such as: one long sine wave on the bottom of the screen for the ground...
	// and then have obstacles to jump over which can kill the player, rather than platforms
	// include speed up and slow down pads, which you might need to make certain jumps





	private float prev_length = 0f;
	private float current_x = 0f;
	private float current_y = 0f;

	private float space_between_platforms = 1f;
	public GameObject platform;
	
	private float min_platform_l = 6f;
	private float max_platform_l = 15f;

	private float init_x_offset = -5f;

	private float length = 20f;
	private float slope = -0.1f;

	private float current_max_amplitude = 0.0f;

	
	void Start ()
	{
		QualitySettings.antiAliasing = 8;
		Application.targetFrameRate = 120;



		int num_platforms = 50;
		for (int i = 0; i < num_platforms; i++) {

			float idx = i * 1.0f / num_platforms * 1.0f;

			space_between_platforms = Random.Range (0.1f, 0.5f);

			current_x += prev_length + space_between_platforms;
			current_y += 0;

			Vector3 v = new Vector3 (current_x + init_x_offset, current_y, 0f);

			GameObject go = Instantiate (platform, v, Quaternion.identity) as GameObject;
			go.name = i.ToString ();
			go.transform.parent = gameObject.transform;

			// first platform, fixed style
			if (i == 0) {
				// uses values at the top of file
			} else {
				current_max_amplitude = idx;
				length = Random.Range (min_platform_l, max_platform_l);
				slope = Random.Range (-0.2f, 0.0f);
			}

			prev_length = length;

			float[] to_send = {length,slope,current_max_amplitude};
			go.SendMessage ("Init", to_send);

			float new_max_platform_l = max_platform_l - Random.Range (-0.1f, 0.5f);
			max_platform_l = Mathf.Clamp (new_max_platform_l, min_platform_l, max_platform_l);

			float new_min_platform_l = min_platform_l - Random.Range (-0.1f, 0.5f);
			min_platform_l = Mathf.Clamp (new_min_platform_l, 2f, max_platform_l);


		}

	}

	void Update ()
	{

	}
}
