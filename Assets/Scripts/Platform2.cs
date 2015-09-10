using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform2 : MonoBehaviour
{


	
	private float LINE_WIDTH = 0.1f;
	private int POINT_DENSITY = 4;
	
	private List<Vector2> platform = new List<Vector2> (); 

	private float X_INC = 1f;

	
	public Material line_render_mat;
	public PhysicsMaterial2D line_physics_mat;

	// init quantities
	private Vector2 start_pos;
	private Vector2 end_pos;

	private float min_amp;
	private float max_amp;
	private float min_freq;
	private float max_freq;

	private float phase_mod_speed;
	private float amp_mod_speed;
	private float freq_mod_speed;

	private Color c1;
	private Color c2;
	
	// derived quantities
	private float length;
	
	void Init (Dictionary<string, object> _in)
	{
		start_pos = (Vector2)_in ["start_pos"];
		end_pos = (Vector2)_in ["end_pos"];
		min_amp = (float)_in ["min_amp"];
		max_amp = (float)_in ["max_amp"];
		min_freq = (float)_in ["min_freq"];
		max_freq = (float)_in ["max_freq"];

		phase_mod_speed = (float)_in ["phase_mod_speed"];
		amp_mod_speed = (float)_in ["amp_mod_speed"];
		freq_mod_speed = (float)_in ["freq_mod_speed"];

		c1 = (Color)_in ["c1"];
		c2 = (Color)_in ["c2"];

		length = Vector2.Distance (start_pos, end_pos);
	}
	
	void Start ()
	{

		int points = (int)Vector2.Distance (start_pos, end_pos) * POINT_DENSITY;
		//Debug.Log (points);
		for (int i = 0; i <= points; i++) {
			Vector2 v = new Vector2 (0f, 0f);
			platform.Add (v);
		}

		LineRenderer lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = line_render_mat;

		/*
		int color_idx1 = Random.Range (0, colors.Length);
		int color_idx2 = Random.Range (0, colors.Length);
		while (color_idx1 == color_idx2) { // make sure 2nd color is diff
			color_idx2 = Random.Range (0, colors.Length);
		}

		lr.SetColors (colors [color_idx1], colors [color_idx2]);*/

		lr.SetColors (c1, c2);

		lr.SetWidth (LINE_WIDTH, LINE_WIDTH);
		lr.useWorldSpace = false;
		lr.SetVertexCount (platform.Count);
		for (int i = 0; i < platform.Count; i++) {
			Vector2 v = platform [i];
			lr.SetPosition (i, new Vector3 (v.x, v.y - LINE_WIDTH / 2f, 0f));
		} 


		EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D> ();
		edgeCollider.points = platform.ToArray ();

		edgeCollider.sharedMaterial = line_physics_mat;

	}

	void Update ()
	{


		// update positions
		for (int i = 0; i < platform.Count; i++) {

			float idx = i * 1f / platform.Count * 1f; // from 0 to 1

			float x = Mathf.Lerp (start_pos.x, end_pos.x, idx); // fixed x points

			float slope = (end_pos.y - start_pos.y) / (end_pos.x - start_pos.x);
			float y_intercept = start_pos.y;

			float final_amp = (max_amp - min_amp) * 0.5f * Mathf.Sin (Time.time * amp_mod_speed * 0.025f) + min_amp * 1.5f;
			float final_phase = -1f * Time.time * phase_mod_speed / length * Mathf.PI * 0.25f;
			float final_freq = (max_freq - min_freq) * ((Mathf.Sin (Time.time * freq_mod_speed * 0.1f) + 1f) * 0.5f) + min_freq;

			final_freq *= length / 50f;

			// fomula time!
			float y = slope * x + y_intercept
			+
				final_amp * Mathf.Sin (final_freq * (idx + final_phase)

			);

			
			platform [i] = new Vector2 (x, y);


		}

		// use updated positions
		LineRenderer lr = gameObject.GetComponent<LineRenderer> ();
		for (int i = 0; i < platform.Count; i++) {
			Vector2 v = platform [i];
			lr.SetPosition (i, new Vector3 (v.x, v.y - LINE_WIDTH / 2f, 0f));
		} 
		
		EdgeCollider2D edgeCollider = gameObject.GetComponent<EdgeCollider2D> ();
		edgeCollider.points = platform.ToArray ();


	}
}
