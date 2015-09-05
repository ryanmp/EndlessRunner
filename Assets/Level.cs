using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour
{


	/// TODO
	/// find the bug which is showing up in xcode but not unity
	// remove large files from git history
	// set position of next platform based on max jump height on difference in height between two platforms
	// have platforms gradually go up?
	// have background fade ( in height) from sunset to black and then have stars and shooting stars show up
	// gradually decrease gravity as player goes up

	// game name idea 'fallen star'



	private float prev_length = 0f;
	private float current_x = 0f;
	private float current_y = 0f;

	private float space_between_platforms = 1f;
	public GameObject platform;
	
	private float min_platform_length = 6f;
	private float max_platform_length = 15f;

	private float init_x_offset = -5f;

	private float length = 20f;
	private float slope = -0.1f;

	void Start ()
	{
		QualitySettings.antiAliasing = 8;
		Application.targetFrameRate = 120;



		int num_platforms = 50;
		for (int i = 0; i < num_platforms; i++) {

			space_between_platforms = Random.Range (0.1f, 2f);

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
				length = Random.Range (min_platform_length, max_platform_length);
				slope = Random.Range (-0.2f, 0.0f);
			}

			prev_length = length;

			float[] to_send = {length,slope};
			go.SendMessage ("Init", to_send);

		}

	}

	void Update ()
	{

	}
}
