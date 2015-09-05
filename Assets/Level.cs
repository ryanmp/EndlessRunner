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
	
	private int min_platform_length = 10;
	private int max_platform_length = 40;

	private float init_x_offset = -5;


	void Start ()
	{
		QualitySettings.antiAliasing = 2;
		Application.targetFrameRate = 120;



		int num_platforms = 20;
		for (int i = 0; i < num_platforms; i++) {

			space_between_platforms = Random.Range (1f, 5f);


			current_x += prev_length + space_between_platforms;
			//current_y += Random.Range (0.1f, 1f);

			current_y += 0;

			Vector3 v = new Vector3 (current_x + init_x_offset, current_y, 0f);



			GameObject go = Instantiate (platform, v, Quaternion.identity) as GameObject;
			go.name = i.ToString ();
			go.transform.parent = gameObject.transform;
			int length = Random.Range (min_platform_length, max_platform_length);
			Debug.Log (length);
			prev_length = length;
			go.SendMessage ("Init", length);
		}

	}

	void Update ()
	{

	}
}
