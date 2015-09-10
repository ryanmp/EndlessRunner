using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

	private float start_time = 0f;
	private Vector3 new_position;

	private float lerp_duration = 0.4f;

	public Transform wheel;
	
	public Transform background;

	private Vector2 player_offset = new Vector2 (8f, 0f);
	private float cam_distance = -80f;

	// Use this for initialization
	void Start ()
	{
		new_position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		/*
		Vector3 bg_pos = background.transform.position;
		background.transform.position = new Vector3 (bg_pos.x, (22f - transform.position.x * 0.1f), bg_pos.z);


		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft) {
			cam_distance = -50f;
		} else if (Input.deviceOrientation == DeviceOrientation.Portrait) {
			cam_distance = -60f;
		}
		
		// camera x = wheel x
		transform.position = new Vector3 (wheel.position.x + player_offset.x, transform.position.y + player_offset.y, cam_distance);
		*/
		// camera y lerping?
		//float t = (Time.time - start_time) * (1 / lerp_duration);
		//transform.position = Vector3.Lerp (transform.position, new_position, t);

	}


	void FixedUpdate ()
	{
		transform.position = new Vector3 (wheel.position.x + player_offset.x, transform.position.y + player_offset.y, cam_distance);

	}

	public void UpdatePosition (Vector3 v)
	{
		start_time = Time.time;


		float radius = 0.5f;
		float line_width = 0.1f;
		float cam_offset = -2f;
		//transform.position = new Vector3 (transform.position.x, v.y - radius - (line_width / 2f) - cam_offset, transform.position.z);
		new_position = new Vector3 (transform.position.x, v.y - radius - (line_width / 2f) - cam_offset, transform.position.z);
	}
}
