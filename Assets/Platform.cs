using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{

	public Color[] colors;
	
	private float LINE_WIDTH = 0.2f;
	
	private List<Vector2> platform = new List<Vector2> (); 

	private float X_INC = 1f;
	private float min_height = -4f;
	private float max_height = 2f;
	private float max_incline = 1f;

	private float length = 2f;

	public Material line_mat;

	void Init (int l)
	{
		length = l;
	}
	
	void Start ()
	{

		int verts = (int)length;

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

		Vector2 v1 = new Vector2 (0f, -1f);
		platform.Add (v1);

		Vector2 v2 = new Vector2 (length, -2f);
		platform.Add (v2);


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

		/*
		// update positions
		for (int i = 0; i < platform.Count; i++) {
			platform [i] = new Vector2 (platform [i].x - Time.deltaTime * 5f, platform [i].y);
		}

		// use updated positions
		LineRenderer lr = gameObject.GetComponent<LineRenderer> ();
		for (int i = 0; i < platform.Count; i++) {
			Vector2 v = platform [i];
			lr.SetPosition (i, new Vector3 (v.x, v.y - LINE_WIDTH / 2f, 0f));
		} 
		
		EdgeCollider2D edgeCollider = gameObject.GetComponent<EdgeCollider2D> ();
		edgeCollider.points = platform.ToArray ();
		*/

	}
}
