using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class time : MonoBehaviour
{


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		float temp = Time.time / 2.5f;
		GetComponent<Text> ().text = temp.ToString ("0.0");
	}
}
