using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform2 : MonoBehaviour
{

	public Color[] colors;
	
	private float LINE_WIDTH = 0.1f;
	
	private List<Vector2> platform = new List<Vector2> (); 

	private float X_INC = 1f;
	private float min_height = -4f;
	private float max_height = 2f;
	private float max_incline = 1f;



	public Material line_mat;

	private Vector2 start_pos;
	private Vector2 end_pos;
	private float amplitude;
	private float freq;
	private float phase_mod_speed;
	
	void Init (Dictionary<string, object> _in)
	{
		start_pos = (Vector2)_in ["start_pos"];
		end_pos = (Vector2)_in ["end_pos"];
		amplitude = (float)_in ["amplitude"];
		freq = (float)_in ["freq"];
		phase_mod_speed = (float)_in ["phase_mod_speed"];
	}
	
	void Start ()
	{

		int points = 2 * (int)Vector2.Distance (start_pos, end_pos);
		Debug.Log (points);
		for (int i = 0; i <= points; i++) {
			Vector2 v = new Vector2 (0f, 0f);
			platform.Add (v);
		}

		LineRenderer lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = line_mat;

		int color_idx1 = Random.Range (0, colors.Length);
		int color_idx2 = Random.Range (0, colors.Length);
		while (color_idx1 == color_idx2) { // make sure 2nd color is diff
			color_idx2 = Random.Range (0, colors.Length);
		}

		lr.SetColors (colors [color_idx1], colors [color_idx2]);
		lr.SetWidth (LINE_WIDTH, LINE_WIDTH);
		lr.useWorldSpace = false;
		lr.SetVertexCount (platform.Count);
		for (int i = 0; i < platform.Count; i++) {
			Vector2 v = platform [i];
			lr.SetPosition (i, new Vector3 (v.x, v.y - LINE_WIDTH / 2f, 0f));
		} 


		EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D> ();
		edgeCollider.points = platform.ToArray ();

	}

	void Update ()
	{


		// update positions
		for (int i = 0; i < platform.Count; i++) {

			float idx = i * 1f / platform.Count * 1f; // from 0 to 1

			float x = Mathf.Lerp (start_pos.x, end_pos.x, idx); // fixed x points

			float slope = (end_pos.y - start_pos.y) / (end_pos.x - start_pos.x);
			float y_intercept = start_pos.y;

			//Debug.Log (y_intercept);

			float y = slope * x + y_intercept
			+
				amplitude * Mathf.Sin (freq * (idx - Time.time * phase_mod_speed) 

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
