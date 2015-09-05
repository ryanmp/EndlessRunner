using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{

	public Color[] colors;
	
	private float LINE_WIDTH = 0.1f;
	
	private List<Vector2> platform = new List<Vector2> (); 

	private float X_INC = 1f;
	private float min_height = -4f;
	private float max_height = 2f;
	private float max_incline = 1f;

	private float length = 2f;
	private float slope = 1f;

	public Material line_mat;

	public GameObject quad;


	public float phase_mod_speed = 0f;

	private float freq = 1f;
	private float amplitude = 1f;


	void Init (float[] _in)
	{
		length = _in [0];
		slope = _in [1];
	}
	
	void Start ()
	{
		freq = Random.Range (0f, 4f);
		amplitude = Random.Range (0f, 1f);
		phase_mod_speed = Random.Range (0f, 1f);


		//GameObject platform = Instantiate (quad, transform.position, transform.rotation) as GameObject;
		//platform.transform.eulerAngles = new Vector3 (0f, 0f, -5f);
		//platform.transform.localScale = new Vector3 (length, 1f, 1f);
		//platform.transform.parent = transform;


		//int verts = (int)length;

		/*
		float current_height = -3f;
		float current_incline = -0.1f;
		for (int i = 0; i <= verts; i++) {
			float x = i * X_INC;

			current_incline = Mathf.Clamp (current_incline, -max_incline, 0);
			current_incline += Random.Range (-0.05f, 0.05f);

			current_height = Mathf.Clamp (current_height, min_height, max_height);
			current_height += current_incline;

			Vector2 v = new Vector2 (x, current_height);
			platform.Add (v);
		}
		*/

		//int points = Random.Range (2, 20);

		int points = 30;

		for (int i = 0; i <= points; i++) {
			/*
			float x = Mathf.Lerp (0, length, i * 1f / points * 1f);
			float y = slope * x + Mathf.Sin (
				Mathf.Lerp (0f, Mathf.PI, i * 1f / points * 1f) - Mathf.PI + Time.time
			);*/
			float x = 0f;
			float y = 0f;

			Vector2 v = new Vector2 (x, y);
			platform.Add (v);

		}

		/*
		Vector2 v1 = new Vector2 (0f, 0f);
		platform.Add (v1);

		Vector2 v2 = new Vector2 (length, -decline);
		platform.Add (v2);
		*/


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

			float x = Mathf.Lerp (0, length, idx); // fixed x points

			float y = slope * x +
				amplitude * Mathf.Sin (
					freq * (idx - Time.time * phase_mod_speed)
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
