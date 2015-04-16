using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	float translation;
	float rotation;

	// Use this for initialization
	void Start () {
		speed = 25.0f;
		rotationSpeed = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		translation = Input.GetAxis ("Vertical") * speed;
		rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);
	}
}
